CREATE DATABASE Inventario_AJM
GO
USE Inventario_AJM
GO

CREATE TABLE Usuarios(
	IdUsuario				INT IDENTITY(1,1),
	Nombre					VARCHAR(30)		NOT NULL,
	Contrasena				NVARCHAR(MAX)	NOT NULL,
	IdEmpleado				INT,
	IdPerfil				INT,
	Activo					BIT				NOT NULL,
	IdUsuarioCreacion		INT				NOT NULL,
	FechaCreacion			DATETIME		NOT NULL,
	IdUsuarioModificacion	INT,
	FechaModificacion		DATETIME		NOT NULL
);