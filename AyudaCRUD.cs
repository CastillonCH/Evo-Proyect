using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NEGOCIO;

namespace RESTAURANTEFINAL
{
    // Funciones comunes de las pantallas CRUD (búsqueda, encabezados, códigos y errores)
    public static class AyudaCRUD
    {
        // Escapa el texto para DataView.RowFilter: comilla simple y comodines de LIKE
        public static string Escapar_Filtro(string texto)
        {
            StringBuilder resultado = new StringBuilder();
            foreach (char c in texto)
            {
                if (c == '\'')
                    resultado.Append("''");
                else if (c == '[' || c == ']' || c == '*' || c == '%')
                    resultado.Append('[').Append(c).Append(']');
                else
                    resultado.Append(c);
            }
            return resultado.ToString();
        }

        // Filtra la tabla del grid buscando el texto en varias columnas
        public static void Buscar(DataGridView grid, string texto, params string[] columnas)
        {
            DataTable tabla = grid.DataSource as DataTable;
            if (tabla == null)
                return;

            tabla.DefaultView.RowFilter = Filtro_Texto(texto, columnas);
        }

        // Expresión "col1 LIKE '%texto%' OR col2 LIKE ..." ("" si no hay texto)
        public static string Filtro_Texto(string texto, params string[] columnas)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "";

            string valor = Escapar_Filtro(texto.Trim());
            return string.Join(" OR ",
                columnas.Select(c => "CONVERT([" + c + "], 'System.String') LIKE '%" + valor + "%'"));
        }

        // Encabezados legibles: Encabezados(grid, "ID_Cliente", "Código", "Nom_Cliente", "Nombres", ...)
        public static void Encabezados(DataGridView grid, params string[] columnaYTitulo)
        {
            for (int i = 0; i + 1 < columnaYTitulo.Length; i += 2)
            {
                if (grid.Columns.Contains(columnaYTitulo[i]))
                    grid.Columns[columnaYTitulo[i]].HeaderText = columnaYTitulo[i + 1];
            }
        }

        // Siguiente código según los datos cargados (ej. P005 -> P006)
        public static string Siguiente_Codigo(DataTable tabla, string columna, string prefijo, int digitos)
        {
            Regex formato = new Regex("^" + Regex.Escape(prefijo) + "\\d{" + digitos + "}$");
            string ultimo = tabla.AsEnumerable()
                                 .Select(f => f[columna].ToString())
                                 .Where(c => formato.IsMatch(c))
                                 .OrderBy(c => c)
                                 .LastOrDefault();
            return GeneradorCodigo.Siguiente(ultimo, prefijo, digitos);
        }

        // Error 547 de SQL Server = el registro está referenciado por otra tabla (FK)
        public static bool Es_Error_Relacion(Exception ex)
        {
            for (Exception actual = ex; actual != null; actual = actual.InnerException)
            {
                SqlException sql = actual as SqlException;
                if (sql != null && sql.Number == 547)
                    return true;
            }
            return false;
        }

        public static void Mostrar_Error_Eliminar(Exception ex)
        {
            if (Es_Error_Relacion(ex))
                MessageBox.Show("No se puede eliminar: tiene registros asociados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
