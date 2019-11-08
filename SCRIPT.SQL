USE GD2C2019
GO

--DROP CONSTRAINTS (FKs)
/*La primera vez que ejecuten el SCRIPT haganlo con los DROP CONSTRAINTS Comentado. 
  Desde la 2da en adelante saquen los comentarios a DROP CONSTRAINTS para ejecutar para que no tengan problemas con las FK y la consulta sea ejecutada siempre correctamente*/

/*  
ALTER TABLE [MANA].PROVEEDOR DROP CONSTRAINT FK_RUBRO_ID;
ALTER TABLE [MANA].FACTURA DROP CONSTRAINT FK_OF_VEN_ID;
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
IF OBJECT_ID('MANA.MigrarCargaCredito') IS NOT NULL
    DROP PROCEDURE MANA.MigrarCargaCredito;
IF OBJECT_ID('MANA.MigrarTipoPago') IS NOT NULL
    DROP PROCEDURE MANA.MigrarTipoPago;			
IF OBJECT_ID('MANA.MigrarOferta') IS NOT NULL
    DROP PROCEDURE MANA.MigrarOferta;			
IF OBJECT_ID('MANA.MigrarOfertaVendida') IS NOT NULL
    DROP PROCEDURE MANA.MigrarOfertaVendida;
IF OBJECT_ID('MANA.MigrarFactura') IS NOT NULL
    DROP PROCEDURE MANA.MigrarFactura;
	      /*Login, Usuario, Rol */
IF OBJECT_ID('MANA.LoginFallido') IS NOT NULL
    DROP PROCEDURE MANA.LoginFallido;
IF OBJECT_ID('MANA.LimpiarLoginFallido') IS NOT NULL
    DROP PROCEDURE MANA.LimpiarLoginFallido;
IF OBJECT_ID('MANA.CrearRol') IS NOT NULL
    DROP PROCEDURE MANA.CrearRol;
IF OBJECT_ID('MANA.ObtenerRoles') IS NOT NULL
    DROP PROCEDURE MANA.ObtenerRoles;
IF OBJECT_ID('MANA.FuncionalidadRol_VW') IS NOT NULL
    DROP VIEW MANA.FuncionalidadRol_VW;
IF OBJECT_ID('MANA.ObtenerFuncionalidadesDeRol') IS NOT NULL
    DROP PROCEDURE MANA.ObtenerFuncionalidadesDeRol;	
IF OBJECT_ID('MANA.EliminarFuncionalidadesDeRol') IS NOT NULL
    DROP PROCEDURE MANA.EliminarFuncionalidadesDeRol;
IF OBJECT_ID('MANA.EliminarUsuariosDeRol') IS NOT NULL
    DROP PROCEDURE MANA.EliminarUsuariosDeRol;	
IF OBJECT_ID('MANA.CambiarNombreDeRol') IS NOT NULL
    DROP PROCEDURE MANA.CambiarNombreDeRol;
IF OBJECT_ID('MANA.HabilitarRol') IS NOT NULL
    DROP PROCEDURE MANA.HabilitarRol;			
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
IF OBJECT_ID('MANA.BajaUsuario') IS NOT NULL
    DROP PROCEDURE MANA.BajaUsuario;
IF OBJECT_ID('MANA.CambiarPassword') IS NOT NULL
    DROP PROCEDURE MANA.CambiarPassword;
             /*Cliente*/
IF OBJECT_ID('MANA.CrearCliente') IS NOT NULL
    DROP PROCEDURE MANA.CrearCliente;	
IF OBJECT_ID('MANA.ModificarCliente') IS NOT NULL
    DROP PROCEDURE MANA.ModificarCliente;
IF OBJECT_ID('MANA.HabilitarCliente') IS NOT NULL
    DROP PROCEDURE MANA.HabilitarCliente;
IF OBJECT_ID('MANA.BajaCliente') IS NOT NULL
    DROP PROCEDURE MANA.BajaCliente;
IF OBJECT_ID('MANA.CargarTipoPago') IS NOT NULL
    DROP PROCEDURE MANA.CargarTipoPago;
IF OBJECT_ID('MANA.ObtenerIdTipopago') IS NOT NULL
    DROP FUNCTION MANA.ObtenerIdTipoPago;
IF OBJECT_ID('MANA.CargarSaldo') IS NOT NULL
    DROP PROCEDURE MANA.CargarSaldo;
IF OBJECT_ID('MANA.DescontarSaldo') IS NOT NULL
    DROP PROCEDURE MANA.DescontarSaldo;
IF OBJECT_ID('MANA.CargarCredito') IS NOT NULL
    DROP PROCEDURE MANA.CargarCredito;
            /*Proveedor*/
IF OBJECT_ID('MANA.ObtenerIdRubro') IS NOT NULL
    DROP FUNCTION MANA.ObtenerIdRubro;		
IF OBJECT_ID('MANA.CrearProveedor') IS NOT NULL
    DROP PROCEDURE MANA.CrearProveedor;	
IF OBJECT_ID('MANA.ModificarProveedor') IS NOT NULL
    DROP PROCEDURE MANA.ModificarProveedor;
IF OBJECT_ID('MANA.HabilitarProveedor') IS NOT NULL
    DROP PROCEDURE MANA.HabilitarProveedor;
IF OBJECT_ID('MANA.BajaProveedor') IS NOT NULL
    DROP PROCEDURE MANA.BajaProveedor;
	        /*Oferta*/
IF OBJECT_ID('MANA.CrearConsumoOferta') IS NOT NULL
    DROP PROCEDURE MANA.CrearConsumoOferta;
IF OBJECT_ID('MANA.CrearCupon') IS NOT NULL
    DROP PROCEDURE MANA.CrearCupon;
IF OBJECT_ID('MANA.BajaCupon') IS NOT NULL
    DROP PROCEDURE MANA.BajaCupon;
IF OBJECT_ID('MANA.ObtenerIdCupon') IS NOT NULL
    DROP FUNCTION MANA.ObtenerIdCupon;
IF OBJECT_ID('MANA.ObtenerEstadoCupon') IS NOT NULL
    DROP FUNCTION MANA.ObtenerEstadoCupon;
IF OBJECT_ID('MANA.ObtenerProveedorOferta') IS NOT NULL
    DROP FUNCTION MANA.ObtenerProveedorOferta;
IF OBJECT_ID('MANA.ValidarCupon') IS NOT NULL
    DROP PROCEDURE MANA.ValidarCupon;
IF OBJECT_ID('MANA.CanjearCupon') IS NOT NULL
    DROP PROCEDURE MANA.CanjearCupon;							
IF OBJECT_ID('MANA.CrearOferta') IS NOT NULL
    DROP PROCEDURE MANA.CrearOferta;
IF OBJECT_ID('MANA.BajaOferta') IS NOT NULL
    DROP PROCEDURE MANA.BajaOferta;			
						
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
	PROV_ESTADO NVARCHAR(20),
	
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
	CLI_SALDO NUMERIC(18) DEFAULT 200,
	CLI_ESTADO NVARCHAR(20),
	
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
	OF_MAXIMO_UNIDAD_COMPRA INT,
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
	CUPON_CLI_ID INT,
	CUPON_ESTADO NVARCHAR(20),
	
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

	CONSTRAINT OFVEN_PK PRIMARY KEY (OF_VEN_ID)
);

CREATE TABLE [MANA].FACTURA (
    FACT_ID INT NOT NULL IDENTITY,
	FACT_NUMERO NUMERIC(18),
	FACT_FECHA DATETIME,
	FACT_OF_VEN_ID INT, 
	FACT_IMPORTE NUMERIC(18),
	
	CONSTRAINT FACT_PK PRIMARY KEY (FACT_ID)
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
ALTER TABLE [MANA].FACTURA ADD CONSTRAINT FK_OF_VEN_ID FOREIGN KEY (FACT_OF_VEN_ID) REFERENCES [MANA].OFERTA_VENDIDA (OF_VEN_ID);
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
GO 


/** TRIGGERS **/

create TRIGGER MANA.PublicarOferta
on MANA.OFERTA
   after INSERT
AS
BEGIN
  Update OFERTA set OF_ESTADO = 'Habilitado' where OFERTA.OF_NUMERO in
  (select O.OF_NUMERO
    from OFERTA O
	where O.OF_FECHA_PUBLICACION <= GETDATE())
END
GO

create TRIGGER MANA.ValidarVencimientoOferta 
on MANA.OFERTA
   after INSERT
AS
BEGIN
   Update OFERTA set OF_ESTADO = 'Deshabilitado' where OFERTA.OF_NUMERO in
   (select O.OF_NUMERO
    from OFERTA O
	where O.OF_FECHA_VENCIMIENTO <= GETDATE())
END
GO

/*El cupon vence cuando vence la oferta, hasta esa fecha tenes tiempo de canjearlo*/
create TRIGGER MANA.ValidarVencimientoCupon
   on MANA.CUPON
   after INSERT
AS
BEGIN
   update CUPON set CUPON_ESTADO = 'Deshabilitado' where CUPON_ID in
   (select CUPON_ID
    from CUPON C, OFERTA O
	where C.CUPON_NUMERO_OFERTA = O.OF_NUMERO AND O.OF_FECHA_VENCIMIENTO <= GETDATE())
END
GO



/** MIGRACION **/

/*Cliente*/

CREATE PROCEDURE MANA.MigrarCliente
AS
insert into MANA.CLIENTE
select M.Cli_Nombre, M.Cli_Apellido, M.Cli_Dni, M.Cli_Mail, M.Cli_Telefono, M.Cli_Direccion, NULL as CODIGO_POSTAL, M.Cli_Ciudad, M.Cli_Fecha_Nac, 200 as SALDO, 'Habilitado'
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
where M.Provee_Rubro IS NOT NULL 
group by M.Provee_Rubro
GO

MANA.MigrarRubro
GO	

/*Proveedor*/

CREATE PROCEDURE MANA.MigrarProveedor
AS
insert into MANA.PROVEEDOR
select M.Provee_RS, M.Provee_CUIT, NULL as NOMBRE_CONTACO, NULL as EMAIL, M.Provee_Telefono, M.Provee_Dom, NULL as CODIGO_POSTAL, M.Provee_Ciudad, R.RUBRO_ID, 'Habilitado'
from gd_esquema.Maestra M, MANA.RUBRO R
where  M.Provee_Rubro = R.RUBRO_DESCRIPCION
group by M.Provee_RS, M.Provee_CUIT, M.Provee_Telefono, M.Provee_Dom, M.Provee_Ciudad, R.RUBRO_ID
GO

MANA.MigrarProveedor
GO

/*Tipo Pago*/

CREATE PROCEDURE MANA.MigrarTipoPago
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

CREATE PROCEDURE MANA.MigrarCargaCredito
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

CREATE PROCEDURE MANA.MigrarOferta
AS
insert into MANA.OFERTA
select M.Oferta_Codigo, M.Oferta_Descripcion, M.Oferta_Fecha, M.Oferta_Fecha_Venc, M.Oferta_Precio, M.Oferta_Precio_Ficticio, P.PROV_ID, M.Oferta_Cantidad, NULL as Maximo_Unidad_Por_Compra ,'En Espera'
from gd_esquema.Maestra M, MANA.PROVEEDOR P 
where
   (M.Provee_RS = P.PROV_RAZON_SOCIAL AND
	M.Provee_CUIT = P.PROV_CUIT AND
	M.Provee_Telefono = P.PROV_TELEFONO AND
	M.Provee_Dom = P.PROV_DIRECCION AND
	M.Provee_Ciudad = P.PROV_CIUDAD)	
group by M.Oferta_Codigo, M.Oferta_Descripcion, M.Oferta_Fecha, M.Oferta_Fecha_Venc, M.Oferta_Precio, M.Oferta_Precio_Ficticio, P.PROV_ID, M.Oferta_Cantidad
ORDER BY P.PROV_ID	
GO

MANA.MigrarOferta
GO

/*Cupon*/

CREATE PROCEDURE MANA.MigrarCupon
AS
insert into MANA.CUPON
select M.Oferta_Fecha_Compra, M.Oferta_Codigo, M.Oferta_Precio, M.Oferta_Precio_Ficticio, NULL as Cantidad_Adquirida, C.CLI_ID, 'Habilitado'
from gd_esquema.Maestra M, MANA.CLIENTE C
where
    M.Oferta_Fecha_Compra IS NOT NULL AND
	M.Cli_Nombre = C.CLI_NOMBRE AND
	M.Cli_Apellido = C.CLI_APELLIDO AND
	M.Cli_Dni = C.CLI_DNI AND
	M.Cli_Mail = C.CLI_MAIL AND
	M.Cli_Telefono = C.CLI_TELEFONO AND
	M.Cli_Direccion = C.CLI_DIRECCION AND
	M.Cli_Ciudad = C.CLI_CIUDAD AND
	M.Cli_Fecha_Nac = C.CLI_FECHA_NACIMIENTO		
group by M.Oferta_Fecha_Compra, M.Oferta_Codigo, M.Oferta_Precio, M.Oferta_Precio_Ficticio, C.CLI_ID
GO

MANA.MigrarCupon
GO

/*Consumo Oferta*/  

CREATE PROCEDURE MANA.MigrarConsumoOferta
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

/*Oferta Vendida a facturar*/

CREATE PROCEDURE MANA.MigrarOfertaVendida
AS
insert into MANA.OFERTA_VENDIDA
select M.Oferta_Fecha_Compra, C.CUPON_ID , P.PROV_ID, M.Oferta_Codigo
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
group by M.Oferta_Fecha_Compra, C.CUPON_ID, P.PROV_ID, M.Oferta_Codigo
GO

Mana.MigrarOfertaVendida
GO

/*Factura*/

CREATE PROCEDURE MANA.MigrarFactura
AS
insert into MANA.FACTURA
select DISTINCT M.Factura_Nro, M.Factura_Fecha, OV.OF_VEN_ID, NULL as IMPORTE
from gd_esquema.Maestra M, MANA.OFERTA_VENDIDA OV
where
    M.Factura_Nro is not null AND
   (M.Oferta_Fecha_Compra = OV.OF_VEN_FECHA_COMPRA AND M.Oferta_Codigo = OV.OF_VEN_OF_NUMERO)  
group by M.Factura_Nro, M.Factura_Fecha, OV.OF_VEN_ID	 
GO

Mana.MigrarFactura
GO




/** STORES PROCEDURES PARA LA APLICACION **/


/*Login*/

CREATE PROCEDURE MANA.LoginFallido @Username nvarchar(20)
AS
BEGIN
	DECLARE @Nueva_Cant_Int_Fallidos int
	SET @Nueva_Cant_Int_Fallidos = (SELECT USER_INTENTOS_FALLIDOS FROM MANA.USUARIO WHERE USER_USERNAME = @Username) + 1

	IF @Nueva_Cant_Int_Fallidos >= 3
		BEGIN
			UPDATE MANA.USUARIO 
				SET USER_INTENTOS_FALLIDOS = @Nueva_Cant_Int_Fallidos
				WHERE USER_USERNAME = @Username            
		END		
	ELSE
		BEGIN
			UPDATE MANA.USUARIO 
				SET USER_INTENTOS_FALLIDOS = @Nueva_Cant_Int_Fallidos
				WHERE USER_USERNAME = @Username 
		END
END
GO

CREATE PROCEDURE MANA.LimpiarLoginFallido @Username nvarchar(20)
AS
BEGIN
	UPDATE MANA.USUARIO 
	  SET USER_INTENTOS_FALLIDOS = 0
	  WHERE USER_USERNAME = @Username 
END
GO



/*Rol*/

CREATE PROCEDURE MANA.CrearRol @Nombre nvarchar(20)
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

CREATE PROCEDURE MANA.ObtenerRoles  
AS
   	select R.ROL_ID, R.ROL_NOMBRE, R.ROL_ESTADO
	from MANA.ROL R
GO

CREATE VIEW MANA.FuncionalidadRol_VW
AS 
select R.ROL_ID, R.ROL_NOMBRE,F.FUNC_ID, F.FUN_NOMBRE
from
    MANA.ROL R,
    MANA.FUNCIONALIDAD_ROL FR,
    MANA.FUNCIONALIDAD F
where R.ROL_ID = FR.FR_ROL_ID AND FR.FR_FUNCIONALIDAD_ID = F.FUNC_ID    
GO

CREATE PROCEDURE MANA.ObtenerFuncionalidadesDeRol @RolID int
AS
    select FR.FUNC_ID, FR.FUN_NOMBRE
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

CREATE PROCEDURE MANA.HabilitarRol @RolId int
AS
    update MANA.ROL
    SET ROL_ESTADO = 'Habilitado'
    where ROL_ID = @RolId
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
  insert into MANA.FUNCIONALIDAD values('Abm Oferta');
  insert into MANA.FUNCIONALIDAD values('Comprar Oferta');
  insert into MANA.FUNCIONALIDAD values('Facturacion');
  insert into MANA.FUNCIONALIDAD values('Listado Estadistico');
GO

MANA.CrearFuncionalidades
GO


/*Funcionalidad Rol*/

CREATE PROCEDURE MANA.AsignarFuncionRol @RolID int, @FuncionID int
AS
IF(NOT EXISTS(SELECT FR_ROL_ID, FR_FUNCIONALIDAD_ID FROM MANA.FUNCIONALIDAD_ROL WHERE FR_ROL_ID = @RolID AND FR_FUNCIONALIDAD_ID = @FuncionID))
BEGIN
insert into MANA.FUNCIONALIDAD_ROL values (@RolID,@FuncionID);
END
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

/*Funcionalidades de Administrador General*/
MANA.AsignarFuncionesAdministrador
GO
/*Funcionalidades de Cliente*/
Mana.AsignarFuncionRol 2, 4
GO
Mana.AsignarFuncionRol 2, 6
GO
/*Funcionalidades de Proveedor*/
Mana.AsignarFuncionRol 3, 5
GO
/*Funcionalidades de Administrativo*/
Mana.AsignarFuncionRol 4, 2
GO
Mana.AsignarFuncionRol 4, 3
GO
Mana.AsignarFuncionRol 4, 5
GO
Mana.AsignarFuncionRol 4, 7
GO
Mana.AsignarFuncionRol 4, 8
GO


/*Usuario*/

CREATE PROCEDURE MANA.CrearUsuario @Username nvarchar(20), @Password nvarchar(20)
AS
IF(NOT EXISTS(SELECT USER_USERNAME FROM MANA.USUARIO WHERE USER_USERNAME = @Username))
BEGIN
insert into MANA.USUARIO values (@Username, @Password, 0, 'Habilitado');
END
GO
/*Creo el Usuario Admin, pedido en enunciado*/
Mana.CrearUsuario 'admin', 'w23e'
GO

CREATE PROCEDURE MANA.BajaUsuario @Username nvarchar(20)
AS
UPDATE MANA.USUARIO
SET USUARIO_ESTADO = 'Deshabilitado'
WHERE USER_USERNAME = @Username
GO

CREATE PROCEDURE MANA.CambiarPassword @Username nvarchar(20), @Password nvarchar(20)
AS
UPDATE MANA.USUARIO
SET USER_PASSWORD = @Password
WHERE USER_USERNAME = @Username
GO

/*UsuarioRol*/

CREATE PROCEDURE MANA.AsignarUsuarioRol @Username nvarchar(20), @RolNombre nvarchar(20)
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



/*ABM Cliente*/

CREATE PROCEDURE MANA.CrearCliente @Nombre nvarchar(255), @Apellido nvarchar(255), @Dni numeric(18), @Mail nvarchar(255), 
                                   @Telefono numeric(18), @Direccion nvarchar(255), @CodigoPostal nvarchar(18), @Ciudad nvarchar(255), @FechaNac datetime
AS
IF(NOT EXISTS(SELECT CLI_NOMBRE, CLI_APELLIDO, CLI_DNI FROM MANA.CLIENTE 
              where CLI_NOMBRE = @Nombre AND CLI_APELLIDO = @Apellido AND CLI_DNI = @Dni))
BEGIN
insert into MANA.CLIENTE values(@Nombre, @Apellido, @Dni, @Mail, @Telefono, @Direccion, @CodigoPostal, @Ciudad, @FechaNac, 200, 'Habilitado');
END
GO

CREATE PROCEDURE MANA.ModificarCliente @ID int, @Nombre nvarchar(255), @Apellido nvarchar(255), @Dni numeric(18), @Mail nvarchar(255), 
                                   @Telefono numeric(18), @Direccion nvarchar(255), @CodigoPostal nvarchar(18), @Ciudad nvarchar(255), @FechaNac datetime
AS
IF(NOT EXISTS(SELECT CLI_NOMBRE, CLI_APELLIDO, CLI_DNI FROM MANA.CLIENTE 
              where CLI_NOMBRE = @Nombre AND CLI_APELLIDO = @Apellido AND CLI_DNI = @Dni))
BEGIN
   UPDATE MANA.CLIENTE
   SET  CLI_NOMBRE = @Nombre, CLI_APELLIDO = @Apellido, CLI_DNI = @Dni, CLI_MAIL = @Mail, CLI_TELEFONO = @Telefono,
	    CLI_DIRECCION = @Direccion, CLI_CODIGO_POSTAL = @CodigoPostal, CLI_CIUDAD = @Ciudad, CLI_FECHA_NACIMIENTO = @FechaNac
	  WHERE CLI_ID = @ID
END
GO

CREATE PROCEDURE MANA.HabilitarCliente @ClienteId int
AS
  UPDATE MANA.CLIENTE
  SET CLI_ESTADO = 'Habilitado'
  WHERE CLI_ID = @ClienteId
GO

CREATE PROCEDURE MANA.BajaCliente @Nombre nvarchar(255), @Apellido nvarchar(255), @Dni numeric(18), @Mail nvarchar(255)
AS
   UPDATE MANA.CLIENTE
      SET   CLI_ESTADO = 'Deshabilitado'
	  WHERE CLI_NOMBRE = @Nombre AND CLI_APELLIDO = @Apellido AND CLI_DNI = @Dni AND CLI_MAIL = @Mail
GO

CREATE PROCEDURE MANA.CargarTipoPago @TipoPago nvarchar(100)
AS
   insert into MANA.TIPO_PAGO values (@TipoPago);  
GO
/*Faltaba esta opcion en la maestra*/
Mana.CargarTipoPago 'Debito'
GO

CREATE FUNCTION MANA.ObtenerIdTipoPago (@TipoPago nvarchar(100))
RETURNS INT
AS
BEGIN
return (SELECT TP_ID FROM MANA.TIPO_PAGO where TP_DESCRIPCION = @TipoPago )
END  
GO

CREATE PROCEDURE MANA.CargarSaldo @ClienteId int, @Monto numeric(18)
AS
UPDATE MANA.CLIENTE
SET CLI_SALDO = CLI_SALDO + @Monto
WHERE CLI_ID = @ClienteId 
GO

CREATE PROCEDURE MANA.DescontarSaldo @ClienteId int, @Monto numeric(18)
AS
UPDATE MANA.CLIENTE
SET CLI_SALDO = CLI_SALDO - @Monto
WHERE CLI_ID = @ClienteId
GO

CREATE PROCEDURE MANA.CargarCredito @FechaCarga datetime, @ClienteId int, @TipoPago nvarchar(100), @Monto numeric(18), @NumeroTarjeta int
AS
  insert into MANA.CARGA_CREDITO values (@FechaCarga, @ClienteId, Mana.ObtenerIdTipoPago(@TipoPago), @Monto, @NumeroTarjeta)
  EXECUTE MANA.CargarSaldo @ClienteId, @Monto
GO



/*ABM Proveedor*/

CREATE FUNCTION MANA.ObtenerIdRubro (@Rubro nvarchar(100))
RETURNS INT
AS
BEGIN
  return( select RUBRO_ID from MANA.RUBRO where RUBRO_DESCRIPCION = @Rubro )
END	   
GO   

CREATE PROCEDURE MANA.CrearProveedor @RazonSocial nvarchar(100), @CUIT nvarchar(20), @NombreContacto nvarchar(20), @Mail nvarchar(100), 
                                   @Telefono numeric(18), @Direccion nvarchar(100), @CodigoPostal nvarchar(18), @Ciudad nvarchar(255), @Rubro nvarchar(100)
AS
IF(NOT EXISTS(SELECT PROV_RAZON_SOCIAL, PROV_CUIT FROM MANA.PROVEEDOR 
              where PROV_RAZON_SOCIAL = @RazonSocial AND PROV_CUIT = @CUIT))
BEGIN
insert into MANA.PROVEEDOR values(@RazonSocial, @CUIT, @NombreContacto, @Mail, @Telefono, @Direccion, @CodigoPostal, @Ciudad, MANA.ObtenerIdRubro(@Rubro),'Habilitado');
END
GO

CREATE PROCEDURE MANA.ModificarProveedor @ID int, @RazonSocial nvarchar(100), @NombreContacto nvarchar(20), @CUIT nvarchar(20), @Mail nvarchar(100), 
                                   @Telefono numeric(18), @Direccion nvarchar(100), @CodigoPostal nvarchar(18), @Ciudad nvarchar(255), @Rubro nvarchar(100)
AS
IF(NOT EXISTS(SELECT PROV_RAZON_SOCIAL, PROV_CUIT FROM MANA.PROVEEDOR 
              where PROV_RAZON_SOCIAL = @RazonSocial AND PROV_CUIT = @CUIT))
BEGIN
   UPDATE MANA.PROVEEDOR
   SET  PROV_RAZON_SOCIAL = @RazonSocial, PROV_CUIT = @CUIT, PROV_MAIL = @Mail, PROV_TELEFONO = @Telefono, 
	    PROV_DIRECCION = @Direccion, PROV_CODIGO_POSTAL = @CodigoPostal, PROV_CIUDAD = @Ciudad, PROV_RUBRO_ID = Mana.ObtenerIdRubro(@Rubro)
	  WHERE PROV_ID = @ID
END
GO

CREATE PROCEDURE MANA.HabilitarProveedor @RazonSocial nvarchar(100), @CUIT nvarchar(20)
AS
   UPDATE MANA.PROVEEDOR
      SET   PROV_ESTADO = 'Habilitado'
	  WHERE PROV_RAZON_SOCIAL = @RazonSocial AND PROV_CUIT = @CUIT
GO

CREATE PROCEDURE MANA.BajaProveedor @RazonSocial nvarchar(100), @CUIT nvarchar(20)
AS
   UPDATE MANA.PROVEEDOR
      SET   PROV_ESTADO = 'Deshabilitado'
	  WHERE PROV_RAZON_SOCIAL = @RazonSocial AND PROV_CUIT = @CUIT
GO




/*ABM Oferta*/

CREATE PROCEDURE MANA.CrearOferta @Descripcion nvarchar(255), @FechaPublicacion datetime, @FechaVencimiento datetime, @PrecioOferta numeric(18), @PrecioLista numeric(18), 
								  @ProveedorId int, @CantidadDisponible numeric (18), @MaximoUnidadesPorCompra int
AS
declare @NumeroOferta nvarchar(50) = 1  /*Autogenerar Codigo*/
IF(NOT EXISTS(SELECT OF_NUMERO FROM MANA.OFERTA where OF_NUMERO = @NumeroOferta ) AND @FechaPublicacion >= CONVERT(DATE,GETDATE()) AND @FechaVencimiento >= CONVERT(DATE,GETDATE()))
BEGIN
insert into MANA.OFERTA values (@NumeroOferta, @Descripcion, @FechaPublicacion, @FechaVencimiento, @PrecioOferta, @PrecioLista, @ProveedorId , @CantidadDisponible, @MaximoUnidadesPorCompra,'En Espera');
END
ELSE
BEGIN
set @NumeroOferta = @NumeroOferta +1
insert into MANA.OFERTA values (@NumeroOferta, @Descripcion, @FechaPublicacion, @FechaVencimiento, @PrecioOferta, @PrecioLista, @ProveedorId , @CantidadDisponible, @MaximoUnidadesPorCompra,'En Espera');
END
GO

CREATE FUNCTION MANA.ObtenerProveedorOferta (@NumeroOferta nvarchar(50))
RETURNS INT
AS
BEGIN
  return( select O.OF_PROVEEDOR_ID from MANA.OFERTA O where O.OF_NUMERO = @NumeroOferta )
END	   
GO

CREATE PROCEDURE MANA.CrearConsumoOferta @FechaEntrega datetime, @ProveedorId int, @CuponId int, @C_Dest_Nombre nvarchar(255), @C_Dest_Apellido nvarchar(255), @C_Dest_Dni numeric(18), 
                                 @C_Dest_Direccion nvarchar(255), @C_Dest_Telefono numeric(18), @C_Dest_Mail nvarchar(255), @C_Dest_Fecha_Nac datetime, @C_Dest_Ciudad nvarchar(255)
AS
insert into MANA.CONSUMO_OFERTA values (@FechaEntrega, @ProveedorId, @CuponId, @C_Dest_Nombre, @C_Dest_Apellido, @C_Dest_Dni, @C_Dest_Direccion, @C_Dest_Telefono, @C_Dest_Mail, @C_Dest_Fecha_Nac, @C_Dest_Ciudad)
GO

CREATE PROCEDURE MANA.CrearCupon @FechaCompra datetime, @OfertaNumero nvarchar(50), @PrecioOferta numeric(18), @PrecioLista numeric(18), @CantidadAdquirida int, @ClienteId int
AS
insert into MANA.CUPON values (@FechaCompra, @OfertaNumero, @PrecioOferta, @PrecioLista, @CantidadAdquirida, @ClienteId, 'Habilitado')
GO

CREATE PROCEDURE MANA.BajaCupon (@CuponId int, @NumeroOferta nvarchar(50))
AS
  UPDATE MANA.CUPON
  SET CUPON_ESTADO = 'Deshabilitado'
  WHERE CUPON_ID = @CuponId and CUPON_NUMERO_OFERTA = @NumeroOferta
GO

CREATE FUNCTION MANA.ObtenerEstadoCupon (@CuponId int)
RETURNS NVARCHAR
AS
BEGIN
  return( select C.CUPON_ESTADO from MANA.CUPON C where C.CUPON_ID = @CuponId)
END	   
GO

CREATE PROCEDURE MANA.CanjearCupon @CuponId int, @NumeroOferta nvarchar(50), @ProveedorId int, @FechaEntrega datetime, @C_Dest_Nombre nvarchar(255), @C_Dest_Apellido nvarchar(255), @C_Dest_Dni numeric(18), 
                                @C_Dest_Direccion nvarchar(255), @C_Dest_Telefono numeric(18), @C_Dest_Mail nvarchar(255), @C_Dest_Fecha_Nac datetime, @C_Dest_Ciudad nvarchar(255)
AS
 BEGIN 
    /*El cupon esta habilitado desde su creacion; si ya fue canjeado o ya se vencio va a estar Deshabilitado -> Si sigue habilitado es Valido -> VALIDAR EN VISUAL QUE CUPON ESTE HABILITADO ANTES DE CANJEAR*/
  IF(Mana.ObtenerProveedorOferta(@NumeroOferta) = @ProveedorId)
  EXECUTE MANA.BajaCupon @CuponId, @NumeroOferta
  EXECUTE Mana.CrearConsumoOferta @FechaEntrega, @ProveedorId, @CuponId, @C_Dest_Nombre, @C_Dest_Apellido, @C_Dest_Dni, @C_Dest_Direccion, @C_Dest_Telefono, @C_Dest_Mail, @C_Dest_Fecha_Nac, @C_Dest_Ciudad
 END
GO



/** Test **/

/*ABM Cliente*/
Mana.CrearCliente 'Gregory', 'House', 88430112, 'house@hotmail.com', 15856682, 'HOSPITAL521', 1252, 'Miami', '1985/06/10'
GO
Mana.ModificarCliente 5, 'Patrick', 'Jane', 62525087, 'jane@hotmail.com', 15534689, 'FBI5212', 1456, 'California', '1990/07/11'
GO
Mana.BajaCliente 'Adaia', 'Pino', 97990522, 'adaia@gmail.com'
GO    
Mana.CargarCredito '2020/10/07', 7, 'Debito', 500, 155648989
GO

/*ABM Proveedor*/
Mana.CrearProveedor 'Proveedor Cortinas S.R.L.', '11-22445103-2',  'Cortinas Congreso', 'cortinas@gmail.com', 43825679, 'Pozos618', 1256, 'CABA', 'Electronica' 
GO
Mana.ModificarProveedor 10, 'Proveedor Freddo S.R.L.', '71-43350643-1',  'Freddo', 'freddo@gmail.com', 48625167, 'Rivadavia6115', 1423, 'CABA', 'Comestibles' 
GO
Mana.BajaProveedor 'Proveedor N°13S.R.L.', '13-52415793-5'
GO

/*ABM Oferta*/
Mana.CrearOferta 'NotebookICoreI9', '2019/08/11', '2020/02/11', 15000, 20000, 15, 10, 2
GO
Mana.CrearOferta 'CelularMotorolaE5', '2019/09/11', '2025/05/11', 7700, 12500, 12, 15, 5
GO
Mana.CanjearCupon 5, 'AZHEVYMSAC6', 26, '2020-01-08', 'Mirtha', 'Legrand', 00000001, NULL, 41114565, 'eltrece 99', '1920/04/10', 'CABA'			
GO
Mana.BajaCupon 3, 'AFMGNLXQFD10'
GO				                    