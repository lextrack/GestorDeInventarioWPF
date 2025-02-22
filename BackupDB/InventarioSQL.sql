USE [master]
GO
/****** Object:  Database [InventarioDB]    Script Date: 20-Feb-25 8:42:31 PM ******/
CREATE DATABASE [InventarioDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InventarioDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\InventarioDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InventarioDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\InventarioDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [InventarioDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventarioDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InventarioDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InventarioDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InventarioDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InventarioDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InventarioDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [InventarioDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InventarioDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InventarioDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InventarioDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InventarioDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InventarioDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InventarioDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InventarioDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InventarioDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InventarioDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InventarioDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InventarioDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InventarioDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InventarioDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InventarioDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InventarioDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InventarioDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InventarioDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InventarioDB] SET  MULTI_USER 
GO
ALTER DATABASE [InventarioDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InventarioDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InventarioDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InventarioDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InventarioDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InventarioDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [InventarioDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [InventarioDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [InventarioDB]
GO
/****** Object:  Table [dbo].[Entrada]    Script Date: 20-Feb-25 8:42:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrada](
	[EntradaID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[Cantidad] [int] NULL,
	[ProductoID] [int] NULL,
	[Observacion] [nvarchar](60) NULL,
 CONSTRAINT [PK_Entrada] PRIMARY KEY CLUSTERED 
(
	[EntradaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 20-Feb-25 8:42:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ProductoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[SKU] [int] NULL,
	[Valor] [decimal](12, 2) NULL,
	[Cantidad] [int] NULL,
	[Responsable] [nvarchar](50) NULL,
	[StockMinimo] [int] NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salida]    Script Date: 20-Feb-25 8:42:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salida](
	[SalidaID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[Cantidad] [int] NULL,
	[ProductoID] [int] NULL,
	[Observacion] [nvarchar](60) NULL,
 CONSTRAINT [PK_Salida] PRIMARY KEY CLUSTERED 
(
	[SalidaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Entrada]  WITH CHECK ADD  CONSTRAINT [FK_Entrada_Producto] FOREIGN KEY([ProductoID])
REFERENCES [dbo].[Producto] ([ProductoID])
GO
ALTER TABLE [dbo].[Entrada] CHECK CONSTRAINT [FK_Entrada_Producto]
GO
ALTER TABLE [dbo].[Salida]  WITH CHECK ADD  CONSTRAINT [FK_Salida_Producto] FOREIGN KEY([ProductoID])
REFERENCES [dbo].[Producto] ([ProductoID])
GO
ALTER TABLE [dbo].[Salida] CHECK CONSTRAINT [FK_Salida_Producto]
GO
/****** Object:  Trigger [dbo].[ActualizarCantidadEntrada]    Script Date: 20-Feb-25 8:42:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[ActualizarCantidadEntrada]
ON [dbo].[Entrada]
AFTER INSERT, UPDATE
AS
BEGIN
    -- Actualizar la cantidad en la tabla Producto para inserciones
    IF EXISTS (SELECT 1 FROM inserted i LEFT JOIN deleted d ON i.ProductoID = d.ProductoID WHERE d.ProductoID IS NULL) 
    BEGIN
        -- Es una inserción, actualizar la cantidad en la tabla Producto
        UPDATE Producto
        SET Cantidad = Producto.Cantidad + i.Cantidad
        FROM Producto
        INNER JOIN inserted AS i ON Producto.ProductoID = i.ProductoID;
    END
    ELSE
    BEGIN
        -- Es una actualización, ajustar la cantidad en la tabla Producto
        UPDATE Producto
        SET Cantidad = Producto.Cantidad + (i.Cantidad - d.Cantidad)
        FROM Producto
        INNER JOIN inserted AS i ON Producto.ProductoID = i.ProductoID
        INNER JOIN deleted AS d ON Producto.ProductoID = d.ProductoID;
    END
END;
GO
ALTER TABLE [dbo].[Entrada] ENABLE TRIGGER [ActualizarCantidadEntrada]
GO
/****** Object:  Trigger [dbo].[ActualizarCantidadSalida]    Script Date: 20-Feb-25 8:42:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[ActualizarCantidadSalida]
ON [dbo].[Salida]
AFTER INSERT, UPDATE
AS
BEGIN
    -- Actualizar la cantidad en la tabla Producto para inserciones
    IF EXISTS (SELECT 1 FROM inserted i LEFT JOIN deleted d ON i.ProductoID = d.ProductoID WHERE d.ProductoID IS NULL) 
    BEGIN
        -- Es una inserción, actualizar la cantidad en la tabla Producto
        UPDATE Producto
        SET Cantidad = Producto.Cantidad - i.Cantidad
        FROM Producto
        INNER JOIN inserted AS i ON Producto.ProductoID = i.ProductoID;
    END
    ELSE
    BEGIN
        -- Es una actualización, ajustar la cantidad en la tabla Producto
        UPDATE Producto
        SET Cantidad = Producto.Cantidad - (i.Cantidad - d.Cantidad)
        FROM Producto
        INNER JOIN inserted AS i ON Producto.ProductoID = i.ProductoID
        INNER JOIN deleted AS d ON Producto.ProductoID = d.ProductoID;
    END
END;
GO
ALTER TABLE [dbo].[Salida] ENABLE TRIGGER [ActualizarCantidadSalida]
GO
USE [master]
GO
ALTER DATABASE [InventarioDB] SET  READ_WRITE 
GO
