USE GD2C2019
GO

--DROP CONSTRAINTS (FKs)
/*La primera vez que ejecuten el SCRIPT haganlo con los DROP CONSTRAINTS Comentado. 
  Desde la 2da en adelante saquen los comentarios a DROP CONSTRAINTS para ejecutar para que no tengan problemas con las FK y la consulta sea ejecutada siempre correctamente*/

/*
ALTER TABLE [MANA].PROVEEDOR DROP CONSTRAINT FK_RUBRO_ID;
ALTER TABLE [MANA].ITEM_FACTURA DROP CONSTRAINT FK_OF_VEN_ID;
ALTER TABLE [MANA].FACTURA DROP CONSTRAINT FK_PR_ID;
ALTER TABLE [MANA].CONSUMO_OFERTA DROP CONSTRAINT FK_CUPON_ID;
ALTER TABLE [MANA].CONSUMO_OFERTA DROP CONSTRAINT FK_PROVEED_ID;  
ALTER TABLE [MANA].CARGA_CREDITO DROP CONSTRAINT FK_CLI_ID;
ALTER TABLE [MANA].CARGA_CREDITO DROP CONSTRAINT FK_TP_ID; 
ALTER TABLE [MANA].CUPON DROP CONSTRAINT FK_CLIENTE_ID;
ALTER TABLE [MANA].OFERTA DROP CONSTRAINT FK_PROVEEDOR_ID;
ALTER TABLE [MANA].OFERTA_VENDIDA DROP CONSTRAINT FK_CUP_ID;
ALTER TABLE [MANA].OFERTA_VENDIDA DROP CONSTRAINT FK_PROVEE_ID;  
ALTER TABLE [MANA].USUARIO_ROL DROP CONSTRAINT FK_USER_ID; 
ALTER TABLE [MANA].USUARIO_ROL DROP CONSTRAINT FK_ROL_ID; 
ALTER TABLE [MANA].FUNCIONALIDAD_ROL DROP CONSTRAINT FK_R_ID; 
ALTER TABLE [MANA].FUNCIONALIDAD_ROL DROP CONSTRAINT FK_FUNC_ID;
ALTER TABLE [MANA].CLIENTE DROP CONSTRAINT FK_CLI_USER_ID;
ALTER TABLE [MANA].PROVEEDOR DROP CONSTRAINT FK_PROV_USER_ID;
*/

--DROP TABLES
IF OBJECT_ID('MANA.PROVEEDOR') IS NOT NULL
DROP TABLE MANA.PROVEEDOR;
IF OBJECT_ID('MANA.RUBRO') IS NOT NULL
DROP TABLE MANA.RUBRO;
IF OBJECT_ID('MANA.ITEM_FACTURA') IS NOT NULL
DROP TABLE MANA.ITEM_FACTURA;
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
IF OBJECT_ID('MANA.PublicarOferta') IS NOT NULL
    DROP TRIGGER MANA.PublicarOferta;
IF OBJECT_ID('MANA.ValidarVencimientoOferta') IS NOT NULL
    DROP TRIGGER MANA.ValidarVencimientoOferta;
IF OBJECT_ID('MANA.ValidarStockOferta') IS NOT NULL
    DROP TRIGGER MANA.ValidarStockOferta;
IF OBJECT_ID('MANA.ValidarVencimientoCupon') IS NOT NULL
    DROP TRIGGER MANA.ValidarVencimientoCupon;
	       /*Migracion*/
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
IF OBJECT_ID('MANA.CanjearCuponesMigrados') IS NOT NULL
    DROP PROCEDURE MANA.CanjearCuponesMigrados;
IF OBJECT_ID('MANA.MigrarCargaCredito') IS NOT NULL
    DROP PROCEDURE MANA.MigrarCargaCredito;
IF OBJECT_ID('MANA.MigrarTipoPago') IS NOT NULL
    DROP PROCEDURE MANA.MigrarTipoPago;			
IF OBJECT_ID('MANA.MigrarOferta') IS NOT NULL
    DROP PROCEDURE MANA.MigrarOferta;			
IF OBJECT_ID('MANA.MigrarOfertaVendida') IS NOT NULL
    DROP PROCEDURE MANA.MigrarOfertaVendida;
IF OBJECT_ID('MANA.MigrarItemFactura') IS NOT NULL
    DROP PROCEDURE MANA.MigrarItemFactura;
IF OBJECT_ID('MANA.MigrarFactura') IS NOT NULL
    DROP PROCEDURE MANA.MigrarFactura;
	      /*Login, Usuario, Rol */
IF OBJECT_ID('MANA.ValidarPassword') IS NOT NULL
    DROP PROCEDURE MANA.ValidarPassword;	
IF OBJECT_ID('MANA.Encriptar') IS NOT NULL
    DROP FUNCTION MANA.Encriptar;			
IF OBJECT_ID('MANA.BorrarTT') IS NOT NULL
    DROP PROCEDURE MANA.BorrarTT	
IF OBJECT_ID('MANA.CrearRol') IS NOT NULL
    DROP PROCEDURE MANA.CrearRol;
IF OBJECT_ID('MANA.FuncionalidadRol_VW') IS NOT NULL
    DROP VIEW MANA.FuncionalidadRol_VW;	
IF OBJECT_ID('MANA.EliminarFuncionalidadesDeRol') IS NOT NULL
    DROP PROCEDURE MANA.EliminarFuncionalidadesDeRol;
IF OBJECT_ID('MANA.EliminarUsuariosDeRol') IS NOT NULL
    DROP PROCEDURE MANA.EliminarUsuariosDeRol;			
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
IF OBJECT_ID('MANA.AltaUsuario') IS NOT NULL
    DROP PROCEDURE MANA.AltaUsuario;
IF OBJECT_ID('MANA.BajaUsuario') IS NOT NULL
    DROP PROCEDURE MANA.BajaUsuario;
IF OBJECT_ID('MANA.CambiarPassword') IS NOT NULL
    DROP PROCEDURE MANA.CambiarPassword;
IF OBJECT_ID('MANA.AsignarUserIdCliente') IS NOT NULL
    DROP PROCEDURE MANA.AsignarUserIdCliente;
IF OBJECT_ID('MANA.AsignarUserIdProveedor') IS NOT NULL
    DROP PROCEDURE MANA.AsignarUserIdProveedor;
IF OBJECT_ID('MANA.CrearUsuariosParaClientesMigrados') IS NOT NULL
    DROP PROCEDURE MANA.CrearUsuariosParaClientesMigrados;
IF OBJECT_ID('MANA.CrearUsuariosParaProveedoresMigrados') IS NOT NULL
    DROP PROCEDURE MANA.CrearUsuariosParaProveedoresMigrados;
             /*Cliente*/
IF OBJECT_ID('MANA.CrearUsuarioCliente') IS NOT NULL
    DROP PROCEDURE MANA.CrearUsuarioCliente;
IF OBJECT_ID('MANA.ModificarCliente') IS NOT NULL
    DROP PROCEDURE MANA.ModificarCliente;
IF OBJECT_ID('MANA.CargarTipoPago') IS NOT NULL
    DROP PROCEDURE MANA.CargarTipoPago;
IF OBJECT_ID('MANA.ObtenerIdTipopago') IS NOT NULL
    DROP FUNCTION MANA.ObtenerIdTipoPago;
IF OBJECT_ID('MANA.CargarSaldo') IS NOT NULL
    DROP PROCEDURE MANA.CargarSaldo;
IF OBJECT_ID('MANA.DescontarSaldo') IS NOT NULL
    DROP PROCEDURE MANA.DescontarSaldo;
IF OBJECT_ID('MANA.ObtenerSaldo') IS NOT NULL
    DROP FUNCTION MANA.ObtenerSaldo;
IF OBJECT_ID('MANA.CargarCredito') IS NOT NULL
    DROP PROCEDURE MANA.CargarCredito;
            /*Proveedor*/
IF OBJECT_ID('MANA.ObtenerIdRubro') IS NOT NULL
    DROP FUNCTION MANA.ObtenerIdRubro;
IF OBJECT_ID('MANA.CrearUsuarioProveedor') IS NOT NULL
    DROP PROCEDURE MANA.CrearUsuarioProveedor;				
IF OBJECT_ID('MANA.ModificarProveedor') IS NOT NULL
    DROP PROCEDURE MANA.ModificarProveedor;
	        /*Oferta*/
IF OBJECT_ID('MANA.CrearConsumoOferta') IS NOT NULL
    DROP PROCEDURE MANA.CrearConsumoOferta;
IF OBJECT_ID('MANA.CrearCupon') IS NOT NULL
    DROP PROCEDURE MANA.CrearCupon;
IF OBJECT_ID('MANA.BajaCupon') IS NOT NULL
    DROP PROCEDURE MANA.BajaCupon;
IF OBJECT_ID('MANA.ObtenerNroOfertaCupon') IS NOT NULL
    DROP FUNCTION MANA.ObtenerNroOfertaCupon;
IF OBJECT_ID('MANA.ObtenerEstadoCupon') IS NOT NULL
    DROP FUNCTION MANA.ObtenerEstadoCupon;
IF OBJECT_ID('MANA.ObtenerProveedorOferta') IS NOT NULL
    DROP FUNCTION MANA.ObtenerProveedorOferta;
IF OBJECT_ID('MANA.ObtenerMaximoUnidadOferta') IS NOT NULL
    DROP FUNCTION MANA.ObtenerMaximoUnidadOferta;
IF OBJECT_ID('MANA.ActualizarStock') IS NOT NULL
    DROP PROCEDURE MANA.ActualizarStock;
IF OBJECT_ID('MANA.RegistrarOfertaVendida') IS NOT NULL
    DROP PROCEDURE MANA.RegistrarOfertaVendida;
IF OBJECT_ID('MANA.CanjearCupon') IS NOT NULL
    DROP PROCEDURE MANA.CanjearCupon;							
IF OBJECT_ID('MANA.CrearOferta') IS NOT NULL
    DROP PROCEDURE MANA.CrearOferta;
IF OBJECT_ID('MANA.ComprarOferta') IS NOT NULL
    DROP PROCEDURE MANA.ComprarOferta;
	       /*Factura*/
IF OBJECT_ID('MANA.CrearItemFactura') IS NOT NULL
    DROP PROCEDURE MANA.CrearItemFactura;
IF OBJECT_ID('MANA.CrearFactura') IS NOT NULL
    DROP PROCEDURE MANA.CrearFactura;	
IF OBJECT_ID('MANA.FacturarOfertasAProveedor') IS NOT NULL
    DROP PROCEDURE MANA.FacturarOfertasAProveedor;					

						
--DROP SCHEMA
IF EXISTS(SELECT NAME FROM SYS.SCHEMAS WHERE NAME='MANA')
DROP SCHEMA MANA
GO

/** CREACION DE ESQUEMA **/
CREATE SCHEMA MANA --AUTHORIZATION gdCupon2019
GO

--------------------------------------------------------------------------------------

/** CREACION DE TABLAS **/

CREATE TABLE [MANA].RUBRO (
    RUBRO_ID INT NOT NULL IDENTITY,
	RUBRO_DESCRIPCION NVARCHAR(100),

	CONSTRAINT RUBRO_PK PRIMARY KEY (RUBRO_ID)
);

CREATE TABLE [MANA].PROVEEDOR (
	PROV_ID INT NOT NULL IDENTITY,
	PROV_RAZON_SOCIAL NVARCHAR(100),
	PROV_CUIT NVARCHAR(20),
	PROV_NOMBRE_CONTACTO NVARCHAR(20),
	PROV_MAIL NVARCHAR(100),
	PROV_TELEFONO NUMERIC(18),
	PROV_DIRECCION NVARCHAR(100),
	PROV_CODIGO_POSTAL NVARCHAR(18),	
	PROV_CIUDAD NVARCHAR(255),
	PROV_RUBRO_ID INT,
	PROV_USER_ID INT,
	
	CONSTRAINT PROV_PK PRIMARY KEY (PROV_ID)
);

CREATE TABLE [MANA].CLIENTE (
	CLI_ID INT NOT NULL IDENTITY,
	CLI_NOMBRE NVARCHAR(255),
	CLI_APELLIDO NVARCHAR(255),
	CLI_DNI NUMERIC(18),
	CLI_MAIL NVARCHAR(255),
	CLI_TELEFONO NUMERIC(18),
	CLI_DIRECCION NVARCHAR(255),
	CLI_CODIGO_POSTAL NVARCHAR(18),
	CLI_CIUDAD NVARCHAR(255),
	CLI_FECHA_NACIMIENTO DATETIME,
	CLI_SALDO NUMERIC(18),
	CLI_USER_ID INT,
	
	CONSTRAINT CLI_PK PRIMARY KEY (CLI_ID)
);

CREATE TABLE [MANA].TIPO_PAGO (
    TP_ID INT NOT NULL IDENTITY,
	TP_DESCRIPCION NVARCHAR(100),
	
	CONSTRAINT TP_PK PRIMARY KEY (TP_ID) 
);

CREATE TABLE [MANA].CARGA_CREDITO (
	CC_ID INT NOT NULL IDENTITY,
	CC_FECHA_CARGA DATETIME,
	CC_CLIENTE_ID INT,
	CC_TIPO_PAGO_ID INT,
	CC_MONTO NUMERIC(18),
	CC_NUMERO_TARJETA INT,

	CONSTRAINT CC_PK PRIMARY KEY (CC_ID)
);

CREATE TABLE [MANA].OFERTA (
	OF_NUMERO NVARCHAR(50),
	OF_DESCRIPCION NVARCHAR(255),
	OF_FECHA_PUBLICACION DATETIME,
	OF_FECHA_VENCIMIENTO DATETIME,
	OF_PRECIO_OFERTA NUMERIC(18),
	OF_PRECIO_LISTA NUMERIC(18),
	OF_PROVEEDOR_ID INT,
	OF_CANTIDAD_DISPONIBLE NUMERIC(18),
	OF_MAXIMO_UNIDAD_CLIENTE INT,
	OF_ESTADO NVARCHAR(20),
	
	CONSTRAINT OF_PK PRIMARY KEY (OF_NUMERO)
);

CREATE TABLE [MANA].CUPON (
	CUPON_ID INT NOT NULL IDENTITY,
	CUPON_FECHA_COMPRA DATETIME,
	CUPON_NUMERO_OFERTA NVARCHAR(50),
	CUPON_PRECIO_OFERTA NUMERIC(18),
	CUPON_PRECIO_LISTA NUMERIC(18),	
	CUPON_CANTIDAD_ADQUIRIDA INT,
	CUPON_IMPORTE NUMERIC (18),	
	CUPON_CLI_ID INT,	
	CUPON_ESTADO NVARCHAR(20),
	CUPON_FECHA_VALIDEZ DATETIME,

	CONSTRAINT CUPON_PK PRIMARY KEY (CUPON_ID)
);

CREATE TABLE [MANA].CONSUMO_OFERTA (
	CONSOF_ID INT NOT NULL IDENTITY,
	CONSOF_FECHA_ENTREGA DATETIME,
	CONSOF_PROV_ID INT,
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

CREATE TABLE [MANA].OFERTA_VENDIDA (
    OF_VEN_ID INT NOT NULL IDENTITY,
	OF_VEN_FECHA_COMPRA DATETIME,
	OF_VEN_CUPON_ID INT,
	OF_VEN_PROV_ID INT,
	OF_VEN_OF_NUMERO NVARCHAR(50),
	OF_VEN_IMPORTE NUMERIC(18),
	CONSTRAINT OFVEN_PK PRIMARY KEY (OF_VEN_ID)
);


CREATE TABLE [MANA].ITEM_FACTURA (
    I_FACT_ID INT NOT NULL IDENTITY,
	I_FACT_NUMERO NUMERIC(18),
	I_FACT_OF_VEN_ID INT, 
	I_FACT_IMPORTE NUMERIC(18),
	
	CONSTRAINT ITEM_FACT_PK PRIMARY KEY (I_FACT_ID)
);

CREATE TABLE [MANA].FACTURA (
    FACT_ID INT NOT NULL IDENTITY,
	FACT_NUMERO NUMERIC(18),
	FACT_FECHA DATETIME,
	FACT_IMPORTE_TOTAL NUMERIC(18),
	FACT_PROV_ID INT,
	CONSTRAINT FACT_PK PRIMARY KEY (FACT_ID)
);

CREATE TABLE [MANA].USUARIO (
	USER_ID INT NOT NULL IDENTITY,
	USER_USERNAME NVARCHAR(200),
	USER_PASSWORD NVARCHAR(200),
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
ALTER TABLE [MANA].ITEM_FACTURA ADD CONSTRAINT FK_OF_VEN_ID FOREIGN KEY (I_FACT_OF_VEN_ID) REFERENCES [MANA].OFERTA_VENDIDA (OF_VEN_ID);
ALTER TABLE [MANA].FACTURA ADD CONSTRAINT FK_PR_ID FOREIGN KEY (FACT_PROV_ID) REFERENCES [MANA].PROVEEDOR (PROV_ID);
ALTER TABLE [MANA].CONSUMO_OFERTA ADD CONSTRAINT FK_PROVEED_ID FOREIGN KEY (CONSOF_PROV_ID) REFERENCES [MANA].PROVEEDOR(PROV_ID);
ALTER TABLE [MANA].CONSUMO_OFERTA ADD CONSTRAINT FK_CUPON_ID FOREIGN KEY (CONSOF_CUPON_ID) REFERENCES [MANA].CUPON (CUPON_ID);
ALTER TABLE [MANA].CARGA_CREDITO ADD CONSTRAINT FK_CLI_ID FOREIGN KEY (CC_CLIENTE_ID) REFERENCES [MANA].CLIENTE (CLI_ID);
ALTER TABLE [MANA].CARGA_CREDITO ADD CONSTRAINT FK_TP_ID FOREIGN KEY (CC_TIPO_PAGO_ID) REFERENCES [MANA].TIPO_PAGO (TP_ID);
ALTER TABLE [MANA].CUPON ADD CONSTRAINT FK_CLIENTE_ID FOREIGN KEY (CUPON_CLI_ID) REFERENCES [MANA].CLIENTE (CLI_ID);
ALTER TABLE [MANA].OFERTA ADD CONSTRAINT FK_PROVEEDOR_ID FOREIGN KEY (OF_PROVEEDOR_ID) REFERENCES [MANA].PROVEEDOR (PROV_ID);
ALTER TABLE [MANA].OFERTA_VENDIDA ADD CONSTRAINT FK_CUP_ID FOREIGN KEY (OF_VEN_CUPON_ID) REFERENCES [MANA].CUPON (CUPON_ID);
ALTER TABLE [MANA].OFERTA_VENDIDA ADD CONSTRAINT FK_PROVEE_ID FOREIGN KEY (OF_VEN_PROV_ID) REFERENCES [MANA].PROVEEDOR (PROV_ID);
ALTER TABLE [MANA].USUARIO_ROL ADD CONSTRAINT FK_USER_ID FOREIGN KEY (UR_USR_ID) REFERENCES [MANA].USUARIO (USER_ID);
ALTER TABLE [MANA].USUARIO_ROL ADD CONSTRAINT FK_ROL_ID FOREIGN KEY (UR_ROL_ID) REFERENCES [MANA].ROL (ROL_ID);
ALTER TABLE [MANA].FUNCIONALIDAD_ROL ADD CONSTRAINT FK_R_ID FOREIGN KEY (FR_ROL_ID) REFERENCES [MANA].ROL (ROL_ID);
ALTER TABLE [MANA].FUNCIONALIDAD_ROL ADD CONSTRAINT FK_FUNC_ID FOREIGN KEY (FR_FUNCIONALIDAD_ID) REFERENCES [MANA].FUNCIONALIDAD (FUNC_ID);
ALTER TABLE [MANA].CLIENTE ADD CONSTRAINT FK_CLI_USER_ID FOREIGN KEY (CLI_USER_ID) REFERENCES [MANA].USUARIO (USER_ID);
ALTER TABLE [MANA].PROVEEDOR ADD CONSTRAINT FK_PROV_USER_ID FOREIGN KEY (PROV_USER_ID) REFERENCES [MANA].USUARIO (USER_ID);
GO 


/** TRIGGERS **/

/*Ofertas*/
create TRIGGER MANA.PublicarOferta  /*Publica las Ofertas, cambiando su estado a Habilitado*/
on MANA.OFERTA
   after INSERT
AS              /*Las ofertas que son Publicadas pasan a Habilitadas*/
BEGIN 
  Update OFERTA set OF_ESTADO = 'Habilitado' where OFERTA.OF_NUMERO in
  (select O.OF_NUMERO
    from OFERTA O
	where O.OF_FECHA_PUBLICACION <= GETDATE())        
END
GO

create TRIGGER MANA.ValidarVencimientoOferta  /*Valida el vencimiento de las Ofertas, cambiando su estado a Deshabilitado*/         
on MANA.OFERTA
   after INSERT
AS              /*Cuando las ofertas vencen pasan a Deshabilitadas*/
BEGIN
   Update OFERTA set OF_ESTADO = 'Deshabilitado' where OFERTA.OF_NUMERO in
   (select O.OF_NUMERO
    from OFERTA O
	where O.OF_FECHA_VENCIMIENTO <= GETDATE())           
END
GO

create TRIGGER MANA.ValidarStockOferta   /*Valida el stock de las ofertas, cambiando su estado a Deshabilitado*/             
on MANA.OFERTA
   after INSERT, UPDATE
AS             /*Cuando ya no hay stock las ofertas pasan a Deshabilitadas*/
BEGIN
   Update OFERTA SET OF_ESTADO = 'Deshabilitado' where OFERTA.OF_NUMERO in
   (select O.OF_NUMERO
    from OFERTA O
	where O.OF_CANTIDAD_DISPONIBLE = 0) 
END
GO

create TRIGGER MANA.ValidarVencimientoCupon   /*Valida el vencimiento del Cupon, cambiando su estado a Deshabilitado*/
   on MANA.CUPON
   after INSERT
AS
BEGIN   /*El cupon vence 1 MES despues de comprar la Oferta, lo elegimos asi al no especificar el cuando en el enunciado*/
   update CUPON set CUPON_ESTADO = 'Deshabilitado' where CUPON_ID in
   (select CUPON_ID
    from CUPON C
	where DATEADD(MONTH, 1, C.CUPON_FECHA_COMPRA) <= GETDATE())
END
GO



/** MIGRACION **/

/*Cliente*/

CREATE PROCEDURE MANA.MigrarCliente  /*Inserta los datos del Cliente de la tabla Maestra a la Tabla CLIENTE*/
AS
insert into MANA.CLIENTE         /*Como todavia no estan creados los usuarios para los clientes migrados user id es null; se asigna el userId mas abajo*/
select M.Cli_Nombre, M.Cli_Apellido, M.Cli_Dni, M.Cli_Mail, M.Cli_Telefono, M.Cli_Direccion, NULL as CODIGO_POSTAL, M.Cli_Ciudad, M.Cli_Fecha_Nac, 200 as SALDO, NULL as USER_ID
from gd_esquema.Maestra M
group by M.Cli_Nombre, M.Cli_Apellido, M.Cli_Dni, M.Cli_Mail, M.Cli_Telefono, M.Cli_Direccion, M.Cli_Ciudad, M.Cli_Fecha_Nac
GO

MANA.MigrarCliente
GO

/*Rubro*/

CREATE PROCEDURE MANA.MigrarRubro   /*Inserta los datos del Rubro de la tabla Maestra a la Tabla RUBRO*/
AS
insert into MANA.RUBRO
select M.Provee_Rubro
from gd_esquema.Maestra M
where M.Provee_Rubro IS NOT NULL 
group by M.Provee_Rubro
GO

MANA.MigrarRubro
GO	

/*Proveedor*/

CREATE PROCEDURE MANA.MigrarProveedor   /*Inserta los datos del Proveedor de la tabla Maestra a la Tabla PROVEEDOR*/
AS
insert into MANA.PROVEEDOR  /*Como todavia no estan creados los usuarios para los proveedores migrados user id es null; se asigna el userId mas abajo*/
select M.Provee_RS, M.Provee_CUIT, NULL as NOMBRE_CONTACO, NULL as EMAIL, M.Provee_Telefono, M.Provee_Dom, NULL as CODIGO_POSTAL, M.Provee_Ciudad, R.RUBRO_ID, NULL
from gd_esquema.Maestra M, MANA.RUBRO R
where  M.Provee_Rubro = R.RUBRO_DESCRIPCION
group by M.Provee_RS, M.Provee_CUIT, M.Provee_Telefono, M.Provee_Dom, M.Provee_Ciudad, R.RUBRO_ID
GO

MANA.MigrarProveedor
GO

/*Tipo Pago*/

CREATE PROCEDURE MANA.MigrarTipoPago  /*Inserta los datos del Tipo de Pago de la tabla Maestra a la Tabla TIPO_PAGO*/
AS
insert into MANA.TIPO_PAGO
select M.Tipo_Pago_Desc
from gd_esquema.Maestra M
where M.Tipo_Pago_Desc is not null
group by M.Tipo_Pago_Desc
GO

MANA.MigrarTipoPago
GO

/*Carga Credito */

CREATE PROCEDURE MANA.MigrarCargaCredito  /*Inserta los datos de las Cargas de Credito de la tabla Maestra a la Tabla CARGA_CREDITO*/
AS
insert into MANA.CARGA_CREDITO
select M.Carga_Fecha, C.CLI_ID,	TP.TP_ID, M.Carga_Credito, NULL	
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

/*Oferta*/

CREATE PROCEDURE MANA.MigrarOferta   /*Inserta los datos de las Ofertas de la tabla Maestra a la Tabla OFERTA*/
AS
insert into MANA.OFERTA         /*Como en la tabla maestra no habia una restriccion de maximo de unidades por cliente, le asigno la cantidad disponible*/
select M.Oferta_Codigo, M.Oferta_Descripcion, M.Oferta_Fecha, M.Oferta_Fecha_Venc, M.Oferta_Precio, M.Oferta_Precio_Ficticio, P.PROV_ID, M.Oferta_Cantidad, M.Oferta_Cantidad ,'En Espera'
from gd_esquema.Maestra M, MANA.PROVEEDOR P 
where
   (M.Provee_RS = P.PROV_RAZON_SOCIAL AND
	M.Provee_CUIT = P.PROV_CUIT AND
	M.Provee_Telefono = P.PROV_TELEFONO AND
	M.Provee_Dom = P.PROV_DIRECCION AND
	M.Provee_Ciudad = P.PROV_CIUDAD)	
group by M.Oferta_Codigo, M.Oferta_Descripcion, M.Oferta_Fecha, M.Oferta_Fecha_Venc, M.Oferta_Precio, M.Oferta_Precio_Ficticio, P.PROV_ID, M.Oferta_Cantidad, M.Oferta_Cantidad
GO

MANA.MigrarOferta
GO

/*Cupon*/

CREATE PROCEDURE MANA.MigrarCupon    /*Inserta los datos del Cupon de la tabla Maestra a la Tabla CUPON*/
AS          /*Importe = PrecioOferta * CantAdq pero como no tengo registrada la cantidad en la Maestra, elegimos que sea 1, siendo el importe = precioOferta */
insert into MANA.CUPON                                        /*Fecha Validez = Fecha Compra + 1 mes*/
select M.Oferta_Fecha_Compra, M.Oferta_Codigo, M.Oferta_Precio, M.Oferta_Precio_Ficticio, 1 as Cantidad_Adquirida, M.Oferta_Precio as Importe, C.CLI_ID, 'Habilitado', DATEADD(MONTH, 1,M.Oferta_Fecha_Compra) as Validez
from gd_esquema.Maestra M, MANA.CLIENTE C                          /*Le asigno estado habilitado, luego abajo con 1 procedure voy a asignarles Deshabilitado */
where                                                              /* a los cupones que ya han sido canjeados, que son los que estan registrados en Consumo Oferta*/
    M.Oferta_Fecha_Compra IS NOT NULL AND	
	M.Cli_Nombre = C.CLI_NOMBRE AND
	M.Cli_Apellido = C.CLI_APELLIDO AND
	M.Cli_Dni = C.CLI_DNI AND
	M.Cli_Mail = C.CLI_MAIL AND
	M.Cli_Telefono = C.CLI_TELEFONO AND
	M.Cli_Direccion = C.CLI_DIRECCION AND
	M.Cli_Ciudad = C.CLI_CIUDAD AND
	M.Cli_Fecha_Nac = C.CLI_FECHA_NACIMIENTO		
group by M.Oferta_Fecha_Compra, M.Oferta_Codigo, M.Oferta_Precio, M.Oferta_Precio_Ficticio, C.CLI_ID, DATEADD(MONTH, 1,M.Oferta_Fecha_Compra)
GO

MANA.MigrarCupon
GO

/*Consumo Oferta*/  

CREATE PROCEDURE MANA.MigrarConsumoOferta    /*Inserta los datos del Canje de Cupon de la tabla Maestra a la Tabla CONSUMO_OFERTA*/
AS
insert into MANA.CONSUMO_OFERTA
select distinct M.Oferta_Entregado_Fecha, P.PROV_ID, C.CUPON_ID, M.Cli_Dest_Nombre, M.Cli_Dest_Apellido, M.Cli_Dest_Dni, M.Cli_Dest_Mail, M.Cli_Dest_Telefono, M.Cli_Dest_Direccion, M.Cli_Dest_Fecha_Nac, M.Cli_Dest_Ciudad	
from gd_esquema.Maestra M, MANA.PROVEEDOR P, MANA.CUPON C
where
    M.Oferta_Entregado_Fecha IS NOT NULL AND
   (M.Provee_RS = P.PROV_RAZON_SOCIAL AND
	M.Provee_CUIT = P.PROV_CUIT AND
	M.Provee_Telefono = P.PROV_TELEFONO AND
	M.Provee_Dom = P.PROV_DIRECCION AND
	M.Provee_Ciudad = P.PROV_CIUDAD) AND
   (M.Oferta_Fecha_Compra = C.CUPON_FECHA_COMPRA AND
	M.Oferta_Codigo = C.CUPON_NUMERO_OFERTA AND
	M.Oferta_Precio = C.CUPON_PRECIO_OFERTA AND
	M.Oferta_Precio_Ficticio= C.CUPON_PRECIO_LISTA)
group by M.Oferta_Entregado_Fecha, P.PROV_ID, C.CUPON_ID, M.Cli_Dest_Nombre, M.Cli_Dest_Apellido, M.Cli_Dest_Dni, M.Cli_Dest_Mail, M.Cli_Dest_Telefono, M.Cli_Dest_Direccion, M.Cli_Dest_Fecha_Nac, M.Cli_Dest_Ciudad
GO

MANA.MigrarConsumoOferta
GO

CREATE PROCEDURE MANA.CanjearCuponesMigrados  /*Cambia el estado a Deshabilitado a cada Cupon MIGRADO que ya haya sido canjeado*/
AS
   declare @CuponId int
              /*Selecciono todos los cupones ya han sido canjeados, es decir, todos los cupones que estan registrado en la tabla Consumo Oferta*/
   declare Cupon CURSOR FOR
   select CONSOF_CUPON_ID from CONSUMO_OFERTA
   Open Cupon
   FETCH NEXT FROM Cupon into @CuponId
   --check for a new row
   WHILE @@FETCH_STATUS = 0
   BEGIN                                                     
    UPDATE MANA.CUPON
	set CUPON_ESTADO = 'Deshabilitado'
	where CUPON_ID = @CuponId
	FETCH NEXT FROM Cupon into @CuponId
   END
   close Cupon
   Deallocate Cupon
GO

Mana.CanjearCuponesMigrados
GO

/*Oferta Vendida a facturar*/

CREATE PROCEDURE MANA.MigrarOfertaVendida  /*Inserta los datos de la Oferta Vendida de la tabla Maestra a la Tabla OFERTA_VENDIDA*/
AS
insert into MANA.OFERTA_VENDIDA
select M.Oferta_Fecha_Compra, C.CUPON_ID , P.PROV_ID, M.Oferta_Codigo, C.CUPON_IMPORTE
from gd_esquema.Maestra M, MANA.CUPON C , MANA.PROVEEDOR P
where
   (M.Oferta_Fecha_Compra = C.CUPON_FECHA_COMPRA AND
	M.Oferta_Codigo = C.CUPON_NUMERO_OFERTA AND
	M.Oferta_Precio = C.CUPON_PRECIO_OFERTA AND
	M.Oferta_Precio_Ficticio = C.CUPON_PRECIO_LISTA) AND
   (M.Provee_RS = P.PROV_RAZON_SOCIAL AND
	M.Provee_CUIT = P.PROV_CUIT AND
	M.Provee_Telefono = P.PROV_TELEFONO AND
	M.Provee_Dom = P.PROV_DIRECCION AND
	M.Provee_Ciudad = P.PROV_CIUDAD)
group by M.Oferta_Fecha_Compra, C.CUPON_ID, P.PROV_ID, M.Oferta_Codigo, C.CUPON_IMPORTE
GO

Mana.MigrarOfertaVendida
GO


/*Item Factura*/

CREATE PROCEDURE MANA.MigrarItemFactura   /*Inserta los datos de todas las Ofertas Vendidas facturadas de la tabla Maestra a la Tabla ITEM FACTURA*/
AS
insert into MANA.ITEM_FACTURA
select DISTINCT M.Factura_Nro, OV.OF_VEN_ID, OV.OF_VEN_IMPORTE
from gd_esquema.Maestra M, MANA.OFERTA_VENDIDA OV
where
    M.Factura_Nro is not null AND
   (M.Oferta_Fecha_Compra = OV.OF_VEN_FECHA_COMPRA AND M.Oferta_Codigo = OV.OF_VEN_OF_NUMERO)     
group by M.Factura_Nro, OV.OF_VEN_ID, OV.OF_VEN_IMPORTE
ORDER BY M.Factura_Nro ASC	 
GO

Mana.MigrarItemFactura
GO


/*Factura*/

CREATE PROCEDURE MANA.MigrarFactura   /*Inserta los datos de las Facturas de la tabla Maestra a la Tabla FACTURA*/
AS
insert into MANA.FACTURA
select DISTINCT M.Factura_Nro, M.Factura_Fecha, (select SUM(I_FACT_IMPORTE) FROM ITEM_FACTURA WHERE I_FACT_NUMERO = M.Factura_Nro), OV.OF_VEN_PROV_ID
from gd_esquema.Maestra M, MANA.OFERTA_VENDIDA OV
where M.Factura_Nro is not null AND
   (M.Oferta_Fecha_Compra = OV.OF_VEN_FECHA_COMPRA AND M.Oferta_Codigo = OV.OF_VEN_OF_NUMERO)        
group by M.Factura_Nro, M.Factura_Fecha, OV.OF_VEN_PROV_ID
Order by M.Factura_Nro ASC
GO

Mana.MigrarFactura
GO



/** STORES PROCEDURES PARA LA APLICACION **/


/*Login*/

CREATE FUNCTION MANA.Encriptar (@Password NVARCHAR(200))  /*Encripta la contraseña bajo el algoritmo SHA256*/
RETURNS NVARCHAR(255)
BEGIN    
    set @Password = HASHBYTES('SHA2_256', SUBSTRING(@Password,1,255))
	return @Password
END
GO

CREATE PROCEDURE MANA.ValidarPassword (@Password NVARCHAR(200)) /*Valida la pw ingresada por comando, guardandola primero en una Tabla de uso Temporal, y luego encriptando el valor, para*/
AS                                                              /* compararlo con el password encriptado almacenado del Usuario ingresado por comando, en la tabla Usuario*/
     BEGIN
	 CREATE TABLE [MANA].TT (USER_PASSWORD NVARCHAR(200));
	 insert into MANA.TT values (@Password)
	 UPDATE MANA.TT
	 SET USER_PASSWORD = Mana.Encriptar(USER_PASSWORD)        
	 END
GO

CREATE PROCEDURE MANA.BorrarTT  /*Borra la tabla de uso Temporal creada y utilizada en procedure Validar Password*/
AS
  IF OBJECT_ID('MANA.TT') IS NOT NULL
  DROP TABLE MANA.TT;
GO



/*Rol*/

CREATE PROCEDURE MANA.CrearRol @Nombre nvarchar(20)  /*Inserta un nuevo rol en la tabla ROL*/
AS	
IF(NOT EXISTS(SELECT ROL_NOMBRE FROM MANA.ROL WHERE ROL_NOMBRE = @Nombre))
BEGIN
  insert into MANA.ROL(ROL_NOMBRE, ROL_ESTADO) values (@Nombre,'Habilitado');	
END
GO
/*Creo los roles pedidos en enunciado*/
MANA.CrearRol 'AdministradorGral'
GO
MANA.CrearRol 'Cliente'              
GO
MANA.CrearRol 'Proveedor'            
GO
MANA.CrearRol 'Administrativo'       
GO          

CREATE VIEW MANA.FuncionalidadRol_VW       /*Crea una vista de 1 rol con sus respectivas funcionalidades*/
AS 
select R.ROL_ID, R.ROL_NOMBRE,F.FUNC_ID, F.FUN_NOMBRE
from
    MANA.ROL R,
    MANA.FUNCIONALIDAD_ROL FR,
    MANA.FUNCIONALIDAD F
where R.ROL_ID = FR.FR_ROL_ID AND FR.FR_FUNCIONALIDAD_ID = F.FUNC_ID    
GO

CREATE PROCEDURE MANA.EliminarFuncionalidadesDeRol @RolID int  
AS                                                      /*Elimina todas las asociaciones de las funcionalidades con 1 rol de la tabla FUNCIONALIDAD_ROL*/
    delete from MANA.FUNCIONALIDAD_ROL
    where MANA.FUNCIONALIDAD_ROL.FR_ROL_ID = @RolID
GO

CREATE PROCEDURE MANA.EliminarUsuariosDeRol @RolID int
AS                                                      /*Elimina todas las asociaciones de los usuarios con 1 rol de la tabla USUARIO_ROL*/
    delete from MANA.USUARIO_ROL
    where MANA.USUARIO_ROL.UR_ROL_ID = @RolID
GO

CREATE PROCEDURE MANA.BajaDeRol @RolID int     /*Da de baja 1 rol modificando su estado a Deshabilitado, y eliminando todas las asociaciones de las funcionalidades y de los*/
AS                                             /*usuarios con el Rol de las tablas FUNCIONALIDAD_ROL y USUARIO_ROL*/
    exec MANA.EliminarFuncionalidadesDeRol @RolID
    exec MANA.EliminarUsuariosDeRol @RolID    
    update MANA.ROL
    SET MANA.ROL.ROL_ESTADO = 'Deshabilitado'
    where MANA.ROL.ROL_ID = @RolID
GO


/*Funcionalidad*/

CREATE PROCEDURE MANA.CrearFuncionalidades  /*Crea todas las funcionalidades de la Aplicacion*/
AS
  insert into MANA.FUNCIONALIDAD values('Seguridad')
  insert into MANA.FUNCIONALIDAD values('Abm Rol');
  insert into MANA.FUNCIONALIDAD values('Abm Cliente');
  insert into MANA.FUNCIONALIDAD values('Abm Proveedor');
  insert into MANA.FUNCIONALIDAD values('Carga Credito');
  insert into MANA.FUNCIONALIDAD values('Ofertas');
  insert into MANA.FUNCIONALIDAD values('Comprar Oferta');
  insert into MANA.FUNCIONALIDAD values('Facturacion');
  insert into MANA.FUNCIONALIDAD values('Listado Estadistico');
GO

MANA.CrearFuncionalidades
GO


/*Funcionalidad Rol*/

CREATE PROCEDURE MANA.AsignarFuncionRol @RolID int, @FuncionID int  /*Asigna una Funcion a 1 Rol, insertando la asociacion en la tabla FUNCIONALIDAD_ROL*/
AS
IF(NOT EXISTS(SELECT FR_ROL_ID, FR_FUNCIONALIDAD_ID FROM MANA.FUNCIONALIDAD_ROL WHERE FR_ROL_ID = @RolID AND FR_FUNCIONALIDAD_ID = @FuncionID))
BEGIN
insert into MANA.FUNCIONALIDAD_ROL values (@RolID,@FuncionID);
END
GO

CREATE PROCEDURE MANA.EliminarFuncionRol @RolID int, @FuncionID int   /*Elimina una Funcion a 1 Rol, eliminando la asociacion de la tabla FUNCIONALIDAD_ROL*/
AS
    delete from MANA.FUNCIONALIDAD_ROL where MANA.FUNCIONALIDAD_ROL.FR_ROL_ID = @RolID and MANA.FUNCIONALIDAD_ROL.FR_FUNCIONALIDAD_ID = @FuncionID;
GO

CREATE PROCEDURE MANA.AsignarFuncionesAdministrador   /*Asigna todas las funciones existentes al Rol AdministradorGral*/
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

/*Funcionalidades de Administrador General*/
MANA.AsignarFuncionesAdministrador
GO
/*Funcionalidades de Cliente*/
Mana.AsignarFuncionRol 2, 1
GO
Mana.AsignarFuncionRol 2, 5
GO
Mana.AsignarFuncionRol 2, 7
GO
/*Funcionalidades de Proveedor*/
Mana.AsignarFuncionRol 3, 1
GO
Mana.AsignarFuncionRol 3, 6
GO
/*Funcionalidades de Administrativo*/
Mana.AsignarFuncionRol 4, 1
GO
Mana.AsignarFuncionRol 4, 3
GO
Mana.AsignarFuncionRol 4, 4
GO
Mana.AsignarFuncionRol 4, 6
GO
Mana.AsignarFuncionRol 4, 8
GO


/*Usuario*/

CREATE PROCEDURE MANA.CrearUsuario @Username nvarchar(200), @Password nvarchar(200)  /*Crea 1 nuevo usuario, encriptando su password bajo el algoritmo SHA256*/
AS
IF(NOT EXISTS(SELECT USER_USERNAME FROM MANA.USUARIO WHERE USER_USERNAME = @Username))
BEGIN
  declare @PasswordEncriptado nvarchar(200)
  set @PasswordEncriptado = MANA.Encriptar (@Password)
insert into MANA.USUARIO values (@Username, @PasswordEncriptado, 0, 'Habilitado');
END
GO
/*Creo el Usuario Admin, pedido en enunciado*/
Mana.CrearUsuario 'admin', 'w23e'
GO

CREATE PROCEDURE MANA.AltaUsuario @UserId int  /*Da de alta 1 usuario modificando su estado a Habilitado*/
AS
UPDATE MANA.USUARIO
SET USUARIO_ESTADO = 'Habilitado'
WHERE USER_ID = @UserId
UPDATE MANA.USUARIO
SET USER_INTENTOS_FALLIDOS = 0
WHERE USER_ID = @UserId
GO

CREATE PROCEDURE MANA.BajaUsuario @UserId int  /*Da de baja 1 usuario modificando su estado a Deshabilitado*/
AS
UPDATE MANA.USUARIO
SET USUARIO_ESTADO = 'Deshabilitado'
WHERE USER_ID = @UserId
GO

CREATE PROCEDURE MANA.CambiarPassword @Username nvarchar(200), @Password nvarchar(200) /*Cambia la password de 1 usuario, modificando su valor en la tabla USUARIO*/
AS
 declare @PasswordEncriptado nvarchar(200)
 set @PasswordEncriptado = MANA.Encriptar (@Password)
UPDATE MANA.USUARIO
SET USER_PASSWORD = @PasswordEncriptado
WHERE USER_USERNAME = @Username
GO


/*UsuarioRol*/

CREATE PROCEDURE MANA.AsignarUsuarioRol @Username nvarchar(200), @RolNombre nvarchar(20) /*Asocia 1 rol a 1 usuario, registrandolo en la tabla USUARIO_ROL*/
AS
DECLARE @UserID int = (select USER_ID from MANA.USUARIO WHERE USER_USERNAME = @Username)
DECLARE @RolID int = (select ROL_ID from MANA.ROL R WHERE R.ROL_NOMBRE = @RolNombre)
DECLARE @RolEstado nvarchar(20) = (select ROL_ESTADO from MANA.ROL WHERE ROL_NOMBRE = @RolNombre)
IF(@RolEstado = 'Habilitado')
BEGIN
insert into MANA.USUARIO_ROL values (@UserID, @RolID );
END
GO
/*Asigno al usuario admin el rol de Administrador General, pedido en enunciado*/
Mana.AsignarUsuarioRol 'admin', 'AdministradorGral'
GO

/*Usuarios para Clientes y Proveedores Migrados*/
CREATE PROCEDURE MANA.AsignarUserIdCliente @Nombre nvarchar(255), @Apellido nvarchar(255), @Dni numeric(18), @UserId int
AS                        /*Asigna el Id de Usuario del Cliente en el campo USER_ID de la tabla CLIENTE*/
  declare @ClienteId int
  set @ClienteId = (select CLI_ID from MANA.CLIENTE where CLI_NOMBRE = @Nombre and CLI_APELLIDO = @Apellido and CLI_DNI = @Dni)
  UPDATE MANA.CLIENTE
  SET CLI_USER_ID = @UserId
  where CLI_ID = @ClienteId
GO

CREATE PROCEDURE MANA.CrearUsuariosParaClientesMigrados /*Genera un usuario para todos los Clientes MIGRADOS*/
AS
  declare @Username nvarchar(200)
  declare @Password nvarchar(200)
  declare @Nombre nvarchar(255)
  declare @Apellido nvarchar(255)
  declare @Dni numeric(18)
  declare @UserId int

  declare Cliente CURSOR FOR
   select CLI_NOMBRE, CLI_APELLIDO, CLI_DNI, CLI_USER_ID from CLIENTE 
   Open Cliente
   FETCH NEXT FROM Cliente into @Nombre, @Apellido, @Dni, @UserId
   --check for a new row
   WHILE @@FETCH_STATUS = 0
   BEGIN                                                               /*Username = Nombre + Primer y Segundo Caracter del Apellido*/
    set @Username = @Nombre + substring(@Apellido, 1, 1) + UPPER(SUBSTRING(@Apellido, 2, 1))   
	set @Password = @Dni	

    EXECUTE MANA.CrearUsuario @Username, @Password                     /*Creo el usuario*/	
	EXECUTE MANA.AsignarUsuarioRol @Username, 'Cliente'                /*Asigno rol al usuario*/
	set @UserId = (select max(USER_ID) from MANA.USUARIO)
	EXECUTE MANA.AsignarUserIdCliente @Nombre, @Apellido, @Dni, @UserId   /*Asigno el Id de Usuario correspondiente a cada Cliente Migrado*/
	FETCH NEXT FROM Cliente into @Nombre, @Apellido, @Dni, @UserId
   END
   close Cliente
   Deallocate Cliente
GO

Mana.CrearUsuariosParaClientesMigrados
GO

CREATE PROCEDURE MANA.AsignarUserIdProveedor @RazonSocial nvarchar(255), @Cuit nvarchar(255), @UserId int
AS                        /*Asigna el Id de Usuario del Proveedor en el campo USER_ID de la tabla PROVEEDOR*/
  declare @ProvId int
  set @ProvId = (select PROV_ID from MANA.PROVEEDOR where PROV_RAZON_SOCIAL = @RazonSocial and  PROV_CUIT= @Cuit)
  UPDATE MANA.PROVEEDOR
  SET PROV_USER_ID = @UserId
  where PROV_ID = @ProvId
GO

CREATE PROCEDURE MANA.CrearUsuariosParaProveedoresMigrados /*Genera un Usuario para los Proveedores MIGRADOS*/
AS
  declare @Username nvarchar(200)
  declare @Password nvarchar(200)
  declare @RazonSocial nvarchar(255)
  declare @Cuit nvarchar(255)
  declare @UserId int

  declare Proveedor CURSOR FOR
   select PROV_RAZON_SOCIAL, PROV_CUIT, PROV_USER_ID from PROVEEDOR
   Open Proveedor
   FETCH NEXT FROM Proveedor into @RazonSocial, @Cuit, @UserId
   --check for a new row
   WHILE @@FETCH_STATUS = 0
   BEGIN                                                     
    set @Username = @RazonSocial
	set @Password = @Cuit
    EXECUTE MANA.CrearUsuario @Username, @Password                     /*Creo el usuario*/
	EXECUTE MANA.AsignarUsuarioRol @Username,'Proveedor'               /*Asigno rol al usuario*/
	set @UserId = (select max(USER_ID) from MANA.USUARIO)
	EXECUTE Mana.AsignarUserIdProveedor @RazonSocial, @Cuit, @UserId   /*Asigno el Id de Usuario correspondiente a cada Proveedor Migrado*/
	FETCH NEXT FROM Proveedor into @RazonSocial, @Cuit, @UserId
   END
   close Proveedor
   Deallocate Proveedor

GO

Mana.CrearUsuariosParaProveedoresMigrados
GO



/*ABM Cliente*/

CREATE PROCEDURE MANA.CrearUsuarioCliente  /*Creo 1 cliente insertando sus datos en la tabla CLIENTE, previa creacion de 1 USUARIO para ese Cliente*/
@RolId int, @Username nvarchar(200), @Password nvarchar(200),
@Nombre nvarchar(255), @Apellido nvarchar(255), @Dni numeric(18), @Mail nvarchar(255), 
@Telefono numeric(18), @Direccion nvarchar(255), @CodigoPostal nvarchar(18), @Ciudad nvarchar(255), @FechaNac datetime
AS
BEGIN TRANSACTION
BEGIN TRY
DECLARE @idGenerado int
EXECUTE MANA.CrearUsuario @Username, @Password                      /*Creo el usuario*/
SET @idGenerado = (SELECT MAX(USER_ID) FROM MANA.USUARIO)           
INSERT INTO MANA.USUARIO_ROL VALUES(@idGenerado, @RolId)            /*Asocio el usuario creado al rol Cliente*/
INSERT INTO MANA.CLIENTE values(@Nombre, @Apellido, @Dni, @Mail, @Telefono, @Direccion, @CodigoPostal, @Ciudad, @FechaNac, 200, @idGenerado);
COMMIT TRANSACTION                                                  /*Inserto los datos del Cliente en la tabla CLIENTE*/
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION
END CATCH
GO

CREATE PROCEDURE MANA.ModificarCliente @ID int, @Nombre nvarchar(255), @Apellido nvarchar(255), @Dni numeric(18), @Mail nvarchar(255), 
                                   @Telefono numeric(18), @Direccion nvarchar(255), @CodigoPostal nvarchar(18), @Ciudad nvarchar(255), @FechaNac datetime
AS   
BEGIN
   UPDATE MANA.CLIENTE                /*Modifica los campos de 1 cliente registrado en la tabla CLIENTE*/
   SET  CLI_NOMBRE = @Nombre, CLI_APELLIDO = @Apellido, CLI_DNI = @Dni, CLI_MAIL = @Mail, CLI_TELEFONO = @Telefono,
	    CLI_DIRECCION = @Direccion, CLI_CODIGO_POSTAL = @CodigoPostal, CLI_CIUDAD = @Ciudad, CLI_FECHA_NACIMIENTO = @FechaNac
	  WHERE CLI_ID = @ID
END
GO

CREATE PROCEDURE MANA.CargarTipoPago @TipoPago nvarchar(100)  /*Inserta 1 nuevo tipo de pago en la tabla TIPO_PAGO*/
AS
   insert into MANA.TIPO_PAGO values (@TipoPago);  
GO
/*Faltaba esta opcion en la maestra*/
Mana.CargarTipoPago 'Debito'
GO

CREATE FUNCTION MANA.ObtenerIdTipoPago (@TipoPago nvarchar(100))  /*Obtiene el codigo del tipo de pago ingresado*/
RETURNS INT
AS
BEGIN
return (SELECT TP_ID FROM MANA.TIPO_PAGO where TP_DESCRIPCION = @TipoPago )
END  
GO

CREATE PROCEDURE MANA.CargarSaldo @ClienteId int, @Monto numeric(18) /*Carga el saldo a 1 cliente modificando el campo Saldo del Cliente registrado en la tabla CLIENTE*/
AS
UPDATE MANA.CLIENTE
SET CLI_SALDO = CLI_SALDO + @Monto
WHERE CLI_ID = @ClienteId 
GO

CREATE PROCEDURE MANA.DescontarSaldo @ClienteId int, @Monto numeric(18) /*Descuenta el saldo a 1 cliente modificando el campo Saldo del Cliente registrado en la tabla CLIENTE*/
AS
UPDATE MANA.CLIENTE
SET CLI_SALDO = CLI_SALDO - @Monto
WHERE CLI_ID = @ClienteId
GO

CREATE FUNCTION MANA.ObtenerSaldo (@ClienteId int)  /*Obtiene el saldo de 1 cliente registrado en la tabla CLIENTE*/
RETURNS NUMERIC
AS
BEGIN
  return (SELECT CLI_SALDO FROM MANA.CLIENTE WHERE CLI_ID = @ClienteId)
END
GO
    /*Carga el Credito a 1 cliente modificando el campo Saldo del Cliente registrado en la tabla CLIENTE, y registrando la carga en la tabla CARGA_CREDITO*/
CREATE PROCEDURE MANA.CargarCredito @FechaCarga datetime, @ClienteId int, @TipoPago nvarchar(100), @Monto numeric(18), @NumeroTarjeta int
AS
  insert into MANA.CARGA_CREDITO values (@FechaCarga, @ClienteId, Mana.ObtenerIdTipoPago(@TipoPago), @Monto, @NumeroTarjeta)
  EXECUTE MANA.CargarSaldo @ClienteId, @Monto
GO



/*ABM Proveedor*/

CREATE FUNCTION MANA.ObtenerIdRubro (@Rubro nvarchar(100))  /*Obtiene el codigo del Rubro ingresado*/
RETURNS INT
AS
BEGIN
  return( select RUBRO_ID from MANA.RUBRO where RUBRO_DESCRIPCION = @Rubro )
END	   
GO   

CREATE PROCEDURE MANA.CrearUsuarioProveedor   /*Creo 1 Proveedor insertando sus datos en la tabla CLIENTE, previa creacion de 1 USUARIO para ese Proveedor*/
@RolId int, @Username nvarchar(200), @Password nvarchar(200),
@RazonSocial nvarchar(100), @CUIT nvarchar(20), @NombreContacto nvarchar(20), @Mail nvarchar(100), 
@Telefono numeric(18), @Direccion nvarchar(100), @CodigoPostal nvarchar(18), @Ciudad nvarchar(255), @Rubro nvarchar(100)
AS
BEGIN TRANSACTION
BEGIN TRY
DECLARE @idGenerado int
EXECUTE MANA.CrearUsuario @Username, @Password               /*Creo el usuario*/
SET @idGenerado = (SELECT MAX(USER_ID) FROM MANA.USUARIO) 
INSERT INTO MANA.USUARIO_ROL VALUES(@idGenerado, @RolId)     /*Asocio el usuario con el rol Proveedor*/
INSERT INTO MANA.PROVEEDOR values(@RazonSocial, @CUIT, @NombreContacto, @Mail, @Telefono, @Direccion, @CodigoPostal, @Ciudad, MANA.ObtenerIdRubro(@Rubro),@idGenerado);
COMMIT TRANSACTION                                           /*Registro el Proveedor en la tabla PROVEEDOR*/
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION
END CATCH
GO

CREATE PROCEDURE MANA.ModificarProveedor @ID int, @RazonSocial nvarchar(100), @NombreContacto nvarchar(20), @CUIT nvarchar(20), @Mail nvarchar(100), 
                                   @Telefono numeric(18), @Direccion nvarchar(100), @CodigoPostal nvarchar(18), @Ciudad nvarchar(255), @Rubro nvarchar(100)
AS          /*Modifica los campos de 1 Proveedor registrado en la tabla PROVEEDOR */
BEGIN
   UPDATE MANA.PROVEEDOR
   SET  PROV_RAZON_SOCIAL = @RazonSocial, PROV_NOMBRE_CONTACTO = @NombreContacto, PROV_CUIT = @CUIT, PROV_MAIL = @Mail, PROV_TELEFONO = @Telefono, 
	    PROV_DIRECCION = @Direccion, PROV_CODIGO_POSTAL = @CodigoPostal, PROV_CIUDAD = @Ciudad, PROV_RUBRO_ID = Mana.ObtenerIdRubro(@Rubro)
	  WHERE PROV_ID = @ID
END
GO



/*ABM Oferta*/
                      /*Crea 1 Oferta, insertando los datos en la tabla OFERTA*/
CREATE PROCEDURE MANA.CrearOferta @Descripcion nvarchar(255), @FechaPublicacion datetime, @FechaVencimiento datetime, @PrecioOferta numeric(18), @PrecioLista numeric(18), 
								  @ProveedorId int, @CantidadDisponible numeric (18), @MaximoUnidadesPorCliente int
AS
  IF(@FechaPublicacion >= CONVERT(DATE,GETDATE()) AND @FechaVencimiento >= CONVERT(DATE,GETDATE())) /*Validado en visual tambien*/
  BEGIN
       declare @NumeroOferta nvarchar(50) = (select COUNT(OF_NUMERO) from MANA.OFERTA) 
       set @NumeroOferta = @NumeroOferta +1
  insert into MANA.OFERTA values (@NumeroOferta, @Descripcion, @FechaPublicacion, @FechaVencimiento, @PrecioOferta, @PrecioLista, @ProveedorId , @CantidadDisponible, @MaximoUnidadesPorCliente,'En Espera');     
  END
GO

CREATE FUNCTION MANA.ObtenerMaximoUnidadOferta (@NumeroOferta nvarchar(50)) /*Retorna el valor del campo MaximoUnidadCliente de la Oferta ingresada */
RETURNS INT
AS
BEGIN
 return (SELECT OF_MAXIMO_UNIDAD_CLIENTE FROM MANA.OFERTA WHERE OF_NUMERO = @NumeroOferta)
END
GO

CREATE FUNCTION MANA.ObtenerProveedorOferta (@NumeroOferta nvarchar(50))  /*Retorna el valor del campo Proveedor_Id de la Oferta Ingresada*/
RETURNS INT
AS
BEGIN
  return ( select O.OF_PROVEEDOR_ID from MANA.OFERTA O where O.OF_NUMERO = @NumeroOferta )
END	   
GO

CREATE PROCEDURE MANA.ActualizarStock @NumeroOferta nvarchar(50), @CantidadAdquirida int  /*Actualiza el stock de la oferta, modificando el campo Cantidad Disponible*/
AS
 UPDATE OFERTA
 SET OF_CANTIDAD_DISPONIBLE = OF_CANTIDAD_DISPONIBLE - @CantidadAdquirida
 WHERE OF_NUMERO = @NumeroOferta
GO
                              /*Registra el canje de 1 cupon en la tabla CONSUMO_OFERTA*/
CREATE PROCEDURE MANA.CrearConsumoOferta @FechaEntrega datetime, @ProveedorId int, @CuponId int, @C_Dest_Nombre nvarchar(255), @C_Dest_Apellido nvarchar(255), @C_Dest_Dni numeric(18), 
                                 @C_Dest_Direccion nvarchar(255), @C_Dest_Telefono numeric(18), @C_Dest_Mail nvarchar(255), @C_Dest_Fecha_Nac datetime, @C_Dest_Ciudad nvarchar(255)
AS         
insert into MANA.CONSUMO_OFERTA values (@FechaEntrega, @ProveedorId, @CuponId, @C_Dest_Nombre, @C_Dest_Apellido, @C_Dest_Dni, @C_Dest_Direccion, @C_Dest_Telefono, @C_Dest_Mail, @C_Dest_Fecha_Nac, @C_Dest_Ciudad)
GO
                             /*Crea 1 cupon, registrando los datos en la tabla CUPON*/
CREATE PROCEDURE MANA.CrearCupon @FechaCompra datetime, @OfertaNumero nvarchar(50), @PrecioOferta numeric(18), @PrecioLista numeric(18), @CantidadAdquirida int, @Importe numeric (18), @ClienteId int, @FechaValidez datetime
AS
insert into MANA.CUPON values (@FechaCompra, @OfertaNumero, @PrecioOferta, @PrecioLista, @CantidadAdquirida, @Importe, @ClienteId, 'Habilitado', @FechaValidez)
GO
                              /*Registra la baja de 1 cupon, cambiando su estado a Deshabilitado*/
CREATE PROCEDURE MANA.BajaCupon (@CuponId int, @NumeroOferta nvarchar(50))
AS
  UPDATE MANA.CUPON
  SET CUPON_ESTADO = 'Deshabilitado'
  WHERE CUPON_ID = @CuponId  and CUPON_NUMERO_OFERTA = @NumeroOferta
GO

CREATE FUNCTION MANA.ObtenerEstadoCupon (@CuponId int)  /*Obtiene el estado del Cupon ingresado*/
RETURNS NVARCHAR
AS
BEGIN
  return( select C.CUPON_ESTADO from MANA.CUPON C where C.CUPON_ID = @CuponId)
END	   
GO

CREATE FUNCTION MANA.ObtenerNroOfertaCupon (@CuponId int)   /*Obtiene el valor del campo Numero Oferta del Cupon ingresado*/
RETURNS NVARCHAR
AS
BEGIN
 return (select C.CUPON_NUMERO_OFERTA from MANA.CUPON C where C.CUPON_ID = @CuponId)
END
GO

                      /*Registra la Oferta Vendida en la tabla OFERTA_VENDIDA*/
CREATE PROCEDURE MANA.RegistrarOfertaVendida @FechaCompra datetime, @CuponId int, @ProveedorId int, @OfertaNumero nvarchar(50), @Importe numeric(18)
AS
    insert into MANA.OFERTA_VENDIDA values (@FechaCompra, @CuponId, @ProveedorId, @OfertaNumero, @Importe)
GO

/*Registra la Compra de 1 Oferta en la tabla Oferta Vendida y los procesos consecuentes: Generacion de 1 Cupon, Actualizacion de saldo de 1 Cliente y del Stock de la Oferta*/
CREATE PROCEDURE MANA.ComprarOferta @FechaCompra datetime, @OfertaNumero nvarchar(50), @PrecioOferta numeric(18), @PrecioLista numeric(18), @CantidadAdquirida int, @ClienteId int, @FechaValidez datetime
AS
       declare @Importe numeric(18)
       set @Importe = @PrecioOferta * @CantidadAdquirida
                            /*Valido el saldo del Cliente y QUE CUMPLA CON LA RESTRICCION DE MAX UNIDADES POR COMPRA POR CLIENTE */  
  IF(Mana.ObtenerSaldo(@ClienteId) >= @Importe AND @CantidadAdquirida <= Mana.ObtenerMaximoUnidadOferta(@OfertaNumero)) 
 BEGIN                                          	   
	   declare @ProvId int
	   declare @CuponId int	        	  
	   set @ProvId = Mana.ObtenerProveedorOferta (@OfertaNumero)
  	   	                                                                                           /*Genero el Cupon*/ 
	   EXECUTE Mana.CrearCupon @FechaCompra, @OfertaNumero, @PrecioOferta, @PrecioLista, @CantidadAdquirida, @Importe, @ClienteId, @FechaValidez	  
	   EXECUTE Mana.DescontarSaldo @ClienteId, @Importe                                            /*Actualizo saldo de Cliente*/
       EXECUTE Mana.ActualizarStock @OfertaNumero, @CantidadAdquirida                              /*Actualizo el stock de la Oferta*/	   

	   set @CuponId = (select max(CUPON_ID) from CUPON)                                            /*Obtengo Id del Cupon Generado*/
	   EXECUTE Mana.RegistrarOfertaVendida @FechaCompra, @CuponId, @ProvId, @OfertaNumero, @Importe          /*Registro la compra*/      
 END
GO

  /*Canjea 1 Cupon registrandolo en la tabla CONSUMO_OFERTA y actualizando el campo Estado del Cupon a Deshabilitado*/
CREATE PROCEDURE MANA.CanjearCupon @CuponId int, @NumeroOferta nvarchar(50), @ProveedorId int, @FechaEntrega datetime, @C_Dest_Nombre nvarchar(255), @C_Dest_Apellido nvarchar(255), @C_Dest_Dni numeric(18), 
                                @C_Dest_Direccion nvarchar(255), @C_Dest_Telefono numeric(18), @C_Dest_Mail nvarchar(255), @C_Dest_Fecha_Nac datetime, @C_Dest_Ciudad nvarchar(255)
AS   
    /*El cupon esta habilitado desde su creacion; si ya fue canjeado o ya se vencio va a estar Deshabilitado -> Valido que no este deshabilitado y que la Oferta pertenezca al proveedor que quiere canjear el cupon */
  IF((Mana.ObtenerProveedorOferta(@NumeroOferta) = @ProveedorId) AND (Mana.ObtenerEstadoCupon(@CuponId) != 'Deshabilitado' ))
   BEGIN
    EXECUTE MANA.BajaCupon @CuponId, @NumeroOferta                                                     /*Baja Logica del Cupon*/                                                 
    EXECUTE Mana.CrearConsumoOferta @FechaEntrega, @ProveedorId, @CuponId, @C_Dest_Nombre, @C_Dest_Apellido, @C_Dest_Dni, @C_Dest_Direccion, 
                                  @C_Dest_Telefono, @C_Dest_Mail, @C_Dest_Fecha_Nac, @C_Dest_Ciudad  /*Registramos la baja del Cupon en la tabla ConsumoOferta */
   END 
GO


/**Factura**/

CREATE PROCEDURE MANA.CrearItemFactura @OfertaVendidaId int /*Registra todas las Ofertas Vendidas que se facturan en la tabla ITEM_FACTURA*/
AS
    declare @FactNro int
	declare @Importe numeric
    set @FactNro =  (select max(FACT_NUMERO) from FACTURA) + 1
	set @Importe =  (select CUPON_IMPORTE from CUPON where CUPON_ID = (SELECT OF_VEN_CUPON_ID FROM OFERTA_VENDIDA WHERE OF_VEN_ID = @OfertaVendidaId))
  IF(NOT EXISTS(SELECT I_FACT_OF_VEN_ID FROM ITEM_FACTURA WHERE I_FACT_OF_VEN_ID = @OfertaVendidaId)) /*Valido que la Oferta NO se haya facturado*/
    insert into MANA.ITEM_FACTURA values (@FactNro, @OfertaVendidaId, @Importe)
GO

CREATE PROCEDURE MANA.CrearFactura @FacturaNro int, @ImporteTotal numeric(18), @ProvId int  /*Registra las Facturas realizadas en la tabla FACTURA*/
AS     
	insert into MANA.FACTURA values(@FacturaNro, GETDATE(), @ImporteTotal, @ProvId)
GO

/*Factura todas las Ofertas Vendidas de 1 Proveedor, registrando cada Oferta Vendida facturada en la tabla ITEM_FACTURA y la factura generada en la tabla FACTURA*/
CREATE PROCEDURE MANA.FacturarOfertasAProveedor @ProveedorId int, @FechaInicio datetime, @FechaFinal datetime
AS   	
   declare @OfertaVendidaId int    

 IF((select COUNT(OF_VEN_ID) from OFERTA_VENDIDA where OF_VEN_PROV_ID = @ProveedorId AND OF_VEN_FECHA_COMPRA BETWEEN @FechaInicio AND @FechaFinal) != 0) /*Valido que existan Ofertas entre esas fechas*/
  BEGIN
   declare OfertaVendida CURSOR FOR
   select OF_VEN_ID from OFERTA_VENDIDA where OF_VEN_PROV_ID = @ProveedorId AND OF_VEN_FECHA_COMPRA BETWEEN @FechaInicio AND @FechaFinal
   Open OfertaVendida
   FETCH NEXT FROM OfertaVendida into @OfertaVendidaId
   --check for a new row
   WHILE @@FETCH_STATUS = 0
   BEGIN                                              
    EXECUTE MANA.CrearItemFactura @OfertaVendidaId     /*Facturo todas las Ofertas Vendidas y lo registro en Item Factura*/
	FETCH NEXT FROM OfertaVendida into @OfertaVendidaId
   END
   close OfertaVendida
   Deallocate OfertaVendida	  
                 /*Si las todas las ofertas que estaban entre las fechas ya estaban facturadas -> No se factura ninguna oferta -> NO se Creo ningun Item en la Factura*/ 
     BEGIN TRANSACTION                           
       declare @FactNro int
	   declare @ImporteTotal numeric(18)  
	   set @FactNro = (select max(FACT_NUMERO) from FACTURA) + 1
	   set @ImporteTotal = (select SUM(I_FACT_IMPORTE) FROM ITEM_FACTURA WHERE I_FACT_NUMERO = @FactNro)   /*Calculo el importe total de la factura */  
       EXECUTE MANA.CrearFactura @FactNro, @ImporteTotal, @ProveedorId      /*Creo la factura*/          
	                                                                  
	 IF((SELECT COUNT(I_FACT_ID) FROM ITEM_FACTURA WHERE I_FACT_NUMERO = @FactNro) != 0)     
	  COMMIT TRANSACTION          	               /*Si hubo ofertas facturadas -> Se genera la Factura*/
	 ELSE                                          
	  ROLLBACK TRANSACTION                         /*Si No hubo ofertas facturadas -> No se genera la Factura*/ 	  	   	 
  END     
GO

