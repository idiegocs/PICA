CREATE NONCLUSTERED INDEX IX_Producto_CodProducto 
    ON Producto.Producto (CodigoProducto); 
GO
CREATE NONCLUSTERED INDEX IX_Producto_NomProducto 
    ON Producto.Producto (NombreProducto); 
GO
CREATE NONCLUSTERED INDEX IX_Producto_DescProducto 
    ON Producto.Producto (DescripcionProducto); 
GO
CREATE NONCLUSTERED INDEX IX_Producto_IdSubCat 
    ON Producto.Producto (IdSubcategoria); 
GO