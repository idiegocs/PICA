select 'INSERT INTO ORDEN(IDORDEN,FECHAORDEN,IDESTADOORDEN,IDUSUARIO,CANTITEMORDEN,TOTALORDEN,NUMPREORDEN) VALUES ('
+ convert(varchar,IDORDEN) + ','
+ 'TO_DATE(''' + convert(varchar,FECHAORDEN,103) + '''),'
+ convert(varchar,IDESTADOORDEN) + ','
+ convert(varchar,IDCLIENTE) + ','
+ convert(varchar,CANTITEMORDEN) + ','
+ convert(varchar,TOTALORDEN) + ','
+ convert(varchar,NUMPREORDEN) + ');/'
from producto.orden;


