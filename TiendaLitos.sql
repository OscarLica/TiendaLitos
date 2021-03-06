USE [master]
GO
/****** Object:  Database [TiendaLitos]    Script Date: 23/12/2020 7:59:13 ******/
CREATE DATABASE [TiendaLitos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TiendaLitos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TiendaLitos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TiendaLitos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TiendaLitos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TiendaLitos] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TiendaLitos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TiendaLitos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TiendaLitos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TiendaLitos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TiendaLitos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TiendaLitos] SET ARITHABORT OFF 
GO
ALTER DATABASE [TiendaLitos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TiendaLitos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TiendaLitos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TiendaLitos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TiendaLitos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TiendaLitos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TiendaLitos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TiendaLitos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TiendaLitos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TiendaLitos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TiendaLitos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TiendaLitos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TiendaLitos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TiendaLitos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TiendaLitos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TiendaLitos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TiendaLitos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TiendaLitos] SET RECOVERY FULL 
GO
ALTER DATABASE [TiendaLitos] SET  MULTI_USER 
GO
ALTER DATABASE [TiendaLitos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TiendaLitos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TiendaLitos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TiendaLitos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TiendaLitos] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TiendaLitos', N'ON'
GO
ALTER DATABASE [TiendaLitos] SET QUERY_STORE = OFF
GO
USE [TiendaLitos]
GO
/****** Object:  Table [dbo].[TbArticulo]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbArticulo](
	[IdArticulo] [int] IDENTITY(1,1) NOT NULL,
	[NombreArticulo] [nvarchar](50) NULL,
	[Descripción] [nvarchar](50) NULL,
	[IdSubCategoria] [int] NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_TbArticulo] PRIMARY KEY CLUSTERED 
(
	[IdArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbArticuloBaja]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbArticuloBaja](
	[IdArticulosBaja] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoMovimimiento] [int] NULL,
	[IdArticuloBodega] [int] NULL,
	[Cantidad] [int] NULL,
	[NombreMedida] [nvarchar](50) NULL,
	[TotalUnidades] [decimal](18, 0) NULL,
	[DescripciónArticuloBaja] [nvarchar](50) NULL,
	[IdArticulo] [int] NULL,
 CONSTRAINT [PK_TbArticuloBaja] PRIMARY KEY CLUSTERED 
(
	[IdArticulosBaja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbArticuloBodega]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbArticuloBodega](
	[IdArticuloBodega] [int] IDENTITY(1,1) NOT NULL,
	[IdBodega] [int] NULL,
	[IdArticulo] [int] NULL,
	[IdMedida] [int] NULL,
	[IdMarca] [int] NULL,
	[IdColor] [int] NULL,
	[IdTalla] [int] NULL,
	[Existencia] [nvarchar](50) NULL,
	[PrecioCompra] [float] NULL,
	[PrecioVenta] [float] NULL,
	[Descuento] [float] NULL,
	[DescuentoMaximo] [float] NULL,
	[IdCompra] [int] NULL,
 CONSTRAINT [PK_TbArticuloBodega] PRIMARY KEY CLUSTERED 
(
	[IdArticuloBodega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbBodega]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbBodega](
	[IdBodega] [int] IDENTITY(1,1) NOT NULL,
	[Bodega] [nvarchar](50) NULL,
	[Descripción] [nvarchar](50) NULL,
 CONSTRAINT [PK_TbBodega] PRIMARY KEY CLUSTERED 
(
	[IdBodega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbCategoria]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbCategoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[NombreCategoria] [nvarchar](50) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_TbCategoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbColor]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbColor](
	[IdColor] [int] IDENTITY(1,1) NOT NULL,
	[NombreColor] [nvarchar](50) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_TbColor] PRIMARY KEY CLUSTERED 
(
	[IdColor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbCompra]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbCompra](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[FechaCompra] [date] NULL,
	[SubTotal] [float] NULL,
	[Iva] [float] NULL,
	[Anular] [bit] NULL,
	[Total] [float] NULL,
	[NoFactura] [nvarchar](50) NULL,
	[IdProveedor] [int] NULL,
	[IdUsuario] [int] NULL,
	[IdTipoMoneda] [int] NULL,
 CONSTRAINT [PK_TbCompra] PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbConfiguración]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbConfiguración](
	[IdConfiguración] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[NombreTienda] [nvarchar](50) NULL,
	[CofiguraciónDelLema] [nvarchar](50) NULL,
	[ConfTelefono] [numeric](18, 0) NULL,
	[ConfDireccion] [nvarchar](50) NULL,
	[ConfEncabezadoFactura] [nvarchar](50) NULL,
 CONSTRAINT [PK_TbConfiguración] PRIMARY KEY CLUSTERED 
(
	[IdConfiguración] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbDetalleCompra]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbDetalleCompra](
	[IdCompra] [int] NULL,
	[IdArticulo] [int] NULL,
	[Cantidad] [float] NULL,
	[Precio] [float] NULL,
	[Descuento] [float] NULL,
	[SubTotal] [float] NULL,
	[IdDetalleCompra] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbDetalleVenta]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbDetalleVenta](
	[IdVenta] [int] NULL,
	[IdArticulo] [int] NULL,
	[DescripciónArticulo] [nvarchar](50) NULL,
	[UdMedidaVenta] [nvarchar](50) NULL,
	[PrecioPorUnidad] [float] NULL,
	[Cantidad] [float] NULL,
	[PrecioVenta] [money] NULL,
	[SubTotal] [money] NULL,
	[Descuento] [float] NULL,
	[Pago] [money] NULL,
	[Cambio] [money] NULL,
	[IdDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbDevoluciònVenta]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbDevoluciònVenta](
	[IdDevoluciònVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[IdVenta] [int] NULL,
	[NoFactura] [nvarchar](50) NULL,
	[FechaDevoluciòn] [date] NULL,
	[IdArticulo] [int] NULL,
	[Cantidad] [int] NULL,
	[DescripciònDevoluciòn] [nvarchar](50) NULL,
 CONSTRAINT [PK_TbDevoluciònVenta] PRIMARY KEY CLUSTERED 
(
	[IdDevoluciònVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbMarca]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbMarca](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[NombreMarca] [nvarchar](50) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_TbMarca] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbMedida]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbMedida](
	[IdMedida] [int] IDENTITY(1,1) NOT NULL,
	[NombreMedida] [nvarchar](50) NULL,
	[PrecioMedida] [float] NULL,
	[UdidadesEquivalente] [float] NULL,
 CONSTRAINT [PK_TbMedida] PRIMARY KEY CLUSTERED 
(
	[IdMedida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbMovimientoArticulo]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbMovimientoArticulo](
	[IdMovimientoArticulo] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoMovimiento] [int] NULL,
	[IdUsuario] [int] NULL,
	[IdArticuloBodega] [int] NULL,
	[FechaMovimiento] [smalldatetime] NULL,
	[Cantidad] [int] NULL,
	[TotalMedida] [float] NULL,
	[DescripciónMovimientoArticulo] [nvarchar](50) NULL,
	[IdArticulo] [int] NULL,
 CONSTRAINT [PK_TbMovimientoArticulo] PRIMARY KEY CLUSTERED 
(
	[IdMovimientoArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbPromoción]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbPromoción](
	[IdPromoción] [int] IDENTITY(1,1) NOT NULL,
	[NombrePromoción] [nvarchar](50) NULL,
	[Descuento] [money] NULL,
	[InicioPromoción] [smalldatetime] NULL,
	[FinPromoción] [smalldatetime] NULL,
	[Descripción] [nvarchar](50) NULL,
 CONSTRAINT [PK_TbPromoción] PRIMARY KEY CLUSTERED 
(
	[IdPromoción] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbProveedor]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbProveedor](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpresa] [nvarchar](50) NULL,
	[Dirección] [nvarchar](50) NULL,
	[NombreConctato] [nvarchar](50) NULL,
	[Tefonono] [numeric](18, 0) NULL,
	[Departamento] [nvarchar](50) NULL,
	[Municipio] [nvarchar](50) NULL,
 CONSTRAINT [PK_TbProveedor] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbRol]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbRol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [nvarchar](50) NULL,
	[Descripción] [nvarchar](50) NULL,
 CONSTRAINT [PK_TbRol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbRolUsuario]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbRolUsuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbSubCategoria]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbSubCategoria](
	[IdSubCategoria] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NULL,
	[Descripción] [nvarchar](50) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_TbSubCategoria] PRIMARY KEY CLUSTERED 
(
	[IdSubCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbTalla]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbTalla](
	[IdTalla] [int] IDENTITY(1,1) NOT NULL,
	[NombreTalla] [nvarchar](50) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_TbTalla] PRIMARY KEY CLUSTERED 
(
	[IdTalla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbTipoMovimiento]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbTipoMovimiento](
	[IdTipoMovimiento] [int] IDENTITY(1,1) NOT NULL,
	[NombreMovimiento] [nvarchar](50) NULL,
	[DescripciónTipoMovimiento] [nvarchar](50) NULL,
 CONSTRAINT [PK_TbTipoMovimiento] PRIMARY KEY CLUSTERED 
(
	[IdTipoMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbUsuario]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbUsuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[Cedula] [nvarchar](50) NULL,
	[Telefono] [numeric](18, 0) NULL,
	[Contraseña] [nvarchar](50) NULL,
 CONSTRAINT [PK_TbUsuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbVenta]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbVenta](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[IdPromoción] [int] NULL,
	[Fecha] [date] NULL,
	[Iva] [float] NULL,
	[Total] [float] NULL,
	[Anular] [bit] NULL,
	[SubTotal] [float] NULL,
	[NombreCliente] [nvarchar](50) NULL,
	[IdTipoMoneda] [int] NULL,
 CONSTRAINT [PK_TbVenta] PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPOMONEDA]    Script Date: 23/12/2020 7:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPOMONEDA](
	[IdTipoMoneda] [int] IDENTITY(1,1) NOT NULL,
	[TMoneda] [nvarchar](50) NULL,
	[Activo] [bit] NULL,
	[TasaCambio] [float] NULL,
 CONSTRAINT [PK__TIPOMONE__8A49267F7283DDDE] PRIMARY KEY CLUSTERED 
(
	[IdTipoMoneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TbArticulo]  WITH CHECK ADD  CONSTRAINT [FK_TbArticulo_TbSubCategoria] FOREIGN KEY([IdSubCategoria])
REFERENCES [dbo].[TbSubCategoria] ([IdSubCategoria])
GO
ALTER TABLE [dbo].[TbArticulo] CHECK CONSTRAINT [FK_TbArticulo_TbSubCategoria]
GO
ALTER TABLE [dbo].[TbArticuloBaja]  WITH CHECK ADD  CONSTRAINT [FK_TbArticuloBaja_TbArticuloBodega] FOREIGN KEY([IdArticuloBodega])
REFERENCES [dbo].[TbArticuloBodega] ([IdArticuloBodega])
GO
ALTER TABLE [dbo].[TbArticuloBaja] CHECK CONSTRAINT [FK_TbArticuloBaja_TbArticuloBodega]
GO
ALTER TABLE [dbo].[TbArticuloBaja]  WITH CHECK ADD  CONSTRAINT [FK_TbArticuloBaja_TbTipoMovimiento] FOREIGN KEY([IdTipoMovimimiento])
REFERENCES [dbo].[TbTipoMovimiento] ([IdTipoMovimiento])
GO
ALTER TABLE [dbo].[TbArticuloBaja] CHECK CONSTRAINT [FK_TbArticuloBaja_TbTipoMovimiento]
GO
ALTER TABLE [dbo].[TbArticuloBodega]  WITH CHECK ADD  CONSTRAINT [FK_TbArticuloBodega_TbArticulo] FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[TbArticulo] ([IdArticulo])
GO
ALTER TABLE [dbo].[TbArticuloBodega] CHECK CONSTRAINT [FK_TbArticuloBodega_TbArticulo]
GO
ALTER TABLE [dbo].[TbArticuloBodega]  WITH CHECK ADD  CONSTRAINT [FK_TbArticuloBodega_TbBodega] FOREIGN KEY([IdBodega])
REFERENCES [dbo].[TbBodega] ([IdBodega])
GO
ALTER TABLE [dbo].[TbArticuloBodega] CHECK CONSTRAINT [FK_TbArticuloBodega_TbBodega]
GO
ALTER TABLE [dbo].[TbArticuloBodega]  WITH CHECK ADD  CONSTRAINT [FK_TbArticuloBodega_TbColor] FOREIGN KEY([IdColor])
REFERENCES [dbo].[TbColor] ([IdColor])
GO
ALTER TABLE [dbo].[TbArticuloBodega] CHECK CONSTRAINT [FK_TbArticuloBodega_TbColor]
GO
ALTER TABLE [dbo].[TbArticuloBodega]  WITH CHECK ADD  CONSTRAINT [FK_TbArticuloBodega_TbMarca] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[TbMarca] ([IdMarca])
GO
ALTER TABLE [dbo].[TbArticuloBodega] CHECK CONSTRAINT [FK_TbArticuloBodega_TbMarca]
GO
ALTER TABLE [dbo].[TbArticuloBodega]  WITH CHECK ADD  CONSTRAINT [FK_TbArticuloBodega_TbMedida] FOREIGN KEY([IdMedida])
REFERENCES [dbo].[TbMedida] ([IdMedida])
GO
ALTER TABLE [dbo].[TbArticuloBodega] CHECK CONSTRAINT [FK_TbArticuloBodega_TbMedida]
GO
ALTER TABLE [dbo].[TbArticuloBodega]  WITH CHECK ADD  CONSTRAINT [FK_TbArticuloBodega_TbTalla] FOREIGN KEY([IdTalla])
REFERENCES [dbo].[TbTalla] ([IdTalla])
GO
ALTER TABLE [dbo].[TbArticuloBodega] CHECK CONSTRAINT [FK_TbArticuloBodega_TbTalla]
GO
ALTER TABLE [dbo].[TbCompra]  WITH CHECK ADD  CONSTRAINT [FK_TbCompra_TbProveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[TbProveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[TbCompra] CHECK CONSTRAINT [FK_TbCompra_TbProveedor]
GO
ALTER TABLE [dbo].[TbCompra]  WITH CHECK ADD  CONSTRAINT [FK_TbCompra_TbUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[TbUsuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TbCompra] CHECK CONSTRAINT [FK_TbCompra_TbUsuario]
GO
ALTER TABLE [dbo].[TbConfiguración]  WITH CHECK ADD  CONSTRAINT [FK_TbConfiguración_TbUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[TbUsuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TbConfiguración] CHECK CONSTRAINT [FK_TbConfiguración_TbUsuario]
GO
ALTER TABLE [dbo].[TbDetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_TbDetalleCompra_TbCompra1] FOREIGN KEY([IdCompra])
REFERENCES [dbo].[TbCompra] ([IdCompra])
GO
ALTER TABLE [dbo].[TbDetalleCompra] CHECK CONSTRAINT [FK_TbDetalleCompra_TbCompra1]
GO
ALTER TABLE [dbo].[TbDetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_TbDetalleVenta_TbVenta1] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[TbVenta] ([IdVenta])
GO
ALTER TABLE [dbo].[TbDetalleVenta] CHECK CONSTRAINT [FK_TbDetalleVenta_TbVenta1]
GO
ALTER TABLE [dbo].[TbDevoluciònVenta]  WITH CHECK ADD  CONSTRAINT [FK_TbDevoluciònVenta_TbArticulo] FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[TbArticulo] ([IdArticulo])
GO
ALTER TABLE [dbo].[TbDevoluciònVenta] CHECK CONSTRAINT [FK_TbDevoluciònVenta_TbArticulo]
GO
ALTER TABLE [dbo].[TbDevoluciònVenta]  WITH CHECK ADD  CONSTRAINT [FK_TbDevoluciònVenta_TbUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[TbUsuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TbDevoluciònVenta] CHECK CONSTRAINT [FK_TbDevoluciònVenta_TbUsuario]
GO
ALTER TABLE [dbo].[TbDevoluciònVenta]  WITH CHECK ADD  CONSTRAINT [FK_TbDevoluciònVenta_TbVenta] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[TbVenta] ([IdVenta])
GO
ALTER TABLE [dbo].[TbDevoluciònVenta] CHECK CONSTRAINT [FK_TbDevoluciònVenta_TbVenta]
GO
ALTER TABLE [dbo].[TbMovimientoArticulo]  WITH CHECK ADD  CONSTRAINT [FK_TbMovimientoArticulo_TbArticulo] FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[TbArticulo] ([IdArticulo])
GO
ALTER TABLE [dbo].[TbMovimientoArticulo] CHECK CONSTRAINT [FK_TbMovimientoArticulo_TbArticulo]
GO
ALTER TABLE [dbo].[TbMovimientoArticulo]  WITH CHECK ADD  CONSTRAINT [FK_TbMovimientoArticulo_TbArticuloBodega] FOREIGN KEY([IdArticuloBodega])
REFERENCES [dbo].[TbArticuloBodega] ([IdArticuloBodega])
GO
ALTER TABLE [dbo].[TbMovimientoArticulo] CHECK CONSTRAINT [FK_TbMovimientoArticulo_TbArticuloBodega]
GO
ALTER TABLE [dbo].[TbMovimientoArticulo]  WITH CHECK ADD  CONSTRAINT [FK_TbMovimientoArticulo_TbTipoMovimiento] FOREIGN KEY([IdTipoMovimiento])
REFERENCES [dbo].[TbTipoMovimiento] ([IdTipoMovimiento])
GO
ALTER TABLE [dbo].[TbMovimientoArticulo] CHECK CONSTRAINT [FK_TbMovimientoArticulo_TbTipoMovimiento]
GO
ALTER TABLE [dbo].[TbRolUsuario]  WITH CHECK ADD  CONSTRAINT [FK_TbRolUsuario_TbRol1] FOREIGN KEY([IdRol])
REFERENCES [dbo].[TbRol] ([IdRol])
GO
ALTER TABLE [dbo].[TbRolUsuario] CHECK CONSTRAINT [FK_TbRolUsuario_TbRol1]
GO
ALTER TABLE [dbo].[TbRolUsuario]  WITH CHECK ADD  CONSTRAINT [FK_TbRolUsuario_TbUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[TbUsuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TbRolUsuario] CHECK CONSTRAINT [FK_TbRolUsuario_TbUsuario]
GO
ALTER TABLE [dbo].[TbSubCategoria]  WITH CHECK ADD  CONSTRAINT [FK_TbSubCategoria_TbCategoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[TbCategoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[TbSubCategoria] CHECK CONSTRAINT [FK_TbSubCategoria_TbCategoria]
GO
ALTER TABLE [dbo].[TbVenta]  WITH CHECK ADD  CONSTRAINT [FK_TbVenta_TbPromoción] FOREIGN KEY([IdPromoción])
REFERENCES [dbo].[TbPromoción] ([IdPromoción])
GO
ALTER TABLE [dbo].[TbVenta] CHECK CONSTRAINT [FK_TbVenta_TbPromoción]
GO
ALTER TABLE [dbo].[TbVenta]  WITH CHECK ADD  CONSTRAINT [FK_TbVenta_TbUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[TbUsuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TbVenta] CHECK CONSTRAINT [FK_TbVenta_TbUsuario]
GO
USE [master]
GO
ALTER DATABASE [TiendaLitos] SET  READ_WRITE 
GO
