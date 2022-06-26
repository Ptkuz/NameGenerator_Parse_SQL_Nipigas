CREATE DATABASE [NipigasDB]
GO
USE [NipigasDB]
GO
CREATE TABLE NameGenerator (
    [Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Person_Name] [nvarchar](256) NOT NULL,
    [Addres] [nvarchar](300) NOT NULL,
    [Mothers_Maiden_Name] [nvarchar](256) NOT NULL,
    [SSN] [nvarchar](256) NOT NULL,
    [Geo_Coordinates] [nvarchar](256) NOT NULL,
    [Phone] [nvarchar](256) NOT NULL,
    [Country_Code] [int] NOT NULL,
    [Birthday] [datetime2](7) NOT NULL,
    [Age] [int] NOT NULL,
    [Tropical_Zodiac] [nvarchar](256) NOT NULL,
    [Email] [nvarchar](300) NOT NULL,
    [UserName] [nvarchar](256) NOT NULL,
    [Password] [nvarchar](256) NOT NULL,
    [Website] [nvarchar](256) NOT NULL,
    [MasterCard] [nvarchar](256) NOT NULL,
    [Expires] [nvarchar](256) NOT NULL,
    [CVC2] [int] NOT NULL,
    [Company] [nvarchar](256) NOT NULL,
    [Occupation] [nvarchar](300) NOT NULL,
    [Height] [nvarchar](256) NOT NULL,
    [Weight] [nvarchar](256) NOT NULL,
    [Blood_Type] [nvarchar](256) NOT NULL,
    [Favorite_Color] [nvarchar](256) NOT NULL,
    [GUID] [nvarchar](500) NULL
)
