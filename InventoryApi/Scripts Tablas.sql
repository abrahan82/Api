

USE [dbInventory]
GO
/****** Object:  Table [dbo].[tblInventory]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblInventory](
	[IdInventory] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [numeric](18, 2) NULL,
	[UnidadMedida] [varchar](10) NULL,
	[Fecha] [datetime] NULL,
	[Status] [varchar](1) NULL,
 CONSTRAINT [PK_tblInventory] PRIMARY KEY CLUSTERED 
(
	[IdInventory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProd]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProd](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[Producto] [varchar](200) NULL,
	[UnidadMedida] [varchar](10) NULL,
	[PrecioCosto] [numeric](18, 2) NULL,
	[PrecioVenta] [numeric](18, 2) NULL,
	[Status] [varchar](1) NULL,
	[Nit] [varchar](30) NULL,
 CONSTRAINT [PK_tblProd] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vwAllIns]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwAllIns]
AS
SELECT        i.IdInventory, i.IdProducto, p.Producto, i.UnidadMedida, i.Cantidad, i.Fecha, i.Status
FROM            dbo.tblInventory AS i INNER JOIN
                         dbo.tblProd AS p ON p.idProducto = i.IdProducto
GO
/****** Object:  Table [dbo].[tblEgresos]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEgresos](
	[IdEg] [int] IDENTITY(1,1) NOT NULL,
	[Tarjeta] [varchar](15) NULL,
	[IdVeh] [int] NULL,
	[Entrada] [datetime] NULL,
	[Salida] [datetime] NULL,
	[IdPiloto] [int] NULL,
	[IdCli] [int] NULL,
	[IdTrans] [int] NULL,
	[PesoBruto] [numeric](18, 2) NULL,
	[Tara] [numeric](18, 2) NULL,
	[PesoNeto] [numeric](18, 2) NULL,
	[PrecioVenta] [numeric](18, 2) NULL,
	[IdUser] [int] NULL,
	[Comentarios] [varchar](250) NULL,
	[Status] [varchar](1) NULL,
	[IdProd] [int] NULL,
 CONSTRAINT [PK_tblEgresos] PRIMARY KEY CLUSTERED 
(
	[IdEg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPilotos]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPilotos](
	[idPiloto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NULL,
 CONSTRAINT [PK_tblPilotos] PRIMARY KEY CLUSTERED 
(
	[idPiloto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProv]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProv](
	[idProveedor] [int] IDENTITY(1,1) NOT NULL,
	[NombreProveedor] [varchar](200) NULL,
	[DirProveedor] [varchar](200) NULL,
	[Telefono1] [int] NULL,
	[Telefono2] [int] NULL,
	[Telefono3] [int] NULL,
	[email] [varchar](200) NULL,
	[Status] [varchar](1) NOT NULL,
	[Nit] [varchar](30) NULL,
	[Tarjeta] [varchar](30) NULL,
 CONSTRAINT [PK_tblProv] PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTrans]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTrans](
	[idTrans] [int] IDENTITY(1,1) NOT NULL,
	[idProv] [int] NULL,
	[Descripcion] [varchar](200) NULL,
	[Status] [varchar](1) NULL,
	[idCli] [int] NULL,
 CONSTRAINT [PK_tblTrans] PRIMARY KEY CLUSTERED 
(
	[idTrans] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsr]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsr](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Name] [varchar](150) NULL,
	[Password] [varchar](50) NULL,
	[Status] [varchar](1) NULL,
	[profile] [varchar](10) NULL,
	[money] [numeric](18, 2) NULL,
 CONSTRAINT [PK_tblUsr] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVeh]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVeh](
	[idVeh] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](200) NULL,
	[Placa] [nchar](10) NULL,
	[idTrans] [int] NULL,
	[Status] [varchar](1) NULL,
 CONSTRAINT [PK_tblVeh] PRIMARY KEY CLUSTERED 
(
	[idVeh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vwEgresos]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwEgresos]
AS
SELECT        Eg.IdEg, Eg.Tarjeta, Eg.IdVeh, ISNULL(v.Placa, '') AS Placa, Eg.Entrada, Eg.Salida, Eg.IdPiloto, ISNULL(p.Nombre, '') AS Nombre, Eg.IdCli, ISNULL(pr.NombreProveedor, '') AS NombreProveedor, Eg.IdTrans, 
                         ISNULL(tr.Descripcion, '') AS Descripcion, Eg.PesoBruto, Eg.Tara, Eg.PesoNeto, Eg.PrecioVenta, Eg.IdUser, ISNULL(usr.Name, '') AS Name, Eg.Comentarios, Eg.Status, Eg.IdProd, ISNULL(prod.Producto, '') AS Producto, 
                         Eg.PesoNeto / 100 * Eg.PrecioVenta AS Total
FROM            dbo.tblEgresos AS Eg LEFT OUTER JOIN
                         dbo.tblVeh AS v ON Eg.IdVeh = v.idVeh LEFT OUTER JOIN
                         dbo.tblPilotos AS p ON Eg.IdPiloto = p.idPiloto LEFT OUTER JOIN
                         dbo.tblProv AS pr ON pr.idProveedor = Eg.IdCli LEFT OUTER JOIN
                         dbo.tblTrans AS tr ON tr.idTrans = Eg.IdTrans LEFT OUTER JOIN
                         dbo.tblProd AS prod ON prod.idProducto = Eg.IdProd LEFT OUTER JOIN
                         dbo.tblUsr AS usr ON usr.Id = Eg.IdUser
GO
/****** Object:  Table [dbo].[tblIngresos]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblIngresos](
	[IdIn] [int] IDENTITY(1,1) NOT NULL,
	[Tarjeta] [varchar](15) NULL,
	[IdVeh] [int] NULL,
	[Entrada] [datetime] NULL,
	[Salida] [datetime] NULL,
	[IdPiloto] [int] NULL,
	[IdProv] [int] NULL,
	[IdTrans] [int] NULL,
	[PesoBruto] [numeric](18, 2) NULL,
	[Tara] [numeric](18, 2) NULL,
	[PesoNeto] [numeric](18, 2) NULL,
	[PrecioCompra] [numeric](18, 2) NULL,
	[IdUser] [int] NULL,
	[Comentarios] [varchar](250) NULL,
	[Status] [varchar](1) NULL,
	[IdProd] [int] NULL,
 CONSTRAINT [PK_tblIngresos] PRIMARY KEY CLUSTERED 
(
	[IdIn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vwIngresos]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE
view [dbo].[vwIngresos]
as
SELECT
       Ing.[IdIn]
      ,Ing.[Tarjeta]
      ,Ing.[IdVeh]
	  ,v.Placa
      ,Ing.[Entrada]
      ,Ing.[Salida]
      ,Ing.[IdPiloto]
	  ,p.Nombre
      ,Ing.[IdProv]
	  ,isnull(pr.NombreProveedor,'') NombreProveedor
      ,Ing.[IdTrans]
	  ,tr.Descripcion
      ,Ing.[PesoBruto]
      ,Ing.[Tara]
      ,Ing.[PesoNeto]
      ,Ing.[PrecioCompra]
      ,Ing.[IdUser]
	  ,isnull(usr.Name,'') Name
      ,Ing.[Comentarios]
      ,Ing.[Status]
	  ,Ing.[IdProd]
	  ,isnull(prod.Producto,'') Producto
	  ,(Ing.[PesoNeto]/100)*Ing.[PrecioCompra] Total
  FROM [dbInventory].[dbo].[tblIngresos] Ing
       LEFT join tblVeh v on Ing.IdVeh = v.idVeh
	   LEFT join tblPilotos p on Ing.IdPiloto = p.idPiloto
	   LEFT join tblProv pr on pr.idProveedor = Ing.IdProv
	   LEFT join tblTrans tr on tr.idTrans = ing.IdTrans
	   LEFT join tblProd prod on prod.idProducto = Ing.IdProd
	   LEFT join tblUsr usr on usr.Id	= Ing.IdUser
GO
/****** Object:  View [dbo].[vwLastIn]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwLastIn]
AS
SELECT        i.IdInventory, i.IdProducto, p.Producto, i.UnidadMedida, i.Cantidad, MAX(i.Fecha) AS Fecha, i.Status
FROM            dbo.tblInventory AS i INNER JOIN
                         dbo.tblProd AS p ON p.idProducto = i.IdProducto
GROUP BY i.IdInventory, i.IdProducto, p.Producto, i.UnidadMedida, i.Cantidad, i.Status
GO
/****** Object:  Table [dbo].[tblCli]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCli](
	[idCli] [int] IDENTITY(1,1) NOT NULL,
	[NombreCliente] [varchar](200) NULL,
	[DirCliente] [varchar](200) NULL,
	[Telefono1] [int] NULL,
	[Telefono2] [int] NULL,
	[Telefono3] [int] NULL,
	[email] [varchar](200) NULL,
	[Status] [varchar](1) NOT NULL,
	[Nit] [varchar](30) NULL,
 CONSTRAINT [PK_tblCli] PRIMARY KEY CLUSTERED 
(
	[idCli] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProdProvCli]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProdProvCli](
	[idProdProv] [int] IDENTITY(1,1) NOT NULL,
	[idProd] [int] NULL,
	[idProv] [int] NULL,
	[Status] [varchar](1) NULL,
	[idCli] [int] NULL,
 CONSTRAINT [PK_tblProdProv] PRIMARY KEY CLUSTERED 
(
	[idProdProv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vwProdProvCli]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwProdProvCli]
AS
SELECT        Pc.idProdProv, Pc.idProd, p.Producto, Pc.idProv, CASE WHEN Pc.idProv > 0 THEN
                             (SELECT        pr.NombreProveedor
                               FROM            tblProv pr
                               WHERE        pr.idProveedor = Pc.idProv) ELSE '' END AS proveedor, Pc.idCli, CASE WHEN Pc.idCli > 0 THEN
                             (SELECT        cli.NombreCliente
                               FROM            tblCli cli
                               WHERE        cli.idCli = Pc.idProv) ELSE '' END AS cliente, Pc.Status, p.UnidadMedida, p.idProducto, p.PrecioCosto, p.PrecioVenta
FROM            dbo.tblProdProvCli AS Pc INNER JOIN
                         dbo.tblProd AS p ON Pc.idProd = p.idProducto AND p.Status = 'A'
GO
/****** Object:  View [dbo].[vwTransProvCli]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwTransProvCli]
AS
SELECT        idTrans, idProv, CASE WHEN trans.idProv > 0 THEN
                             (SELECT        pr.NombreProveedor
                               FROM            tblProv pr
                               WHERE        pr.idProveedor = trans.idProv) ELSE '' END AS proveedor, idCli, CASE WHEN trans.idCli > 0 THEN
                             (SELECT        cli.NombreCliente
                               FROM            tblCli cli
                               WHERE        cli.idCli = trans.idCli) ELSE '' END AS cliente, Status, Descripcion
FROM            dbo.tblTrans AS trans
GO
/****** Object:  View [dbo].[vwTransProvCliVeh]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vwTransProvCliVeh]
as
 select trans.idTrans, v.idVeh, v.Tipo, v.Placa, v.Status,
	trans.idProv, case when trans.idProv>0 then (select pr.NombreProveedor from tblProv pr where pr.idProveedor = trans.idProv) else '' end proveedor,
	trans.idCli, case when trans.idCli>0 then (select cli.NombreCliente from tblCli cli where cli.idCli = trans.idProv) else '' end cliente
 from tblTrans trans
     inner join tblVeh V on v.idTrans = trans.idTrans and v.Status = 'A' 
GO
/****** Object:  Table [dbo].[tblAperturaCierre]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAperturaCierre](
	[idRegister] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NULL,
	[money] [numeric](18, 2) NULL,
	[fecha] [datetime] NULL,
	[tipo] [varchar](50) NULL,
 CONSTRAINT [PK_tblAperturaCierre] PRIMARY KEY CLUSTERED 
(
	[idRegister] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProvPrice]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProvPrice](
	[IdRegister] [int] IDENTITY(1,1) NOT NULL,
	[IdProv] [int] NOT NULL,
	[Price] [numeric](18, 2) NULL,
	[IdProd] [int] NOT NULL,
 CONSTRAINT [PK_tblProvPrice] PRIMARY KEY CLUSTERED 
(
	[IdRegister] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTrxCaja]    Script Date: 06/09/2021 09:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTrxCaja](
	[idCaja] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NULL,
	[TipoTransaccion] [varchar](100) NULL,
	[monto] [numeric](18, 2) NULL,
	[fecha] [datetime] NULL,
	[incrementaMonto] [int] NULL,
	[Status] [varchar](1) NULL,
	[Estado] [varchar](1) NULL,
 CONSTRAINT [PK_tblTrxCaja] PRIMARY KEY CLUSTERED 
(
	[idCaja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblCli] ADD  CONSTRAINT [DF_tblCli_Status]  DEFAULT ('A') FOR [Status]
GO
ALTER TABLE [dbo].[tblProd] ADD  CONSTRAINT [DF_tblProd_Status]  DEFAULT ('A') FOR [Status]
GO
ALTER TABLE [dbo].[tblProdProvCli] ADD  CONSTRAINT [DF_tblProdProv_Status]  DEFAULT ('A') FOR [Status]
GO
ALTER TABLE [dbo].[tblProv] ADD  CONSTRAINT [DF_tblProv_Status]  DEFAULT ('A') FOR [Status]
GO
ALTER TABLE [dbo].[tblTrans] ADD  CONSTRAINT [DF_tblTrans_Status]  DEFAULT ('A') FOR [Status]
GO
ALTER TABLE [dbo].[tblVeh] ADD  CONSTRAINT [DF_tblVeh_Status]  DEFAULT ('A') FOR [Status]
GO
