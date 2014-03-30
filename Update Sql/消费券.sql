SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Coupons_Subject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Inactive] [bit] NULL,
 CONSTRAINT [PK_Common_CouponsGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[Coupons_List](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL,
	[Money] [money] NULL,
	[IsMoney] [bit] NULL,
	[Password] [nvarchar](50) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[IsUse] [bit] NULL,
	[UserID] [int] NULL,
	[UseDate] [datetime] NULL,
	[Memo] [nvarchar](50) NULL,
	[Inactive] [bit] NULL,
 CONSTRAINT [PK_Common_Coupons] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Coupons_List] ADD  CONSTRAINT [DF_Coupons_List_Inactive]  DEFAULT ((0)) FOR [Inactive]
GO

CREATE VIEW [dbo].[vw_Coupons_Subject]
AS
SELECT     ID, Name, StartDate, EndDate, Inactive,
                          (SELECT     COUNT(*) AS Expr1
                            FROM          dbo.Coupons_List
                            WHERE      (SubjectID = s.ID)) AS money_count
FROM         dbo.Coupons_Subject AS s

GO

CREATE VIEW [dbo].[vw_Coupons_List]
AS
SELECT     list.ID, list.SubjectID, s.Name AS SubjectName, list.Money, list.IsMoney, list.Password, list.StartDate, list.EndDate, list.IsUse, list.UserID, list.UseDate, list.Memo, 
                      u.LoginName
FROM         dbo.Coupons_List AS list LEFT OUTER JOIN
                      dbo.Coupons_Subject AS s ON list.SubjectID = s.ID LEFT OUTER JOIN
                      dbo.Users AS u ON list.UserID = u.ID

GO