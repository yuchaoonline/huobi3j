SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TABLE dbo.Coupons_Subject ADD SubjectType NVARCHAR(50)
ALTER TABLE dbo.Coupons_Subject ADD CreateUserID INT
GO

CREATE TABLE [dbo].[Coupons_CashWhenFee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Money] [money] NULL,
	[Fee] [money] NULL,
	[CreateUserID] [int] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Coupons_CashWhenFee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Coupons_CashWhenFee_Code](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fee] [money] NULL,
	[Money] [money] NULL,
	[Count] [int] NULL,
	[UseCount] [int] NULL,
	[UserID] [int] NULL,
	[SaleManUserID] [int] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_Coupons_CashWhenFee_Code] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Coupons_CashWhenFee_CodeLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserCode] [varchar](8) NULL,
	[CodeID] [int] NULL,
	[UseCount] [int] NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_Coupons_CashWhenFee_CodeLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Coupons_CashWhenFee_Condition](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SaleManUserID] [int] NULL,
	[Money] [money] NULL,
	[Memo] [nvarchar](50) NULL,
	[IsShow] [bit] NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_Coupons_CashWhenFee_Condition] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE VIEW [dbo].[vw_Coupons_CashWhenFee_UserTicket]
AS
SELECT   code.ID, code.Fee, code.Money, code.Count, code.UseCount, code.UserID, u.LoginName AS UserName, 
                code.SaleManUserID, code.StartDate, code.EndDate, code.CreateTime, saleman.CompanyName
FROM      dbo.Coupons_CashWhenFee_Code AS code LEFT OUTER JOIN
                dbo.vw_Key_CircleSaleMan AS saleman ON code.SaleManUserID = saleman.UserID LEFT OUTER JOIN
                dbo.Users AS u ON code.UserID = u.ID

GO

CREATE VIEW [dbo].[vw_Coupons_CashWhenFee_UseLog]
AS
SELECT   l.ID, l.UserCode, l.CodeID, l.UseCount, l.CreateTime, code.Money, code.Fee
FROM      dbo.Coupons_CashWhenFee_CodeLog AS l LEFT OUTER JOIN
                dbo.Coupons_CashWhenFee_Code AS code ON l.CodeID = code.ID

GO

INSERT  INTO [dbo].[BaseData]([Name] ,[Value] ,[IDentity])VALUES('接口站点' ,'http://mobile.huobi3j.com',2)
GO