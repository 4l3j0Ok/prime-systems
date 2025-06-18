IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PrimeSystems')
BEGIN
    CREATE DATABASE PrimeSystems
END;