IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Addresses] (
    [Id] int NOT NULL IDENTITY,
    [Country] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Developers] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [YearsOfExperience] int NOT NULL,
    [EstimateIncome] decimal(18,2) NOT NULL,
    [AddressId] int NULL,
    CONSTRAINT [PK_Developers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Developers_Addresses_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Addresses] ([Id]) ON DELETE SET NULL
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Country') AND [object_id] = OBJECT_ID(N'[Addresses]'))
    SET IDENTITY_INSERT [Addresses] ON;
INSERT INTO [Addresses] ([Id], [Country])
VALUES (1, N'Nepal'),
(2, N'India'),
(3, N'Bangladesh'),
(4, N'China'),
(5, N'Pakistan'),
(6, N'Japan'),
(7, N'USA'),
(8, N'Uk'),
(9, N'Brazil'),
(10, N'Spain');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Country') AND [object_id] = OBJECT_ID(N'[Addresses]'))
    SET IDENTITY_INSERT [Addresses] OFF;
GO

CREATE INDEX [IX_Developers_AddressId] ON [Developers] ([AddressId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250528090829_FirstMigration', N'8.0.0');
GO

COMMIT;
GO

