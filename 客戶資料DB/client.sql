USE [G:\PROJECTS\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\客戶資料.MDF]
GO
/****** Object:  Table [dbo].[客戶聯絡人]    Script Date: 2017/12/9 下午 10:41:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[客戶聯絡人](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[客戶Id] [int] NOT NULL,
	[職稱] [nvarchar](50) NOT NULL,
	[姓名] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[手機] [nvarchar](50) NULL,
	[電話] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[客戶資料]    Script Date: 2017/12/9 下午 10:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[客戶資料](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[客戶名稱] [nvarchar](50) NOT NULL,
	[統一編號] [char](8) NOT NULL,
	[電話] [nvarchar](50) NOT NULL,
	[傳真] [nvarchar](50) NULL,
	[地址] [nvarchar](100) NULL,
	[Email] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[客戶銀行資訊]    Script Date: 2017/12/9 下午 10:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[客戶銀行資訊](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[客戶Id] [int] NOT NULL,
	[銀行名稱] [nvarchar](50) NOT NULL,
	[銀行代碼] [int] NOT NULL,
	[分行代碼] [int] NULL,
	[帳戶名稱] [nvarchar](50) NOT NULL,
	[帳戶號碼] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_客戶銀行資訊] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[客戶資料] ON 

INSERT [dbo].[客戶資料] ([Id], [客戶名稱], [統一編號], [電話], [傳真], [地址], [Email]) VALUES (1, N'多奇數位', N'12694272', N'0223222480', N'0223418318', N'台北市中正區杭州南路一段六巷五號三樓', N'service@miniasp.com')
SET IDENTITY_INSERT [dbo].[客戶資料] OFF
ALTER TABLE [dbo].[客戶聯絡人]  WITH CHECK ADD  CONSTRAINT [FK_客戶聯絡人_客戶資料] FOREIGN KEY([客戶Id])
REFERENCES [dbo].[客戶資料] ([Id])
GO
ALTER TABLE [dbo].[客戶聯絡人] CHECK CONSTRAINT [FK_客戶聯絡人_客戶資料]
GO
ALTER TABLE [dbo].[客戶銀行資訊]  WITH CHECK ADD  CONSTRAINT [FK_客戶銀行資訊_客戶資料] FOREIGN KEY([客戶Id])
REFERENCES [dbo].[客戶資料] ([Id])
GO
ALTER TABLE [dbo].[客戶銀行資訊] CHECK CONSTRAINT [FK_客戶銀行資訊_客戶資料]
GO
