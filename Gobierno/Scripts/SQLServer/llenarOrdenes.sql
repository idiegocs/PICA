alter procedure producto.p_llenar_ordenes
as
begin

declare @indexOrden numeric, 
@cant_ordenes numeric,
@flag_cambia_usuario int,
@flag_cambia_fecha int,
@id_usuario numeric,
@fecha_orden date,
@indexItem numeric,
@cant_items numeric,
@id_item_orden numeric,
@Id_Producto numeric(10,0),
@Id_Producto_temp numeric(10,0),

@codigoProducto nvarchar(32),
@NombreProducto nvarchar(64),
@ValorUnitarioProducto numeric(18,0)

set @indexOrden = 1
set @cant_ordenes = 50000
set @flag_cambia_usuario = 1
set @flag_cambia_fecha = 1
set @id_usuario = 10
set @fecha_orden = '2014-01-01'
set @id_item_orden = 1

declare @temporal table
(
	idproductotemp numeric(10,0)
)

while(@cant_ordenes >= @indexOrden)
begin
	
	set @indexItem = 1
	delete @temporal;

	if(@indexOrden % 2) = 0
	begin
		set @cant_items = 2
	end
	else
	begin
		set @cant_items = 1
	end

	insert into producto.ORDEN(IDORDEN,FECHAORDEN,IDESTADOORDEN,IDCLIENTE,CANTITEMORDEN,TOTALORDEN,NUMPREORDEN)
	values(@indexOrden,@fecha_orden,2,@id_usuario,@cant_items,0,@indexOrden)

	while(@cant_items >= @indexItem)
	begin
		
		regenerate:
		set @Id_Producto = 1125500 + CONVERT(INT, (1125637-1125500+1)*RAND())

		if exists(select idproductotemp from @temporal where idproductotemp = @Id_Producto)
		begin
			goto regenerate
		end
		else
		begin
			insert into @temporal values(@Id_Producto)
		end

		select @codigoProducto = [CodigoProducto]
			,@NombreProducto = [NombreProducto]
			,@ValorUnitarioProducto = convert(numeric(18,0),[PrecioUnitario])
		from producto.Producto
		where IdProducto = @Id_Producto

		insert into Producto.ITEM_ORDEN(IDITEM,TIPOITEM,IDORDEN,IDPRODUCTO,CODIGOPRODUCTO,NOMBREPRODUCTO,CANTIDADITEM,VALORUNITARIOITEM)
		values(@id_item_orden,1,@indexOrden,@Id_Producto,@codigoProducto,@NombreProducto,1,@ValorUnitarioProducto)

		set @codigoProducto = null
		set @NombreProducto = null
		set @ValorUnitarioProducto = null

		set @indexItem = (@indexItem + 1)
		set @id_item_orden = (@id_item_orden + 1)
		
	end
	
	set @indexOrden = (@indexOrden + 1)
	set @flag_cambia_usuario = (@flag_cambia_usuario + 1)
	set @flag_cambia_fecha = (@flag_cambia_fecha + 1)


	if(@flag_cambia_fecha = 137)
	begin
		set @flag_cambia_fecha = 1
		set @fecha_orden = DATEADD(day,1,@fecha_orden)
	end
	if (@flag_cambia_usuario = 4)
	begin
		set @flag_cambia_usuario = 1
		set @id_usuario = (@id_usuario + 1)
	end

end

end
go