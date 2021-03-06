USE [DHL]
GO
/****** Object:  Table [dbo].[ITEM]    Script Date: 17/05/2015 12:49:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ITEM](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ITEMID] [nvarchar](max) NULL,
	[PRODID] [nvarchar](max) NULL,
	[PRODUCTNAME] [nvarchar](max) NULL,
	[PARTNUMBER] [nvarchar](max) NULL,
	[PRICE] [int] NULL,
	[QUANTITY] [int] NULL,
	[SHIPORDERID] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SHIPMENT]    Script Date: 17/05/2015 12:49:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SHIPMENT](
	[SHIPMENTID] [bigint] IDENTITY(1,1) NOT NULL,
	[SHIPPARTNER] [nvarchar](max) NULL,
	[SHIPSUPPLIER] [nvarchar](max) NULL,
	[SHIPORDERID] [nvarchar](max) NULL,
	[SHIPADDRESSEENAME] [nvarchar](max) NULL,
	[SHIPADDRESSEELASTNAME] [nvarchar](max) NULL,
	[SHIPCOUNTRY] [nvarchar](max) NULL,
	[SHIPCITY] [nvarchar](max) NULL,
	[SHIPSTREET] [nvarchar](max) NULL,
	[SHIPSTATE] [nvarchar](max) NULL,
	[SHIPZIPCODE] [nvarchar](max) NULL,
	[SHIPITEMS] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
