IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AddProducts] (
    [Name] nvarchar(450) NOT NULL,
    [Price] int NOT NULL,
    CONSTRAINT [PK_AddProducts] PRIMARY KEY ([Name])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180609143908_InitialDb', N'2.0.2-rtm-10011');

GO

