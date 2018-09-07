USE [Lotodb]
GO

/****** Object:  Table [dbo].[tblKetqua]    Script Date: 9/6/2018 1:53:48 PM ******/

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblKetqua](
	[NgayMoThuong] [date] NOT NULL,
	[G0] [nchar](2) NOT NULL,
	[G1] [nchar](2) NOT NULL,
	[G21] [nchar](2) NOT NULL,
	[G22] [nchar](2) NOT NULL,
	[G31] [nchar](2) NOT NULL,
	[G32] [nchar](2) NOT NULL,
	[G33] [nchar](2) NOT NULL,
	[G34] [nchar](2) NOT NULL,
	[G35] [nchar](2) NOT NULL,
	[G36] [nchar](2) NOT NULL,
	[G41] [nchar](2) NOT NULL,
	[G42] [nchar](2) NOT NULL,
	[G43] [nchar](2) NOT NULL,
	[G44] [nchar](2) NOT NULL,
	[G51] [nchar](2) NOT NULL,
	[G52] [nchar](2) NOT NULL,
	[G53] [nchar](2) NOT NULL,
	[G54] [nchar](2) NOT NULL,
	[G55] [nchar](2) NOT NULL,
	[G56] [nchar](2) NOT NULL,
	[G61] [nchar](2) NOT NULL,
	[G62] [nchar](2) NOT NULL,
	[G63] [nchar](2) NOT NULL,
	[G71] [nchar](2) NOT NULL,
	[G72] [nchar](2) NOT NULL,
	[G73] [nchar](2) NOT NULL,
	[G74] [nchar](2) NOT NULL,
	[UserId] [nvarchar](50) NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	CONSTRAINT [PK_tblKetqua] PRIMARY KEY CLUSTERED 
(
	[NgayMoThuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblKetqua] ADD  CONSTRAINT [DF_tblKetqua_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO


