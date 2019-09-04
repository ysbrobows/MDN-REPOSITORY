﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDN
{
    public class CRIACAO_DE_BANCO
    {
    }
}

// https://github.com/TheKalin/jQuery-File-Upload.MVC5 

//USE[master]
//GO

//CREATE DATABASE[SISGTS2]
// CONTAINMENT = NONE
// ON  PRIMARY
//(NAME = N'SISGTS2', FILENAME = N'E:\MSSQL\DATA\SISGTS2.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
// LOG ON
//(NAME = N'SISGTS2_log', FILENAME = N'E:\MSSQL\LOG\SISGTS2_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10 %)
//GO

//ALTER DATABASE[SISGTS2] SET COMPATIBILITY_LEVEL = 120
//GO

//IF(1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
//begin
//EXEC[SISGTS2].[dbo].[sp_fulltext_database] @action = 'enable'
//end
//GO

//ALTER DATABASE[SISGTS2] SET ANSI_NULL_DEFAULT OFF
//GO

//ALTER DATABASE[SISGTS2] SET ANSI_NULLS OFF
//GO

//ALTER DATABASE[SISGTS2] SET ANSI_PADDING OFF
//GO

//ALTER DATABASE[SISGTS2] SET ANSI_WARNINGS OFF
//GO

//ALTER DATABASE[SISGTS2] SET ARITHABORT OFF
//GO

//ALTER DATABASE[SISGTS2] SET AUTO_CLOSE OFF
//GO

//ALTER DATABASE[SISGTS2] SET AUTO_SHRINK OFF
//GO

//ALTER DATABASE[SISGTS2] SET AUTO_UPDATE_STATISTICS ON
//GO

//ALTER DATABASE[SISGTS2] SET CURSOR_CLOSE_ON_COMMIT OFF
//GO

//ALTER DATABASE[SISGTS2] SET CURSOR_DEFAULT  GLOBAL
//GO

//ALTER DATABASE[SISGTS2] SET CONCAT_NULL_YIELDS_NULL OFF
//GO

//ALTER DATABASE[SISGTS2] SET NUMERIC_ROUNDABORT OFF
//GO

//ALTER DATABASE[SISGTS2] SET QUOTED_IDENTIFIER OFF
//GO

//ALTER DATABASE[SISGTS2] SET RECURSIVE_TRIGGERS OFF
//GO

//ALTER DATABASE[SISGTS2] SET DISABLE_BROKER
//GO

//ALTER DATABASE[SISGTS2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
//GO

//ALTER DATABASE[SISGTS2] SET DATE_CORRELATION_OPTIMIZATION OFF
//GO

//ALTER DATABASE[SISGTS2] SET TRUSTWORTHY OFF
//GO

//ALTER DATABASE[SISGTS2] SET ALLOW_SNAPSHOT_ISOLATION OFF
//GO

//ALTER DATABASE[SISGTS2] SET PARAMETERIZATION SIMPLE
//GO

//ALTER DATABASE[SISGTS2] SET READ_COMMITTED_SNAPSHOT OFF
//GO

//ALTER DATABASE[SISGTS2] SET HONOR_BROKER_PRIORITY OFF
//GO

//ALTER DATABASE[SISGTS2] SET RECOVERY FULL
//GO

//ALTER DATABASE[SISGTS2] SET  MULTI_USER
//GO

//ALTER DATABASE[SISGTS2] SET PAGE_VERIFY CHECKSUM
//GO

//ALTER DATABASE[SISGTS2] SET DB_CHAINING OFF
//GO

//ALTER DATABASE[SISGTS2] SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF)
//GO

//ALTER DATABASE[SISGTS2] SET TARGET_RECOVERY_TIME = 0 SECONDS
//GO

//ALTER DATABASE[SISGTS2] SET DELAYED_DURABILITY = DISABLED
//GO

//ALTER DATABASE[SISGTS2] SET  READ_WRITE
//GO


//**************************************************************************************************************************************
//USE[SISMDN]
//GO

///****** Object:  Table [dbo].[T002_CATEGORIA]    Script Date: 04/09/2019 17:15:28 ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE[dbo].[T002_CATEGORIA]
//(

//   [T002_ID_CATEGORIA][int] IDENTITY(1,1) NOT NULL,

//  [T002_NO_CATEGORIA] [varchar] (100) NULL,
// CONSTRAINT[PK_T002_CATEGORIA] PRIMARY KEY CLUSTERED
//(
//   [T002_ID_CATEGORIA] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
//) ON[PRIMARY]

//GO



//**************************************************************************************************************************************
//USE[SISMDN]
//GO

///****** Object:  Table [dbo].[T003_UF]    Script Date: 04/09/2019 17:16:43 ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE[dbo].[T003_UF]
//(

//   [T003_ID_UF][int] IDENTITY(1,1) NOT NULL,

//  [T003_NO_UF] [varchar] (2) NULL,
// CONSTRAINT[PK_T003_UF] PRIMARY KEY CLUSTERED
//(
//   [T003_ID_UF] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
//) ON[PRIMARY]

//GO




//**************************************************************************************************************************************
//USE[SISMDN]
//GO

///****** Object:  Table [dbo].[T001_PRODUTO]    Script Date: 04/09/2019 17:13:37 ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE[dbo].[T001_PRODUTO]
//(

//   [T001_ID_PRODUTO][int] IDENTITY(1,1) NOT NULL,

//  [T001_TITULO] [varchar] (100) NULL,
//	[T001_DESCRICAO] [varchar] (8000) NULL,
//	[T001_FOTO] [nchar] (10) NULL,
//	[T001_PRECO] [money] NULL,
//	[T002_ID_CATEGORIA] [int] NULL,
//	[T003_ID_UF] [int] NULL,
//	[UserName] [nvarchar] (256) NULL,
// CONSTRAINT[PK_T001_PRODUTO] PRIMARY KEY CLUSTERED
//(
//   [T001_ID_PRODUTO] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
//) ON[PRIMARY]

//GO

//ALTER TABLE[dbo].[T001_PRODUTO] WITH CHECK ADD CONSTRAINT[FK_T001_PRODUTO_T002_CATEGORIA] FOREIGN KEY([T002_ID_CATEGORIA])
//REFERENCES[dbo].[T002_CATEGORIA]
//([T002_ID_CATEGORIA])
//GO

//ALTER TABLE[dbo].[T001_PRODUTO]
//CHECK CONSTRAINT[FK_T001_PRODUTO_T002_CATEGORIA]
//GO

//ALTER TABLE[dbo].[T001_PRODUTO] WITH CHECK ADD CONSTRAINT[FK_T001_PRODUTO_T003_UF] FOREIGN KEY([T003_ID_UF])
//REFERENCES[dbo].[T003_UF]
//([T003_ID_UF])
//GO

//ALTER TABLE[dbo].[T001_PRODUTO]
//CHECK CONSTRAINT[FK_T001_PRODUTO_T003_UF]
//GO



