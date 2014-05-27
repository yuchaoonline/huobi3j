SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TABLE dbo.Coupons_Subject ADD SubjectType NVARCHAR(50)
ALTER TABLE dbo.Coupons_Subject ADD CreateUserID INT
GO

CREATE TABLE [dbo].[Coupons_CashWhenFee](
	[ID] [int] NOT NULL,
	[Money] [money] NULL,
	[Fee] [money] NULL,
	[CouponsSubjectID] [int] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[CreateDate] [date] NULL,
 CONSTRAINT [PK_Coupons_CashWhenFee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Coupons_CashWhenFee_Code](
	[ID] [int] NOT NULL,
	[Coupons_ListID] [int] NULL,
	[Code] [nvarchar](50) NULL,
 CONSTRAINT [PK_Coupons_CashWhenFee_Code] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE VIEW [dbo].[vw_Coupons_CashWhenFee_UserTicket]
AS
SELECT   s.SaleMan, s.SaleManUserID, l.ID, l.SubjectID, l.Money, l.StartDate, l.EndDate, l.IsUse, l.UserID, l.UseDate, 
                l.Memo AS Fee, code.Code
FROM      dbo.Coupons_List AS l LEFT OUTER JOIN
                    (SELECT   CouponsSubjectID
                     FROM      dbo.Coupons_CashWhenFee
                     GROUP BY CouponsSubjectID) AS ca ON l.SubjectID = ca.CouponsSubjectID LEFT OUTER JOIN
                    (SELECT   u.LoginName AS SaleMan, su.CreateUserID AS SaleManUserID, su.ID
                     FROM      dbo.Coupons_Subject AS su LEFT OUTER JOIN
                                     dbo.Users AS u ON su.CreateUserID = u.ID) AS s ON l.SubjectID = s.ID LEFT OUTER JOIN
                dbo.Coupons_CashWhenFee_Code AS code ON l.ID = code.Coupons_ListID
WHERE   (ca.CouponsSubjectID IS NOT NULL)

GO

INSERT  INTO [dbo].[BaseData]([Name] ,[Value] ,[IDentity])VALUES('接口站点' ,'http://mobile.huobi3j.com',2)
GO

CREATE TABLE [dbo].[Coupons_CashWhenFee_Condition](
	[ID] [int] NOT NULL,
	[SalemanUserID] [int] NULL,
	[Money] [money] NULL,
	[Memo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Coupons_CashWhenFee_Condition] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO