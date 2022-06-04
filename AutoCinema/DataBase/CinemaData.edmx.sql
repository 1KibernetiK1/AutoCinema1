
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/05/2022 00:43:38
-- Generated from EDMX file: C:\Users\12345\Desktop\AutoCinema\Autos\AutoCinema\AutoCinema\DataBase\CinemaData.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CinemaBase1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Билеты_Залы]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Билеты] DROP CONSTRAINT [FK_Билеты_Залы];
GO
IF OBJECT_ID(N'[dbo].[FK_Билеты_Сеансы]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Билеты] DROP CONSTRAINT [FK_Билеты_Сеансы];
GO
IF OBJECT_ID(N'[dbo].[FK_Бронь_Билеты]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Бронь] DROP CONSTRAINT [FK_Бронь_Билеты];
GO
IF OBJECT_ID(N'[dbo].[FK_Table_1_РазмерыЗалов]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Залы] DROP CONSTRAINT [FK_Table_1_РазмерыЗалов];
GO
IF OBJECT_ID(N'[dbo].[FK_СтоимостьБилетов_Сеансы]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[СтоимостьБилетов] DROP CONSTRAINT [FK_СтоимостьБилетов_Сеансы];
GO
IF OBJECT_ID(N'[dbo].[FK_Сеансы_Фильмы]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Сеансы] DROP CONSTRAINT [FK_Сеансы_Фильмы];
GO
IF OBJECT_ID(N'[dbo].[FK_СеансыЗалы]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Сеансы] DROP CONSTRAINT [FK_СеансыЗалы];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Билеты]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Билеты];
GO
IF OBJECT_ID(N'[dbo].[Бронь]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Бронь];
GO
IF OBJECT_ID(N'[dbo].[Залы]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Залы];
GO
IF OBJECT_ID(N'[dbo].[Пользователи]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Пользователи];
GO
IF OBJECT_ID(N'[dbo].[РазмерыЗалов]', 'U') IS NOT NULL
    DROP TABLE [dbo].[РазмерыЗалов];
GO
IF OBJECT_ID(N'[dbo].[Сеансы]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Сеансы];
GO
IF OBJECT_ID(N'[dbo].[СтоимостьБилетов]', 'U') IS NOT NULL
    DROP TABLE [dbo].[СтоимостьБилетов];
GO
IF OBJECT_ID(N'[dbo].[Фильмы]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Фильмы];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Билеты'
CREATE TABLE [dbo].[Билеты] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IDСеанса] int  NULL,
    [IDЗала] int  NULL,
    [Ряд] int  NULL,
    [Место] int  NULL,
    [Бронь] bit  NULL
);
GO

-- Creating table 'Бронь'
CREATE TABLE [dbo].[Бронь] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IDБилета] int  NULL,
    [ФИО] nvarchar(50)  NULL,
    [Телефон] nvarchar(50)  NULL
);
GO

-- Creating table 'Залы'
CREATE TABLE [dbo].[Залы] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [НомерЗала] int  NULL,
    [IDРазмера] int  NULL
);
GO

-- Creating table 'Пользователи'
CREATE TABLE [dbo].[Пользователи] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Логин] nvarchar(50)  NULL,
    [Пароль] nvarchar(50)  NULL,
    [УровеньДоступа] nvarchar(50)  NULL
);
GO

-- Creating table 'РазмерыЗалов'
CREATE TABLE [dbo].[РазмерыЗалов] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Наименование] nvarchar(50)  NULL,
    [КоличествоРядов] int  NULL
);
GO

-- Creating table 'Сеансы'
CREATE TABLE [dbo].[Сеансы] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IDФильма] int  NULL,
    [IDЗала] int  NULL,
    [Дата] nvarchar(max)  NULL,
    [Время] nvarchar(50)  NULL,
    [Премьера] nvarchar(max)  NULL,
    [Залы_ID] int  NULL
);
GO

-- Creating table 'СтоимостьБилетов'
CREATE TABLE [dbo].[СтоимостьБилетов] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IDСеанса] int  NULL,
    [Стоимость] int  NULL
);
GO

-- Creating table 'Фильмы'
CREATE TABLE [dbo].[Фильмы] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Название] nvarchar(100)  NULL,
    [Жанр] nvarchar(100)  NULL,
    [Длительность] nvarchar(100)  NULL,
    [Год] int  NULL,
    [Страна] nvarchar(100)  NULL,
    [Авторы] nvarchar(100)  NULL,
    [Описание] nvarchar(1000)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Билеты'
ALTER TABLE [dbo].[Билеты]
ADD CONSTRAINT [PK_Билеты]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Бронь'
ALTER TABLE [dbo].[Бронь]
ADD CONSTRAINT [PK_Бронь]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Залы'
ALTER TABLE [dbo].[Залы]
ADD CONSTRAINT [PK_Залы]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Пользователи'
ALTER TABLE [dbo].[Пользователи]
ADD CONSTRAINT [PK_Пользователи]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'РазмерыЗалов'
ALTER TABLE [dbo].[РазмерыЗалов]
ADD CONSTRAINT [PK_РазмерыЗалов]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Сеансы'
ALTER TABLE [dbo].[Сеансы]
ADD CONSTRAINT [PK_Сеансы]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'СтоимостьБилетов'
ALTER TABLE [dbo].[СтоимостьБилетов]
ADD CONSTRAINT [PK_СтоимостьБилетов]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Фильмы'
ALTER TABLE [dbo].[Фильмы]
ADD CONSTRAINT [PK_Фильмы]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IDЗала] in table 'Билеты'
ALTER TABLE [dbo].[Билеты]
ADD CONSTRAINT [FK_Билеты_Залы]
    FOREIGN KEY ([IDЗала])
    REFERENCES [dbo].[Залы]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Билеты_Залы'
CREATE INDEX [IX_FK_Билеты_Залы]
ON [dbo].[Билеты]
    ([IDЗала]);
GO

-- Creating foreign key on [IDСеанса] in table 'Билеты'
ALTER TABLE [dbo].[Билеты]
ADD CONSTRAINT [FK_Билеты_Сеансы]
    FOREIGN KEY ([IDСеанса])
    REFERENCES [dbo].[Сеансы]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Билеты_Сеансы'
CREATE INDEX [IX_FK_Билеты_Сеансы]
ON [dbo].[Билеты]
    ([IDСеанса]);
GO

-- Creating foreign key on [IDБилета] in table 'Бронь'
ALTER TABLE [dbo].[Бронь]
ADD CONSTRAINT [FK_Бронь_Билеты]
    FOREIGN KEY ([IDБилета])
    REFERENCES [dbo].[Билеты]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Бронь_Билеты'
CREATE INDEX [IX_FK_Бронь_Билеты]
ON [dbo].[Бронь]
    ([IDБилета]);
GO

-- Creating foreign key on [IDРазмера] in table 'Залы'
ALTER TABLE [dbo].[Залы]
ADD CONSTRAINT [FK_Table_1_РазмерыЗалов]
    FOREIGN KEY ([IDРазмера])
    REFERENCES [dbo].[РазмерыЗалов]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Table_1_РазмерыЗалов'
CREATE INDEX [IX_FK_Table_1_РазмерыЗалов]
ON [dbo].[Залы]
    ([IDРазмера]);
GO

-- Creating foreign key on [IDСеанса] in table 'СтоимостьБилетов'
ALTER TABLE [dbo].[СтоимостьБилетов]
ADD CONSTRAINT [FK_СтоимостьБилетов_Сеансы]
    FOREIGN KEY ([IDСеанса])
    REFERENCES [dbo].[Сеансы]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_СтоимостьБилетов_Сеансы'
CREATE INDEX [IX_FK_СтоимостьБилетов_Сеансы]
ON [dbo].[СтоимостьБилетов]
    ([IDСеанса]);
GO

-- Creating foreign key on [IDФильма] in table 'Сеансы'
ALTER TABLE [dbo].[Сеансы]
ADD CONSTRAINT [FK_Сеансы_Фильмы]
    FOREIGN KEY ([IDФильма])
    REFERENCES [dbo].[Фильмы]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Сеансы_Фильмы'
CREATE INDEX [IX_FK_Сеансы_Фильмы]
ON [dbo].[Сеансы]
    ([IDФильма]);
GO

-- Creating foreign key on [Залы_ID] in table 'Сеансы'
ALTER TABLE [dbo].[Сеансы]
ADD CONSTRAINT [FK_СеансыЗалы]
    FOREIGN KEY ([Залы_ID])
    REFERENCES [dbo].[Залы]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_СеансыЗалы'
CREATE INDEX [IX_FK_СеансыЗалы]
ON [dbo].[Сеансы]
    ([Залы_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------