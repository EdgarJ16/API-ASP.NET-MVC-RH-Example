USE [master]
GO
/****** Object:  Database [Proyecto2]    Script Date: 15/08/2022 11:58:01 p. m. ******/
CREATE DATABASE [Proyecto2]

GO
ALTER DATABASE [Proyecto2] SET COMPATIBILITY_LEVEL = 150
GO

USE [Proyecto2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15/08/2022 11:58:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Concursante]    Script Date: 15/08/2022 11:58:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Concursante](
	[ID] [int] NOT NULL,
	[Nombre] [nvarchar](60) NULL,
	[NotaPPsic] [int] NULL,
	[NotaPEnt] [int] NULL,
	[NotaPTec] [int] NULL,
	[ConcursoID] [int] NULL,
 CONSTRAINT [PK_Concursante] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Concurso]    Script Date: 15/08/2022 11:58:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Concurso](
	[ID] [int] NOT NULL,
	[Estado] [nvarchar](50) NULL,
	[Nombre] [varchar](max) NULL,
 CONSTRAINT [PK_Concurso] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Experiencia]    Script Date: 15/08/2022 11:58:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Experiencia](
	[ID] [nvarchar](60) NOT NULL,
	[OferenteID] [nvarchar](12) NULL,
	[Empresa] [nvarchar](150) NULL,
	[AñoInicio] [int] NULL,
	[AñoFIn] [int] NULL,
 CONSTRAINT [PK_Experiencia] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oferentes]    Script Date: 15/08/2022 11:58:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oferentes](
	[ID] [nvarchar](12) NOT NULL,
	[Nombre] [nvarchar](60) NOT NULL,
	[Ministerios] [varchar](50) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Correo] [nvarchar](100) NOT NULL,
	[Profesion] [varchar](50) NOT NULL,
	[Nacimiento] [int] NOT NULL,
	[AñoExp] [int] NOT NULL,
 CONSTRAINT [PK_Oferentes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Titulos]    Script Date: 15/08/2022 11:58:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titulos](
	[ID] [varchar](50) NOT NULL,
	[Grado] [varchar](150) NULL,
	[Centro] [varchar](60) NULL,
	[AñoAdquirido] [int] NULL,
	[OferenteID] [nvarchar](12) NULL,
 CONSTRAINT [PK_Titulos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Concursante] ([ID], [Nombre], [NotaPPsic], [NotaPEnt], [NotaPTec], [ConcursoID]) VALUES (3, N'string', 100, 100, 100, NULL)
GO
INSERT [dbo].[Concurso] ([ID], [Estado], [Nombre]) VALUES (4, N'string', N'string')
GO
INSERT [dbo].[Experiencia] ([ID], [OferenteID], [Empresa], [AñoInicio], [AñoFIn]) VALUES (N'1E111222333698', NULL, N'Universidad UNED', 2002, 2022)
GO
INSERT [dbo].[Experiencia] ([ID], [OferenteID], [Empresa], [AñoInicio], [AñoFIn]) VALUES (N'1E878111333444', NULL, N'Teleperformance', 2005, 2022)
GO
INSERT [dbo].[Experiencia] ([ID], [OferenteID], [Empresa], [AñoInicio], [AñoFIn]) VALUES (N'1E888888888888', NULL, N'Universidad UNED', 2005, 2010)
GO
INSERT [dbo].[Experiencia] ([ID], [OferenteID], [Empresa], [AñoInicio], [AñoFIn]) VALUES (N'2E888888888888', NULL, N'Teleperformance', 2006, 2007)
GO
INSERT [dbo].[Oferentes] ([ID], [Nombre], [Ministerios], [Telefono], [Correo], [Profesion], [Nacimiento], [AñoExp]) VALUES (N'111222333698', N'Edgar Jacob', N'MREC', 111555888, N'edgarjacob16@gmail.com', N'ing en sistemas', 2000, 0)
GO
INSERT [dbo].[Oferentes] ([ID], [Nombre], [Ministerios], [Telefono], [Correo], [Profesion], [Nacimiento], [AñoExp]) VALUES (N'878111333444', N'Alberto Einstain', N'MOPT', 666555444, N'edgarjacob16@gmail.com', N'ing en sistemas', 1956, 0)
GO
INSERT [dbo].[Oferentes] ([ID], [Nombre], [Ministerios], [Telefono], [Correo], [Profesion], [Nacimiento], [AñoExp]) VALUES (N'888888888888', N'Alan tornin', N'MIDEPLAN', 154125145, N'edgarjacob16@gmail.com', N'ing en sistemas', 2000, 0)
GO
INSERT [dbo].[Titulos] ([ID], [Grado], [Centro], [AñoAdquirido], [OferenteID]) VALUES (N'1T878111333444', N'Licenciatura', N'UNED CostaRica', 2002, NULL)
GO
INSERT [dbo].[Titulos] ([ID], [Grado], [Centro], [AñoAdquirido], [OferenteID]) VALUES (N'1T888888888888', N'Doctorados', N'UNED CostaRica', 2006, NULL)
GO
INSERT [dbo].[Titulos] ([ID], [Grado], [Centro], [AñoAdquirido], [OferenteID]) VALUES (N'2T878111333444', N'Licenciatura', N'UNED CostaRica', 2002, NULL)
GO
INSERT [dbo].[Titulos] ([ID], [Grado], [Centro], [AñoAdquirido], [OferenteID]) VALUES (N'2T888888888888', N'Doctorados', N'Tecnologico de costa rica', 2007, NULL)
GO
INSERT [dbo].[Titulos] ([ID], [Grado], [Centro], [AñoAdquirido], [OferenteID]) VALUES (N'3T878111333444', N'Licenciatura', N'UNED CostaRica', 2002, NULL)
GO
INSERT [dbo].[Titulos] ([ID], [Grado], [Centro], [AñoAdquirido], [OferenteID]) VALUES (N'3T888888888888', N'Doctorados', N'Tecnologico de costa rica', 2007, NULL)
GO
ALTER TABLE [dbo].[Concursante]  WITH CHECK ADD  CONSTRAINT [FK_Concursante_Concurso] FOREIGN KEY([ConcursoID])
REFERENCES [dbo].[Concurso] ([ID])
GO
ALTER TABLE [dbo].[Concursante] CHECK CONSTRAINT [FK_Concursante_Concurso]
GO
ALTER TABLE [dbo].[Experiencia]  WITH CHECK ADD  CONSTRAINT [FK_Experiencia_Oferentes] FOREIGN KEY([OferenteID])
REFERENCES [dbo].[Oferentes] ([ID])
GO
ALTER TABLE [dbo].[Experiencia] CHECK CONSTRAINT [FK_Experiencia_Oferentes]
GO
ALTER TABLE [dbo].[Titulos]  WITH CHECK ADD  CONSTRAINT [FK_Titulos_Oferentes] FOREIGN KEY([OferenteID])
REFERENCES [dbo].[Oferentes] ([ID])
GO
ALTER TABLE [dbo].[Titulos] CHECK CONSTRAINT [FK_Titulos_Oferentes]
GO
USE [master]
GO
ALTER DATABASE [Proyecto2] SET  READ_WRITE 
GO
