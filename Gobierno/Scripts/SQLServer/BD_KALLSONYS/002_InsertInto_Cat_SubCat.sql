use KALLSONYS
go
SET IDENTITY_INSERT Producto.Categoria ON;
GO
insert into producto.Categoria(IdCategoria,NombreCategoria) values(1,'Electrodomestico')
GO
SET IDENTITY_INSERT Producto.Categoria off;
GO
SET IDENTITY_INSERT Producto.Subcategoria ON;
go
insert into Producto.Subcategoria(IdSubcategoria,NombreSubcategoria,IdCategoria) values(1,'Lavadora',1)
insert into Producto.Subcategoria(IdSubcategoria,NombreSubcategoria,IdCategoria) values(2,'Nevera',1)
insert into Producto.Subcategoria(IdSubcategoria,NombreSubcategoria,IdCategoria) values(3,'Horno Microondas',1)
insert into Producto.Subcategoria(IdSubcategoria,NombreSubcategoria,IdCategoria) values(4,'Estufa',1)
insert into Producto.Subcategoria(IdSubcategoria,NombreSubcategoria,IdCategoria) values(5,'Licuadora',1)
insert into Producto.Subcategoria(IdSubcategoria,NombreSubcategoria,IdCategoria) values(6,'Plancha',1)
go
SET IDENTITY_INSERT Producto.Subcategoria off;
go

