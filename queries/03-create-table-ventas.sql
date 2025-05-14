USE PrimeSystemsVentas;

CREATE TABLE Categorias (
id_categoria INT PRIMARY KEY,
 categoria VARCHAR(255)
 );
 
CREATE TABLE Clientes (
    id_cliente INT IDENTITY(1, 1) PRIMARY KEY,
    CUIT INT,
    nombre VARCHAR(255),
    entidad VARCHAR(255),
    tel VARCHAR(255),
    mail VARCHAR(255),
    dir VARCHAR(255)
);
CREATE TABLE Clientes_Pagos (
    id_pago INT IDENTITY(1, 1) PRIMARY KEY,
    id_cliente INT,
    fecha VARCHAR(255),
    monto VARCHAR(255)
);
CREATE TABLE H_Altas_arts (
    id_altas INT IDENTITY(1, 1) PRIMARY KEY,
    reg_alta VARCHAR(255),
    fecha_hora DATETIME
);
CREATE TABLE H_Mod_Arts (
    id_historico INT IDENTITY(1, 1) PRIMARY KEY,
    reg_antes VARCHAR(255),
    reg_despues VARCHAR(255),
    fecha_hora DATETIME
);
CREATE TABLE H_Stock (
    id_histstock INT IDENTITY(1, 1) PRIMARY KEY,
    reg_antes VARCHAR(255),
    reg_despues VARCHAR(255),
    fecha_hora DATETIME
);
CREATE TABLE imprime_balance (
    id_balance INT IDENTITY(1, 1) PRIMARY KEY,
    fecha VARCHAR(255),
    desde VARCHAR(255),
    hasta VARCHAR(255),
    ingreso VARCHAR(255),
    egresos VARCHAR(255),
    total_costo_rem VARCHAR(255),
    total_rem VARCHAR(255),
    total_ingresos VARCHAR(255),
    total_egresos VARCHAR(255),
    ganacia VARCHAR(255),
    total_comisiones VARCHAR(255)
);
CREATE TABLE Ingreso_Egreso (
    id_movimiento INT IDENTITY(1, 1) PRIMARY KEY,
    tipo VARCHAR(255),
    detalle VARCHAR(255),
    monto VARCHAR(255),
    fecha VARCHAR(255),
    mes VARCHAR(255),
    año VARCHAR(255)
);
CREATE TABLE Proveedores (
    id_proveedor INT IDENTITY(1, 1) PRIMARY KEY,
    proveedor VARCHAR(255),
    nombre VARCHAR(255),
    tel VARCHAR(255),
    email VARCHAR(255)
);
CREATE TABLE Vendedores (
    id_vendedor INT IDENTITY(1, 1) PRIMARY KEY,
    dni_vendedor VARCHAR(255),
    nombre VARCHAR(255),
    tel VARCHAR(255),
    dir VARCHAR(255),
    comision INT
);
CREATE TABLE Vendedores_Pagos (
    id_pago INT IDENTITY(1, 1) PRIMARY KEY,
    nombre VARCHAR(255),
    fecha VARCHAR(255),
    monto VARCHAR(255)
);
CREATE TABLE Vendedores_Ventas (
    id_vendedor_venta INT IDENTITY(1, 1) PRIMARY KEY,
    nombre VARCHAR(255),
    fecha VARCHAR(255),
    remito_num INT,
    total_remito VARCHAR(255),
    costo_remito VARCHAR(255),
    comision VARCHAR(255),
    total_comision VARCHAR(255),
    mes VARCHAR(255),
    año VARCHAR(255)
);
CREATE TABLE H_Presupuesto (
    id_presupuesto INT IDENTITY(1, 1) PRIMARY KEY,
    fecha_hora VARCHAR(255),
    nombre VARCHAR(255),
    tel VARCHAR(255),
    mail VARCHAR(255),
    entidad VARCHAR(255),
    dni VARCHAR(255),
    subtotal VARCHAR(255),
    descu VARCHAR(255),
    total VARCHAR(255),
    dir VARCHAR(255)
);
CREATE TABLE H_Remito (
    id_remito INT IDENTITY(1, 1) PRIMARY KEY,
    fecha_hora VARCHAR(255),
    nombre VARCHAR(255),
    tel VARCHAR(255),
    mail VARCHAR(255),
    entidad VARCHAR(255),
    dni VARCHAR(255),
    subtotal VARCHAR(255),
    descu VARCHAR(255),
    total VARCHAR(255),
    totcostos VARCHAR(255),
    mes VARCHAR(255),
    año VARCHAR(255),
    dir VARCHAR(255)
);
CREATE TABLE H_Remito_Detalle (
    id_det_remito INT IDENTITY(1, 1) PRIMARY KEY,
    id_remito INT FOREIGN KEY REFERENCES H_Remito(id_remito),
    cod_art VARCHAR(255),
    descr VARCHAR(255),
    p_unit VARCHAR(255),
    cant VARCHAR(255),
    p_x_cant VARCHAR(255)
);
CREATE TABLE H_Presupuesto_Detalle (
    id_det_presupuesto INT IDENTITY(1, 1) PRIMARY KEY,
    id_presupuesto INT FOREIGN KEY REFERENCES H_Presupuesto(id_presupuesto),
    cod_art VARCHAR(255),
    descr VARCHAR(255),
    p_unit VARCHAR(255),
    cant VARCHAR(255),
    p_x_cant VARCHAR(255)
);

CREATE TABLE Subcategoria (
    id_subcategoria INT IDENTITY(1, 1) PRIMARY KEY,
    subcategoria VARCHAR(255),
    id_categoria INT FOREIGN KEY REFERENCES Categorias(id_categoria)
);
CREATE TABLE Articulos (
    id_articulo INT IDENTITY(1, 1) PRIMARY KEY,
    cod_articulo VARCHAR(255) NOT NULL,
    art_desc VARCHAR(255),
    cod_categoria INT FOREIGN KEY REFERENCES Categorias(id_categoria),
    cod_subcat INT FOREIGN KEY REFERENCES Subcategoria(id_subcategoria),
    id_proveedor INT FOREIGN KEY REFERENCES Proveedores(id_proveedor),
);
CREATE TABLE Stock (
    cod_stock INT IDENTITY(1, 1) PRIMARY KEY,
    id_articulo INT FOREIGN KEY REFERENCES Articulos(id_articulo),
    cantidad INT,
    costo VARCHAR(255),
    ganancia Integer
);
CREATE TABLE His_Remito_Detalle (
    id_det_remito INT IDENTITY(1, 1) PRIMARY KEY,
    id_remito INT FOREIGN KEY REFERENCES H_Remito(id_remito),
    cod_art VARCHAR(255),
    descr VARCHAR(255),
    p_unit VARCHAR(255),
    cant VARCHAR(255),
    p_x_cant VARCHAR(255),
    cuxcant VARCHAR(255)
);
CREATE TABLE Proveedores_CtaCte (
    id_ctacte_prov INT IDENTITY(1, 1) PRIMARY KEY,
    id_proveedor INT FOREIGN KEY REFERENCES Proveedores(id_proveedor),
    compras VARCHAR(255),
    pagos VARCHAR(255),
    fecha VARCHAR(255)
);
