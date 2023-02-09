USE [master]
GO
DROP DATABASE [MOSSA]
GO
CREATE DATABASE [MOSSA]
GO
USE [MOSSA]
GO


CREATE TABLE [dbo].[TBITACORA](
	[ConsecutivoError] [int] IDENTITY(1,1) NOT NULL,
	[IDusuario] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[CodigoError] [int] NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Origen] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TBITACORA] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoError] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/*Doctores*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctores](
	[IdDoctor] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuarioFK] [int] NOT NULL,
	[HoraEntrada] datetime NOT NULL,
	[HoraSalida] datetime NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDoctor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*Planilla*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planilla](
	[idPlanilla] [int] IDENTITY(1,1) NOT NULL,
	[IdDoctorFK] [int] NOT NULL,
	[horasTrabajadas] [int] NOT NULL,
	[salarioBruto] [decimal](18, 0) NOT NULL,
	[seguro] [int] NOT NULL,
	[deducciones] [decimal](18, 0) NULL,
	[pagosExtra] [decimal](18, 0) NULL,
	[salarioNeto] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[idPlanilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*tipo persona*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPersona](
	[idTipoPersona] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*Usuarios*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[primerApellido] [varchar](255) NOT NULL,
	[segundoApellido] [varchar](255) NULL,
	[cedula] [varchar](255) NOT NULL,
	[telefono] [int] NOT NULL,
	[email] [varchar](255) NOT NULL,
	[genero] [varchar](255) NOT NULL,
	[edad] [int]NOT NULL,
	[Contrasenna] [varchar](100) NOT NULL,
	[idTipoPersonaFk] [int] NOT NULL,
	[state] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*Citas*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Citas](
	[IdCitas] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuarioFk] [int] NOT NULL,
	[IdDoctorFK] [int] NOT NULL,
	[condicion] [varchar](255) NOT NULL,
	[Hora] [datetime] NOT NULL,
	[status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCitas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*Expediente*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expediente](
	[IdExpediente] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuarioFk] [int] NOT NULL,
	[IdDoctorFK] [int] NOT NULL,
	[Padecimiento] [varchar](2500) NOT NULL,
	[Tratamiento] [varchar](2500) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[IdExpediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*Comentarios*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentarios](
	[idComentarios] [int] IDENTITY(1,1) NOT NULL,
	[idUsuariosFk] [int] NULL,
	[textoComentario] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idComentarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*ALTERS*/

ALTER TABLE [dbo].[Comentarios]  WITH CHECK ADD FOREIGN KEY([idUsuariosFk])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Doctores]  WITH CHECK ADD FOREIGN KEY([IdUsuarioFK])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Planilla]  WITH CHECK ADD FOREIGN KEY([IdDoctorFK])
REFERENCES [dbo].[Doctores] ([IdDoctor])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([idTipoPersonaFk])
REFERENCES [dbo].[TipoPersona] ([idTipoPersona])
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD FOREIGN KEY([IdDoctorFK])
REFERENCES [dbo].[Doctores] ([IdDoctor])
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD FOREIGN KEY([IdUsuarioFk])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Expediente]  WITH CHECK ADD FOREIGN KEY([IdDoctorFK])
REFERENCES [dbo].[Doctores] ([IdDoctor])
GO
ALTER TABLE [dbo].[Expediente]  WITH CHECK ADD FOREIGN KEY([IdUsuarioFk])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO

/*Stored Procedures*/

/*BITACORA*/
--Guarda en bitacora 
CREATE PROCEDURE [dbo].[Registrar_Bitacora]
	@Email				VARCHAR(75),
	@FechaHora          DATETIME,
	@CodigoError		INT,
	@Descripcion		NVARCHAR(MAX),
	@Origen				VARCHAR(50)
AS
BEGIN
	
	DECLARE @IdUsuario INT
	SELECT	@IdUsuario = IdUsuario
	FROM	Usuario
	WHERE	Email = @Email

	IF(@IdUsuario IS NOT NULL)
	BEGIN
		
		INSERT INTO dbo.TBITACORA (IDusuario,FechaHora,CodigoError,Descripcion,Origen)
		VALUES (@IdUsuario, @FechaHora, @CodigoError, @Descripcion, @Origen)
           
	END

END
GO

/*USUARIO*/

--Guardar usuario
CREATE PROCEDURE [dbo].[Registrar_Datos_Usuario]
	@Nombre varchar(100),
	@Apellido1 varchar(100),
	@Apellido2 varchar(100),
	@Cedula varchar(100),
	@Telefono int,
	@Email varchar(300),
	@Genero varchar(100),
	@Edad int,
	@Contrasenna varchar(100),
	@TipoUsuario int
	
AS
BEGIN

	INSERT INTO dbo.Usuario(Nombre,primerApellido, segundoApellido, cedula , telefono, email, genero, edad, Contrasenna, idTipoPersonaFk, state)
    VALUES (@Nombre, @Apellido1, @Apellido2, @Cedula, @Telefono, @Email, @Genero, @Edad, @Contrasenna, @TipoUsuario, 1)

END
GO

--Editar datos de usuario 
CREATE PROCEDURE [dbo].[Editar_Datos_Usuario]
	@Nombre varchar(100),
	@Apellido1 varchar(100),
	@Apellido2 varchar(100),
	@Cedula varchar(100),
	@Telefono int,
	@Email varchar(300),
	@Genero varchar(100),
	@Edad int,
	@Contrasenna varchar(100),
	@TipoUsuario int,
	@State bit,
	@IDusuario int
	
AS
BEGIN

	UPDATE Usuario
	SET
	Nombre = @Nombre,
	primerApellido = @Apellido1,
	segundoApellido = @Apellido2,
	cedula = @Cedula,
	telefono = @Telefono,
	email = @Email,
	genero = @Genero,
	edad = @Edad,
	Contrasenna = @Contrasenna,
	idTipoPersonaFk = @TipoUsuario,
	state = @State

	WHERE IdUsuario = @IDusuario
	END
GO

--Validar ususario por mail y contraseña
CREATE PROCEDURE [dbo].[Consultar_Datos_Usuario]
	@Email VARCHAR(300),
	@Contrasenna VARCHAR(100)
AS
BEGIN

	SELECT	IdUsuario,
			Nombre,
			primerApellido,
			segundoApellido,
			cedula,
			telefono,
			Email,
			genero,
			edad,
			Contrasenna
			idTipoPersonaFk,
			state
			
	FROM	dbo.Usuario
	WHERE	Email		= @Email
		AND Contrasenna = @Contrasenna
		AND state		= 1

END
GO
--consultar usuario por estado
CREATE PROCEDURE [dbo].[Consultar_Usuarios_Estado]
	@indicador int
AS
BEGIN

	SELECT	IdUsuario,
			Nombre,
			primerApellido,
			segundoApellido,
			cedula,
			telefono,
			Email,
			genero,
			edad,
			idTipoPersonaFk,
			state
			
	FROM	dbo.Usuario
	WHERE	state		= @indicador
		    

END
GO


/*PLANILLA*/

--Guardar planilla
CREATE PROCEDURE [dbo].[Registrar_Planilla]
	@IdDoctor int,
	@HorasT int,
	@SalBrut decimal,
	@Seguro decimal,
	@Deducc decimal,
	@Extra decimal,
	@SalNet decimal
	
AS
BEGIN

	INSERT INTO dbo.Planilla(IdDoctorFK, horasTrabajadas, salarioBruto, seguro, deducciones,pagosExtra, salarioNeto)
    VALUES (@IdDoctor, @HorasT, @SalBrut, @Seguro, @Deducc, @Extra, @SalNet)

END
GO

--Editar datos de planilla 
CREATE PROCEDURE [dbo].[Editar_Datos_Planilla]
	@IdPlanilla int,
	@IdDoctor int,
	@HorasT int,
	@SalBrut decimal,
	@Seguro decimal,
	@Deducc decimal,
	@Extra decimal,
	@SalNet decimal
	
AS
BEGIN

	UPDATE Planilla
	SET
	IdDoctorFK = @IdDoctor,
	horasTrabajadas = @HorasT,
	salarioBruto = @SalBrut,
	seguro = @Seguro,
	deducciones = @Deducc,
	pagosExtra = @Extra,
	salarioNeto = @SalNet

	WHERE idPlanilla = @IdPlanilla
	END
GO

--consultar planilla por numero de doctor
CREATE PROCEDURE [dbo].[Consultar_Planilla_Doctor]
	@IdDoctor int
AS
BEGIN

	SELECT	*
	FROM	dbo.Planilla
	WHERE	IdDoctorFK = @IdDoctor

END
GO

--consultar planilla por numero de planilla
CREATE PROCEDURE [dbo].[Consultar_IdPlanilla]
	@IdPlanilla int
AS
BEGIN

	SELECT	*
	FROM	dbo.Planilla
	WHERE	idPlanilla = @IdPlanilla

END
GO


/*CITAS*/

--Guardar citas
CREATE PROCEDURE [dbo].[Registrar_Cita]

	@IdUsuario int,
	@IdDoctor int,
	@Condicion varchar(1000),
	@Hora datetime
	
AS
BEGIN

	INSERT INTO dbo.Citas(IdUsuarioFk, IdDoctorFK, condicion, Hora,status)
    VALUES (@IdUsuario, @IdDoctor, @Condicion, @Hora, 1)

END
GO

--Editar datos de Citas 
CREATE PROCEDURE [dbo].[Editar_Citas]
	@IdCita int,
	@IdUsuario int,
	@IdDoctor int,
	@Condicion varchar(1000),
	@Hora datetime,
	@Status bit
	
AS
BEGIN

	UPDATE Citas
	SET
	IdUsuarioFk = @IdUsuario,
	IdDoctorFK = @IdDoctor,
	condicion = @Condicion,
	Hora = @Hora,
	status = @Status

	WHERE IdCitas = @IdCita
	END
GO

--consultar citas por doctor
CREATE PROCEDURE [dbo].[Consultar_Citas_Doctor]
	@IdDoctor int
AS
BEGIN

	SELECT	*
	FROM	dbo.Citas
	WHERE	IdDoctorFK = @IdDoctor

END
GO

--consultar citas por paciente
CREATE PROCEDURE [dbo].[Consultar_Citas_Paciente]
	@IdPaciente int
AS
BEGIN

	SELECT	*
	FROM	dbo.Citas
	WHERE	IdUsuarioFk = @IdPaciente

END
GO


/*EXPEDIENTE*/

--Guardar expediente
CREATE PROCEDURE [dbo].[Registrar_Expediente]

	@IdUsuario int,
	@IdDoctor int,
	@Padecimiento varchar(1000),
	@Tratamiento varchar(1000)
	
AS
BEGIN

	INSERT INTO dbo.Expediente(IdUsuarioFk, IdDoctorFK, Padecimiento, Tratamiento)
    VALUES (@IdUsuario, @IdDoctor, @Padecimiento, @Tratamiento)

END
GO

--Editar datos de expediente 
CREATE PROCEDURE [dbo].[Editar_Expediente]
	@IdExpediente int,
	@IdUsuario int,
	@IdDoctor int,
	@Padecimiento varchar(1000),
	@Tratamiento varchar(1000)
	
AS
BEGIN

	UPDATE Expediente
	SET
	IdUsuarioFk = @IdUsuario,
	IdDoctorFK = @IdDoctor,
	Padecimiento = @Padecimiento,
	Tratamiento = @Tratamiento

	WHERE IdExpediente = @IdExpediente
	END
GO

--consultar expediente por paciente
CREATE PROCEDURE [dbo].[Consultar_Expediente_Paciente]
	@IdPaciente int
AS
BEGIN

	SELECT	*
	FROM	dbo.Expediente
	WHERE	IdUsuarioFk = @IdPaciente

END
GO