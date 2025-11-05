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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251103183415_AddDiaryEntryTable'
)
BEGIN
    CREATE TABLE [DiaryEntries] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [Created] datetime2 NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_DiaryEntries] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251103183415_AddDiaryEntryTable'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251103183415_AddDiaryEntryTable', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251105135226_AddedSeedingDataDiaryEntry'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Content', N'Created', N'IsActive', N'Title') AND [object_id] = OBJECT_ID(N'[DiaryEntries]'))
        SET IDENTITY_INSERT [DiaryEntries] ON;
    EXEC(N'INSERT INTO [DiaryEntries] ([Id], [Content], [Created], [IsActive], [Title])
    VALUES (1, N''Went hiking with Joe!'', ''2025-11-05T21:52:24.5859711+08:00'', CAST(1 AS bit), N''Went Hiking''),
    (2, N''Went shopping with Joe!'', ''2025-11-05T21:52:24.5860405+08:00'', CAST(1 AS bit), N''Went Shopping''),
    (3, N''Went diving with Joe!'', ''2025-11-05T21:52:24.5860407+08:00'', CAST(1 AS bit), N''Went Diving'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Content', N'Created', N'IsActive', N'Title') AND [object_id] = OBJECT_ID(N'[DiaryEntries]'))
        SET IDENTITY_INSERT [DiaryEntries] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251105135226_AddedSeedingDataDiaryEntry'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251105135226_AddedSeedingDataDiaryEntry', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251105135832_UpdatedValuesForCreated'
)
BEGIN
    EXEC(N'UPDATE [DiaryEntries] SET [Created] = ''2025-11-05T00:00:00.0000000''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251105135832_UpdatedValuesForCreated'
)
BEGIN
    EXEC(N'UPDATE [DiaryEntries] SET [Created] = ''2025-11-05T00:00:00.0000000''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251105135832_UpdatedValuesForCreated'
)
BEGIN
    EXEC(N'UPDATE [DiaryEntries] SET [Created] = ''2025-11-05T00:00:00.0000000''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251105135832_UpdatedValuesForCreated'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251105135832_UpdatedValuesForCreated', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251105184933_PostgresInitial'
)
BEGIN
    DECLARE @var sysname;
    SELECT @var = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DiaryEntries]') AND [c].[name] = N'Title');
    IF @var IS NOT NULL EXEC(N'ALTER TABLE [DiaryEntries] DROP CONSTRAINT [' + @var + '];');
    ALTER TABLE [DiaryEntries] ALTER COLUMN [Title] nvarchar(100) NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251105184933_PostgresInitial'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DiaryEntries]') AND [c].[name] = N'Content');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [DiaryEntries] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [DiaryEntries] ALTER COLUMN [Content] nvarchar(100) NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251105184933_PostgresInitial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251105184933_PostgresInitial', N'9.0.10');
END;

COMMIT;
GO

