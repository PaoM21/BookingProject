IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Booking')
BEGIN
    CREATE DATABASE Booking;
END
GO

USE [Booking]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Clients') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Clients] (
        [Id] INT IDENTITY(1,1) NOT NULL,
        [Name] NVARCHAR(100) NOT NULL,
        [Email] NVARCHAR(100) NOT NULL,
        PRIMARY KEY CLUSTERED ([Id] ASC)
        WITH (
            PAD_INDEX = OFF,
            STATISTICS_NORECOMPUTE = OFF,
            IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON
        ) ON [PRIMARY],
        UNIQUE NONCLUSTERED ([Email] ASC)
        WITH (
            PAD_INDEX = OFF,
            STATISTICS_NORECOMPUTE = OFF,
            IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON
        ) ON [PRIMARY]
    ) ON [PRIMARY];

    INSERT INTO [dbo].[Clients] ([Name], [Email])
    VALUES 
        ('Cliente1', 'cliente1@gmail.com'),
        ('Cliente2', 'cliente2@gmail.com'),
        ('Cliente3', 'cliente3@gmail.com');
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Reservations') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Reservations] (
        [Id] INT IDENTITY(1,1) NOT NULL,
        [ClientId] INT NOT NULL,
        [ServiceId] INT NOT NULL,
        [ReservationDate] DATETIME NOT NULL,
        PRIMARY KEY CLUSTERED ([Id] ASC)
        WITH (
            PAD_INDEX = OFF,
            STATISTICS_NORECOMPUTE = OFF,
            IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON
        ) ON [PRIMARY]
    ) ON [PRIMARY];
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Services') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Services] (
        [Id] INT IDENTITY(1,1) NOT NULL,
        [ServiceName] NVARCHAR(100) NOT NULL,
        [Price] DECIMAL(18, 2) NOT NULL,
        PRIMARY KEY CLUSTERED ([Id] ASC)
        WITH (
            PAD_INDEX = OFF,
            STATISTICS_NORECOMPUTE = OFF,
            IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON
        ) ON [PRIMARY]
    ) ON [PRIMARY];

    INSERT INTO [dbo].[Services] ([ServiceName], [Price])
    VALUES 
        ('Servicio1', 1000.00),
        ('Servicio2', 300.00),
        ('Servicio3', 450.00);
END
GO

ALTER TABLE [dbo].[Reservations] WITH CHECK ADD FOREIGN KEY ([ClientId])
REFERENCES [dbo].[Clients] ([Id]);
GO

ALTER TABLE [dbo].[Reservations] WITH CHECK ADD FOREIGN KEY ([ServiceId])
REFERENCES [dbo].[Services] ([Id]);
GO

INSERT INTO [dbo].[Reservations] ([ClientId], [ServiceId], [ReservationDate])
VALUES 
    (1, 1, GETDATE()),
    (2, 2, GETDATE()),
    (3, 3, GETDATE());
GO
