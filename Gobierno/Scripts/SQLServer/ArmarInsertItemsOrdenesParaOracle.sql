SELECT *
FROM 
(
	select 'INSERT INTO ITEM_ORDEN (IDITEM,TIPOITEM,IDORDEN,IDPRODUCTO,CODIGOPRODUCTO,NOMBREPRODUCTO,CANTIDADITEM,VALORUNITARIOITEM) VALUES ('
	+ convert(varchar,IDITEM) + ','
	+ convert(varchar,TIPOITEM) + ','
	+ convert(varchar,IDORDEN) + ','
	+ convert(varchar,IDPRODUCTO) +  ','''
	+ CODIGOPRODUCTO + ''','''
	+ NOMBREPRODUCTO + ''','
	+ convert(varchar,CANTIDADITEM) + ','
	+ convert(varchar,VALORUNITARIOITEM) + ');/' COLUMNA
	from Producto.Item_ORDEN) TABLA
WHERE COLUMNA IS NOT NULL