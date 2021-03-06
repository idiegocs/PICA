--------------------------------------------------------
-- Archivo creado  - viernes-abril-03-2015   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Sequence SEQ_CIUDAD
--------------------------------------------------------
   --CREATE SEQUENCE  "SEQ_CIUDAD"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 NOCACHE  NOORDER  NOCYCLE ;
 --se omite esta secuencia debido que esta tabla es paramétrica, no es transaccional.
 
--------------------------------------------------------
--  DDL for Sequence SEQ_CLIENTE
--------------------------------------------------------
   CREATE SEQUENCE  "SEQ_CLIENTE"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 NOCACHE  NOORDER  NOCYCLE ;
   
--------------------------------------------------------
--  DDL for Sequence SEQ_DIRECCION
--------------------------------------------------------
   CREATE SEQUENCE  "SEQ_DIRECCION"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 NOCACHE  NOORDER  NOCYCLE ;
   
--------------------------------------------------------
--  DDL for Sequence SEQ_ESTADO
--------------------------------------------------------
   CREATE SEQUENCE  "SEQ_ESTADO"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 NOCACHE  NOORDER  NOCYCLE ;
   
--------------------------------------------------------
--  DDL for Sequence SEQ_PAIS
--------------------------------------------------------
   --CREATE SEQUENCE  "SEQ_PAIS"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 NOCACHE  NOORDER  NOCYCLE ;
   --se omite esta secuencia debido que esta tabla es paramétrica, no es transaccional.
   
--------------------------------------------------------
--  DDL for Sequence SEQ_PRE_ORDEN
--------------------------------------------------------
   CREATE SEQUENCE  "SEQ_PRE_ORDEN"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1049 NOCACHE  NOORDER  NOCYCLE ;
   
--------------------------------------------------------
--  DDL for Sequence SEQ_PROMO
--------------------------------------------------------
   CREATE SEQUENCE  "SEQ_PROMO"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 NOCACHE  NOORDER  NOCYCLE ;
   
  
--------------------------------------------------------
--  DDL for Table CIUDAD
--------------------------------------------------------

  CREATE TABLE "CIUDAD" 
   (	"IDCIUDAD" NUMBER, 
		"IDDEPARTAMENTO" NUMBER, 
		"NOMBRECIUDAD" VARCHAR2(50 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Table DEPARTAMENTO
--------------------------------------------------------

  CREATE TABLE "DEPARTAMENTO" 
   (	"IDDEPARTAMENTO" NUMBER, 
		"IDPAIS" NUMBER, 
		"NOMBREDEPARTAMENTO" VARCHAR2(500 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
  
--------------------------------------------------------
--  DDL for Table PAIS
--------------------------------------------------------

  CREATE TABLE "PAIS" 
   (	"IDPAIS" NUMBER, 
		"NOMBREPAIS" VARCHAR2(50 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Table DIRECCION
--------------------------------------------------------

  CREATE TABLE "DIRECCION" 
   (	"IDDIRECCION" NUMBER(18,0), 
		"IDCIUDAD" NUMBER, 
		"NUMERODIRECCION" VARCHAR2(500 BYTE), 
		"CODIGOPOSTAL" VARCHAR2(10 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Table ESTADO_ORDEN
--------------------------------------------------------

  CREATE TABLE "ESTADO_ORDEN" 
   (	"IDESTADOORDEN" NUMBER, 
		"NOMBREESTADOORDEN" VARCHAR2(20 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Table ITEM_ORDEN
--------------------------------------------------------

  CREATE TABLE "ITEM_ORDEN" 
   (	"IDITEM" NUMBER,
		"TIPOITEM" NUMBER(*,0), 
		"IDORDEN" NUMBER, 
		"IDPRODUCTO" NUMBER(10,0),
		"CODIGOPRODUCTO" VARCHAR2(32 BYTE), 
		"NOMBREPRODUCTO" VARCHAR2(64 BYTE),
		"CANTIDADITEM" NUMBER(*,0),
		"VALORUNITARIOITEM" NUMBER DEFAULT 0
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Table ORDEN
--------------------------------------------------------

  CREATE TABLE "ORDEN" 
   (	"IDORDEN" NUMBER, 
		"FECHAORDEN" DATE, 
		"IDESTADOORDEN" NUMBER, 
		"IDCLIENTE" NUMBER, 
		"CANTITEMORDEN" NUMBER(*,0) DEFAULT 0, 
		"TOTALORDEN" NUMBER DEFAULT 0, 
		"NUMPREORDEN" NUMBER
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;

--------------------------------------------------------
--  DDL for Table ROLES
--------------------------------------------------------

  CREATE TABLE "ROLES" 
   (	"IDROL" NUMBER(18,0), 
		"NOMBREROL" VARCHAR2(20 BYTE), 
		"DESCRIPCIONROL" VARCHAR2(200 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Table CLIENTEXROL
--------------------------------------------------------

  CREATE TABLE "CLIENTEXROL" 
   (	"IDUSUARIO" NUMBER(18,0), 
		"IDROL" NUMBER(18,0)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Table USUARIO
--------------------------------------------------------

  CREATE TABLE "USUARIO" 
   (	"IDUSUARIO" NUMBER(18,0), 
		"NOMBRES" VARCHAR2(80 BYTE), 
		"APELLIDOS" VARCHAR2(80 BYTE), 
		"EMAIL" VARCHAR2(80 BYTE), 
		"PASSWORD" VARCHAR2(128 BYTE), 
		"TIPODOCUMENTO" NUMBER, 
		"NUMERODOCUMENTO" VARCHAR2(50 BYTE), 
		"IDDIRECCION" NUMBER(18,0), 
		"USERNAME" VARCHAR2(40 BYTE), 
		"TELEFONO" VARCHAR2(20 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for View V_USER_ROLE
--------------------------------------------------------

CREATE OR REPLACE FORCE VIEW "V_USER_ROLE" ("USERNAME", "PASSWORD", "NOMBRES", "APELLIDOS", "NOMBREROL") AS 
SELECT  US.USERNAME, US.PASSWORD, US.NOMBRES,US.APELLIDOS, RO.NOMBREROL 
FROM CLIENTEXROL UR
INNER JOIN USUARIO US ON US.IDUSUARIO = UR.IDUSUARIO
INNER JOIN ROLES RO ON RO.IDROL = UR.IDROL;

REM INSERTING into PAIS
SET DEFINE OFF;
Insert into PAIS (IDPAIS,NOMBREPAIS) values ('57','COLOMBIA');

REM INSERTING into DEPARTAMENTO
SET DEFINE OFF;
Insert into DEPARTAMENTO (IDDEPARTAMENTO,IDPAIS,NOMBREDEPARTAMENTO) values ('11','57','BOGOTA D.C.');
Insert into DEPARTAMENTO (IDDEPARTAMENTO,IDPAIS,NOMBREDEPARTAMENTO) values ('25','57','CUNDINAMARCA');

REM INSERTING into CIUDAD
SET DEFINE OFF;
Insert into CIUDAD (IDCIUDAD,IDDEPARTAMENTO,NOMBRECIUDAD) values ('1','11','BOGOTA');

REM INSERTING into DIRECCION
SET DEFINE OFF;
Insert into DIRECCION (IDDIRECCION,IDCIUDAD,NUMERODIRECCION,CODIGOPOSTAL) values ('1','1','KR 9A #21 90','20015');

REM INSERTING into ESTADO_ORDEN
SET DEFINE OFF;
Insert into ESTADO_ORDEN (IDESTADOORDEN,NOMBREESTADOORDEN) values ('1','CREADA');
Insert into ESTADO_ORDEN (IDESTADOORDEN,NOMBREESTADOORDEN) values ('2','CERRADA');

REM INSERTING into ORDEN
SET DEFINE OFF;
Insert into ORDEN (IDORDEN,FECHAORDEN,IDESTADOORDEN,IDCLIENTE,CANTITEMORDEN,TOTALORDEN,NUMPREORDEN) values ('1',to_date('22/03/15','DD/MM/RR'),'1','1','3','23423554','1');

REM INSERTING into ITEM_ORDEN
SET DEFINE OFF;
Insert into ITEM_ORDEN (IDITEM,CANTIDADITEM,TIPOITEM,IDORDEN,IDPRODUCTO,CODIGOPRODUCTO,VALORUNITARIOITEM) values ('1','2','1','1','13214','2143254','4352');
Insert into ITEM_ORDEN (IDITEM,CANTIDADITEM,TIPOITEM,IDORDEN,IDPRODUCTO,CODIGOPRODUCTO,VALORUNITARIOITEM) values ('2','3','1','1','12134','132321454','324325');
Insert into ITEM_ORDEN (IDITEM,CANTIDADITEM,TIPOITEM,IDORDEN,IDPRODUCTO,CODIGOPRODUCTO,VALORUNITARIOITEM) values ('3','3','1','1','314','2144','345');

REM INSERTING into ROLES
SET DEFINE OFF;
Insert into ROLES (IDROL,NOMBREROL,DESCRIPCIONROL) values ('1','ADMINISTRADOR','ADMINISTRADOR SISTEMA');
Insert into ROLES (IDROL,NOMBREROL,DESCRIPCIONROL) values ('2','GERENTE','GERENTE KALLSONYS');
Insert into ROLES (IDROL,NOMBREROL,DESCRIPCIONROL) values ('3','USUARIO','USUARIO KALLSONYS');

REM INSERTING into USUARIO
SET DEFINE OFF;
Insert into USUARIO (IDUSUARIO,NOMBRES,APELLIDOS,EMAIL,PASSWORD,TIPODOCUMENTO,NUMERODOCUMENTO,IDDIRECCION,USERNAME,TELEFONO) values ('1','Diego','Castaneda_12345','idiegocs@gmail.com','827ccb0eea8a706c4c34a16891f84e7b','1','3146856','1','idiegocs@gmail.com','12345');
Insert into USUARIO (IDUSUARIO,NOMBRES,APELLIDOS,EMAIL,PASSWORD,TIPODOCUMENTO,NUMERODOCUMENTO,IDDIRECCION,USERNAME,TELEFONO) values ('2','nnn','ape_dics','nnnn','a7978674e72c6bad21bb25ff8b873067','1','31455','1','idiegocs','1234');

REM INSERTING into CLIENTEXROL
SET DEFINE OFF;
Insert into CLIENTEXROL (IDUSUARIO,IDROL) values ('1','1');
Insert into CLIENTEXROL (IDUSUARIO,IDROL) values ('2','1');

--------------------------------------------------------
--  DDL for Index CLIENTES_UK1
--------------------------------------------------------

  CREATE UNIQUE INDEX "CLIENTES_UK1" ON "USUARIO" ("USERNAME") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Index ROLES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ROLES_PK" ON "ROLES" ("IDROL") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Index PAIS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PAIS_PK" ON "PAIS" ("IDPAIS") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Index ORDEN_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ORDEN_PK" ON "ORDEN" ("IDORDEN") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Index DIRECCION_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "DIRECCION_PK" ON "DIRECCION" ("IDDIRECCION") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Index CLIENTES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "CLIENTES_PK" ON "USUARIO" ("IDUSUARIO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Index ESTADO_ORDEN_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ESTADO_ORDEN_PK" ON "ESTADO_ORDEN" ("IDESTADOORDEN") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Index USER_ROLES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "USER_ROLES_PK" ON "CLIENTEXROL" ("IDUSUARIO", "IDROL") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS";
--------------------------------------------------------
--  DDL for Index ESTADO_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ESTADO_PK" ON "DEPARTAMENTO" ("IDDEPARTAMENTO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Index ITEM_ORDEN_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ITEM_ORDEN_PK" ON "ITEM_ORDEN" ("IDITEM") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  DDL for Index CIUDAD_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "CIUDAD_PK" ON "CIUDAD" ("IDCIUDAD") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS" ;
--------------------------------------------------------
--  Constraints for Table PAIS
--------------------------------------------------------

  ALTER TABLE "PAIS" ADD CONSTRAINT "PAIS_PK" PRIMARY KEY ("IDPAIS")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS"  ENABLE;
  ALTER TABLE "PAIS" MODIFY ("NOMBREPAIS" NOT NULL ENABLE);
  ALTER TABLE "PAIS" MODIFY ("IDPAIS" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table USUARIO
--------------------------------------------------------

  ALTER TABLE "USUARIO" ADD CONSTRAINT "CLIENTES_UK1" UNIQUE ("USERNAME")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS"  ENABLE;
  ALTER TABLE "USUARIO" MODIFY ("USERNAME" NOT NULL ENABLE);
  ALTER TABLE "USUARIO" ADD CONSTRAINT "CLIENTES_PK" PRIMARY KEY ("IDUSUARIO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS"  ENABLE;
  ALTER TABLE "USUARIO" MODIFY ("NUMERODOCUMENTO" NOT NULL ENABLE);
  ALTER TABLE "USUARIO" MODIFY ("TIPODOCUMENTO" NOT NULL ENABLE);
  ALTER TABLE "USUARIO" MODIFY ("PASSWORD" NOT NULL ENABLE);
  ALTER TABLE "USUARIO" MODIFY ("APELLIDOS" NOT NULL ENABLE);
  ALTER TABLE "USUARIO" MODIFY ("NOMBRES" NOT NULL ENABLE);
  ALTER TABLE "USUARIO" MODIFY ("IDUSUARIO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CLIENTEXROL
--------------------------------------------------------

  ALTER TABLE "CLIENTEXROL" ADD CONSTRAINT "USER_ROLES_PK" PRIMARY KEY ("IDUSUARIO", "IDROL")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS"  ENABLE;
  ALTER TABLE "CLIENTEXROL" MODIFY ("IDROL" NOT NULL ENABLE);
  ALTER TABLE "CLIENTEXROL" MODIFY ("IDUSUARIO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ITEM_ORDEN
--------------------------------------------------------

  ALTER TABLE "ITEM_ORDEN" MODIFY ("TIPOITEM" NOT NULL ENABLE);
  --Por campaniasas no se deja obligatorio este campo
  --ALTER TABLE "ITEM_ORDEN" MODIFY ("CODIGOPRODUCTO" NOT NULL ENABLE);
  ALTER TABLE "ITEM_ORDEN" MODIFY ("IDPRODUCTO" NOT NULL ENABLE);
  ALTER TABLE "ITEM_ORDEN" MODIFY ("IDORDEN" NOT NULL ENABLE);
  ALTER TABLE "ITEM_ORDEN" MODIFY ("VALORUNITARIOITEM" NOT NULL ENABLE);
  ALTER TABLE "ITEM_ORDEN" ADD CONSTRAINT "ITEM_ORDEN_PK" PRIMARY KEY ("IDITEM")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS"  ENABLE;
  ALTER TABLE "ITEM_ORDEN" MODIFY ("IDITEM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table DEPARTAMENTO
--------------------------------------------------------

  ALTER TABLE "DEPARTAMENTO" ADD CONSTRAINT "ESTADO_PK" PRIMARY KEY ("IDDEPARTAMENTO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS"  ENABLE;
  ALTER TABLE "DEPARTAMENTO" MODIFY ("NOMBREDEPARTAMENTO" NOT NULL ENABLE);
  ALTER TABLE "DEPARTAMENTO" MODIFY ("IDPAIS" NOT NULL ENABLE);
  ALTER TABLE "DEPARTAMENTO" MODIFY ("IDDEPARTAMENTO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ESTADO_ORDEN
--------------------------------------------------------

  ALTER TABLE "ESTADO_ORDEN" ADD CONSTRAINT "ESTADO_ORDEN_PK" PRIMARY KEY ("IDESTADOORDEN")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS"  ENABLE;
  ALTER TABLE "ESTADO_ORDEN" MODIFY ("IDESTADOORDEN" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ROLES
--------------------------------------------------------

  ALTER TABLE "ROLES" ADD CONSTRAINT "ROLES_PK" PRIMARY KEY ("IDROL")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS"  ENABLE;
  ALTER TABLE "ROLES" MODIFY ("IDROL" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CIUDAD
--------------------------------------------------------

  ALTER TABLE "CIUDAD" ADD CONSTRAINT "CIUDAD_PK" PRIMARY KEY ("IDCIUDAD")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS"  ENABLE;
  ALTER TABLE "CIUDAD" MODIFY ("IDCIUDAD" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table DIRECCION
--------------------------------------------------------

  ALTER TABLE "DIRECCION" ADD CONSTRAINT "DIRECCION_PK" PRIMARY KEY ("IDDIRECCION")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS"  ENABLE;
  ALTER TABLE "DIRECCION" MODIFY ("NUMERODIRECCION" NOT NULL ENABLE);
  ALTER TABLE "DIRECCION" MODIFY ("IDCIUDAD" NOT NULL ENABLE);
  ALTER TABLE "DIRECCION" MODIFY ("IDDIRECCION" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ORDEN
--------------------------------------------------------

  ALTER TABLE "ORDEN" MODIFY ("NUMPREORDEN" NOT NULL ENABLE);
  ALTER TABLE "ORDEN" MODIFY ("IDCLIENTE" NOT NULL ENABLE);
  ALTER TABLE "ORDEN" MODIFY ("IDESTADOORDEN" NOT NULL ENABLE);
  ALTER TABLE "ORDEN" ADD CONSTRAINT "ORDEN_PK" PRIMARY KEY ("IDORDEN")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "TBS_OMS"  ENABLE;
  ALTER TABLE "ORDEN" MODIFY ("IDORDEN" NOT NULL ENABLE);
--------------------------------------------------------
--  Ref Constraints for Table CIUDAD
--------------------------------------------------------

  ALTER TABLE "CIUDAD" ADD CONSTRAINT "CIUDAD_FK" FOREIGN KEY ("IDDEPARTAMENTO")
	  REFERENCES "DEPARTAMENTO" ("IDDEPARTAMENTO") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table DEPARTAMENTO
--------------------------------------------------------

  ALTER TABLE "DEPARTAMENTO" ADD CONSTRAINT "ESTADO_FK" FOREIGN KEY ("IDPAIS")
	  REFERENCES "PAIS" ("IDPAIS") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table DIRECCION
--------------------------------------------------------

  ALTER TABLE "DIRECCION" ADD CONSTRAINT "DIRECCION_FK" FOREIGN KEY ("IDCIUDAD")
	  REFERENCES "CIUDAD" ("IDCIUDAD") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table ITEM_ORDEN
--------------------------------------------------------

  ALTER TABLE "ITEM_ORDEN" ADD CONSTRAINT "ITEM_ORDEN_FK1" FOREIGN KEY ("IDORDEN")
	  REFERENCES "ORDEN" ("IDORDEN") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table ORDEN
--------------------------------------------------------

  ALTER TABLE "ORDEN" ADD CONSTRAINT "ORDEN_FK1" FOREIGN KEY ("IDESTADOORDEN")
	  REFERENCES "ESTADO_ORDEN" ("IDESTADOORDEN") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CLIENTEXROL
--------------------------------------------------------

  ALTER TABLE "CLIENTEXROL" ADD CONSTRAINT "USER_ROLES_FK1" FOREIGN KEY ("IDUSUARIO")
	  REFERENCES "USUARIO" ("IDUSUARIO") ENABLE;
  ALTER TABLE "CLIENTEXROL" ADD CONSTRAINT "USER_ROLES_FK2" FOREIGN KEY ("IDROL")
	  REFERENCES "ROLES" ("IDROL") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table USUARIO
--------------------------------------------------------

  ALTER TABLE "USUARIO" ADD CONSTRAINT "CLIENTE_DIRECCION_FK" FOREIGN KEY ("IDDIRECCION")
	  REFERENCES "DIRECCION" ("IDDIRECCION") ENABLE;
