
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/19/2021 00:17:06
-- Generated from EDMX file: E:\Projects\Cine\OrjinalCode\CineBook\CinemaBooking\CinemaBooking\CinemaBookingDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CinemaBooking];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ModuleAuth_ModuleOperation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ModuleAuth] DROP CONSTRAINT [FK_ModuleAuth_ModuleOperation];
GO
IF OBJECT_ID(N'[dbo].[FK_ModuleAuth_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ModuleAuth] DROP CONSTRAINT [FK_ModuleAuth_User];
GO
IF OBJECT_ID(N'[dbo].[FK_ModuleAuth_UserGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ModuleAuth] DROP CONSTRAINT [FK_ModuleAuth_UserGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_ModuleOperation_Module]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ModuleOperation] DROP CONSTRAINT [FK_ModuleOperation_Module];
GO
IF OBJECT_ID(N'[dbo].[FK_Movie_MovieCast_Movie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movie_MovieCast] DROP CONSTRAINT [FK_Movie_MovieCast_Movie];
GO
IF OBJECT_ID(N'[dbo].[FK_Movie_MovieCast_MovieCast]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movie_MovieCast] DROP CONSTRAINT [FK_Movie_MovieCast_MovieCast];
GO
IF OBJECT_ID(N'[dbo].[FK_Movie_MovieCategory_Movie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movie_MovieCategory] DROP CONSTRAINT [FK_Movie_MovieCategory_Movie];
GO
IF OBJECT_ID(N'[dbo].[FK_Movie_MovieCategory_MovieCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movie_MovieCategory] DROP CONSTRAINT [FK_Movie_MovieCategory_MovieCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_Movie_MovieDirector_Movie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movie_MovieDirector] DROP CONSTRAINT [FK_Movie_MovieDirector_Movie];
GO
IF OBJECT_ID(N'[dbo].[FK_Movie_MovieDirector_MovieDirector]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movie_MovieDirector] DROP CONSTRAINT [FK_Movie_MovieDirector_MovieDirector];
GO
IF OBJECT_ID(N'[dbo].[FK_Movie_MovieFormat_Movie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movie_MovieFormat] DROP CONSTRAINT [FK_Movie_MovieFormat_Movie];
GO
IF OBJECT_ID(N'[dbo].[FK_Movie_MovieFormat_MovieFormat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movie_MovieFormat] DROP CONSTRAINT [FK_Movie_MovieFormat_MovieFormat];
GO
IF OBJECT_ID(N'[dbo].[FK_Movie_MovieType_Movie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movie_MovieType] DROP CONSTRAINT [FK_Movie_MovieType_Movie];
GO
IF OBJECT_ID(N'[dbo].[FK_Movie_MovieType_MovieType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movie_MovieType] DROP CONSTRAINT [FK_Movie_MovieType_MovieType];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieSession_Movie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieSession] DROP CONSTRAINT [FK_MovieSession_Movie];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieSession_MovieTheatrePlace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieSession] DROP CONSTRAINT [FK_MovieSession_MovieTheatrePlace];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieSessionAmount_MovieSeatType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieSessionAmount] DROP CONSTRAINT [FK_MovieSessionAmount_MovieSeatType];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieSessionAmount_MovieSession]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieSessionAmount] DROP CONSTRAINT [FK_MovieSessionAmount_MovieSession];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieSessionAmount_MovieTariff]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieSessionAmount] DROP CONSTRAINT [FK_MovieSessionAmount_MovieTariff];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieSessionBooking_MovieSession]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieSessionBooking] DROP CONSTRAINT [FK_MovieSessionBooking_MovieSession];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieSessionBookingDetail_MovieSeatType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieSessionBookingDetail] DROP CONSTRAINT [FK_MovieSessionBookingDetail_MovieSeatType];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieSessionBookingDetail_MovieSessionBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieSessionBookingDetail] DROP CONSTRAINT [FK_MovieSessionBookingDetail_MovieSessionBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieSessionReservation_MovieSeatType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieSessionReservation] DROP CONSTRAINT [FK_MovieSessionReservation_MovieSeatType];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieSessionReservation_MovieSession]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieSessionReservation] DROP CONSTRAINT [FK_MovieSessionReservation_MovieSession];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieSessionReservation_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieSessionReservation] DROP CONSTRAINT [FK_MovieSessionReservation_User];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieTheatrePlace_MovieTheater]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieTheatrePlace] DROP CONSTRAINT [FK_MovieTheatrePlace_MovieTheater];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieTheatrePlace_MovieTheatrePlaceTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieTheatrePlace] DROP CONSTRAINT [FK_MovieTheatrePlace_MovieTheatrePlaceTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieTheatrePlaceTemplateBlock_MovieTheatrePlaceTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieTheatrePlaceTemplateBlock] DROP CONSTRAINT [FK_MovieTheatrePlaceTemplateBlock_MovieTheatrePlaceTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieTheatrePlaceTemplateDetails_MovieSeatType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieTheatrePlaceTemplateDetails] DROP CONSTRAINT [FK_MovieTheatrePlaceTemplateDetails_MovieSeatType];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieTheatrePlaceTemplateDetails_MovieTheatrePlaceTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieTheatrePlaceTemplateDetails] DROP CONSTRAINT [FK_MovieTheatrePlaceTemplateDetails_MovieTheatrePlaceTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieTicket_MovieSeatType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieTicket] DROP CONSTRAINT [FK_MovieTicket_MovieSeatType];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieTicket_MovieTariff]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieTicket] DROP CONSTRAINT [FK_MovieTicket_MovieTariff];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieTicket_MovieTicketSale]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieTicket] DROP CONSTRAINT [FK_MovieTicket_MovieTicketSale];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieTicketSale_MovieSession]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieTicketSale] DROP CONSTRAINT [FK_MovieTicketSale_MovieSession];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieTicketSale_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieTicketSale] DROP CONSTRAINT [FK_MovieTicketSale_User];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieTicketSaleOption_MovieTicketOption]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieTicketSaleOption] DROP CONSTRAINT [FK_MovieTicketSaleOption_MovieTicketOption];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieTicketSaleOption_MovieTicketSale]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieTicketSaleOption] DROP CONSTRAINT [FK_MovieTicketSaleOption_MovieTicketSale];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieTicketSalePayment_MovieTicketSale]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieTicketSalePayment] DROP CONSTRAINT [FK_MovieTicketSalePayment_MovieTicketSale];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieTicketSalePayment_MovieTicketSalePaymentType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieTicketSalePayment] DROP CONSTRAINT [FK_MovieTicketSalePayment_MovieTicketSalePaymentType];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Languages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Languages];
GO
IF OBJECT_ID(N'[dbo].[FK_UserGroup_User_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserGroup_User] DROP CONSTRAINT [FK_UserGroup_User_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserGroup_User_UserGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserGroup_User] DROP CONSTRAINT [FK_UserGroup_User_UserGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_UserSession_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSession] DROP CONSTRAINT [FK_UserSession_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[LabelDictionary]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LabelDictionary];
GO
IF OBJECT_ID(N'[dbo].[Languages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Languages];
GO
IF OBJECT_ID(N'[dbo].[Module]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Module];
GO
IF OBJECT_ID(N'[dbo].[ModuleAuth]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ModuleAuth];
GO
IF OBJECT_ID(N'[dbo].[ModuleOperation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ModuleOperation];
GO
IF OBJECT_ID(N'[dbo].[Movie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movie];
GO
IF OBJECT_ID(N'[dbo].[Movie_MovieCast]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movie_MovieCast];
GO
IF OBJECT_ID(N'[dbo].[Movie_MovieCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movie_MovieCategory];
GO
IF OBJECT_ID(N'[dbo].[Movie_MovieDirector]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movie_MovieDirector];
GO
IF OBJECT_ID(N'[dbo].[Movie_MovieFormat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movie_MovieFormat];
GO
IF OBJECT_ID(N'[dbo].[Movie_MovieType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movie_MovieType];
GO
IF OBJECT_ID(N'[dbo].[MovieCast]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieCast];
GO
IF OBJECT_ID(N'[dbo].[MovieCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieCategory];
GO
IF OBJECT_ID(N'[dbo].[MovieDirector]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieDirector];
GO
IF OBJECT_ID(N'[dbo].[MovieFormat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieFormat];
GO
IF OBJECT_ID(N'[dbo].[MovieSeatType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieSeatType];
GO
IF OBJECT_ID(N'[dbo].[MovieSession]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieSession];
GO
IF OBJECT_ID(N'[dbo].[MovieSession_MovieFormat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieSession_MovieFormat];
GO
IF OBJECT_ID(N'[dbo].[MovieSessionAmount]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieSessionAmount];
GO
IF OBJECT_ID(N'[dbo].[MovieSessionBooking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieSessionBooking];
GO
IF OBJECT_ID(N'[dbo].[MovieSessionBookingDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieSessionBookingDetail];
GO
IF OBJECT_ID(N'[dbo].[MovieSessionLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieSessionLog];
GO
IF OBJECT_ID(N'[dbo].[MovieSessionReservation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieSessionReservation];
GO
IF OBJECT_ID(N'[dbo].[MovieTariff]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTariff];
GO
IF OBJECT_ID(N'[dbo].[MovieTheater]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTheater];
GO
IF OBJECT_ID(N'[dbo].[MovieTheaterLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTheaterLog];
GO
IF OBJECT_ID(N'[dbo].[MovieTheatrePlace]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTheatrePlace];
GO
IF OBJECT_ID(N'[dbo].[MovieTheatrePlaceLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTheatrePlaceLog];
GO
IF OBJECT_ID(N'[dbo].[MovieTheatrePlaceTemplate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTheatrePlaceTemplate];
GO
IF OBJECT_ID(N'[dbo].[MovieTheatrePlaceTemplateBlock]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTheatrePlaceTemplateBlock];
GO
IF OBJECT_ID(N'[dbo].[MovieTheatrePlaceTemplateDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTheatrePlaceTemplateDetails];
GO
IF OBJECT_ID(N'[dbo].[MovieTheatrePlaceTemplateDetailsLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTheatrePlaceTemplateDetailsLog];
GO
IF OBJECT_ID(N'[dbo].[MovieTicket]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTicket];
GO
IF OBJECT_ID(N'[dbo].[MovieTicketOption]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTicketOption];
GO
IF OBJECT_ID(N'[dbo].[MovieTicketSale]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTicketSale];
GO
IF OBJECT_ID(N'[dbo].[MovieTicketSaleLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTicketSaleLog];
GO
IF OBJECT_ID(N'[dbo].[MovieTicketSaleOption]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTicketSaleOption];
GO
IF OBJECT_ID(N'[dbo].[MovieTicketSalePayment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTicketSalePayment];
GO
IF OBJECT_ID(N'[dbo].[MovieTicketSalePaymentType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieTicketSalePaymentType];
GO
IF OBJECT_ID(N'[dbo].[MovieType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieType];
GO
IF OBJECT_ID(N'[dbo].[PrinterTemplate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrinterTemplate];
GO
IF OBJECT_ID(N'[dbo].[SystemParameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SystemParameter];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserGroup];
GO
IF OBJECT_ID(N'[dbo].[UserGroup_User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserGroup_User];
GO
IF OBJECT_ID(N'[dbo].[UserSession]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSession];
GO
IF OBJECT_ID(N'[CinemaBookingDataModelStoreContainer].[Device]', 'U') IS NOT NULL
    DROP TABLE [CinemaBookingDataModelStoreContainer].[Device];
GO
IF OBJECT_ID(N'[CinemaBookingDataModelStoreContainer].[MovieTheatrePlaceTemplateDetailsOto]', 'U') IS NOT NULL
    DROP TABLE [CinemaBookingDataModelStoreContainer].[MovieTheatrePlaceTemplateDetailsOto];
GO
IF OBJECT_ID(N'[CinemaBookingDataModelStoreContainer].[MovieTheatrePlaceTemplateDetailsSon]', 'U') IS NOT NULL
    DROP TABLE [CinemaBookingDataModelStoreContainer].[MovieTheatrePlaceTemplateDetailsSon];
GO
IF OBJECT_ID(N'[CinemaBookingDataModelStoreContainer].[MovieTheatrePlaceTemplateDetailsYdk]', 'U') IS NOT NULL
    DROP TABLE [CinemaBookingDataModelStoreContainer].[MovieTheatrePlaceTemplateDetailsYdk];
GO
IF OBJECT_ID(N'[CinemaBookingDataModelStoreContainer].[MovieTheatrePlaceTemplateDetailsYdk2]', 'U') IS NOT NULL
    DROP TABLE [CinemaBookingDataModelStoreContainer].[MovieTheatrePlaceTemplateDetailsYdk2];
GO
IF OBJECT_ID(N'[CinemaBookingDataModelStoreContainer].[MovieTicketDeleted]', 'U') IS NOT NULL
    DROP TABLE [CinemaBookingDataModelStoreContainer].[MovieTicketDeleted];
GO
IF OBJECT_ID(N'[CinemaBookingDataModelStoreContainer].[MovieTicketSaleDeleted]', 'U') IS NOT NULL
    DROP TABLE [CinemaBookingDataModelStoreContainer].[MovieTicketSaleDeleted];
GO
IF OBJECT_ID(N'[CinemaBookingDataModelStoreContainer].[MovieTicketSaleOptionDeleted]', 'U') IS NOT NULL
    DROP TABLE [CinemaBookingDataModelStoreContainer].[MovieTicketSaleOptionDeleted];
GO
IF OBJECT_ID(N'[CinemaBookingDataModelStoreContainer].[MovieTicketSalePaymentDeleted]', 'U') IS NOT NULL
    DROP TABLE [CinemaBookingDataModelStoreContainer].[MovieTicketSalePaymentDeleted];
GO
IF OBJECT_ID(N'[CinemaBookingDataModelStoreContainer].[PrinterTemplate_20171210]', 'U') IS NOT NULL
    DROP TABLE [CinemaBookingDataModelStoreContainer].[PrinterTemplate_20171210];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'LabelDictionary'
CREATE TABLE [dbo].[LabelDictionary] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LanguagesId] int  NULL,
    [Label] nvarchar(50)  NULL,
    [LabelLng] nvarchar(50)  NULL
);
GO

-- Creating table 'Languages'
CREATE TABLE [dbo].[Languages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Active] bit  NULL
);
GO

-- Creating table 'Module'
CREATE TABLE [dbo].[Module] (
    [ModuleId] int IDENTITY(1,1) NOT NULL,
    [ModuleCode] nvarchar(20)  NOT NULL,
    [ModuleName] nvarchar(50)  NULL,
    [Description] nvarchar(50)  NULL
);
GO

-- Creating table 'ModuleAuth'
CREATE TABLE [dbo].[ModuleAuth] (
    [AuthId] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [UserGroupId] int  NULL,
    [OperationCode] nvarchar(20)  NULL
);
GO

-- Creating table 'ModuleOperation'
CREATE TABLE [dbo].[ModuleOperation] (
    [ModuleCode] nvarchar(20)  NULL,
    [OperationId] int IDENTITY(1,1) NOT NULL,
    [OperationCode] nvarchar(20)  NOT NULL,
    [OperationName] nvarchar(50)  NULL,
    [Description] nvarchar(50)  NULL
);
GO

-- Creating table 'Movie'
CREATE TABLE [dbo].[Movie] (
    [MovieId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Description] nvarchar(100)  NOT NULL,
    [Duration] int  NOT NULL,
    [PosterPreview] varbinary(max)  NULL,
    [PosterOriginal] varbinary(max)  NULL,
    [ReleaseDate] datetime  NULL,
    [Summary] nvarchar(max)  NULL,
    [Story] nvarchar(max)  NULL,
    [NameTr] nvarchar(100)  NULL,
    [MadeYear] int  NULL,
    [VisionDate2] datetime  NULL,
    [Distributor] nvarchar(50)  NULL,
    [LastUpdate] datetime  NULL,
    [CreateDate] datetime  NULL,
    [SgmMovieId] int  NULL,
    [PosterUrl] nvarchar(200)  NULL,
    [TemplateName] nvarchar(50)  NULL
);
GO

-- Creating table 'Movie_MovieCast'
CREATE TABLE [dbo].[Movie_MovieCast] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MovieId] int  NOT NULL,
    [MovieCastId] int  NOT NULL
);
GO

-- Creating table 'Movie_MovieCategory'
CREATE TABLE [dbo].[Movie_MovieCategory] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MovieId] int  NOT NULL,
    [MovieCategoryId] int  NOT NULL
);
GO

-- Creating table 'Movie_MovieDirector'
CREATE TABLE [dbo].[Movie_MovieDirector] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MovieId] int  NOT NULL,
    [MovieDirectorId] int  NOT NULL
);
GO

-- Creating table 'Movie_MovieFormat'
CREATE TABLE [dbo].[Movie_MovieFormat] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MovieId] int  NOT NULL,
    [MovieFormatId] int  NOT NULL
);
GO

-- Creating table 'Movie_MovieType'
CREATE TABLE [dbo].[Movie_MovieType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MovieId] int  NOT NULL,
    [MovieTypeId] int  NOT NULL
);
GO

-- Creating table 'MovieCast'
CREATE TABLE [dbo].[MovieCast] (
    [MovieCastId] int IDENTITY(1,1) NOT NULL,
    [CastName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'MovieCategory'
CREATE TABLE [dbo].[MovieCategory] (
    [MovieCategoryId] int IDENTITY(1,1) NOT NULL,
    [MovieCategoryCode] nvarchar(10)  NOT NULL,
    [MovieCategoryName] nvarchar(50)  NOT NULL,
    [MovieCategoryImage] varbinary(max)  NULL
);
GO

-- Creating table 'MovieDirector'
CREATE TABLE [dbo].[MovieDirector] (
    [MovieDirectorId] int IDENTITY(1,1) NOT NULL,
    [MovieDirectorName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'MovieFormat'
CREATE TABLE [dbo].[MovieFormat] (
    [MovieFormatId] int IDENTITY(1,1) NOT NULL,
    [MovieFormatCode] nvarchar(15)  NOT NULL,
    [MovieFormatName] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'MovieSeatType'
CREATE TABLE [dbo].[MovieSeatType] (
    [MovieSeatTypeId] int  NOT NULL,
    [MovieSeatTypeName] nvarchar(20)  NOT NULL,
    [MovieSeatTypeBackground] nvarchar(10)  NOT NULL,
    [MovieSeatTypeForeground] nvarchar(10)  NOT NULL,
    [Reserved] bit  NOT NULL,
    [Salable] bit  NOT NULL
);
GO

-- Creating table 'MovieSession'
CREATE TABLE [dbo].[MovieSession] (
    [MovieSessionId] int IDENTITY(1,1) NOT NULL,
    [MovieId] int  NOT NULL,
    [MovieTheatrePlaceId] int  NOT NULL,
    [SessionTime] datetime  NOT NULL,
    [SgmSessionId] int  NULL,
    [SgmSessionId2] int  NULL
);
GO

-- Creating table 'MovieSession_MovieFormat'
CREATE TABLE [dbo].[MovieSession_MovieFormat] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MovieSessionId] int  NOT NULL,
    [MovieFormatId] int  NOT NULL
);
GO

-- Creating table 'MovieSessionAmount'
CREATE TABLE [dbo].[MovieSessionAmount] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MovieSessionId] int  NOT NULL,
    [MovieTariffId] int  NOT NULL,
    [MovieSeatTypeId] int  NOT NULL,
    [Amount] decimal(10,4)  NOT NULL,
    [MovieTheatrePlaceTemplateDetailsId] int  NULL
);
GO

-- Creating table 'MovieSessionBooking'
CREATE TABLE [dbo].[MovieSessionBooking] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ReservationId] nvarchar(50)  NOT NULL,
    [CustomerPhone] nvarchar(50)  NOT NULL,
    [CustomerName] nvarchar(50)  NOT NULL,
    [CustomerEmail] nvarchar(50)  NOT NULL,
    [MovieSessionId] int  NOT NULL,
    [BookingTime] datetime  NOT NULL,
    [ExpirationTime] datetime  NOT NULL,
    [UserId] int  NULL,
    [SessionId] nvarchar(32)  NULL,
    [MovieTicketSaleId] int  NULL,
    [CancellationTime] datetime  NULL,
    [CancellationUserId] int  NULL,
    [CancellationSessionId] nvarchar(32)  NULL,
    [Status] varchar(9)  NOT NULL
);
GO

-- Creating table 'MovieSessionBookingDetail'
CREATE TABLE [dbo].[MovieSessionBookingDetail] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BookingId] int  NOT NULL,
    [MovieSeatTypeId] int  NOT NULL,
    [SeatPrefix] nvarchar(5)  NOT NULL,
    [SeatSuffix] nvarchar(5)  NOT NULL,
    [SeatCode] nvarchar(5)  NOT NULL,
    [MovieTariffId] int  NOT NULL,
    [CustomerInfo] nvarchar(50)  NULL,
    [Block] int  NULL
);
GO

-- Creating table 'MovieSessionLog'
CREATE TABLE [dbo].[MovieSessionLog] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MovieSessionId] int  NULL,
    [SaloonName] nvarchar(50)  NULL,
    [BranchName] nvarchar(150)  NULL,
    [SeanceTime] datetime  NULL,
    [FilmId] nvarchar(50)  NULL,
    [VersionName] nvarchar(50)  NULL,
    [State] int  NULL,
    [Response] nvarchar(200)  NULL,
    [TranDate] datetime  NULL,
    [IsSend] bit  NULL,
    [SgmSessionId] int  NULL
);
GO

-- Creating table 'MovieSessionReservation'
CREATE TABLE [dbo].[MovieSessionReservation] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MovieSessionId] int  NOT NULL,
    [MovieSeatTypeId] int  NOT NULL,
    [SeatPrefix] nvarchar(5)  NOT NULL,
    [SeatSuffix] nvarchar(5)  NOT NULL,
    [SeatCode] nvarchar(5)  NOT NULL,
    [LastUpdate] datetime  NOT NULL,
    [UserId] int  NOT NULL,
    [SessionId] nvarchar(32)  NOT NULL,
    [MovieTheatrePlaceTemplateDetailsId] int  NULL,
    [Block] int  NULL
);
GO

-- Creating table 'MovieTariff'
CREATE TABLE [dbo].[MovieTariff] (
    [MovieTariffId] int  NOT NULL,
    [MovieTariffName] nvarchar(50)  NOT NULL,
    [CustomerAuthorization] bit  NOT NULL
);
GO

-- Creating table 'MovieTheater'
CREATE TABLE [dbo].[MovieTheater] (
    [MovieTheaterId] int IDENTITY(1,1) NOT NULL,
    [MovieTheaterName] nvarchar(50)  NOT NULL,
    [FirstName] nvarchar(150)  NULL,
    [LastName] nvarchar(150)  NULL,
    [Phone] nvarchar(20)  NULL,
    [Email] nvarchar(100)  NULL,
    [CityName] nvarchar(50)  NULL,
    [TownName] nvarchar(50)  NULL,
    [Address] nvarchar(200)  NULL,
    [AvmName] nvarchar(100)  NULL,
    [Latitude] nvarchar(50)  NULL,
    [Longitude] nvarchar(50)  NULL
);
GO

-- Creating table 'MovieTheaterLog'
CREATE TABLE [dbo].[MovieTheaterLog] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [CityName] nvarchar(50)  NULL,
    [TownName] nvarchar(50)  NULL,
    [Address] nvarchar(150)  NULL,
    [AvmName] nvarchar(50)  NULL,
    [Latitude] nvarchar(50)  NULL,
    [Longitude] nvarchar(50)  NULL,
    [State] int  NULL,
    [Response] nvarchar(200)  NULL,
    [TranDate] datetime  NULL,
    [IsSend] bit  NULL
);
GO

-- Creating table 'MovieTheatrePlace'
CREATE TABLE [dbo].[MovieTheatrePlace] (
    [MovieTheaterId] int  NOT NULL,
    [MovieTheatrePlaceId] int IDENTITY(1,1) NOT NULL,
    [MovieTheatrePlaceName] nvarchar(20)  NOT NULL,
    [MovieTheatrePlaceTemplateId] int  NOT NULL,
    [SgmSaloonFormat] nchar(10)  NULL
);
GO

-- Creating table 'MovieTheatrePlaceLog'
CREATE TABLE [dbo].[MovieTheatrePlaceLog] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [BranchName] nvarchar(150)  NULL,
    [SaloonTypes] nvarchar(150)  NULL,
    [AudioFormats] nvarchar(150)  NULL,
    [Seats] nvarchar(150)  NULL,
    [State] int  NULL,
    [Response] nvarchar(200)  NULL,
    [TranDate] datetime  NULL,
    [IsSend] bit  NULL
);
GO

-- Creating table 'MovieTheatrePlaceTemplate'
CREATE TABLE [dbo].[MovieTheatrePlaceTemplate] (
    [MovieTheatrePlaceTemplateId] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(50)  NOT NULL,
    [Block] int  NULL
);
GO

-- Creating table 'MovieTheatrePlaceTemplateBlock'
CREATE TABLE [dbo].[MovieTheatrePlaceTemplateBlock] (
    [MovieTheaterBlockId] int IDENTITY(1,1) NOT NULL,
    [MovieTheaterBlockName] nvarchar(50)  NOT NULL,
    [MovieTheatrePlaceTemplateId] int  NULL,
    [BlockIndex] int  NULL
);
GO

-- Creating table 'MovieTheatrePlaceTemplateDetails'
CREATE TABLE [dbo].[MovieTheatrePlaceTemplateDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MovieTheatrePlaceTemplateId] int  NOT NULL,
    [RowIndex] int  NOT NULL,
    [ColumnIndex] int  NOT NULL,
    [Prefix] nvarchar(3)  NULL,
    [Suffix] nvarchar(4)  NULL,
    [SeatCode] nvarchar(6)  NULL,
    [MovieSeatTypeId] int  NOT NULL,
    [Block] int  NULL
);
GO

-- Creating table 'MovieTheatrePlaceTemplateDetailsLog'
CREATE TABLE [dbo].[MovieTheatrePlaceTemplateDetailsLog] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [BranchName] nvarchar(150)  NULL,
    [SeatName] nvarchar(150)  NULL,
    [State] int  NULL,
    [Response] nvarchar(200)  NULL,
    [TranDate] datetime  NULL,
    [IsSend] bit  NULL
);
GO

-- Creating table 'MovieTicket'
CREATE TABLE [dbo].[MovieTicket] (
    [MovieTicketSaleId] int  NOT NULL,
    [MovieTicketId] int IDENTITY(1,1) NOT NULL,
    [MovieSeatTypeId] int  NOT NULL,
    [MovieTariffId] int  NOT NULL,
    [BlockName] nvarchar(50)  NULL,
    [SeatPrefix] nvarchar(5)  NOT NULL,
    [SeatSuffix] nvarchar(5)  NOT NULL,
    [SeatCode] nvarchar(5)  NOT NULL,
    [Amount] decimal(10,4)  NOT NULL,
    [IsPrinted] bit  NOT NULL,
    [PrintDate] datetime  NULL,
    [PrintLocation] nvarchar(20)  NULL,
    [BarcodeNumber] nvarchar(20)  NOT NULL,
    [TicketOrder] nvarchar(10)  NOT NULL,
    [CustomerInfo] nvarchar(50)  NULL
);
GO

-- Creating table 'MovieTicketOption'
CREATE TABLE [dbo].[MovieTicketOption] (
    [TicketOptionId] int IDENTITY(1,1) NOT NULL,
    [TicketOptionName] nvarchar(50)  NOT NULL,
    [BarcodeNumber] nvarchar(20)  NOT NULL,
    [Amount] decimal(10,4)  NOT NULL
);
GO

-- Creating table 'MovieTicketSale'
CREATE TABLE [dbo].[MovieTicketSale] (
    [MovieTicketSaleId] int IDENTITY(1,1) NOT NULL,
    [MovieSessionId] int  NOT NULL,
    [Amount] decimal(10,4)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [Completed] bit  NOT NULL,
    [UserId] int  NOT NULL,
    [SessionId] nvarchar(32)  NOT NULL,
    [TransactionId] nvarchar(50)  NULL
);
GO

-- Creating table 'MovieTicketSaleLog'
CREATE TABLE [dbo].[MovieTicketSaleLog] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(50)  NULL,
    [SeanceId] nvarchar(50)  NULL,
    [SaleTime] datetime  NULL,
    [PaymentType] varchar(5)  NULL,
    [PlatformType] varchar(5)  NULL,
    [PaymentProvider] varchar(5)  NULL,
    [PaymentNumber] varchar(50)  NULL,
    [PaymentZNumber] varchar(50)  NULL,
    [SeatNumber] varchar(50)  NULL,
    [Price] decimal(18,2)  NULL,
    [TaxAmount] decimal(18,2)  NULL,
    [TicketType] varchar(50)  NULL,
    [State] int  NULL,
    [Response] nvarchar(200)  NULL,
    [TranDate] datetime  NULL,
    [IsSend] bit  NULL
);
GO

-- Creating table 'MovieTicketSaleOption'
CREATE TABLE [dbo].[MovieTicketSaleOption] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MovieTicketSaleId] int  NOT NULL,
    [TicketOptionId] int  NOT NULL,
    [Amount] decimal(10,4)  NOT NULL,
    [Count] int  NOT NULL,
    [TotalAmount] decimal(10,4)  NOT NULL
);
GO

-- Creating table 'MovieTicketSalePayment'
CREATE TABLE [dbo].[MovieTicketSalePayment] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MovieTicketSaleId] int  NOT NULL,
    [MovieTicketSalePaymentTypeId] int  NOT NULL,
    [Amount] decimal(10,4)  NOT NULL,
    [KotaId] int  NULL,
    [Kod] nvarchar(20)  NULL
);
GO

-- Creating table 'MovieTicketSalePaymentType'
CREATE TABLE [dbo].[MovieTicketSalePaymentType] (
    [MovieTicketSalePaymentTypeId] int  NOT NULL,
    [MovieTicketSalePaymentTypeName] nvarchar(20)  NOT NULL,
    [IsDefault] bit  NOT NULL
);
GO

-- Creating table 'MovieType'
CREATE TABLE [dbo].[MovieType] (
    [MovieTypeId] int IDENTITY(1,1) NOT NULL,
    [MovieTypeName] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'PrinterTemplate'
CREATE TABLE [dbo].[PrinterTemplate] (
    [TemplateName] nvarchar(50)  NOT NULL,
    [TemplateContent] nvarchar(max)  NULL
);
GO

-- Creating table 'SystemParameter'
CREATE TABLE [dbo].[SystemParameter] (
    [ParameterName] nvarchar(50)  NOT NULL,
    [ParameterValue] nvarchar(100)  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserCode] nvarchar(20)  NULL,
    [UserName] nvarchar(100)  NOT NULL,
    [Password] nvarchar(max)  NULL,
    [MailAddress] nvarchar(50)  NULL,
    [Deleted] bit  NULL,
    [SessionId] nvarchar(50)  NULL,
    [LanguagesId] int  NULL
);
GO

-- Creating table 'UserGroup'
CREATE TABLE [dbo].[UserGroup] (
    [UserGroupId] int IDENTITY(1,1) NOT NULL,
    [UserGroupCode] nvarchar(20)  NULL,
    [UserGroupName] nvarchar(50)  NULL,
    [Deleted] bit  NOT NULL
);
GO

-- Creating table 'UserGroup_User'
CREATE TABLE [dbo].[UserGroup_User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserGroupId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'UserSession'
CREATE TABLE [dbo].[UserSession] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [SessionId] nvarchar(32)  NOT NULL,
    [LoginTime] datetime  NOT NULL
);
GO

-- Creating table 'Device'
CREATE TABLE [dbo].[Device] (
    [DeviceId] int IDENTITY(1,1) NOT NULL,
    [DeviceName] nvarchar(50)  NULL,
    [MacAddress] nvarchar(20)  NULL,
    [IpAddress] nvarchar(20)  NULL,
    [TcpPort] int  NULL,
    [UdpPort] int  NULL,
    [Version] nvarchar(10)  NULL
);
GO

-- Creating table 'MovieTheatrePlaceTemplateDetailsOto'
CREATE TABLE [dbo].[MovieTheatrePlaceTemplateDetailsOto] (
    [MovieTheatrePlaceTemplateId] int  NOT NULL,
    [RowIndex] int  NOT NULL,
    [ColumnIndex] int  NOT NULL,
    [Prefix] nvarchar(3)  NULL,
    [Suffix] nvarchar(4)  NULL,
    [SeatCode] nvarchar(6)  NULL,
    [MovieSeatTypeId] int  NOT NULL,
    [Block] int  NULL
);
GO

-- Creating table 'MovieTheatrePlaceTemplateDetailsSon'
CREATE TABLE [dbo].[MovieTheatrePlaceTemplateDetailsSon] (
    [MovieTheatrePlaceTemplateId] int  NOT NULL,
    [RowIndex] int  NOT NULL,
    [ColumnIndex] int  NOT NULL,
    [Prefix] nvarchar(3)  NULL,
    [Suffix] nvarchar(4)  NULL,
    [SeatCode] nvarchar(6)  NULL,
    [MovieSeatTypeId] int  NOT NULL,
    [Block] int  NULL
);
GO

-- Creating table 'MovieTheatrePlaceTemplateDetailsYdk'
CREATE TABLE [dbo].[MovieTheatrePlaceTemplateDetailsYdk] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MovieTheatrePlaceTemplateId] int  NOT NULL,
    [RowIndex] int  NOT NULL,
    [ColumnIndex] int  NOT NULL,
    [Prefix] nvarchar(2)  NULL,
    [Suffix] nvarchar(3)  NULL,
    [SeatCode] nvarchar(5)  NULL,
    [MovieSeatTypeId] int  NOT NULL
);
GO

-- Creating table 'MovieTheatrePlaceTemplateDetailsYdk2'
CREATE TABLE [dbo].[MovieTheatrePlaceTemplateDetailsYdk2] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MovieTheatrePlaceTemplateId] int  NOT NULL,
    [RowIndex] int  NOT NULL,
    [ColumnIndex] int  NOT NULL,
    [Prefix] nvarchar(3)  NULL,
    [Suffix] nvarchar(4)  NULL,
    [SeatCode] nvarchar(6)  NULL,
    [MovieSeatTypeId] int  NOT NULL,
    [Block] int  NULL
);
GO

-- Creating table 'MovieTicketDeleted'
CREATE TABLE [dbo].[MovieTicketDeleted] (
    [MovieTicketSaleId] int  NOT NULL,
    [MovieTicketId] int  NOT NULL,
    [MovieSeatTypeId] int  NOT NULL,
    [MovieTariffId] int  NOT NULL,
    [SeatPrefix] nvarchar(5)  NOT NULL,
    [SeatSuffix] nvarchar(5)  NOT NULL,
    [SeatCode] nvarchar(5)  NOT NULL,
    [Amount] decimal(10,4)  NOT NULL,
    [IsPrinted] bit  NOT NULL,
    [PrintDate] datetime  NULL,
    [PrintLocation] nvarchar(20)  NULL,
    [BarcodeNumber] nvarchar(20)  NOT NULL,
    [TicketOrder] nvarchar(10)  NOT NULL,
    [CustomerInfo] nvarchar(50)  NULL,
    [BlockName] nvarchar(50)  NULL,
    [MovieTicketDeletedId] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'MovieTicketSaleDeleted'
CREATE TABLE [dbo].[MovieTicketSaleDeleted] (
    [MovieTicketSaleId] int  NOT NULL,
    [MovieSessionId] int  NOT NULL,
    [Amount] decimal(10,4)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [Completed] bit  NOT NULL,
    [UserId] int  NOT NULL,
    [SessionId] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'MovieTicketSaleOptionDeleted'
CREATE TABLE [dbo].[MovieTicketSaleOptionDeleted] (
    [Id] int  NOT NULL,
    [MovieTicketSaleId] int  NOT NULL,
    [TicketOptionId] int  NOT NULL,
    [Amount] decimal(10,4)  NOT NULL,
    [Count] int  NOT NULL,
    [TotalAmount] decimal(10,4)  NOT NULL
);
GO

-- Creating table 'MovieTicketSalePaymentDeleted'
CREATE TABLE [dbo].[MovieTicketSalePaymentDeleted] (
    [Id] int  NOT NULL,
    [MovieTicketSaleId] int  NOT NULL,
    [MovieTicketSalePaymentTypeId] int  NOT NULL,
    [Amount] decimal(10,4)  NOT NULL,
    [KotaId] int  NULL,
    [Kod] nvarchar(20)  NULL
);
GO

-- Creating table 'PrinterTemplate_20171210'
CREATE TABLE [dbo].[PrinterTemplate_20171210] (
    [TemplateName] nvarchar(50)  NOT NULL,
    [TemplateContent] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'LabelDictionary'
ALTER TABLE [dbo].[LabelDictionary]
ADD CONSTRAINT [PK_LabelDictionary]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Languages'
ALTER TABLE [dbo].[Languages]
ADD CONSTRAINT [PK_Languages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ModuleCode] in table 'Module'
ALTER TABLE [dbo].[Module]
ADD CONSTRAINT [PK_Module]
    PRIMARY KEY CLUSTERED ([ModuleCode] ASC);
GO

-- Creating primary key on [AuthId] in table 'ModuleAuth'
ALTER TABLE [dbo].[ModuleAuth]
ADD CONSTRAINT [PK_ModuleAuth]
    PRIMARY KEY CLUSTERED ([AuthId] ASC);
GO

-- Creating primary key on [OperationCode] in table 'ModuleOperation'
ALTER TABLE [dbo].[ModuleOperation]
ADD CONSTRAINT [PK_ModuleOperation]
    PRIMARY KEY CLUSTERED ([OperationCode] ASC);
GO

-- Creating primary key on [MovieId] in table 'Movie'
ALTER TABLE [dbo].[Movie]
ADD CONSTRAINT [PK_Movie]
    PRIMARY KEY CLUSTERED ([MovieId] ASC);
GO

-- Creating primary key on [Id] in table 'Movie_MovieCast'
ALTER TABLE [dbo].[Movie_MovieCast]
ADD CONSTRAINT [PK_Movie_MovieCast]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Movie_MovieCategory'
ALTER TABLE [dbo].[Movie_MovieCategory]
ADD CONSTRAINT [PK_Movie_MovieCategory]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Movie_MovieDirector'
ALTER TABLE [dbo].[Movie_MovieDirector]
ADD CONSTRAINT [PK_Movie_MovieDirector]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Movie_MovieFormat'
ALTER TABLE [dbo].[Movie_MovieFormat]
ADD CONSTRAINT [PK_Movie_MovieFormat]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Movie_MovieType'
ALTER TABLE [dbo].[Movie_MovieType]
ADD CONSTRAINT [PK_Movie_MovieType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MovieCastId] in table 'MovieCast'
ALTER TABLE [dbo].[MovieCast]
ADD CONSTRAINT [PK_MovieCast]
    PRIMARY KEY CLUSTERED ([MovieCastId] ASC);
GO

-- Creating primary key on [MovieCategoryId] in table 'MovieCategory'
ALTER TABLE [dbo].[MovieCategory]
ADD CONSTRAINT [PK_MovieCategory]
    PRIMARY KEY CLUSTERED ([MovieCategoryId] ASC);
GO

-- Creating primary key on [MovieDirectorId] in table 'MovieDirector'
ALTER TABLE [dbo].[MovieDirector]
ADD CONSTRAINT [PK_MovieDirector]
    PRIMARY KEY CLUSTERED ([MovieDirectorId] ASC);
GO

-- Creating primary key on [MovieFormatId] in table 'MovieFormat'
ALTER TABLE [dbo].[MovieFormat]
ADD CONSTRAINT [PK_MovieFormat]
    PRIMARY KEY CLUSTERED ([MovieFormatId] ASC);
GO

-- Creating primary key on [MovieSeatTypeId] in table 'MovieSeatType'
ALTER TABLE [dbo].[MovieSeatType]
ADD CONSTRAINT [PK_MovieSeatType]
    PRIMARY KEY CLUSTERED ([MovieSeatTypeId] ASC);
GO

-- Creating primary key on [MovieSessionId] in table 'MovieSession'
ALTER TABLE [dbo].[MovieSession]
ADD CONSTRAINT [PK_MovieSession]
    PRIMARY KEY CLUSTERED ([MovieSessionId] ASC);
GO

-- Creating primary key on [Id] in table 'MovieSession_MovieFormat'
ALTER TABLE [dbo].[MovieSession_MovieFormat]
ADD CONSTRAINT [PK_MovieSession_MovieFormat]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MovieSessionAmount'
ALTER TABLE [dbo].[MovieSessionAmount]
ADD CONSTRAINT [PK_MovieSessionAmount]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MovieSessionBooking'
ALTER TABLE [dbo].[MovieSessionBooking]
ADD CONSTRAINT [PK_MovieSessionBooking]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MovieSessionBookingDetail'
ALTER TABLE [dbo].[MovieSessionBookingDetail]
ADD CONSTRAINT [PK_MovieSessionBookingDetail]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MovieSessionLog'
ALTER TABLE [dbo].[MovieSessionLog]
ADD CONSTRAINT [PK_MovieSessionLog]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MovieSessionReservation'
ALTER TABLE [dbo].[MovieSessionReservation]
ADD CONSTRAINT [PK_MovieSessionReservation]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MovieTariffId] in table 'MovieTariff'
ALTER TABLE [dbo].[MovieTariff]
ADD CONSTRAINT [PK_MovieTariff]
    PRIMARY KEY CLUSTERED ([MovieTariffId] ASC);
GO

-- Creating primary key on [MovieTheaterId] in table 'MovieTheater'
ALTER TABLE [dbo].[MovieTheater]
ADD CONSTRAINT [PK_MovieTheater]
    PRIMARY KEY CLUSTERED ([MovieTheaterId] ASC);
GO

-- Creating primary key on [Id] in table 'MovieTheaterLog'
ALTER TABLE [dbo].[MovieTheaterLog]
ADD CONSTRAINT [PK_MovieTheaterLog]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MovieTheatrePlaceId] in table 'MovieTheatrePlace'
ALTER TABLE [dbo].[MovieTheatrePlace]
ADD CONSTRAINT [PK_MovieTheatrePlace]
    PRIMARY KEY CLUSTERED ([MovieTheatrePlaceId] ASC);
GO

-- Creating primary key on [Id] in table 'MovieTheatrePlaceLog'
ALTER TABLE [dbo].[MovieTheatrePlaceLog]
ADD CONSTRAINT [PK_MovieTheatrePlaceLog]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MovieTheatrePlaceTemplateId] in table 'MovieTheatrePlaceTemplate'
ALTER TABLE [dbo].[MovieTheatrePlaceTemplate]
ADD CONSTRAINT [PK_MovieTheatrePlaceTemplate]
    PRIMARY KEY CLUSTERED ([MovieTheatrePlaceTemplateId] ASC);
GO

-- Creating primary key on [MovieTheaterBlockId] in table 'MovieTheatrePlaceTemplateBlock'
ALTER TABLE [dbo].[MovieTheatrePlaceTemplateBlock]
ADD CONSTRAINT [PK_MovieTheatrePlaceTemplateBlock]
    PRIMARY KEY CLUSTERED ([MovieTheaterBlockId] ASC);
GO

-- Creating primary key on [Id] in table 'MovieTheatrePlaceTemplateDetails'
ALTER TABLE [dbo].[MovieTheatrePlaceTemplateDetails]
ADD CONSTRAINT [PK_MovieTheatrePlaceTemplateDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MovieTheatrePlaceTemplateDetailsLog'
ALTER TABLE [dbo].[MovieTheatrePlaceTemplateDetailsLog]
ADD CONSTRAINT [PK_MovieTheatrePlaceTemplateDetailsLog]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MovieTicketId] in table 'MovieTicket'
ALTER TABLE [dbo].[MovieTicket]
ADD CONSTRAINT [PK_MovieTicket]
    PRIMARY KEY CLUSTERED ([MovieTicketId] ASC);
GO

-- Creating primary key on [TicketOptionId] in table 'MovieTicketOption'
ALTER TABLE [dbo].[MovieTicketOption]
ADD CONSTRAINT [PK_MovieTicketOption]
    PRIMARY KEY CLUSTERED ([TicketOptionId] ASC);
GO

-- Creating primary key on [MovieTicketSaleId] in table 'MovieTicketSale'
ALTER TABLE [dbo].[MovieTicketSale]
ADD CONSTRAINT [PK_MovieTicketSale]
    PRIMARY KEY CLUSTERED ([MovieTicketSaleId] ASC);
GO

-- Creating primary key on [Id] in table 'MovieTicketSaleLog'
ALTER TABLE [dbo].[MovieTicketSaleLog]
ADD CONSTRAINT [PK_MovieTicketSaleLog]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MovieTicketSaleOption'
ALTER TABLE [dbo].[MovieTicketSaleOption]
ADD CONSTRAINT [PK_MovieTicketSaleOption]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MovieTicketSalePayment'
ALTER TABLE [dbo].[MovieTicketSalePayment]
ADD CONSTRAINT [PK_MovieTicketSalePayment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MovieTicketSalePaymentTypeId] in table 'MovieTicketSalePaymentType'
ALTER TABLE [dbo].[MovieTicketSalePaymentType]
ADD CONSTRAINT [PK_MovieTicketSalePaymentType]
    PRIMARY KEY CLUSTERED ([MovieTicketSalePaymentTypeId] ASC);
GO

-- Creating primary key on [MovieTypeId] in table 'MovieType'
ALTER TABLE [dbo].[MovieType]
ADD CONSTRAINT [PK_MovieType]
    PRIMARY KEY CLUSTERED ([MovieTypeId] ASC);
GO

-- Creating primary key on [TemplateName] in table 'PrinterTemplate'
ALTER TABLE [dbo].[PrinterTemplate]
ADD CONSTRAINT [PK_PrinterTemplate]
    PRIMARY KEY CLUSTERED ([TemplateName] ASC);
GO

-- Creating primary key on [ParameterName] in table 'SystemParameter'
ALTER TABLE [dbo].[SystemParameter]
ADD CONSTRAINT [PK_SystemParameter]
    PRIMARY KEY CLUSTERED ([ParameterName] ASC);
GO

-- Creating primary key on [UserId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [UserGroupId] in table 'UserGroup'
ALTER TABLE [dbo].[UserGroup]
ADD CONSTRAINT [PK_UserGroup]
    PRIMARY KEY CLUSTERED ([UserGroupId] ASC);
GO

-- Creating primary key on [Id] in table 'UserGroup_User'
ALTER TABLE [dbo].[UserGroup_User]
ADD CONSTRAINT [PK_UserGroup_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSession'
ALTER TABLE [dbo].[UserSession]
ADD CONSTRAINT [PK_UserSession]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [DeviceId] in table 'Device'
ALTER TABLE [dbo].[Device]
ADD CONSTRAINT [PK_Device]
    PRIMARY KEY CLUSTERED ([DeviceId] ASC);
GO

-- Creating primary key on [MovieTheatrePlaceTemplateId], [RowIndex], [ColumnIndex], [MovieSeatTypeId] in table 'MovieTheatrePlaceTemplateDetailsOto'
ALTER TABLE [dbo].[MovieTheatrePlaceTemplateDetailsOto]
ADD CONSTRAINT [PK_MovieTheatrePlaceTemplateDetailsOto]
    PRIMARY KEY CLUSTERED ([MovieTheatrePlaceTemplateId], [RowIndex], [ColumnIndex], [MovieSeatTypeId] ASC);
GO

-- Creating primary key on [MovieTheatrePlaceTemplateId], [RowIndex], [ColumnIndex], [MovieSeatTypeId] in table 'MovieTheatrePlaceTemplateDetailsSon'
ALTER TABLE [dbo].[MovieTheatrePlaceTemplateDetailsSon]
ADD CONSTRAINT [PK_MovieTheatrePlaceTemplateDetailsSon]
    PRIMARY KEY CLUSTERED ([MovieTheatrePlaceTemplateId], [RowIndex], [ColumnIndex], [MovieSeatTypeId] ASC);
GO

-- Creating primary key on [Id], [MovieTheatrePlaceTemplateId], [RowIndex], [ColumnIndex], [MovieSeatTypeId] in table 'MovieTheatrePlaceTemplateDetailsYdk'
ALTER TABLE [dbo].[MovieTheatrePlaceTemplateDetailsYdk]
ADD CONSTRAINT [PK_MovieTheatrePlaceTemplateDetailsYdk]
    PRIMARY KEY CLUSTERED ([Id], [MovieTheatrePlaceTemplateId], [RowIndex], [ColumnIndex], [MovieSeatTypeId] ASC);
GO

-- Creating primary key on [Id], [MovieTheatrePlaceTemplateId], [RowIndex], [ColumnIndex], [MovieSeatTypeId] in table 'MovieTheatrePlaceTemplateDetailsYdk2'
ALTER TABLE [dbo].[MovieTheatrePlaceTemplateDetailsYdk2]
ADD CONSTRAINT [PK_MovieTheatrePlaceTemplateDetailsYdk2]
    PRIMARY KEY CLUSTERED ([Id], [MovieTheatrePlaceTemplateId], [RowIndex], [ColumnIndex], [MovieSeatTypeId] ASC);
GO

-- Creating primary key on [MovieTicketSaleId], [MovieTicketId], [MovieSeatTypeId], [MovieTariffId], [SeatPrefix], [SeatSuffix], [SeatCode], [Amount], [IsPrinted], [BarcodeNumber], [TicketOrder], [MovieTicketDeletedId] in table 'MovieTicketDeleted'
ALTER TABLE [dbo].[MovieTicketDeleted]
ADD CONSTRAINT [PK_MovieTicketDeleted]
    PRIMARY KEY CLUSTERED ([MovieTicketSaleId], [MovieTicketId], [MovieSeatTypeId], [MovieTariffId], [SeatPrefix], [SeatSuffix], [SeatCode], [Amount], [IsPrinted], [BarcodeNumber], [TicketOrder], [MovieTicketDeletedId] ASC);
GO

-- Creating primary key on [MovieTicketSaleId], [MovieSessionId], [Amount], [DateCreated], [Completed], [UserId], [SessionId] in table 'MovieTicketSaleDeleted'
ALTER TABLE [dbo].[MovieTicketSaleDeleted]
ADD CONSTRAINT [PK_MovieTicketSaleDeleted]
    PRIMARY KEY CLUSTERED ([MovieTicketSaleId], [MovieSessionId], [Amount], [DateCreated], [Completed], [UserId], [SessionId] ASC);
GO

-- Creating primary key on [Id], [MovieTicketSaleId], [TicketOptionId], [Amount], [Count], [TotalAmount] in table 'MovieTicketSaleOptionDeleted'
ALTER TABLE [dbo].[MovieTicketSaleOptionDeleted]
ADD CONSTRAINT [PK_MovieTicketSaleOptionDeleted]
    PRIMARY KEY CLUSTERED ([Id], [MovieTicketSaleId], [TicketOptionId], [Amount], [Count], [TotalAmount] ASC);
GO

-- Creating primary key on [Id], [MovieTicketSaleId], [MovieTicketSalePaymentTypeId], [Amount] in table 'MovieTicketSalePaymentDeleted'
ALTER TABLE [dbo].[MovieTicketSalePaymentDeleted]
ADD CONSTRAINT [PK_MovieTicketSalePaymentDeleted]
    PRIMARY KEY CLUSTERED ([Id], [MovieTicketSaleId], [MovieTicketSalePaymentTypeId], [Amount] ASC);
GO

-- Creating primary key on [TemplateName] in table 'PrinterTemplate_20171210'
ALTER TABLE [dbo].[PrinterTemplate_20171210]
ADD CONSTRAINT [PK_PrinterTemplate_20171210]
    PRIMARY KEY CLUSTERED ([TemplateName] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LanguagesId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_Languages]
    FOREIGN KEY ([LanguagesId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Languages'
CREATE INDEX [IX_FK_User_Languages]
ON [dbo].[User]
    ([LanguagesId]);
GO

-- Creating foreign key on [ModuleCode] in table 'ModuleOperation'
ALTER TABLE [dbo].[ModuleOperation]
ADD CONSTRAINT [FK_ModuleOperation_Module]
    FOREIGN KEY ([ModuleCode])
    REFERENCES [dbo].[Module]
        ([ModuleCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModuleOperation_Module'
CREATE INDEX [IX_FK_ModuleOperation_Module]
ON [dbo].[ModuleOperation]
    ([ModuleCode]);
GO

-- Creating foreign key on [OperationCode] in table 'ModuleAuth'
ALTER TABLE [dbo].[ModuleAuth]
ADD CONSTRAINT [FK_ModuleAuth_ModuleOperation]
    FOREIGN KEY ([OperationCode])
    REFERENCES [dbo].[ModuleOperation]
        ([OperationCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModuleAuth_ModuleOperation'
CREATE INDEX [IX_FK_ModuleAuth_ModuleOperation]
ON [dbo].[ModuleAuth]
    ([OperationCode]);
GO

-- Creating foreign key on [UserId] in table 'ModuleAuth'
ALTER TABLE [dbo].[ModuleAuth]
ADD CONSTRAINT [FK_ModuleAuth_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModuleAuth_User'
CREATE INDEX [IX_FK_ModuleAuth_User]
ON [dbo].[ModuleAuth]
    ([UserId]);
GO

-- Creating foreign key on [UserGroupId] in table 'ModuleAuth'
ALTER TABLE [dbo].[ModuleAuth]
ADD CONSTRAINT [FK_ModuleAuth_UserGroup]
    FOREIGN KEY ([UserGroupId])
    REFERENCES [dbo].[UserGroup]
        ([UserGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModuleAuth_UserGroup'
CREATE INDEX [IX_FK_ModuleAuth_UserGroup]
ON [dbo].[ModuleAuth]
    ([UserGroupId]);
GO

-- Creating foreign key on [MovieId] in table 'Movie_MovieCast'
ALTER TABLE [dbo].[Movie_MovieCast]
ADD CONSTRAINT [FK_Movie_MovieCast_Movie]
    FOREIGN KEY ([MovieId])
    REFERENCES [dbo].[Movie]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Movie_MovieCast_Movie'
CREATE INDEX [IX_FK_Movie_MovieCast_Movie]
ON [dbo].[Movie_MovieCast]
    ([MovieId]);
GO

-- Creating foreign key on [MovieId] in table 'Movie_MovieCategory'
ALTER TABLE [dbo].[Movie_MovieCategory]
ADD CONSTRAINT [FK_Movie_MovieCategory_Movie]
    FOREIGN KEY ([MovieId])
    REFERENCES [dbo].[Movie]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Movie_MovieCategory_Movie'
CREATE INDEX [IX_FK_Movie_MovieCategory_Movie]
ON [dbo].[Movie_MovieCategory]
    ([MovieId]);
GO

-- Creating foreign key on [MovieId] in table 'Movie_MovieDirector'
ALTER TABLE [dbo].[Movie_MovieDirector]
ADD CONSTRAINT [FK_Movie_MovieDirector_Movie]
    FOREIGN KEY ([MovieId])
    REFERENCES [dbo].[Movie]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Movie_MovieDirector_Movie'
CREATE INDEX [IX_FK_Movie_MovieDirector_Movie]
ON [dbo].[Movie_MovieDirector]
    ([MovieId]);
GO

-- Creating foreign key on [MovieId] in table 'Movie_MovieFormat'
ALTER TABLE [dbo].[Movie_MovieFormat]
ADD CONSTRAINT [FK_Movie_MovieFormat_Movie]
    FOREIGN KEY ([MovieId])
    REFERENCES [dbo].[Movie]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Movie_MovieFormat_Movie'
CREATE INDEX [IX_FK_Movie_MovieFormat_Movie]
ON [dbo].[Movie_MovieFormat]
    ([MovieId]);
GO

-- Creating foreign key on [MovieId] in table 'Movie_MovieType'
ALTER TABLE [dbo].[Movie_MovieType]
ADD CONSTRAINT [FK_Movie_MovieType_Movie]
    FOREIGN KEY ([MovieId])
    REFERENCES [dbo].[Movie]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Movie_MovieType_Movie'
CREATE INDEX [IX_FK_Movie_MovieType_Movie]
ON [dbo].[Movie_MovieType]
    ([MovieId]);
GO

-- Creating foreign key on [MovieId] in table 'MovieSession'
ALTER TABLE [dbo].[MovieSession]
ADD CONSTRAINT [FK_MovieSession_Movie]
    FOREIGN KEY ([MovieId])
    REFERENCES [dbo].[Movie]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieSession_Movie'
CREATE INDEX [IX_FK_MovieSession_Movie]
ON [dbo].[MovieSession]
    ([MovieId]);
GO

-- Creating foreign key on [MovieCastId] in table 'Movie_MovieCast'
ALTER TABLE [dbo].[Movie_MovieCast]
ADD CONSTRAINT [FK_Movie_MovieCast_MovieCast]
    FOREIGN KEY ([MovieCastId])
    REFERENCES [dbo].[MovieCast]
        ([MovieCastId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Movie_MovieCast_MovieCast'
CREATE INDEX [IX_FK_Movie_MovieCast_MovieCast]
ON [dbo].[Movie_MovieCast]
    ([MovieCastId]);
GO

-- Creating foreign key on [MovieCategoryId] in table 'Movie_MovieCategory'
ALTER TABLE [dbo].[Movie_MovieCategory]
ADD CONSTRAINT [FK_Movie_MovieCategory_MovieCategory]
    FOREIGN KEY ([MovieCategoryId])
    REFERENCES [dbo].[MovieCategory]
        ([MovieCategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Movie_MovieCategory_MovieCategory'
CREATE INDEX [IX_FK_Movie_MovieCategory_MovieCategory]
ON [dbo].[Movie_MovieCategory]
    ([MovieCategoryId]);
GO

-- Creating foreign key on [MovieDirectorId] in table 'Movie_MovieDirector'
ALTER TABLE [dbo].[Movie_MovieDirector]
ADD CONSTRAINT [FK_Movie_MovieDirector_MovieDirector]
    FOREIGN KEY ([MovieDirectorId])
    REFERENCES [dbo].[MovieDirector]
        ([MovieDirectorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Movie_MovieDirector_MovieDirector'
CREATE INDEX [IX_FK_Movie_MovieDirector_MovieDirector]
ON [dbo].[Movie_MovieDirector]
    ([MovieDirectorId]);
GO

-- Creating foreign key on [MovieFormatId] in table 'Movie_MovieFormat'
ALTER TABLE [dbo].[Movie_MovieFormat]
ADD CONSTRAINT [FK_Movie_MovieFormat_MovieFormat]
    FOREIGN KEY ([MovieFormatId])
    REFERENCES [dbo].[MovieFormat]
        ([MovieFormatId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Movie_MovieFormat_MovieFormat'
CREATE INDEX [IX_FK_Movie_MovieFormat_MovieFormat]
ON [dbo].[Movie_MovieFormat]
    ([MovieFormatId]);
GO

-- Creating foreign key on [MovieTypeId] in table 'Movie_MovieType'
ALTER TABLE [dbo].[Movie_MovieType]
ADD CONSTRAINT [FK_Movie_MovieType_MovieType]
    FOREIGN KEY ([MovieTypeId])
    REFERENCES [dbo].[MovieType]
        ([MovieTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Movie_MovieType_MovieType'
CREATE INDEX [IX_FK_Movie_MovieType_MovieType]
ON [dbo].[Movie_MovieType]
    ([MovieTypeId]);
GO

-- Creating foreign key on [MovieSeatTypeId] in table 'MovieSessionAmount'
ALTER TABLE [dbo].[MovieSessionAmount]
ADD CONSTRAINT [FK_MovieSessionAmount_MovieSeatType]
    FOREIGN KEY ([MovieSeatTypeId])
    REFERENCES [dbo].[MovieSeatType]
        ([MovieSeatTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieSessionAmount_MovieSeatType'
CREATE INDEX [IX_FK_MovieSessionAmount_MovieSeatType]
ON [dbo].[MovieSessionAmount]
    ([MovieSeatTypeId]);
GO

-- Creating foreign key on [MovieSeatTypeId] in table 'MovieSessionBookingDetail'
ALTER TABLE [dbo].[MovieSessionBookingDetail]
ADD CONSTRAINT [FK_MovieSessionBookingDetail_MovieSeatType]
    FOREIGN KEY ([MovieSeatTypeId])
    REFERENCES [dbo].[MovieSeatType]
        ([MovieSeatTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieSessionBookingDetail_MovieSeatType'
CREATE INDEX [IX_FK_MovieSessionBookingDetail_MovieSeatType]
ON [dbo].[MovieSessionBookingDetail]
    ([MovieSeatTypeId]);
GO

-- Creating foreign key on [MovieSeatTypeId] in table 'MovieSessionReservation'
ALTER TABLE [dbo].[MovieSessionReservation]
ADD CONSTRAINT [FK_MovieSessionReservation_MovieSeatType]
    FOREIGN KEY ([MovieSeatTypeId])
    REFERENCES [dbo].[MovieSeatType]
        ([MovieSeatTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieSessionReservation_MovieSeatType'
CREATE INDEX [IX_FK_MovieSessionReservation_MovieSeatType]
ON [dbo].[MovieSessionReservation]
    ([MovieSeatTypeId]);
GO

-- Creating foreign key on [MovieSeatTypeId] in table 'MovieTheatrePlaceTemplateDetails'
ALTER TABLE [dbo].[MovieTheatrePlaceTemplateDetails]
ADD CONSTRAINT [FK_MovieTheatrePlaceTemplateDetails_MovieSeatType]
    FOREIGN KEY ([MovieSeatTypeId])
    REFERENCES [dbo].[MovieSeatType]
        ([MovieSeatTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieTheatrePlaceTemplateDetails_MovieSeatType'
CREATE INDEX [IX_FK_MovieTheatrePlaceTemplateDetails_MovieSeatType]
ON [dbo].[MovieTheatrePlaceTemplateDetails]
    ([MovieSeatTypeId]);
GO

-- Creating foreign key on [MovieSeatTypeId] in table 'MovieTicket'
ALTER TABLE [dbo].[MovieTicket]
ADD CONSTRAINT [FK_MovieTicket_MovieSeatType]
    FOREIGN KEY ([MovieSeatTypeId])
    REFERENCES [dbo].[MovieSeatType]
        ([MovieSeatTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieTicket_MovieSeatType'
CREATE INDEX [IX_FK_MovieTicket_MovieSeatType]
ON [dbo].[MovieTicket]
    ([MovieSeatTypeId]);
GO

-- Creating foreign key on [MovieTheatrePlaceId] in table 'MovieSession'
ALTER TABLE [dbo].[MovieSession]
ADD CONSTRAINT [FK_MovieSession_MovieTheatrePlace]
    FOREIGN KEY ([MovieTheatrePlaceId])
    REFERENCES [dbo].[MovieTheatrePlace]
        ([MovieTheatrePlaceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieSession_MovieTheatrePlace'
CREATE INDEX [IX_FK_MovieSession_MovieTheatrePlace]
ON [dbo].[MovieSession]
    ([MovieTheatrePlaceId]);
GO

-- Creating foreign key on [MovieSessionId] in table 'MovieSessionAmount'
ALTER TABLE [dbo].[MovieSessionAmount]
ADD CONSTRAINT [FK_MovieSessionAmount_MovieSession]
    FOREIGN KEY ([MovieSessionId])
    REFERENCES [dbo].[MovieSession]
        ([MovieSessionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieSessionAmount_MovieSession'
CREATE INDEX [IX_FK_MovieSessionAmount_MovieSession]
ON [dbo].[MovieSessionAmount]
    ([MovieSessionId]);
GO

-- Creating foreign key on [MovieSessionId] in table 'MovieSessionBooking'
ALTER TABLE [dbo].[MovieSessionBooking]
ADD CONSTRAINT [FK_MovieSessionBooking_MovieSession]
    FOREIGN KEY ([MovieSessionId])
    REFERENCES [dbo].[MovieSession]
        ([MovieSessionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieSessionBooking_MovieSession'
CREATE INDEX [IX_FK_MovieSessionBooking_MovieSession]
ON [dbo].[MovieSessionBooking]
    ([MovieSessionId]);
GO

-- Creating foreign key on [MovieSessionId] in table 'MovieSessionReservation'
ALTER TABLE [dbo].[MovieSessionReservation]
ADD CONSTRAINT [FK_MovieSessionReservation_MovieSession]
    FOREIGN KEY ([MovieSessionId])
    REFERENCES [dbo].[MovieSession]
        ([MovieSessionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieSessionReservation_MovieSession'
CREATE INDEX [IX_FK_MovieSessionReservation_MovieSession]
ON [dbo].[MovieSessionReservation]
    ([MovieSessionId]);
GO

-- Creating foreign key on [MovieSessionId] in table 'MovieTicketSale'
ALTER TABLE [dbo].[MovieTicketSale]
ADD CONSTRAINT [FK_MovieTicketSale_MovieSession]
    FOREIGN KEY ([MovieSessionId])
    REFERENCES [dbo].[MovieSession]
        ([MovieSessionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieTicketSale_MovieSession'
CREATE INDEX [IX_FK_MovieTicketSale_MovieSession]
ON [dbo].[MovieTicketSale]
    ([MovieSessionId]);
GO

-- Creating foreign key on [MovieTariffId] in table 'MovieSessionAmount'
ALTER TABLE [dbo].[MovieSessionAmount]
ADD CONSTRAINT [FK_MovieSessionAmount_MovieTariff]
    FOREIGN KEY ([MovieTariffId])
    REFERENCES [dbo].[MovieTariff]
        ([MovieTariffId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieSessionAmount_MovieTariff'
CREATE INDEX [IX_FK_MovieSessionAmount_MovieTariff]
ON [dbo].[MovieSessionAmount]
    ([MovieTariffId]);
GO

-- Creating foreign key on [BookingId] in table 'MovieSessionBookingDetail'
ALTER TABLE [dbo].[MovieSessionBookingDetail]
ADD CONSTRAINT [FK_MovieSessionBookingDetail_MovieSessionBooking]
    FOREIGN KEY ([BookingId])
    REFERENCES [dbo].[MovieSessionBooking]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieSessionBookingDetail_MovieSessionBooking'
CREATE INDEX [IX_FK_MovieSessionBookingDetail_MovieSessionBooking]
ON [dbo].[MovieSessionBookingDetail]
    ([BookingId]);
GO

-- Creating foreign key on [UserId] in table 'MovieSessionReservation'
ALTER TABLE [dbo].[MovieSessionReservation]
ADD CONSTRAINT [FK_MovieSessionReservation_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieSessionReservation_User'
CREATE INDEX [IX_FK_MovieSessionReservation_User]
ON [dbo].[MovieSessionReservation]
    ([UserId]);
GO

-- Creating foreign key on [MovieTariffId] in table 'MovieTicket'
ALTER TABLE [dbo].[MovieTicket]
ADD CONSTRAINT [FK_MovieTicket_MovieTariff]
    FOREIGN KEY ([MovieTariffId])
    REFERENCES [dbo].[MovieTariff]
        ([MovieTariffId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieTicket_MovieTariff'
CREATE INDEX [IX_FK_MovieTicket_MovieTariff]
ON [dbo].[MovieTicket]
    ([MovieTariffId]);
GO

-- Creating foreign key on [MovieTheaterId] in table 'MovieTheatrePlace'
ALTER TABLE [dbo].[MovieTheatrePlace]
ADD CONSTRAINT [FK_MovieTheatrePlace_MovieTheater]
    FOREIGN KEY ([MovieTheaterId])
    REFERENCES [dbo].[MovieTheater]
        ([MovieTheaterId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieTheatrePlace_MovieTheater'
CREATE INDEX [IX_FK_MovieTheatrePlace_MovieTheater]
ON [dbo].[MovieTheatrePlace]
    ([MovieTheaterId]);
GO

-- Creating foreign key on [MovieTheatrePlaceTemplateId] in table 'MovieTheatrePlace'
ALTER TABLE [dbo].[MovieTheatrePlace]
ADD CONSTRAINT [FK_MovieTheatrePlace_MovieTheatrePlaceTemplate]
    FOREIGN KEY ([MovieTheatrePlaceTemplateId])
    REFERENCES [dbo].[MovieTheatrePlaceTemplate]
        ([MovieTheatrePlaceTemplateId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieTheatrePlace_MovieTheatrePlaceTemplate'
CREATE INDEX [IX_FK_MovieTheatrePlace_MovieTheatrePlaceTemplate]
ON [dbo].[MovieTheatrePlace]
    ([MovieTheatrePlaceTemplateId]);
GO

-- Creating foreign key on [MovieTheatrePlaceTemplateId] in table 'MovieTheatrePlaceTemplateBlock'
ALTER TABLE [dbo].[MovieTheatrePlaceTemplateBlock]
ADD CONSTRAINT [FK_MovieTheatrePlaceTemplateBlock_MovieTheatrePlaceTemplate]
    FOREIGN KEY ([MovieTheatrePlaceTemplateId])
    REFERENCES [dbo].[MovieTheatrePlaceTemplate]
        ([MovieTheatrePlaceTemplateId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieTheatrePlaceTemplateBlock_MovieTheatrePlaceTemplate'
CREATE INDEX [IX_FK_MovieTheatrePlaceTemplateBlock_MovieTheatrePlaceTemplate]
ON [dbo].[MovieTheatrePlaceTemplateBlock]
    ([MovieTheatrePlaceTemplateId]);
GO

-- Creating foreign key on [MovieTheatrePlaceTemplateId] in table 'MovieTheatrePlaceTemplateDetails'
ALTER TABLE [dbo].[MovieTheatrePlaceTemplateDetails]
ADD CONSTRAINT [FK_MovieTheatrePlaceTemplateDetails_MovieTheatrePlaceTemplate]
    FOREIGN KEY ([MovieTheatrePlaceTemplateId])
    REFERENCES [dbo].[MovieTheatrePlaceTemplate]
        ([MovieTheatrePlaceTemplateId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieTheatrePlaceTemplateDetails_MovieTheatrePlaceTemplate'
CREATE INDEX [IX_FK_MovieTheatrePlaceTemplateDetails_MovieTheatrePlaceTemplate]
ON [dbo].[MovieTheatrePlaceTemplateDetails]
    ([MovieTheatrePlaceTemplateId]);
GO

-- Creating foreign key on [MovieTicketSaleId] in table 'MovieTicket'
ALTER TABLE [dbo].[MovieTicket]
ADD CONSTRAINT [FK_MovieTicket_MovieTicketSale]
    FOREIGN KEY ([MovieTicketSaleId])
    REFERENCES [dbo].[MovieTicketSale]
        ([MovieTicketSaleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieTicket_MovieTicketSale'
CREATE INDEX [IX_FK_MovieTicket_MovieTicketSale]
ON [dbo].[MovieTicket]
    ([MovieTicketSaleId]);
GO

-- Creating foreign key on [TicketOptionId] in table 'MovieTicketSaleOption'
ALTER TABLE [dbo].[MovieTicketSaleOption]
ADD CONSTRAINT [FK_MovieTicketSaleOption_MovieTicketOption]
    FOREIGN KEY ([TicketOptionId])
    REFERENCES [dbo].[MovieTicketOption]
        ([TicketOptionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieTicketSaleOption_MovieTicketOption'
CREATE INDEX [IX_FK_MovieTicketSaleOption_MovieTicketOption]
ON [dbo].[MovieTicketSaleOption]
    ([TicketOptionId]);
GO

-- Creating foreign key on [UserId] in table 'MovieTicketSale'
ALTER TABLE [dbo].[MovieTicketSale]
ADD CONSTRAINT [FK_MovieTicketSale_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieTicketSale_User'
CREATE INDEX [IX_FK_MovieTicketSale_User]
ON [dbo].[MovieTicketSale]
    ([UserId]);
GO

-- Creating foreign key on [MovieTicketSaleId] in table 'MovieTicketSaleOption'
ALTER TABLE [dbo].[MovieTicketSaleOption]
ADD CONSTRAINT [FK_MovieTicketSaleOption_MovieTicketSale]
    FOREIGN KEY ([MovieTicketSaleId])
    REFERENCES [dbo].[MovieTicketSale]
        ([MovieTicketSaleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieTicketSaleOption_MovieTicketSale'
CREATE INDEX [IX_FK_MovieTicketSaleOption_MovieTicketSale]
ON [dbo].[MovieTicketSaleOption]
    ([MovieTicketSaleId]);
GO

-- Creating foreign key on [MovieTicketSaleId] in table 'MovieTicketSalePayment'
ALTER TABLE [dbo].[MovieTicketSalePayment]
ADD CONSTRAINT [FK_MovieTicketSalePayment_MovieTicketSale]
    FOREIGN KEY ([MovieTicketSaleId])
    REFERENCES [dbo].[MovieTicketSale]
        ([MovieTicketSaleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieTicketSalePayment_MovieTicketSale'
CREATE INDEX [IX_FK_MovieTicketSalePayment_MovieTicketSale]
ON [dbo].[MovieTicketSalePayment]
    ([MovieTicketSaleId]);
GO

-- Creating foreign key on [MovieTicketSalePaymentTypeId] in table 'MovieTicketSalePayment'
ALTER TABLE [dbo].[MovieTicketSalePayment]
ADD CONSTRAINT [FK_MovieTicketSalePayment_MovieTicketSalePaymentType]
    FOREIGN KEY ([MovieTicketSalePaymentTypeId])
    REFERENCES [dbo].[MovieTicketSalePaymentType]
        ([MovieTicketSalePaymentTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieTicketSalePayment_MovieTicketSalePaymentType'
CREATE INDEX [IX_FK_MovieTicketSalePayment_MovieTicketSalePaymentType]
ON [dbo].[MovieTicketSalePayment]
    ([MovieTicketSalePaymentTypeId]);
GO

-- Creating foreign key on [UserId] in table 'UserGroup_User'
ALTER TABLE [dbo].[UserGroup_User]
ADD CONSTRAINT [FK_UserGroup_User_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserGroup_User_User'
CREATE INDEX [IX_FK_UserGroup_User_User]
ON [dbo].[UserGroup_User]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'UserSession'
ALTER TABLE [dbo].[UserSession]
ADD CONSTRAINT [FK_UserSession_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserSession_User'
CREATE INDEX [IX_FK_UserSession_User]
ON [dbo].[UserSession]
    ([UserId]);
GO

-- Creating foreign key on [UserGroupId] in table 'UserGroup_User'
ALTER TABLE [dbo].[UserGroup_User]
ADD CONSTRAINT [FK_UserGroup_User_UserGroup]
    FOREIGN KEY ([UserGroupId])
    REFERENCES [dbo].[UserGroup]
        ([UserGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserGroup_User_UserGroup'
CREATE INDEX [IX_FK_UserGroup_User_UserGroup]
ON [dbo].[UserGroup_User]
    ([UserGroupId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------