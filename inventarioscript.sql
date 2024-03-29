CREATE DATABASE Inventario_AJM
GO
USE Inventario_AJM
GO

CREATE TABLE Empleados(
	IdEmpleado				INT IDENTITY(1,1),
	Identidad				VARCHAR(13)		NOT NULL,
	Nombres					VARCHAR(150)	NOT NULL,
	Apellidos				VARCHAR(150)	NOT NULL,
	Telefono				VARCHAR(20)		NOT NULL,
	Direccion				VARCHAR(500)	NOT NULL,

	Activo					BIT				NOT NULL CONSTRAINT DF_Empleados_Activo DEFAULT 1,
	IdUsuarioCreacion		INT				NOT NULL,
	FechaCreacion			DATETIME		NOT NULL,
	IdUsuarioModificacion	INT,
	FechaModificacion		DATETIME,

	CONSTRAINT PK_Empleados_IdEmpleado	PRIMARY KEY(IdEmpleado),
	CONSTRAINT UC_Empleados_Identidad	UNIQUE(Identidad)
);
GO

CREATE TABLE Perfiles(
	IdPerfil				INT IDENTITY(1,1),
	Nombre					VARCHAR(30)		NOT NULL,

	Activo					BIT				NOT NULL CONSTRAINT DF_Perfiles_Activo DEFAULT 1,
	IdUsuarioCreacion		INT				NOT NULL,
	FechaCreacion			DATETIME		NOT NULL,
	IdUsuarioModificacion	INT,
	FechaModificacion		DATETIME,

	CONSTRAINT PK_Perfiles_IdEmpleado	PRIMARY KEY(IdPerfil),
	CONSTRAINT UC_Perfiles_Nombre		UNIQUE(Nombre)
);
GO

CREATE TABLE Permisos(
	IdPermiso				INT IDENTITY(1,1),
	Nombre					VARCHAR(30)		NOT NULL,

	Activo					BIT				NOT NULL CONSTRAINT DF_Permisos_Activo DEFAULT 1,
	IdUsuarioCreacion		INT				NOT NULL,
	FechaCreacion			DATETIME		NOT NULL,
	IdUsuarioModificacion	INT,
	FechaModificacion		DATETIME,

	CONSTRAINT PK_Permisos_IdPermiso	PRIMARY KEY(IdPermiso),
	CONSTRAINT UC_Permisos_Nombre		UNIQUE(Nombre)
);
GO

CREATE TABLE PerfilesPorPermisos(
	IdPermisoPerfil			INT IDENTITY(1,1),
	IdPermiso				INT				NOT NULL,
	IdPerfil				INT				NOT NULL,

	CONSTRAINT PK_PerfilesPorPermisos_IdPermisoPerfil		PRIMARY KEY(IdPermisoPerfil),
	CONSTRAINT UC_PerfilesPorPermisos_IdPermiso_IdPerfil	UNIQUE(IdPermiso, IdPerfil)
);
GO

CREATE TABLE Usuarios(
	IdUsuario				INT IDENTITY(1,1),
	Nombre					VARCHAR(30)		NOT NULL,
	Contrasena				NVARCHAR(MAX)	NOT NULL,
	IdEmpleado				INT,
	IdPerfil				INT,
	EsAdmin					BIT				NOT NULL,

	Activo					BIT				NOT NULL CONSTRAINT DF_Usuarios_Activo DEFAULT 1,
	IdUsuarioCreacion		INT				NOT NULL,
	FechaCreacion			DATETIME		NOT NULL,
	IdUsuarioModificacion	INT,
	FechaModificacion		DATETIME,

	CONSTRAINT PK_Usuarios_IdUsuario				PRIMARY KEY(IdUsuario),
	CONSTRAINT FK_Usuarios_Empleados_IdEmpleado		FOREIGN KEY(IdEmpleado)		REFERENCES Empleados (IdEmpleado),
	CONSTRAINT FK_Usuarios_Perfil_IdPerfil			FOREIGN KEY(IdPerfil)		REFERENCES Perfiles (IdPerfil),
	CONSTRAINT UC_Usuarios_Nombre					UNIQUE(Nombre)
);
GO

INSERT INTO Usuarios(Nombre,
					 Contrasena,
					 EsAdmin,
					 IdUsuarioCreacion,
					 FechaCreacion)
VALUES ('admin', HASHBYTES('SHA2_512', '123'), 1, 1, GETDATE())
GO

ALTER TABLE Usuarios
ADD CONSTRAINT FK_Usuarios_IdUsuarioCreacion_IdUsuario		FOREIGN KEY(IdUsuarioCreacion)			REFERENCES Usuarios (IdUsuario),
    CONSTRAINT FK_Usuarios_IdUsuarioModificacion_IdUsuario	FOREIGN KEY(IdUsuarioModificacion)		REFERENCES Usuarios (IdUsuario)
GO

ALTER TABLE Perfiles
ADD CONSTRAINT FK_Perfiles_Usuarios_IdUsuarioCreacion_IdUsuario			FOREIGN KEY(IdUsuarioCreacion)			REFERENCES Usuarios (IdUsuario),
    CONSTRAINT FK_Perfiles_Usuarios_IdUsuarioModificacion_IdUsuario		FOREIGN KEY(IdUsuarioModificacion)		REFERENCES Usuarios (IdUsuario)
GO

ALTER TABLE Permisos
ADD CONSTRAINT FK_Permisos_Usuarios_IdUsuarioCreacion_IdUsuario			FOREIGN KEY(IdUsuarioCreacion)			REFERENCES Usuarios (IdUsuario),
    CONSTRAINT FK_Permisos_Usuarios_IdUsuarioModificacion_IdUsuario		FOREIGN KEY(IdUsuarioModificacion)		REFERENCES Usuarios (IdUsuario)
GO

ALTER TABLE Empleados
ADD CONSTRAINT FK_Empleados_Usuarios_IdUsuarioCreacion_IdUsuario			FOREIGN KEY(IdUsuarioCreacion)			REFERENCES Usuarios (IdUsuario),
    CONSTRAINT FK_Empleados_Usuarios_IdUsuarioModificacion_IdUsuario		FOREIGN KEY(IdUsuarioModificacion)		REFERENCES Usuarios (IdUsuario)
GO

CREATE TABLE Productos(
	IdProducto				INT IDENTITY(1,1),
	Nombre					VARCHAR(100)	NOT NULL,

	Activo					BIT				NOT NULL CONSTRAINT DF_Productos_Activo DEFAULT 1,
	IdUsuarioCreacion		INT				NOT NULL,
	FechaCreacion			DATETIME		NOT NULL,
	IdUsuarioModificacion	INT,
	FechaModificacion		DATETIME,

	CONSTRAINT PK_Productos_IdProducto						PRIMARY KEY(IdProducto),
	CONSTRAINT FK_Productos_IdUsuarioCreacion_IdUsuario		FOREIGN KEY(IdUsuarioCreacion)			REFERENCES Usuarios (IdUsuario),
    CONSTRAINT FK_Productos_IdUsuarioModificacion_IdUsuario	FOREIGN KEY(IdUsuarioModificacion)		REFERENCES Usuarios (IdUsuario),
	CONSTRAINT UC_Productos_Nombre					UNIQUE(Nombre)
);
GO

CREATE TABLE Estados(
	IdEstado				INT IDENTITY(1,1),
	Nombre					VARCHAR(100)	NOT NULL,

	Activo					BIT				NOT NULL CONSTRAINT DF_Estados_Activo DEFAULT 1,
	IdUsuarioCreacion		INT				NOT NULL,
	FechaCreacion			DATETIME		NOT NULL,
	IdUsuarioModificacion	INT,
	FechaModificacion		DATETIME,

	CONSTRAINT PK_Estados_IdEstado							PRIMARY KEY(IdEstado),
	CONSTRAINT FK_Estados_IdUsuarioCreacion_IdUsuario		FOREIGN KEY(IdUsuarioCreacion)			REFERENCES Usuarios (IdUsuario),
    CONSTRAINT FK_Estados_IdUsuarioModificacion_IdUsuario	FOREIGN KEY(IdUsuarioModificacion)		REFERENCES Usuarios (IdUsuario),
	CONSTRAINT UC_Estados_Nombre							UNIQUE(Nombre)
);
GO

CREATE TABLE Sucursales(
	IdSucursal				INT IDENTITY(1,1),
	Nombre					VARCHAR(150)	NOT NULL,

	Activo					BIT				NOT NULL CONSTRAINT DF_Sucursales_Activo DEFAULT 1,
	IdUsuarioCreacion		INT				NOT NULL,
	FechaCreacion			DATETIME		NOT NULL,
	IdUsuarioModificacion	INT,
	FechaModificacion		DATETIME,

	CONSTRAINT PK_Sucursales_IdSucursal							PRIMARY KEY(IdSucursal),
	CONSTRAINT FK_Sucursales_IdUsuarioCreacion_IdUsuario		FOREIGN KEY(IdUsuarioCreacion)			REFERENCES Usuarios (IdUsuario),
    CONSTRAINT FK_Sucursales_IdUsuarioModificacion_IdUsuario	FOREIGN KEY(IdUsuarioModificacion)		REFERENCES Usuarios (IdUsuario),
	CONSTRAINT UC_Sucursales_Nombre								UNIQUE(Nombre)
);
GO

CREATE TABLE Lotes(
	IdLote					INT IDENTITY(1,1),
	IdProducto				INT				NOT NULL,
	CantidadInicial			INT				NOT NULL,
	CostoUnidad				DECIMAL(18,2)	NOT NULL,
	FechaVencimiento		DATE			NOT NULL,
	Inventario				INT				NOT NULL,

	Activo					BIT				NOT NULL CONSTRAINT DF_Lotes_Activo DEFAULT 1,
	IdUsuarioCreacion		INT				NOT NULL,
	FechaCreacion			DATETIME		NOT NULL,
	IdUsuarioModificacion	INT,
	FechaModificacion		DATETIME,

	CONSTRAINT PK_Lotes_IdLote							PRIMARY KEY(IdLote),
	CONSTRAINT FK_Lotes_IdUsuarioCreacion_IdUsuario		FOREIGN KEY(IdUsuarioCreacion)			REFERENCES Usuarios (IdUsuario),
    CONSTRAINT FK_Lotes_IdUsuarioModificacion_IdUsuario	FOREIGN KEY(IdUsuarioModificacion)		REFERENCES Usuarios (IdUsuario),
	CONSTRAINT FK_Lotes_Productos_IdProducto			FOREIGN KEY(IdProducto)					REFERENCES Productos (IdProducto)
);
GO

CREATE TABLE SalidasInventario(
	IdSalidaInventario		INT IDENTITY(1,1),
	IdSucursal				INT				NOT NULL,
	IdUsuario				INT				NOT NULL,
	Fecha					DATETIME		NOT NULL,
	Total					DECIMAL(18,2)	NOT NULL,
	FechaRecibido			DATE			NOT NULL,
	IdUsuarioRecibe			INT				NOT NULL,
	IdEstado				INT				NOT NULL,

	Activo					BIT				NOT NULL CONSTRAINT DF_SalidasInventario_Activo DEFAULT 1,
	IdUsuarioCreacion		INT				NOT NULL,
	FechaCreacion			DATETIME		NOT NULL,
	IdUsuarioModificacion	INT,
	FechaModificacion		DATETIME,

	CONSTRAINT PK_SalidasInventario_IdSalidaInventario				PRIMARY KEY(IdSalidaInventario),
	CONSTRAINT FK_SalidasInventario_IdUsuarioCreacion_IdUsuario		FOREIGN KEY(IdUsuarioCreacion)			REFERENCES Usuarios (IdUsuario),
    CONSTRAINT FK_SalidasInventario_IdUsuarioModificacion_IdUsuario	FOREIGN KEY(IdUsuarioModificacion)		REFERENCES Usuarios (IdUsuario),
	CONSTRAINT FK_SalidasInventario_Sucursales_IdSucursal			FOREIGN KEY(IdSucursal)					REFERENCES Sucursales (IdSucursal),
	CONSTRAINT FK_SalidasInventario_Usuarios_IdUsuario				FOREIGN KEY(IdUsuario)					REFERENCES Usuarios (IdUsuario),
	CONSTRAINT FK_SalidasInventario_Usuarios_IdUsuarioRecibe		FOREIGN KEY(IdUsuarioRecibe)			REFERENCES Usuarios (IdUsuario),
	CONSTRAINT FK_SalidasInventario_Estados_IdEstado				FOREIGN KEY(IdEstado)			REFERENCES Estados (IdEstado),
);
GO

CREATE TABLE SalidasInventarioDetalles(
	IdSalidaDetalle			INT IDENTITY(1,1),
	IdSalidaInventario		INT				NOT NULL,
	IdLote					INT				NOT NULL,
	CantidadProducto		INT				NOT NULL,

	Activo					BIT				NOT NULL CONSTRAINT DF_SalidasInventarioDetalles_Activo DEFAULT 1,
	IdUsuarioCreacion		INT				NOT NULL,
	FechaCreacion			DATETIME		NOT NULL,
	IdUsuarioModificacion	INT,
	FechaModificacion		DATETIME,

	CONSTRAINT PK_SalidasInventarioDetalles_IdSalidaDetalle					PRIMARY KEY(IdSalidaDetalle),
	CONSTRAINT FK_SalidasInventarioDetalles_IdUsuarioCreacion_IdUsuario		FOREIGN KEY(IdUsuarioCreacion)			REFERENCES Usuarios (IdUsuario),
    CONSTRAINT FK_SalidasInventarioDetalles_IdUsuarioModificacion_IdUsuario	FOREIGN KEY(IdUsuarioModificacion)		REFERENCES Usuarios (IdUsuario),
	CONSTRAINT FK_SalidasInventarioDetalles_Lotes_IdLote					FOREIGN KEY(IdLote)						REFERENCES Lotes (IdLote),
);
GO

CREATE TABLE __ErroresDb(
	IdErrores		INT IDENTITY(1,1),
	FechaYHora		DATETIME,
	Codigo			VARCHAR(10),
	Mensaje			NVARCHAR(MAX)

	CONSTRAINT PK_ErroresDb_IdErrores PRIMARY KEY(IdErrores)
);

INSERT INTO Sucursales(Nombre,
					   IdUsuarioCreacion,
					   FechaCreacion)
VALUES ('Sucursal 1', 1, GETDATE()),
       ('Sucursal 2', 1, GETDATE()),
       ('Sucursal 3', 1, GETDATE()),
       ('Sucursal 4', 1, GETDATE()),
       ('Sucursal 5', 1, GETDATE())


INSERT INTO Productos(Nombre,
					  IdUsuarioCreacion,
					  FechaCreacion)
VALUES ('Producto 1', 1, GETDATE()),
       ('Producto 2', 1, GETDATE()),
       ('Producto 3', 1, GETDATE()),
       ('Producto 4', 1, GETDATE()),
       ('Producto 5', 1, GETDATE())

INSERT INTO Perfiles(Nombre,
					 IdUsuarioCreacion,
					 FechaCreacion)
VALUES ('Jefe de Tienda', 1, GETDATE()),
	   ('Dependiente', 1, GETDATE())
