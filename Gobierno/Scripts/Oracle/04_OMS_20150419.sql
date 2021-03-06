CREATE TABLE PARAMETRICA
(
  MONTO_GERENCIA  NUMBER DEFAULT 0 NOT NULL
);

alter table USUARIO add (COMPRAENCOLOMBIA number(1,0) NOT NULL CONSTRAINT BITCONSTRAINT CHECK (COMPRAENCOLOMBIA IN (1,0)));

--------------------------------------------------------
--  DDL for Sequence FABRICANTES
--------------------------------------------------------
CREATE SEQUENCE  "SEQ_FABRICANTE"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 NOCACHE  NOORDER  NOCYCLE ;

CREATE TABLE FABRICANTE
(
  IDFABRICANTE  NUMBER(18,0), 
  CODIGO_FABRICANTE VARCHAR2(8 BYTE),
  NOMBRE_FABRICANTE VARCHAR2(128 BYTE),
  ESTADO number(1,0) CONSTRAINT ESTADOCONSTRAINT CHECK (ESTADO IN (1,0))
);

ALTER TABLE FABRICANTE
ADD CONSTRAINT FABRICANTE_PK PRIMARY KEY (IDFABRICANTE);
ALTER TABLE FABRICANTE
ADD CONSTRAINT FABRICANTE_UK_COD UNIQUE (CODIGO_FABRICANTE);
ALTER TABLE FABRICANTE
ADD CONSTRAINT FABRICANTE_UK_NOM UNIQUE (NOMBRE_FABRICANTE);


--------------------------------------------------------
--  DDL for Sequence PROVEEDOR_MENSAJERIA
--------------------------------------------------------
CREATE SEQUENCE  "SEQ_PROV_MENSAJERIA"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 NOCACHE  NOORDER  NOCYCLE ;

CREATE TABLE PROV_MENSAJERIA
(
  IDPROV_MENSAJERIA  NUMBER(18,0), 
  CODIGO_PROV_MENSAJERIA VARCHAR2(8 BYTE),
  NOMBRE_PROV_MENSAJERIA VARCHAR2(128 BYTE),
  ESTADO number(1,0) CONSTRAINT ESTADOCONSTRAINT2 CHECK (ESTADO IN (1,0))
);

ALTER TABLE PROV_MENSAJERIA
ADD CONSTRAINT PROV_MENSAJERIA_PK PRIMARY KEY (IDPROV_MENSAJERIA);
ALTER TABLE PROV_MENSAJERIA
ADD CONSTRAINT PROV_MENSAJERIA_UK_COD UNIQUE (CODIGO_PROV_MENSAJERIA);
ALTER TABLE PROV_MENSAJERIA
ADD CONSTRAINT PROV_MENSAJERIA_UK_NOM UNIQUE (NOMBRE_PROV_MENSAJERIA);

ALTER TABLE "CLIENTEXROL"
DROP CONSTRAINT "USER_ROLES_FK1";

ALTER TABLE "CLIENTEXROL"
DROP CONSTRAINT "USER_ROLES_FK2";

DROP TABLE CLIENTEXROL;

--------------------------------------------------------
--  DDL for Sequence CATEGORIACLIENTE
--------------------------------------------------------
CREATE SEQUENCE  "SEQ_CATEGORIACLIENTE"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 NOCACHE  NOORDER  NOCYCLE ;

CREATE TABLE CATEGORIA_CLIENTE
(
  IDCATEGORIA  NUMBER(18,0),
  NOMBRE_CATEGORIA VARCHAR2(128 BYTE)
);

ALTER TABLE CATEGORIA_CLIENTE
ADD CONSTRAINT CATEGORIA_CLIENTE_PK PRIMARY KEY (IDCATEGORIA);
ALTER TABLE CATEGORIA_CLIENTE
ADD CONSTRAINT CATEGORIA_CLIENTE_UK_NOM UNIQUE (NOMBRE_CATEGORIA);

INSERT INTO CATEGORIA_CLIENTE VALUES(SEQ_CATEGORIACLIENTE.NEXTVAL, 'PLATINO');
INSERT INTO CATEGORIA_CLIENTE VALUES(SEQ_CATEGORIACLIENTE.NEXTVAL, 'DORADO');
INSERT INTO CATEGORIA_CLIENTE VALUES(SEQ_CATEGORIACLIENTE.NEXTVAL, 'PLATEADO');

ALTER TABLE USUARIO
ADD IDCATEGORIA NUMBER(18,0) NOT NULL;

ALTER TABLE USUARIO
ADD CONSTRAINT FK_USUARIO_CATEGORIA
FOREIGN KEY(IDCATEGORIA)
REFERENCES CATEGORIA_CLIENTE(IDCATEGORIA);
