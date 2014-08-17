SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Coupons_CashWhenFee_ShareFriend](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CodeID] [int] NULL,
	[DateTime] [datetime] NULL,
	[ShareType] [int] NULL,
 CONSTRAINT [PK_Coupons_CashWhenFee_ShareFriend] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Coupons_CashWhenFee_ShareFriendLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CodeID] [int] NULL,
	[UserID] [int] NULL,
	[DateTime] [datetime] NULL,
 CONSTRAINT [PK_Coupons_CashWhenFee_ShareFriendLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE dbo.Coupons_CashWhenFee_Code ADD OriginalMoney MONEY DEFAULT 0

CREATE TABLE [dbo].[Coupons_CashWhenFee_ShareFriendLevel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Count] [nvarchar](50) NULL,
	[Money] [money] NULL,
	[CodeID] [int] NULL,
 CONSTRAINT [PK_Coupons_CashWhenFee_ShareFriendLevel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [dbo].[BaseData]([Name],[Value],[IDentity])VALUES('运行网站','http://www.huobi3j.com/',3)
GO