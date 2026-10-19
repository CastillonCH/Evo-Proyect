# Diagrama del proceso: Venta en caja y preparación de pedidos

**SPYC:I**, cadena de comida rápida con 5 sedes.
Carriles: **Cliente / Cajero / Sistema / Cocina / Gerente**.
La versión editable (draw.io, 2 páginas: ANTES y DESPUÉS) está en [`diagrama_proceso.drawio`](diagrama_proceso.drawio).
Se abre en <https://app.diagrams.net> o con la extensión *Draw.io Integration* de VS Code.

---

## ANTES (proceso manual)

```mermaid
flowchart LR
    subgraph CLI[Cliente]
        A1([Pide en caja])
        A9([Recibe su pedido<br/>a veces equivocado])
    end
    subgraph CAJ[Cajero]
        A2[Anota la comanda<br/>en papel]
        A3[Suma con calculadora<br/>y busca la promoción en una lista]
        A4[Cobra y entrega<br/>la comanda a cocina]
    end
    subgraph SIS[Sistema]
        A0[[No hay sistema:<br/>todo es papel y Excel]]
    end
    subgraph COC[Cocina]
        A5[Lee la comanda<br/>de papel]
        A6[Prepara sin saber<br/>qué pedido va primero]
    end
    subgraph GER[Gerente]
        A7[Al final del día pasa<br/>las ventas a Excel]
        A8[Cuenta el inventario a mano<br/>y se entera tarde de los faltantes]
    end
    A1 --> A2 --> A3 --> A4 --> A5 --> A6 --> A9
    A4 -. comandas del día .-> A7 --> A8
```

**Problemas:** errores de cálculo y de promociones, comandas ilegibles o perdidas, sin control de tiempos en cocina, inventario desactualizado (se descubre que falta un insumo cuando el cliente ya pagó) y reportes que llegan un día después.

---

## DESPUÉS (con la aplicación SPYC:I)

```mermaid
flowchart LR
    subgraph CLI[Cliente]
        B1([Pide en caja])
        B10([Recibe comprobante<br/>Boleta o Factura])
        B13([Recibe su pedido])
    end
    subgraph CAJ[Cajero · FrmCaja]
        B2[Arma el pedido con botones<br/>Comer aquí / Para llevar / Delivery]
        B4[Elige cliente opcional,<br/>método de pago y comprobante]
        B5[Presiona COBRAR]
    end
    subgraph SIS[Sistema · NEGOCIO + DATOS]
        B3[Aplica la promoción vigente<br/>y calcula el total con IGV]
        B6{¿Alcanza el stock<br/>según la receta?}
        B7[Avisa qué insumo falta]
        B8[Una sola transacción:<br/>Pedido + Detalle_Pedido + Venta<br/>+ Detalle_Venta + descuento de Inventario]
        B9[Imprime el comprobante]
        B14[Alerta de stock<br/>bajo el mínimo]
    end
    subgraph COC[Cocina · FrmCocina]
        B11[Ve el pedido en Pendiente<br/>se actualiza cada 10 s]
        B12[En preparación → Listo → Entregado<br/>color según el tiempo de espera]
    end
    subgraph GER[Gerente · FrmReportes / FrmInventario]
        B15[Ve KPIs y gráficos<br/>por sede y fechas]
        B16[Registra el abastecimiento<br/>y el stock sube]
    end
    B1 --> B2 --> B3 --> B4 --> B5 --> B6
    B6 -- No --> B7 --> B2
    B6 -- Sí --> B8 --> B9 --> B10
    B8 --> B11 --> B12 --> B13
    B8 --> B14 --> B15 --> B16
```

**Mejoras:**
- **Precio correcto siempre:** el sistema aplica la promoción vigente y calcula el IGV.
- **Cobro en un solo paso:** la venta se registra completa o no se registra.
- **Inventario siempre actualizado:** los insumos se descuentan solos según la receta (`Plato_Insumo`).
- **Cocina ordenada:** los pedidos se muestran por estado y con su tiempo de espera.
- **Gerente informado al momento:** reportes del día y alertas de stock.

## Pantallas por paso

| Paso | Pantalla | Tablas / objetos de BD |
|------|----------|------------------------|
| Login y menú por perfil | `FrmLogin`, `FrmPrincipal` | `Usuario`, `sp_Buscar_Usuario` |
| Clientes | `Cliente` | `Cliente` |
| Venta en caja | `FrmCaja` | `Plato`, `Promocion`, `Pedido`, `Detalle_Pedido`, `Venta`, `Detalle_Venta`, `Inventario`, `Metodo_Pago` |
| Preparación | `FrmCocina` | `Pedido`, `sp_Pedidos_Cocina`, `sp_Cambiar_Estado_Pedido` |
| Inventario | `FrmInventario` | `Inventario`, `Insumo`, `Unidad_Medida`, `Abastecimiento`, `Detalle_Abastecimiento`, `Proveedor`, `Plato_Insumo` |
| Reportes | `FrmReportes` | SPs basados en `ventas_por_sede`, `platos_mas_pedidos`, `Vista_Mapa_Calor_Horas_Pico`, `Vista_Top_Clientes_VIP`, `Vista_Efectividad_Promociones` |
