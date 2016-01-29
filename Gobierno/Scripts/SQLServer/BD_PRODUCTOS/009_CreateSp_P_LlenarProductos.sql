if exists(select *
		  from sys.objects
		  where object_id = OBJECT_ID(N'[Producto].[P_LlenarProductos]') 
			and type in (N'P',N'PC'))
begin
	drop procedure producto.P_LlenarProductos
end
go
create procedure producto.P_LlenarProductos
as
begin
	declare @index int
			,@cant int
			,@CodigoProducto	nvarchar(32)
			,@NombreProducto	nvarchar(64)
			,@DescripcionProducto	nvarchar(128)
			,@NombreFabricante	nvarchar(64)
			,@NombreImagenProducto nvarchar(56)
			,@IdSubcategoria	int
			,@PrecioUnitario	numeric(16,2)

	set @index = 1
	set @cant = 1000000

	truncate table producto.prueba

	while (@cant >= @index)
	begin

		select @PrecioUnitario = convert(numeric(16,2),ABS(Checksum(NewID()) % 47000) + 128500)
		select @CodigoProducto = 'COD_PRO_' + convert(nvarchar,@index)
		select @NombreProducto = 'Nombre Producto No' + convert(nvarchar,@index)
		select @DescripcionProducto = 'Descripcion Producto No ' + convert(nvarchar,@index)
		select @NombreFabricante = 'IMG_PRO_' + convert(nvarchar,@index)
		select @NombreImagenProducto = 'COD_PRO_' + convert(nvarchar,@index)

		if @index >=1 and @index <= 200000
		begin
			set @IdSubcategoria = 1
		end
		if @index >=200001 and @index <= 400000
		begin
			set @IdSubcategoria = 2
		end
		if @index >=400001 and @index <= 600000
		begin
			set @IdSubcategoria = 3
		end
		if @index >=600001 and @index <= 800000
		begin
			set @IdSubcategoria = 4
		end
		if @index >=800001 and @index <= 900000
		begin
			set @IdSubcategoria = 5
		end
		if @index >=900001 and @index <= 1000000
		begin
			set @IdSubcategoria = 6
		end

		insert into producto.Producto values(@CodigoProducto,@NombreProducto,@DescripcionProducto,@NombreFabricante,
													@NombreImagenProducto,@IdSubcategoria,@PrecioUnitario)

		set @index = (@index + 1)
	end

end
go


