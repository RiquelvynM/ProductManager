USE [DBProducts]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Details] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Detail] [nchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAdmin]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAdmin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nchar](50) NOT NULL,
	[Password] [nchar](50) NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[LastName] [nchar](50) NOT NULL,
	[Phone] [nchar](50) NOT NULL,
 CONSTRAINT [PK_UserAdmin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
/****** Object:  StoredProcedure [dbo].[Categories_Listing]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Categories_Listing]
as
begin
select * from Category
end
GO
/****** Object:  StoredProcedure [dbo].[Confirm_User]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Confirm_User]
@email varchar(max),
@password  varchar(max)
as
begin 
select * from UserAdmin where Email = @email and Password = @password
end
GO
/****** Object:  StoredProcedure [dbo].[Create_Category]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Create_Category]
@name varchar(max),
@details varchar(max)
as
begin
insert into Category values(@name,@details)
end
GO
/****** Object:  StoredProcedure [dbo].[Create_Product]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script para el comando SelectTopNRows de SSMS  ******/
CREATE procedure [dbo].[Create_Product]
@name varchar(max),
@price decimal(18,0),
@detail varchar(max),
@categoryId int
as 
begin
insert into Product values(@name,@price,@detail,@categoryId)
end
GO
/****** Object:  StoredProcedure [dbo].[Create_User]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script para el comando SelectTopNRows de SSMS  ******/
CREATE procedure [dbo].[Create_User]
@email varchar(max),
@password varchar(max),
@name varchar(max),
@lastName varchar(max),
@phone varchar(max)
as
begin
insert into UserAdmin values(@Email, @Password,@Name,@LastName,@Phone
)
end
GO
/****** Object:  StoredProcedure [dbo].[Delete_Category]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Delete_Category]
@id int
as
begin
delete Category where Id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[Delete_Product]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Delete_Product]
@id int
as 
begin
delete from Product where Id =@id
end
GO
/****** Object:  StoredProcedure [dbo].[Product_Listing]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Product_Listing]
as
begin 
Select top (1000) Product.Id
      ,Product.[Name]
      ,Product.[Price]
      ,Product.[Detail]
      , Category.Name as NameCategory
	  , Category.Id as IdCategory
	  FROM [DBProducts].[dbo].[Product] as Product
  inner Join [DBProducts].[dbo].[Category] as Category
  on Product.CategoryId = Category.Id
end
GO
/****** Object:  StoredProcedure [dbo].[Search_ByNameCategory]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Search_ByNameCategory]
@name varchar(max)
as
begin
select * from Category where [Name] like concat(@name,'%')
end
GO
/****** Object:  StoredProcedure [dbo].[Search_ByNameProduct]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Search_ByNameProduct]
@name varchar(max)
as
begin
select top (1000) Product.Id
      ,Product.[Name]
      ,Product.[Price]
      ,Product.[Detail]
      , Category.Name as NameCategory
	  FROM [DBProducts].[dbo].[Product] as Product
  inner Join [DBProducts].[dbo].[Category] as Category
  on Product.CategoryId = Category.Id
where Product.Name like concat(@name,'%')
end
GO
/****** Object:  StoredProcedure [dbo].[Search_CategoryById]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Search_CategoryById]
@id int
as
begin
select * from Category where Id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[Search_ProductById]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Search_ProductById]
@id int 
as
begin
Select top (1000) Product.Id 
      ,Product.[Name]
      ,Product.[Price]
      ,Product.[Detail]
      , Category.Name as NameCategory
	  , Category.Id as IdCategory
	  FROM [DBProducts].[dbo].[Product] as Product
  inner Join [DBProducts].[dbo].[Category] as Category
  on Product.CategoryId = Category.Id where Product.Id =@id 

end
GO
/****** Object:  StoredProcedure [dbo].[Search_User]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Search_User]
@id int
as
begin
select * from UserAdmin where Id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[Update_Category]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Update_Category]
@id int,
@name varchar(max),
@details varchar(max)
as
begin
update Category set [Name] = @name , Details =@details
where Id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[Update_Product]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Update_Product]
@id int,
@name varchar(max),
@price decimal(18,0),
@detail varchar(max),
@categoryId int
as
begin
update Product set
[Name] = @name,
Price =@price,
Detail =@detail,
CategoryId =@categoryId
where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[Update_UserAdmin]    Script Date: 11/8/2020 8:17:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script para el comando SelectTopNRows de SSMS  ******/
create procedure [dbo].[Update_UserAdmin]
@id int,
@email varchar(max),
@password varchar(max),
@name varchar(max),
@lastName varchar(max),
@phone varchar(max)
as
begin
update UserAdmin set Email = @email, [Password] = @password, [Name] =@name, LastName= @lastName, Phone =@phone
where Id = @id
end
GO
