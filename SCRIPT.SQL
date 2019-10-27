USE GD2C2019
GO

--DROP CONSTRAINTS (FKs)
/*La primera vez que ejecuten el SCRIPT haganlo con los DROP CONSTRAINTS Comentado. 
  Desde la 2da en adelante saquen los comentarios a DROP CONSTRAINTS para ejecutar para que no tengan problemas con las FK y la consulta sea ejecutada siempre correctamente*/

/*
ALTER TABLE [MANA].PROVEEDOR DROP CONSTRAINT FK_RUBRO_ID;
ALTER TABLE [MANA].FACTURA DROP CONSTRAINT FK_PROV_ID;
ALTER TABLE [MANA].FACTURA DROP CONSTRAINT FK_OF_VEN_ID; 
ALTER TABLE [MANA].CONSUMO_OFERTA DROP CONSTRAINT FK_CUPON_ID; 
ALTER TABLE [MANA].CARGA_CREDITO DROP CONSTRAINT FK_CLI_ID;
ALTER TABLE [MANA].CARGA_CREDITO DROP CONSTRAINT FK_TP_ID; 
ALTER TABLE [MANA].COMPRA_OFERTA DROP CONSTRAINT FK_OF_ID; 
ALTER TABLE [MANA].COMPRA_OFERTA DROP CONSTRAINT FK_CLIENTE_ID; 
ALTER TABLE [MANA].OFERTA DROP CONSTRAINT FK_CUP_ID; 
ALTER TABLE [MANA].OFERTA DROP CONSTRAINT FK_PROVEEDOR_ID; 
ALTER TABLE [MANA].USUARIO_ROL DROP CONSTRAINT FK_USER_ID; 
ALTER TABLE [MANA].USUARIO_ROL DROP CONSTRAINT FK_ROL_ID; 
ALTER TABLE [MANA].FUNCIONALIDAD_ROL DROP CONSTRAINT FK_R_ID; 
ALTER TABLE [MANA].FUNCIONALIDAD_ROL DROP CONSTRAINT FK_FUNC_ID;
*/

--DROP TABLES
IF OBJECT_ID('MANA.PROVEEDOR') IS NOT NULL
DROP TABLE MANA.PROVEEDOR;
IF OBJECT_ID('MANA.RUBRO') IS NOT NULL
DROP TABLE MANA.RUBRO;
IF OBJECT_ID('MANA.FACTURA') IS NOT NULL
DROP TABLE MANA.FACTURA;
IF OBJECT_ID('MANA.OFERTA_VENDIDA') IS NOT NULL
DROP TABLE MANA.OFERTA_VENDIDA;
IF OBJECT_ID('MANA.USUARIO') IS NOT NULL
DROP TABLE MANA.USUARIO;
IF OBJECT_ID('MANA.CONSUMO_OFERTA') IS NOT NULL
DROP TABLE MANA.CONSUMO_OFERTA;
IF OBJECT_ID('MANA.CLIENTE') IS NOT NULL
DROP TABLE MANA.CLIENTE;
IF OBJECT_ID('MANA.CARGA_CREDITO') IS NOT NULL
DROP TABLE MANA.CARGA_CREDITO;
IF OBJECT_ID('MANA.TIPO_PAGO') IS NOT NULL
DROP TABLE MANA.TIPO_PAGO;
IF OBJECT_ID('MANA.COMPRA_OFERTA') IS NOT NULL
DROP TABLE MANA.COMPRA_OFERTA;
IF OBJECT_ID('MANA.OFERTA') IS NOT NULL
DROP TABLE MANA.OFERTA;
IF OBJECT_ID('MANA.CUPON') IS NOT NULL
DROP TABLE MANA.CUPON;
IF OBJECT_ID('MANA.USUARIO_ROL') IS NOT NULL
DROP TABLE MANA.USUARIO_ROL;
IF OBJECT_ID('MANA.ROL') IS NOT NULL
DROP TABLE MANA.ROL;
IF OBJECT_ID('MANA.FUNCIONALIDAD_ROL') IS NOT NULL
DROP TABLE MANA.FUNCIONALIDAD_ROL;
IF OBJECT_ID('MANA.FUNCIONALIDAD') IS NOT NULL
DROP TABLE MANA.FUNCIONALIDAD;

--DROP PROCEDURES, FUNCIONES, TRIGGERS
IF OBJECT_ID('MANA.MigrarCliente') IS NOT NULL
    DROP PROCEDURE MANA.MigrarCliente;
IF OBJECT_ID('MANA.MigrarRubro') IS NOT NULL
    DROP PROCEDURE MANA.MigrarRubro;
IF OBJECT_ID('MANA.MigrarProveedor') IS NOT NULL
    DROP PROCEDURE MANA.MigrarProveedor;
IF OBJECT_ID('MANA.MigrarCupon') IS NOT NULL
    DROP PROCEDURE MANA.MigrarCupon;
IF OBJECT_ID('MANA.MigrarConsumoOferta') IS NOT NULL
    DROP PROCEDURE MANA.MigrarConsumoOferta;
IF OBJECT_ID('MANA.MigrarCargaCredito') IS NOT NULL
    DROP PROCEDURE MANA.MigrarCargaCredito;
IF OBJECT_ID('MANA.MigrarTipoPago') IS NOT NULL
    DROP PROCEDURE MANA.MigrarTipoPago;
IF OBJECT_ID('MANA.Proveedor_VW') IS NOT NULL
    DROP VIEW MANA.Proveedor_VW;				
IF OBJECT_ID('MANA.MigrarOferta') IS NOT NULL
    DROP PROCEDURE MANA.MigrarOferta;	
IF OBJECT_ID('MANA.MigrarCompraOferta') IS NOT NULL
    DROP PROCEDURE MANA.MigrarCompraOferta;
IF OBJECT_ID('MANA.MigrarOfertaVendida') IS NOT NULL
    DROP PROCEDURE MANA.MigrarOfertaVendida;
IF OBJECT_ID('MANA.OfertaVendida_VW') IS NOT NULL
    DROP VIEW MANA.OfertaVendida_VW;
IF OBJECT_ID('MANA.MigrarFactura') IS NOT NULL
    DROP PROCEDURE MANA.MigrarFactura;
IF OBJECT_ID('MANA.CrearRol') IS NOT NULL
    DROP PROCEDURE MANA.CrearRol;
IF OBJECT_ID('MANA.ObtenerRolesHabilitados') IS NOT NULL
    DROP PROCEDURE MANA.ObtenerRolesHabilitados;
IF OBJECT_ID('MANA.FuncionalidadRol_VW') IS NOT NULL
    DROP VIEW MANA.FuncionalidadRol_VW;
IF OBJECT_ID('MANA.ObtenerFuncionalidadesDisponiblesDeRol') IS NOT NULL
    DROP PROCEDURE MANA.ObtenerFuncionalidadesDisponiblesDeRol;
IF OBJECT_ID('MANA.ObtenerFuncionalidadesDeRol') IS NOT NULL
    DROP PROCEDURE MANA.ObtenerFuncionalidadesDeRol;	
IF OBJECT_ID('MANA.EliminarFuncionalidadesDeRol') IS NOT NULL
    DROP PROCEDURE MANA.EliminarFuncionalidadesDeRol;
IF OBJECT_ID('MANA.EliminarUsuariosDeRol') IS NOT NULL
    DROP PROCEDURE MANA.EliminarUsuariosDeRol;	
IF OBJECT_ID('MANA.CambiarNombreDeRol') IS NOT NULL
    DROP PROCEDURE MANA.CambiarNombreDeRol;	
IF OBJECT_ID('MANA.BajaDeRol') IS NOT NULL
    DROP PROCEDURE MANA.BajaDeRol;	
IF OBJECT_ID('MANA.AsignarFuncionRol') IS NOT NULL
    DROP PROCEDURE MANA.AsignarFuncionRol;
IF OBJECT_ID('MANA.EliminarFuncionRol') IS NOT NULL
    DROP PROCEDURE MANA.EliminarFuncionRol;
IF OBJECT_ID('MANA.AsignarFuncionesAdministrador') IS NOT NULL
    DROP PROCEDURE MANA.AsignarFuncionesAdministrador;
IF OBJECT_ID('MANA.CrearFuncionalidades') IS NOT NULL
    DROP PROCEDURE MANA.CrearFuncionalidades;
IF OBJECT_ID('MANA.AsignarUsuarioRol') IS NOT NULL
    DROP PROCEDURE MANA.AsignarUsuarioRol;
IF OBJECT_ID('MANA.CrearUsuario') IS NOT NULL
    DROP PROCEDURE MANA.CrearUsuario;
IF OBJECT_ID('MANA.CrearCliente') IS NOT NULL
    DROP PROCEDURE MANA.CrearCliente;	
IF OBJECT_ID('MANA.ModificarCliente') IS NOT NULL
    DROP PROCEDURE MANA.ModificarCliente;
IF OBJECT_ID('MANA.BajaCliente') IS NOT NULL
    DROP PROCEDURE MANA.BajaCliente;
IF OBJECT_ID('MANA.ObtenerIdRubro') IS NOT NULL
    DROP FUNCTION MANA.ObtenerIdRubro;		
IF OBJECT_ID('MANA.CrearProveedor') IS NOT NULL
    DROP PROCEDURE MANA.CrearProveedor;	
IF OBJECT_ID('MANA.ModificarProveedor') IS NOT NULL
    DROP PROCEDURE MANA.ModificarProveedor;
IF OBJECT_ID('MANA.BajaProveedor') IS NOT NULL
    DROP PROCEDURE MANA.BajaProveedor;
	
						
--DROP SCHEMA
IF EXISTS(SELECT NAME FROM SYS.SCHEMAS WHERE NAME='MANA')
DROP SCHEMA MANA
GO

/** CREACION DE ESQUEMA **/
CREATE SCHEMA MANA --AUTHORIZATION gdCupon2019
GO

--------------------------------------------------------------------------------------

/** CREACION DE TABLAS **/

CREATE TABLE [MANA].PROVEEDOR (
	PROV_ID INT NOT NULL IDENTITY,
	PROV_RAZON_SOCIAL NVARCHAR(100),
	PROV_CUIT NVARCHAR(20),
	PROV_MAIL NVARCHAR(100),
	PROV_TELEFONO NUMERIC(18),
	PROV_DIRECCION NVARCHAR(100),	
	PROV_CIUDAD NVARCHAR(255),
	PROV_RUBRO_ID INT,
	PROV_ESTADO NVARCHAR(20),
	
	CONSTRAINT PROV_PK PRIMARY KEY (PROV_ID)
);

CREATE TABLE [MANA].RUBRO (
    RUBRO_ID INT NOT NULL IDENTITY,
	RUBRO_DESCRIPCION NVARCHAR(100),

	CONSTRAINT RUBRO_PK PRIMARY KEY (RUBRO_ID)
);

CREATE TABLE [MANA].FACTURA (
	FACT_ID INT NOT NULL IDENTITY,
	FACT_NUMERO NUMERIC(18), 
	FACT_FECHA DATETIME,	
	FACT_PROVEEDOR_ID INT,
	FACT_OF_VEN_ID INT, 
	FACT_IMPORTE NUMERIC(18),
	
	CONSTRAINT FACT_PK PRIMARY KEY (FACT_ID)
);

CREATE TABLE [MANA].OFERTA_VENDIDA (
    OF_VEN_ID INT NOT NULL IDENTITY,
	OF_VEN_COMPRA_OFERTA_ID INT,

	CONSTRAINT OFVEN_PK PRIMARY KEY (OF_VEN_ID)
);

CREATE TABLE [MANA].CONSUMO_OFERTA (
	CONSOF_ID INT NOT NULL IDENTITY,
	CONSOF_FECHA_ENTREGA DATETIME,
	CONSOF_CUPON_ID INT,
	CONSOF_CLIENTE_DEST_NOMBRE NVARCHAR(255),
	CONSOF_CLIENTE_DEST_APELLIDO NVARCHAR(255),
	CONSOF_CLIENTE_DEST_DNI NUMERIC(18),
	CONSOF_CLIENTE_DEST_MAIL NVARCHAR(255),
	CONSOF_CLIENTE_DEST_TELEFONO NUMERIC(18),
	CONSOF_CLIENTE_DEST_DIRECCION NVARCHAR(255),
	CONSOF_CLIENTE_DEST_FECHA_NACIMIENTO DATETIME,
	CONSOF_CLIENTE_DEST_CIUDAD NVARCHAR(255),

	CONSTRAINT CONSOF_PK PRIMARY KEY (CONSOF_ID)
);

CREATE TABLE [MANA].CLIENTE (
	CLI_ID INT NOT NULL IDENTITY,
	CLI_NOMBRE NVARCHAR(255),
	CLI_APELLIDO NVARCHAR(255),
	CLI_DNI NUMERIC(18),
	CLI_MAIL NVARCHAR(255),
	CLI_TELEFONO NUMERIC(18),
	CLI_DIRECCION NVARCHAR(255),
	CLI_CIUDAD NVARCHAR(255),
	CLI_FECHA_NACIMIENTO DATETIME,
	CLI_SALDO NUMERIC(18) DEFAULT 200,
	CLI_ESTADO NVARCHAR(20),
	
	CONSTRAINT CLI_PK PRIMARY KEY (CLI_ID)
);

CREATE TABLE [MANA].CARGA_CREDITO (
	CC_ID INT NOT NULL IDENTITY,
	CC_FECHA_CARGA DATETIME,
	CC_CLIENTE_ID INT,
	CC_TIPO_PAGO_ID INT,
	CC_MONTO NUMERIC(18),
	
	CONSTRAINT CC_PK PRIMARY KEY (CC_ID)
);

CREATE TABLE [MANA].TIPO_PAGO (
    TP_ID INT NOT NULL IDENTITY,
	TP_DESCRIPCION NVARCHAR(100),
	
	CONSTRAINT TP_PK PRIMARY KEY (TP_ID) 
);

CREATE TABLE [MANA].COMPRA_OFERTA (
	COMPOF_ID INT NOT NULL IDENTITY,
	COMPOF_FECHA_COMPRA DATETIME,
	COMPOF_OFERTA_ID INT,
	COMPOF_CLIENTE_ID INT,
	
    CONSTRAINT COMPOF_PK PRIMARY KEY (COMPOF_ID)
);

CREATE TABLE [MANA].OFERTA (
	OF_ID INT NOT NULL IDENTITY,
	OF_NUMERO NVARCHAR(50),
	OF_DESCRIPCION NVARCHAR(255),
	OF_FECHA_PUBLICACION DATETIME,
	OF_FECHA_VENCIMIENTO DATETIME,
	OF_CUPON_ID INT,
	OF_PROVEEDOR_ID INT,
	OF_CANTIDAD_DISPONIBLE NUMERIC(18),
	OF_ESTADO NVARCHAR(20),
	
	CONSTRAINT OF_PK PRIMARY KEY (OF_ID)
);

CREATE TABLE [MANA].CUPON (
	CUPON_ID INT NOT NULL IDENTITY,
	CUPON_PRECIO_OFERTA NUMERIC(18),
	CUPON_PRECIO_LISTA NUMERIC(18),
	CUPON_ESTADO NVARCHAR(20),
	
	CONSTRAINT CUPON_PK PRIMARY KEY (CUPON_ID)
);

CREATE TABLE [MANA].USUARIO (
	USER_ID INT NOT NULL IDENTITY,
	USER_USERNAME NVARCHAR(20),
	USER_PASSWORD NVARCHAR(20),
	USER_INTENTOS_FALLIDOS INT,
	USUARIO_ESTADO NVARCHAR(20),
	
	CONSTRAINT USER_PK PRIMARY KEY (USER_ID)
);

CREATE TABLE [MANA].USUARIO_ROL (
	UR_USR_ID INT,
	UR_ROL_ID INT,
	
	CONSTRAINT UR_PK PRIMARY KEY (UR_USR_ID,UR_ROL_ID)
);

CREATE TABLE [MANA].ROL (
	ROL_ID INT NOT NULL IDENTITY,
	ROL_NOMBRE NVARCHAR(20),
	ROL_ESTADO NVARCHAR(20),
	
	CONSTRAINT ROL_PK PRIMARY KEY (ROL_ID)
);

CREATE TABLE [MANA].FUNCIONALIDAD_ROL (
	FR_ROL_ID INT,
	FR_FUNCIONALIDAD_ID INT,
	
	CONSTRAINT FR_PK PRIMARY KEY (FR_ROL_ID,FR_FUNCIONALIDAD_ID)
);

CREATE TABLE [MANA].FUNCIONALIDAD (
	FUNC_ID INT NOT NULL IDENTITY,
	FUN_NOMBRE NVARCHAR(20),
	
	CONSTRAINT FUNC_PK PRIMARY KEY (FUNC_ID)
);

--------------------------------------------------------------------------------------

ALTER TABLE [MANA].PROVEEDOR ADD CONSTRAINT FK_RUBRO_ID FOREIGN KEY (PROV_RUBRO_ID) REFERENCES [MANA].RUBRO (RUBRO_ID);
ALTER TABLE [MANA].FACTURA ADD CONSTRAINT FK_PROV_ID FOREIGN KEY (FACT_PROVEEDOR_ID) REFERENCES [MANA].PROVEEDOR (PROV_ID);
ALTER TABLE [MANA].FACTURA ADD CONSTRAINT FK_OF_VEN_ID FOREIGN KEY (FACT_OF_VEN_ID) REFERENCES [MANA].OFERTA_VENDIDA (OF_VEN_ID);
ALTER TABLE [MANA].CONSUMO_OFERTA ADD CONSTRAINT FK_CUPON_ID FOREIGN KEY (CONSOF_CUPON_ID) REFERENCES [MANA].CUPON (CUPON_ID);
ALTER TABLE [MANA].CARGA_CREDITO ADD CONSTRAINT FK_CLI_ID FOREIGN KEY (CC_CLIENTE_ID) REFERENCES [MANA].CLIENTE (CLI_ID);
ALTER TABLE [MANA].CARGA_CREDITO ADD CONSTRAINT FK_TP_ID FOREIGN KEY (CC_TIPO_PAGO_ID) REFERENCES [MANA].TIPO_PAGO (TP_ID);
ALTER TABLE [MANA].COMPRA_OFERTA ADD CONSTRAINT FK_OF_ID FOREIGN KEY (COMPOF_OFERTA_ID) REFERENCES [MANA].OFERTA (OF_ID);
ALTER TABLE [MANA].COMPRA_OFERTA ADD CONSTRAINT FK_CLIENTE_ID FOREIGN KEY (COMPOF_CLIENTE_ID) REFERENCES [MANA].CLIENTE (CLI_ID);
ALTER TABLE [MANA].OFERTA ADD CONSTRAINT FK_CUP_ID FOREIGN KEY (OF_CUPON_ID) REFERENCES [MANA].CUPON (CUPON_ID);
ALTER TABLE [MANA].OFERTA ADD CONSTRAINT FK_PROVEEDOR_ID FOREIGN KEY (OF_PROVEEDOR_ID) REFERENCES [MANA].PROVEEDOR (PROV_ID);
ALTER TABLE [MANA].USUARIO_ROL ADD CONSTRAINT FK_USER_ID FOREIGN KEY (UR_USR_ID) REFERENCES [MANA].USUARIO (USER_ID);
ALTER TABLE [MANA].USUARIO_ROL ADD CONSTRAINT FK_ROL_ID FOREIGN KEY (UR_ROL_ID) REFERENCES [MANA].ROL (ROL_ID);
ALTER TABLE [MANA].FUNCIONALIDAD_ROL ADD CONSTRAINT FK_R_ID FOREIGN KEY (FR_ROL_ID) REFERENCES [MANA].ROL (ROL_ID);
ALTER TABLE [MANA].FUNCIONALIDAD_ROL ADD CONSTRAINT FK_FUNC_ID FOREIGN KEY (FR_FUNCIONALIDAD_ID) REFERENCES [MANA].FUNCIONALIDAD (FUNC_ID);
GO 


/** MIGRACION **/

/*Cliente*/

CREATE PROCEDURE MANA.MigrarCliente
AS
insert into MANA.CLIENTE
select distinct
    M.Cli_Nombre,
    M.Cli_Apellido,
    M.Cli_Dni,
    M.Cli_Mail,
    M.Cli_Telefono,
	M.Cli_Direccion,
	M.Cli_Ciudad,
	M.Cli_Fecha_Nac,
	200 as SALDO,   /*Aca va MANA.ObtenerSaldoCliente*/
	'Habilitado'
from gd_esquema.Maestra M
group by M.Cli_Nombre, M.Cli_Apellido, M.Cli_Dni, M.Cli_Mail, M.Cli_Telefono, M.Cli_Direccion, M.Cli_Ciudad, M.Cli_Fecha_Nac
GO

MANA.MigrarCliente
GO

/*Rubro*/

CREATE PROCEDURE MANA.MigrarRubro
AS
insert into MANA.RUBRO
select M.Provee_Rubro
from gd_esquema.Maestra M 
group by M.Provee_Rubro
GO

MANA.MigrarRubro
GO	

/*Proveedor*/

CREATE PROCEDURE MANA.MigrarProveedor
AS
insert into MANA.PROVEEDOR
select M.Provee_RS, M.Provee_CUIT, 
       NULL,         /*Aca ver porque en tabla maestra no hay emails para Proveedor*/
	   M.Provee_Telefono, M.Provee_Dom, M.Provee_Ciudad, R.RUBRO_ID,'Habilitado'
from gd_esquema.Maestra M, MANA.RUBRO R
where
     M.Provee_Rubro = R.RUBRO_DESCRIPCION
group by M.Provee_RS, M.Provee_CUIT, M.Provee_Telefono, M.Provee_Dom, M.Provee_Ciudad, R.RUBRO_ID
GO

MANA.MigrarProveedor
GO

/*Cupon*/

CREATE PROCEDURE MANA.MigrarCupon
AS
insert into MANA.CUPON
select M.Oferta_Precio, M.Oferta_Precio_Ficticio,'Habilitado'
from gd_esquema.Maestra M
group by M.Oferta_Precio, M.Oferta_Precio_Ficticio
GO

MANA.MigrarCupon
GO

/*Tipo Pago*/

CREATE PROCEDURE MANA.MigrarTipoPago
AS
insert into MANA.TIPO_PAGO
select M.Tipo_Pago_Desc
from gd_esquema.Maestra M
group by M.Tipo_Pago_Desc
GO

MANA.MigrarTipoPago
GO

/*Consumo Oferta*/

CREATE PROCEDURE MANA.MigrarConsumoOferta
AS
insert into MANA.CONSUMO_OFERTA
select M.Oferta_Entregado_Fecha, C.CUPON_ID, M.Cli_Dest_Nombre, M.Cli_Dest_Apellido, M.Cli_Dest_Dni, M.Cli_Dest_Mail, M.Cli_Dest_Telefono, M.Cli_Dest_Direccion, M.Cli_Dest_Fecha_Nac, M.Cli_Dest_Ciudad	
from gd_esquema.Maestra M, MANA.CUPON C
where
    M.Oferta_Precio = C.CUPON_PRECIO_OFERTA AND
	M.Oferta_Precio_Ficticio = C.CUPON_PRECIO_LISTA
group by M.Oferta_Entregado_Fecha, C.CUPON_ID, M.Cli_Dest_Nombre, M.Cli_Dest_Apellido, M.Cli_Dest_Dni, M.Cli_Dest_Mail, M.Cli_Dest_Telefono, M.Cli_Dest_Direccion, M.Cli_Dest_Fecha_Nac, M.Cli_Dest_Ciudad
GO

MANA.MigrarConsumoOferta
GO

/*Carga Credito */

CREATE PROCEDURE MANA.MigrarCargaCredito
AS
insert into MANA.CARGA_CREDITO
select M.Carga_Fecha, C.CLI_ID,	TP.TP_ID, M.Carga_Credito	
from gd_esquema.Maestra M, MANA.CLIENTE C, MANA.TIPO_PAGO TP
where
    M.Cli_Nombre = C.CLI_NOMBRE AND
    M.Cli_Apellido = C.CLI_APELLIDO AND
    M.Cli_Dni = C.CLI_DNI AND
    M.Cli_Mail = C.CLI_MAIL AND
    M.Cli_Telefono = C.CLI_TELEFONO AND
	M.Cli_Direccion = C.CLI_DIRECCION AND
	M.Cli_Ciudad = C.CLI_CIUDAD AND
	M.Cli_Fecha_Nac = C.CLI_FECHA_NACIMIENTO AND
	M.Tipo_Pago_Desc = TP.TP_DESCRIPCION
group by M.Carga_Fecha, C.CLI_ID, TP.TP_ID, M.Carga_Credito
GO

MANA.MigrarCargaCredito
GO

/* Proveedor Vista*/
CREATE VIEW MANA.Proveedor_VW
AS
select P.PROV_ID, P.PROV_RAZON_SOCIAL, P.PROV_CUIT, P.PROV_MAIL, P.PROV_TELEFONO, P.PROV_DIRECCION, P.PROV_CIUDAD, R.RUBRO_ID, P.PROV_ESTADO
from MANA.PROVEEDOR P, MANA.RUBRO R
where R.RUBRO_ID = P.PROV_RUBRO_ID  
GO

/*Oferta*/

CREATE PROCEDURE MANA.MigrarOferta
AS
insert into MANA.OFERTA
select M.Oferta_Codigo, M.Oferta_Descripcion, M.Oferta_Fecha, M.Oferta_Fecha_Venc, C.CUPON_ID, P.PROV_ID, M.Oferta_Cantidad,'Habilitado'
from gd_esquema.Maestra M, MANA.CUPON C, MANA.PROVEEDOR P, MANA.Proveedor_VW PVW
where
    M.Oferta_Precio = C.CUPON_PRECIO_OFERTA AND
	M.Oferta_Precio_Ficticio = C.CUPON_PRECIO_LISTA AND
	M.Provee_RS = P.PROV_RAZON_SOCIAL AND
	M.Provee_CUIT = P.PROV_CUIT AND
	M.Provee_Telefono = P.PROV_TELEFONO AND
	M.Provee_Dom = P.PROV_DIRECCION AND
	M.Provee_Ciudad = P.PROV_CIUDAD AND
	PVW.RUBRO_ID = P.PROV_RUBRO_ID 
group by M.Oferta_Codigo, M.Oferta_Descripcion, M.Oferta_Fecha, M.Oferta_Fecha_Venc, C.CUPON_ID, P.PROV_ID, M.Oferta_Cantidad	
GO

MANA.MigrarOferta
GO


/*Compra Oferta*/

CREATE PROCEDURE MANA.MigrarCompraOferta
AS
insert into MANA.COMPRA_OFERTA
select M.Oferta_Fecha_Compra, O.OF_ID, C.CLI_ID
from gd_esquema.Maestra M, MANA.OFERTA O, MANA.CLIENTE C
where
    M.Oferta_Codigo = O.OF_NUMERO AND
	M.Oferta_Descripcion = O.OF_DESCRIPCION AND
	M.Oferta_Fecha = O.OF_FECHA_PUBLICACION AND
	M.Oferta_Fecha_Venc = O.OF_FECHA_VENCIMIENTO AND
	M.Oferta_Cantidad = O.OF_CANTIDAD_DISPONIBLE AND
	M.Cli_Nombre = C.CLI_NOMBRE AND
	M.Cli_Apellido = C.CLI_APELLIDO AND
	M.Cli_Dni = C.CLI_DNI AND
	M.Cli_Mail = C.CLI_MAIL AND
	M.Cli_Telefono = C.CLI_TELEFONO AND
	M.Cli_Direccion = C.CLI_DIRECCION AND
	M.Cli_Ciudad = C.CLI_CIUDAD AND
	M.Cli_Fecha_Nac = C.CLI_FECHA_NACIMIENTO
group by M.Oferta_Fecha_Compra, O.OF_ID, C.CLI_ID
GO

MANA.MigrarCompraOferta
GO

/*Oferta Vendida a facturar*/

CREATE PROCEDURE MANA.MigrarOfertaVendida
AS
insert into MANA.OFERTA_VENDIDA
select CO.COMPOF_OFERTA_ID
from MANA.COMPRA_OFERTA CO, gd_esquema.Maestra M
where
	M.Oferta_Fecha_Compra = CO.COMPOF_FECHA_COMPRA 
group by CO.COMPOF_OFERTA_ID
GO

Mana.MigrarOfertaVendida
GO

/* Oferta Vendida Vista*/

CREATE VIEW MANA.OfertaVendida_VW
AS
select OV.OF_VEN_ID, CO.COMPOF_ID
from MANA.OFERTA_VENDIDA OV, MANA.COMPRA_OFERTA CO
where CO.COMPOF_ID = OV.OF_VEN_COMPRA_OFERTA_ID
GO

/*Factura

CREATE PROCEDURE MANA.MigrarFactura
AS
insert into MANA.FACTURA
select distinct M.Factura_Nro, M.Factura_Fecha, P.PROV_ID, OV.OF_VEN_ID,
       5500 
from gd_esquema.Maestra M, MANA.PROVEEDOR P, MANA.Proveedor_VW PVW , MANA.OfertaVendida_VW OVW, MANA.OFERTA_VENDIDA OV	
where
	M.Provee_RS = P.PROV_RAZON_SOCIAL AND
	M.Provee_CUIT = P.PROV_CUIT AND
	M.Provee_Telefono = P.PROV_TELEFONO AND
	M.Provee_Dom = P.PROV_DIRECCION AND
	M.Provee_Ciudad = P.PROV_CIUDAD AND
	PVW.RUBRO_ID = P.PROV_RUBRO_ID
group by M.Factura_Nro, M.Factura_Fecha, P.PROV_ID, OV.OF_VEN_ID 
GO

Mana.MigrarFactura
GO
*/



/** STORES PROCEDURES **/


/*Rol*/

CREATE PROCEDURE MANA.CrearRol @Nombre nvarchar(20)
AS
    DECLARE @iCount int
    set @iCount = (select count(*) from MANA.ROL R where R.ROL_ESTADO = 'Deshabilitado' and R.ROL_NOMBRE =  @Nombre)
	IF @iCount > 0
	BEGIN
		update MANA.ROL
		SET MANA.ROL.ROL_ESTADO = 'Habilitado'
		where MANA.ROL.ROL_NOMBRE = @Nombre
	END
	ELSE
	BEGIN
		insert into MANA.ROL(ROL_NOMBRE, ROL_ESTADO) values (@Nombre,'Habilitado');
	END
GO

MANA.CrearRol 'AdministradorGral'
GO
MANA.CrearRol 'Cliente'              
GO
MANA.CrearRol 'Proveedor'            
GO
MANA.CrearRol 'Administrativo'       
GO          

CREATE PROCEDURE MANA.ObtenerRolesHabilitados   /* Ver*/
AS
   	select R.ROL_ID, R.ROL_NOMBRE, R.ROL_ESTADO
	from MANA.ROL R
	where R.ROL_ESTADO = 'Habilitado'
GO

CREATE VIEW MANA.FuncionalidadRol_VW
AS 
select R.ROL_ID, R.ROL_NOMBRE as RolNombre,
    F.FUNC_ID,
    F.FUN_NOMBRE as FuncionNombre
from
    MANA.ROL R,
    MANA.FUNCIONALIDAD_ROL FR,
    MANA.FUNCIONALIDAD F
where
    R.ROL_ID = FR.FR_ROL_ID
    AND FR.FR_FUNCIONALIDAD_ID = F.FUNC_ID    
GO

CREATE PROCEDURE MANA.ObtenerFuncionalidadesDisponiblesDeRol @RolID int
AS
    select F.FUNC_ID, F.FUN_NOMBRE
    from MANA.FUNCIONALIDAD F
    where 
        F.FUNC_ID not in ( select FR.FUNC_ID 
                           from MANA.FuncionalidadRol_VW FR 
                           where FR.ROL_ID = @RolID )
GO

CREATE PROCEDURE MANA.ObtenerFuncionalidadesDeRol @RolID int
AS
    select FR.FUNC_ID, FR.FuncionNombre
    from MANA.FuncionalidadRol_VW FR
    where FR.ROL_ID = @RolID
GO

CREATE PROCEDURE MANA.EliminarFuncionalidadesDeRol @RolID int
AS
    delete from MANA.FUNCIONALIDAD_ROL
    where MANA.FUNCIONALIDAD_ROL.FR_ROL_ID = @RolID
GO

CREATE PROCEDURE MANA.EliminarUsuariosDeRol @RolID int
AS
    delete from MANA.USUARIO_ROL
    where MANA.USUARIO_ROL.UR_ROL_ID = @RolID
GO

CREATE PROCEDURE MANA.CambiarNombreDeRol @RolID int, @Nombre nvarchar(20)
AS
    update MANA.ROL
    SET MANA.ROL.ROL_NOMBRE = @Nombre
    where MANA.ROL.ROL_ID = @RolID
GO

CREATE PROCEDURE MANA.BajaDeRol @RolID int
AS
    exec MANA.EliminarFuncionalidadesDeRol @RolID
    exec MANA.EliminarUsuariosDeRol @RolID    
    update MANA.ROL
    SET MANA.ROL.ROL_ESTADO = 'Deshabilitado'
    where MANA.ROL.ROL_ID = @RolID
GO

/*Funcionalidad*/

CREATE PROCEDURE MANA.CrearFuncionalidades
AS
  insert into MANA.FUNCIONALIDAD values('Abm Rol');
  insert into MANA.FUNCIONALIDAD values('Abm Cliente');
  insert into MANA.FUNCIONALIDAD values('Abm Proveedor');
  insert into MANA.FUNCIONALIDAD values('Carga Credito');
  insert into MANA.FUNCIONALIDAD values('Crear Oferta');
  insert into MANA.FUNCIONALIDAD values('Comprar Oferta');
  insert into MANA.FUNCIONALIDAD values('Baja Oferta');
  insert into MANA.FUNCIONALIDAD values('Facturacion');
GO

MANA.CrearFuncionalidades
GO


/*Funcionalidad Rol*/

CREATE PROCEDURE MANA.AsignarFuncionRol @RolID int, @FuncionID int
AS
insert into MANA.FUNCIONALIDAD_ROL values (@RolID,@FuncionID);
GO

/*Funcionalidades de Cliente*/
Mana.AsignarFuncionRol 2, 4
GO
Mana.AsignarFuncionRol 2, 6
GO
/*Funcionalidades de Proveedor*/
Mana.AsignarFuncionRol 3, 5
GO
Mana.AsignarFuncionRol 3, 7
GO
/*Funcionalidades de Administrativo*/
Mana.AsignarFuncionRol 4, 2
GO
Mana.AsignarFuncionRol 4, 3
GO
Mana.AsignarFuncionRol 4, 8
GO

CREATE PROCEDURE MANA.EliminarFuncionRol @RolID int, @FuncionID int
AS
    delete from MANA.FUNCIONALIDAD_ROL where MANA.FUNCIONALIDAD_ROL.FR_ROL_ID = @RolID and MANA.FUNCIONALIDAD_ROL.FR_FUNCIONALIDAD_ID = @FuncionID;
GO

CREATE PROCEDURE MANA.AsignarFuncionesAdministrador
AS

DECLARE @FuncionID int 
DECLARE @RolID int = 1 
-- declare a cursor
DECLARE funcion CURSOR FOR 
SELECT FUNC_ID from MANA.FUNCIONALIDAD

OPEN funcion
FETCH NEXT FROM funcion into @FuncionID
 
-- check for a new row
WHILE @@FETCH_STATUS=0
BEGIN

exec MANA.AsignarFuncionRol @RolID,@FuncionID

FETCH NEXT FROM funcion into @FuncionID
END
close funcion
Deallocate funcion
GO

MANA.AsignarFuncionesAdministrador
GO


/*Usuario*/

CREATE PROCEDURE MANA.CrearUsuario @Username nvarchar(20), @Password nvarchar(20)
AS
insert into MANA.USUARIO values (@Username, @Password, 0, 'Habilitado');
GO

Mana.CrearUsuario 'admin', 'w23e'
GO


/*UsuarioRol*/

CREATE PROCEDURE MANA.AsignarUsuarioRol @UserID int, @RolNombre nvarchar(20)
AS
DECLARE @RolID int = (select ROL_ID from MANA.ROL R WHERE R.ROL_NOMBRE = @RolNombre)
insert into MANA.USUARIO_ROL values (@UserID, @RolID );
GO

Mana.AsignarUsuarioRol 1, 'AdministradorGral'
GO


/*ABM Cliente*/

CREATE PROCEDURE MANA.CrearCliente @Nombre nvarchar(255), @Apellido nvarchar(255), @Dni numeric(18), @Mail nvarchar(255), 
                                   @Telefono numeric(18), @Direccion nvarchar(255), @Ciudad nvarchar(255), @FechaNac datetime
AS
insert into MANA.CLIENTE values(@Nombre, @Apellido, @Dni, @Mail, @Telefono, @Direccion, @Ciudad, @FechaNac, 200, 'Habilitado');
GO

CREATE PROCEDURE MANA.ModificarCliente @ID int, @Nombre nvarchar(255), @Apellido nvarchar(255), @Dni numeric(18), @Mail nvarchar(255), 
                                   @Telefono numeric(18), @Direccion nvarchar(255), @Ciudad nvarchar(255), @FechaNac datetime
AS
   UPDATE MANA.CLIENTE
   SET 
      CLI_NOMBRE = @Nombre, CLI_APELLIDO = @Apellido, CLI_DNI = @Dni, CLI_MAIL = @Mail, CLI_TELEFONO = @Telefono,
	  CLI_DIRECCION = @Direccion, CLI_CIUDAD = @Ciudad, CLI_FECHA_NACIMIENTO = @FechaNac
	  WHERE CLI_ID = @ID
GO

CREATE PROCEDURE MANA.BajaCliente @Nombre nvarchar(255), @Apellido nvarchar(255), @Dni numeric(18), @Mail nvarchar(255)
AS
   UPDATE MANA.CLIENTE
   SET
      CLI_ESTADO = 'Deshabilitado'
	  WHERE CLI_NOMBRE = @Nombre AND CLI_APELLIDO = @Apellido AND CLI_DNI = @Dni AND CLI_MAIL = @Mail
GO
/*Test ABM Cliente*/
Mana.CrearCliente 'Gregory', 'House', 40158932, 'house@hotmail.com', 15856682, 'HOSPITAL521', 'Miami', '1985/06/10'
GO
Mana.ModificarCliente 5, 'Patrick', 'Jane', 45124512, 'jane@hotmail.com', 15534689, 'FBI5212', 'California', '1990/07/11'
GO
Mana.BajaCliente 'Adaia', 'Pino', 97990522, 'adaia@gmail.com'
GO    


/*ABM Proveedor*/

CREATE FUNCTION MANA.ObtenerIdRubro (@Rubro nvarchar(100))
RETURNS INT
AS
BEGIN
  return( select R.RUBRO_ID
	      from MANA.RUBRO R
	      where R.RUBRO_DESCRIPCION = @Rubro )
END	   
GO   

CREATE PROCEDURE MANA.CrearProveedor @RazonSocial nvarchar(100), @CUIT nvarchar(20), @Mail nvarchar(100), 
                                   @Telefono numeric(18), @Direccion nvarchar(100), @Ciudad nvarchar(255), @Rubro nvarchar(100)
AS
insert into MANA.PROVEEDOR values(@RazonSocial, @CUIT, @Mail, @Telefono, @Direccion, @Ciudad, MANA.ObtenerIdRubro(@Rubro),'Habilitado');
GO

CREATE PROCEDURE MANA.ModificarProveedor @ID int, @RazonSocial nvarchar(100), @CUIT nvarchar(20), @Mail nvarchar(100), 
                                   @Telefono numeric(18), @Direccion nvarchar(100), @Ciudad nvarchar(255), @Rubro nvarchar(100)
AS
   UPDATE MANA.PROVEEDOR
   SET 
     PROV_RAZON_SOCIAL = @RazonSocial, PROV_CUIT = @CUIT, PROV_MAIL = @Mail, PROV_TELEFONO = @Telefono, 
	 PROV_DIRECCION = @Direccion, PROV_CIUDAD = @Ciudad, PROV_RUBRO_ID = Mana.ObtenerIdRubro(@Rubro)
	  WHERE PROV_ID = @ID
GO

CREATE PROCEDURE MANA.BajaProveedor @RazonSocial nvarchar(100), @CUIT nvarchar(20)
AS
   UPDATE MANA.PROVEEDOR
   SET
      PROV_ESTADO = 'Deshabilitado'
	  WHERE PROV_RAZON_SOCIAL = @RazonSocial AND PROV_CUIT = @CUIT
GO
/*Test ABM Proveedor*/
Mana.CrearProveedor 'CortinasCongreso', 20568945125, 'cortinas@gmail.com', 43825679, 'Pozos618', 'CABA', 'Electronica' 
GO
Mana.ModificarProveedor 10, 'FREDDO', 29589125157, 'freddo@gmail.com', 48625167, 'Rivadavia6115','CABA', 'Comestibles' 
GO
Mana.BajaProveedor 'Proveedor N°13S.R.L.', '13-52415793-5'
GO