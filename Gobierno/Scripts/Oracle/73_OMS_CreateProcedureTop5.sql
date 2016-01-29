--------------------------------------------------------
--  DDL for Procedure P_GET_TOP5_PRODUCTOS
--------------------------------------------------------
set define off;

CREATE OR REPLACE PROCEDURE "P_GET_TOP5_PRODUCTOS" 
AS 
BEGIN

BEGIN

  DELETE PRODUCTOS_TOP5;

   FOR idproducto_rec
      IN (SELECT DISTINCT IDPRODUCTO AS IDPRODUCTO_PADRE FROM ITEM_ORDEN)
   LOOP
      INSERT INTO PRODUCTOS_TOP5(IDPRODUCTO_PADRE,IDPRODUCTO,CANT_ORDENES)
      select idproducto_rec.IDPRODUCTO_PADRE, IDPRODUCTO, cant_orden_juntos
      from
      (
        select IDPRODUCTO, count(distinct IDORDEN) cant_orden_juntos, ROW_NUMBER() OVER (ORDER BY 2 ASC) AS x
        from ITEM_ORDEN
        where IDPRODUCTO <> idproducto_rec.IDPRODUCTO_PADRE
        and IDORDEN in(select DISTINCT idorden
                       from ITEM_ORDEN
                       where IDPRODUCTO = idproducto_rec.IDPRODUCTO_PADRE)
        group by IDPRODUCTO
        order by 2 desc
      )
      where x < 6;
      
   END LOOP;
   
   COMMIT;
   
END;

END P_GET_TOP5_PRODUCTOS;
/
commit;
/
/*
Para probar que el Sp devuelve los datos correctos, ejecutar:
var rc refcursor
execute P_GET_TOP5_PRODUCTOS(1125557, :rc);
print rc;
*/

