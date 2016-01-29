IF EXISTS (SELECT name 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'[Producto].[getDetalleProducto]') 
			AND type in (N'P',N'PC'))
BEGIN
	DROP PROCEDURE producto.getDetalleProducto
END
GO
CREATE procedure producto.getDetalleProducto
	@parTipoFiltro	varchar(8)
	,@parValorFiltro	varchar(128)
	
	
as
begin

	declare @sql nvarchar(max)
	,@IdProducto	varchar(128)

	set @sql = ''
	
	set @sql = @sql + 'select top 50 IdProducto'
	set @sql = @sql + ',CodigoProducto'
	set @sql = @sql + ',NombreProducto'
	set @sql = @sql + ',DescripcionProducto'
	set @sql = @sql + ',NombreImagenProducto'
	set @sql = @sql + ',NombreFabricante'
	set @sql = @sql + ',PrecioUnitario'
	set @sql = @sql + ',IdSubcategoria'
	set @sql = @sql + ' from Producto.Producto '
	
	if(@parTipoFiltro = 'IP')
	begin
		if(substring(@parValorFiltro,1,1) = '|')
		begin
			set @IdProducto = substring(replace(@parValorFiltro,'|',','),2,len(@parValorFiltro)-2)
		end
		else
		begin
			set @IdProducto = @parValorFiltro
		end
		
		set @sql = @sql + ' where IdProducto in(' + @IdProducto + ')'
	end

	if(@parTipoFiltro = 'S')
	begin
		set @sql = @sql + ' where IdSubcategoria in(' + convert(varchar,@parValorFiltro) + ')'
	end

	if(@parTipoFiltro = 'C')
	begin
		set @sql = @sql + ' where CodigoProducto like ''' + '%' + @parValorFiltro + '%' + ''''
	end

	if(@parTipoFiltro = 'N')
	begin
		set @sql = @sql + ' where NombreProducto like ''' + '%' + @parValorFiltro + '%' + ''''
	end

	if(@parTipoFiltro = 'D')
	begin
		set @sql = @sql + ' where DescripcionProducto like ''' + '%' + @parValorFiltro + '%' + ''''
	end
		
	exec sp_executesql @sql

end
go



