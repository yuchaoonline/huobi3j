ALTER TABLE dbo.Coupons_Subject ADD SubjectType NVARCHAR(50)
ALTER TABLE dbo.Coupons_Subject ADD CreateUserID INT

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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