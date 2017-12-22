CREATE TABLE [dbo].[Cache](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](250) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[Created] [datetime] NOT NULL,
	[LastAccess] [datetime] NOT NULL,
	[SlidingExpirationTimeInMinutes] [int] NULL,
	[AbsoluteExpirationTime] [datetime] NULL,
	[ObjectType] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Cache] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO





