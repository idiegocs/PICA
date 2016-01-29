USE [KALLSONYS]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Producto].[FK_Campania_ProductoxCampania]') AND parent_object_id = OBJECT_ID(N'[Producto].[ProductoxCampania]'))
ALTER TABLE [Producto].[ProductoxCampania] DROP CONSTRAINT [FK_Campania_ProductoxCampania]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Producto].[FK_Subcategoria_Categoria]') AND parent_object_id = OBJECT_ID(N'[Producto].[Subcategoria]'))
ALTER TABLE [Producto].[Subcategoria] DROP CONSTRAINT [FK_Subcategoria_Categoria]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Producto].[ProductoxCampania]') AND type in (N'U'))
DROP TABLE [Producto].[ProductoxCampania]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Producto].[Campania]') AND type in (N'U'))
DROP TABLE [Producto].[Campania]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Producto].[Top5]') AND type in (N'U'))
DROP TABLE [Producto].[Top5]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Producto].[Producto]') AND type in (N'U'))
DROP TABLE [Producto].[Producto]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Producto].[Subcategoria]') AND type in (N'U'))
DROP TABLE [Producto].[Subcategoria]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Producto].[Categoria]') AND type in (N'U'))
DROP TABLE [Producto].[Categoria]
GO
--===================================================================================================================================================================
--===================================================================================================================================================================
--===================================================================================================================================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Producto].[Categoria]') AND type in (N'U'))
BEGIN
CREATE TABLE [Producto].[Categoria](
	[IdCategoria] [int] identity(1,1) NOT NULL,
	[NombreCategoria] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Categoria_NombreCategoria] UNIQUE NONCLUSTERED 
(
	[NombreCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Producto].[Subcategoria]') AND type in (N'U'))
BEGIN
CREATE TABLE [Producto].[Subcategoria](
	[IdSubcategoria] [int] identity(1,1) NOT NULL,
	[NombreSubcategoria] [nvarchar](64) NOT NULL,
	[IdCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Subcategoria] PRIMARY KEY CLUSTERED 
(
	[IdSubcategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Subcategoria_NombreSubcategoria] UNIQUE NONCLUSTERED 
(
	[NombreSubcategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Producto].[FK_Subcategoria_Categoria]') AND parent_object_id = OBJECT_ID(N'[Producto].[Subcategoria]'))
ALTER TABLE [Producto].[Subcategoria]  WITH CHECK ADD  CONSTRAINT FK_Subcategoria_Categoria FOREIGN KEY([IdCategoria])
REFERENCES [Producto].[Categoria] ([IdCategoria])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Producto].[FK_Subcategoria_Categoria]') AND parent_object_id = OBJECT_ID(N'[Producto].[Subcategoria]'))
ALTER TABLE [Producto].[Subcategoria] CHECK CONSTRAINT [FK_Subcategoria_Categoria]
GO
--Se agregan las tablas campaña y productoxcampaña
create table Producto.Campania
(
	IdCampania int identity(1,1) not null,
	Nombre	nvarchar(80) not null,
	FechaInicio	datetime not null,
	FechaFin	datetime not null,
	Estado		bit not null,
	NombreImagenCampania	nvarchar(56) not null
)
go
alter table Producto.Campania
add constraint PK_Campania
primary key(IdCampania)
go
create table Producto.ProductoxCampania
(
	IdProductoxCampania int identity(1,1) not null,
	IdCampania int not null,
	IdProducto int not null,
	PorcentajeDescuento	int not null
)
go
alter table Producto.ProductoxCampania
add constraint PK_ProductoxCampania
primary key(IdProductoxCampania)
go
alter table Producto.ProductoxCampania
add constraint FK_Campania_ProductoxCampania
foreign key(IdCampania)
references Producto.Campania(IdCampania)
go
create table Producto.Top5
(
	IdTop5	int identity(1,1) not null,
	IdProductoTop	int not null,
	IdProductoAsociado int not null,
	CantOrdenesAsociados	int not null
)
go
alter table Producto.Top5
add constraint PK_Top5
primary key(IdTop5)
go
