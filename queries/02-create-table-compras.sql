USE PrimeSystemsCompras;
CREATE TABLE Clientes (
    id_cliente INT IDENTITY(1, 1) PRIMARY KEY,
    CUIT INT,
    nombre VARCHAR(255),
    entidad VARCHAR(255),
    tel VARCHAR(255),
    mail VARCHAR(255)
);
CREATE TABLE Categorias (
    id_categoria INT PRIMARY KEY,
    categoria VARCHAR(255)
);
CREATE TABLE Proveedores (
    id_proveedor INT IDENTITY(1, 1) PRIMARY KEY,
    CUIT INT,
    proveedor VARCHAR(255),
    nombre VARCHAR(255),
    tel VARCHAR(255),
    email VARCHAR(255)
);
CREATE TABLE Usuarios_Tipo (
    id_usuario_tipo INT IDENTITY(1, 1) PRIMARY KEY,
    tipo INT,
    descripcion VARCHAR(255)
);
CREATE TABLE Usuarios (
    id_usuario INT IDENTITY(1, 1) PRIMARY KEY,
    DNI INT,
    nombre VARCHAR(255),
    apellido VARCHAR(255),
    tel VARCHAR(255),
    mail VARCHAR(255),
    id_tipo INT FOREIGN KEY REFERENCES Usuarios_Tipo(id_usuario_tipo),
);
CREATE TABLE H_Movimientos (
    id_historico INT IDENTITY(1, 1) PRIMARY KEY,
    id_usuario INT FOREIGN KEY REFERENCES Usuarios(id_usuario),
    tipo_movimiento INT,
    reg_antes VARCHAR(255),
    reg_despues VARCHAR(255),
    fecha_hora DATETIME
);
CREATE TABLE In_Out_Varios (
    id_movimiento INT IDENTITY(1, 1) PRIMARY KEY,
    cod_usuario INT FOREIGN KEY REFERENCES Usuarios(id_usuario),
    tipo VARCHAR(255),
    detalle VARCHAR(255),
    monto VARCHAR(255),
    fecha VARCHAR(255)
);
CREATE TABLE Subcategoria (
    id_subcategoria INT IDENTITY(1, 1) PRIMARY KEY,
    subcategoria VARCHAR(255),
    id_categoria INT FOREIGN KEY REFERENCES Categorias(id_categoria),
);
CREATE TABLE H_Compras (
    id_remito INT IDENTITY(1, 1) PRIMARY KEY,
    cod_usuario INT FOREIGN KEY REFERENCES Usuarios(id_usuario),
    fecha_hora VARCHAR(255),
    id_proveedor INT FOREIGN KEY REFERENCES Proveedores(id_proveedor),
    subtotal VARCHAR(255),
    descu VARCHAR(255),
    total VARCHAR(255)
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
    ganancia INT
);
CREATE TABLE H_Compras_Detalle (
    id_det_remito INT IDENTITY(1, 1) PRIMARY KEY,
    id_remito INT FOREIGN KEY REFERENCES H_Compras(id_remito),
    id_articulo INT FOREIGN KEY REFERENCES Articulos(id_articulo),
    descr VARCHAR(255),
    p_unit VARCHAR(255),
    cant VARCHAR(255),
    p_x_cant VARCHAR(255)
);
CREATE TABLE H_Ventas (
    id_remito INT IDENTITY(1, 1) PRIMARY KEY,
    id_usuario INT FOREIGN KEY REFERENCES Usuarios(id_usuario),
    fecha_hora VARCHAR(255),
    id_cliente INT FOREIGN KEY REFERENCES Clientes(id_cliente),
    subtotal VARCHAR(255),
    descu VARCHAR(255),
    total VARCHAR(255)
);
CREATE TABLE H_Ventas_Detalle (
    id_det_remito INT IDENTITY(1, 1) PRIMARY KEY,
    id_remito INT FOREIGN KEY REFERENCES H_Ventas(id_remito),
    id_articulo INT FOREIGN KEY REFERENCES Articulos(id_articulo),
    descr VARCHAR(255),
    p_unit VARCHAR(255),
    cant VARCHAR(255),
    p_x_cant VARCHAR(255)
);