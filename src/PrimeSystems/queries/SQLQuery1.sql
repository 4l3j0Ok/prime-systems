USE PrimeSystems;
IF NOT EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_NAME = 'Clientes'
        AND TABLE_SCHEMA = 'dbo'
) BEGIN
CREATE TABLE Clientes (
    id_cliente INT IDENTITY(1, 1) PRIMARY KEY,
    CUIT INT,
    nombre VARCHAR(255),
    entidad VARCHAR(255),
    tel VARCHAR(255),
    mail VARCHAR(255)
)
END
