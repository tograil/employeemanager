USE [master]
GO

/****** Object:  Database [EmployeeManagement]    Script Date: 14.12.2023 10:21:56 ******/
CREATE DATABASE [EmployeeManagementNew]
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeManagementNew].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [EmployeeManagementNew] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET ARITHABORT OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [EmployeeManagementNew] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [EmployeeManagementNew] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [EmployeeManagementNew] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET  ENABLE_BROKER 
GO

ALTER DATABASE [EmployeeManagementNew] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [EmployeeManagementNew] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [EmployeeManagementNew] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [EmployeeManagementNew] SET  MULTI_USER 
GO

ALTER DATABASE [EmployeeManagementNew] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [EmployeeManagementNew] SET DB_CHAINING OFF 
GO

ALTER DATABASE [EmployeeManagementNew] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [EmployeeManagementNew] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [EmployeeManagementNew] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [EmployeeManagementNew] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [EmployeeManagementNew] SET QUERY_STORE = OFF
GO

ALTER DATABASE [EmployeeManagementNew] SET  READ_WRITE 
GO

USE [EmployeeManagementNew]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[PersonType] [nvarchar](13) NOT NULL,
	[PayPerHour] [decimal](5, 2) NULL,
	[AnnualSalary] [decimal](10, 2) NULL,
	[MaxExpenseAmount] [decimal](10, 2) NULL,
	[Supervisor_AnnualSalary] [decimal](10, 2) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


