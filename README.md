# SPYC:I · Venta en caja y preparación de pedidos

Aplicación de escritorio **WinForms (.NET Framework 4.8)** para **SPYC:I**, una cadena de comida rápida con 5 sedes.
Automatiza el proceso completo:

caja (POS) → cobro con promoción, IGV, Boleta/Factura → cocina (estados en tiempo real) → descuento automático de inventario según la receta → reportes y alertas para el gerente.

## Estructura de la solución

| Proyecto | Tipo | Contenido |
|----------|------|-----------|
| `RESTAURANTE` (namespace `RESTAURANTEFINAL`) | WinForms (.exe) | Formularios, `FabricaServicios` (composition root), `Estilo`, `AyudaCRUD` |
| `NEGOCIO` | Biblioteca | Interfaces de repositorio (DIP), servicios (SRP), descuentos y comprobantes (OCP) |
| `DATOS` | Biblioteca | Acceso a SQL Server con `SqlClient` (implementa las interfaces de NEGOCIO) |
| `ENTIDADES` | Biblioteca | Clases de datos compartidas |

Documentación para la exposición en [`docs/`](docs):
- [`diagrama_proceso.md`](docs/diagrama_proceso.md): diagrama ANTES y DESPUÉS. También en [`.drawio`](docs/diagrama_proceso.drawio) editable.
- [`solid.md`](docs/solid.md): SRP, OCP y DIP con archivo, líneas y código.
- [`reparto.md`](docs/reparto.md): qué presenta cada integrante, con su guion de 45 a 60 s.
- [`guion_demo.md`](docs/guion_demo.md): demo de 5 minutos con los datos exactos.

## 1. Restaurar la base de datos

Requisitos: SQL Server 2019/2022 (Express sirve) y SQL Server Management Studio (SSMS).

1. **`restaurante.sql`** (raíz del repo): ábrelo en SSMS y ejecútalo (F5).
   - Crea la BD `restaurante` con tablas, vistas, SPs y unos 13 000 registros.
   - Las rutas de los archivos `.mdf` y `.ldf` del `CREATE DATABASE` apuntan a `C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\...`. Si tu instancia es otra (por ejemplo, `MSSQL16.SQLEXPRESS`), corrige esas dos rutas o borra las líneas `ON PRIMARY (...) LOG ON (...)`.
2. **`database/02_cambios_spyci.sql`**: ejecútalo después. Es **idempotente**: se puede correr varias veces y no borra datos. Hace lo siguiente:
   - Tabla `Usuario` con los 3 usuarios de prueba.
   - `Pedido`: `Tipo_Pedido` e `ID_Sede`, estados estándar y `Observaciones` hasta 200 caracteres.
   - `Venta`: datos del comprobante.
   - `Inventario`: stock decimal y `Stock_Minimo`.
   - `Plato_Insumo.Cant_Necesaria` de texto a decimal, en la unidad del insumo.
   - Promoción vigente **P006 "Promo SPYC:I"** (−20 %) en Hamburguesa y Tacos, 3 proveedores, cliente **C0000 "Cliente varios"** y SPs de login, cocina, inventario y reportes.

Para **reiniciar la demo**, ejecuta otra vez los dos scripts. El primero recrea la BD.

## 2. Configurar el servidor

En **`App.config`** cambia `[NOMBRE_SERVIDOR]` por tu instancia:

```xml
<add name="RestauranteBD"
     connectionString="Server=[NOMBRE_SERVIDOR];Database=restaurante;Trusted_Connection=True;TrustServerCertificate=True"
     providerName="System.Data.SqlClient" />
```

Ejemplos: `Server=localhost`, `Server=.\SQLEXPRESS`, `Server=MI-PC\SQLEXPRESS`.
Ya compilado, también se puede editar `bin\Debug\RESTAURANTEFINAL.exe.config` sin recompilar.

## 3. Compilar y ejecutar

1. Abre **`RESTAURANTE.sln`** en Visual Studio 2022 (carga de trabajo "Desarrollo de escritorio de .NET").
2. **Compilar → Recompilar solución**. Debe terminar con 0 errores.
3. Proyecto de inicio: **RESTAURANTE** → **F5**.

Por línea de comandos (Developer PowerShell): `msbuild RESTAURANTE.sln /p:Configuration=Debug`.

## 4. Usuarios de prueba

| Usuario | Contraseña | Perfil | Sede | Ve en el menú |
|---------|------------|--------|------|---------------|
| `admin` | `admin123` | Administrador | Sede Central | Todo, más Administración y Reportes |
| `caja` | `caja123` | Cajero | Sede Central | Caja, Clientes |
| `cocina` | `cocina123` | Cocina | Sede Central | Cocina |

Las contraseñas se guardan como hash **SHA256** (`Usuario.Clave_Hash`).

## 5. Pantallas

| Pantalla | Para qué sirve |
|----------|----------------|
| Login / Menú principal | Acceso por perfil. Las pantallas se abren dentro del panel derecho y la cabecera muestra la alerta de stock. |
| Caja | Venta con botones, promociones, total en vivo, Boleta/Factura y comprobante imprimible. |
| Clientes | Mantenimiento de clientes con código automático y búsqueda. |
| Cocina | Pedidos del día por estado, refresco cada 10 s y color por tiempo de espera. |
| Inventario | Stock por sede (lo bajo el mínimo en rojo), abastecimiento y consumo por receta. |
| Reportes | KPIs y gráficos por sede y rango de fechas. |
| Administración | Productos y Promociones, Recetas, Insumos, Empleados, Sedes y Roles. |

Los formularios antiguos `Pedido`, `Detalle_Pedido` y `Venta` siguen en el proyecto, pero ya no están en el menú: la Caja los reemplaza.
