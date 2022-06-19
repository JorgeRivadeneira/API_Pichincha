USE [master]
GO
/****** Object:  Database [ApiTransactions]    Script Date: 19/6/2022 15:51:09 ******/
CREATE DATABASE [ApiTransactions]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ApiTransactions', FILENAME = N'C:\Users\jorge\ApiTransactions.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ApiTransactions_log', FILENAME = N'C:\Users\jorge\ApiTransactions_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ApiTransactions] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ApiTransactions].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ApiTransactions] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ApiTransactions] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ApiTransactions] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ApiTransactions] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ApiTransactions] SET ARITHABORT OFF 
GO
ALTER DATABASE [ApiTransactions] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ApiTransactions] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ApiTransactions] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ApiTransactions] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ApiTransactions] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ApiTransactions] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ApiTransactions] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ApiTransactions] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ApiTransactions] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ApiTransactions] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ApiTransactions] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ApiTransactions] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ApiTransactions] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ApiTransactions] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ApiTransactions] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ApiTransactions] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ApiTransactions] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ApiTransactions] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ApiTransactions] SET  MULTI_USER 
GO
ALTER DATABASE [ApiTransactions] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ApiTransactions] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ApiTransactions] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ApiTransactions] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ApiTransactions] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ApiTransactions] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ApiTransactions] SET QUERY_STORE = OFF
GO
USE [ApiTransactions]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 19/6/2022 15:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Password] [varchar](250) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Id_Persona] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 19/6/2022 15:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[Id_Cuenta] [int] IDENTITY(1,1) NOT NULL,
	[Nro_Cuenta] [varchar](10) NOT NULL,
	[Tipo_Cuenta] [char](1) NOT NULL,
	[Saldo_Inicial] [float] NULL,
	[Saldo_Disponible] [float] NULL,
	[Estado] [bit] NOT NULL,
	[Id_Cliente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cupo_Diario]    Script Date: 19/6/2022 15:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cupo_Diario](
	[Id_Cupo] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Valor] [float] NOT NULL,
	[Id_Cuenta] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 19/6/2022 15:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[Id_Movimiento] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Tipo_Movimiento] [char](1) NOT NULL,
	[Valor] [float] NULL,
	[Saldo] [float] NULL,
	[Id_Cuenta] [int] NOT NULL,
	[Saldo_Inicial] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametros]    Script Date: 19/6/2022 15:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametros](
	[Id_Parametro] [int] IDENTITY(1,1) NOT NULL,
	[Parametro] [char](10) NULL,
	[Valor] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 19/6/2022 15:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Id_persona] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Genero] [char](1) NOT NULL,
	[Edad] [int] NOT NULL,
	[Identificacion] [varchar](10) NOT NULL,
	[Direccion] [varchar](80) NULL,
	[Telefono] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Persona] FOREIGN KEY([Id_Persona])
REFERENCES [dbo].[Persona] ([Id_persona])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Persona]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Cliente] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[Cliente] ([Id_Cliente])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Cliente]
GO
ALTER TABLE [dbo].[Cupo_Diario]  WITH CHECK ADD  CONSTRAINT [FK_Cupo_Diario_Cuenta] FOREIGN KEY([Id_Cuenta])
REFERENCES [dbo].[Cuenta] ([Id_Cuenta])
GO
ALTER TABLE [dbo].[Cupo_Diario] CHECK CONSTRAINT [FK_Cupo_Diario_Cuenta]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_Cuenta] FOREIGN KEY([Id_Cuenta])
REFERENCES [dbo].[Cuenta] ([Id_Cuenta])
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_Cuenta]
GO

CREATE  TRIGGER [dbo].[tg_cuenta]
ON [dbo].[Cuenta]
AFTER  INSERT
AS
BEGIN 
SET NOCOUNT ON;
			BEGIN TRANSACTION
			
			
		    DECLARE 
		    @saldoInicial  FLOAT,
		    @cuenta        VARCHAR(10);
		    
		    select @cuenta = Id_Cuenta, @saldoInicial = Saldo_Inicial 
		    from inserted;		
			
			update Cuenta set Saldo_Disponible = Saldo_Inicial where Id_Cuenta = @cuenta;
			IF @@ERROR <> 0	
			BEGIN
				ROLLBACK TRAN;
				return;				
			END	
				
							
			COMMIT TRANSACTION;
		
	return;
END
GO


CREATE  TRIGGER [dbo].[tg_movimientos]
ON [dbo].[Movimientos]
AFTER  INSERT, UPDATE
AS
BEGIN 
SET NOCOUNT ON;
		BEGIN TRY
			BEGIN TRANSACTION
			declare @tipo	char(2);
			declare @valor  float;
			declare @cuenta int;
			declare @saldoActual float;
			DECLARE @saldoDisponible FLOAT;
			DECLARE @msg VARCHAR(100);
			DECLARE @paramCupoDiario FLOAT;
			DECLARE @cupoDiario FLOAT;
			DECLARE @idMovimiento INT;
			
		    DECLARE 
		    @ErrorMessage  NVARCHAR(4000), 
		    @ErrorSeverity INT, 
		    @ErrorState    INT;			
			
			select @tipo = Tipo_Movimiento, @valor = Valor, @cuenta = Id_Cuenta, 
			@idMovimiento = Id_Movimiento
			from inserted;
			
			SELECT @saldoActual = Saldo_Disponible FROM Cuenta WHERE Id_Cuenta = @cuenta;
			
			select @valor = case when trim(@tipo) = 'C' then @valor else @valor * -1 end;
		
			select @saldoActual = Saldo_Disponible from Cuenta where Id_Cuenta = @cuenta;
		
			
			IF trim(@tipo) = 'D'
			BEGIN
				--Validar si dispone de saldo disponible
				if (@saldoActual + @valor) < 0
				BEGIN
					ROLLBACK TRAN;
					RAISERROR('Saldo no disponible', 17, 1);
				END
			
				--Validar el cupo diario			
				SELECT @paramCupoDiario = Valor FROM Parametros WHERE Parametro = 'DIARIO';	   
				
				SELECT @cupoDiario =  sum(Valor)
				FROM Cupo_Diario WHERE Id_Cuenta = @cuenta	
				AND convert(DATE,getdate(),101) =  convert(DATE,Fecha,101)		
				
				IF (isnull(@cupoDiario,0) + abs(@valor)) > @paramCupoDiario
				BEGIN					
					ROLLBACK TRAN;		
					RAISERROR('Cupo Diario Excedido', 17, 1);
				END
				
				INSERT INTO dbo.Cupo_Diario (Fecha, Valor, Id_Cuenta)
				VALUES (getdate(), abs(@valor), @cuenta)   
				IF @@ERROR <> 0	
				BEGIN
					ROLLBACK TRAN;
					return;				
				END			  
			END			
		
			update Cuenta SET Saldo_Inicial = @saldoActual,
			Saldo_Disponible = Saldo_Disponible + @valor where Id_Cuenta = @cuenta;
			
			UPDATE Movimientos SET Saldo_Inicial = @saldoActual,
			Fecha = getdate(), 
			Saldo = isnull(@saldoActual,0) + @valor,
			Valor = @valor
			WHERE Id_Cuenta = @cuenta
			AND Id_Movimiento = @idMovimiento;
			
			COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
		    SELECT 
		        @ErrorMessage = ERROR_MESSAGE(), 
		        @ErrorSeverity = ERROR_SEVERITY(), 
		        @ErrorState = ERROR_STATE();
		        
		    	RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
		END CATCH
	return;
END
GO




USE [master]
GO
ALTER DATABASE [ApiTransactions] SET  READ_WRITE 
GO
