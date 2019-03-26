IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181015071351_new')
BEGIN
    CREATE TABLE [appoinment] (
        [ID] int NOT NULL IDENTITY,
        [Customer] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [fromTime] datetime2 NOT NULL,
        [toTime] datetime2 NOT NULL,
        CONSTRAINT [PK_appoinment] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181015071351_new')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181015071351_new', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181015074356_new1')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Email');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [Email] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181015074356_new1')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Customer');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [Customer] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181015074356_new1')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Address');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [Address] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181015074356_new1')
BEGIN
    ALTER TABLE [appoinment] ADD [Cmnd] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181015074356_new1')
BEGIN
    ALTER TABLE [appoinment] ADD [Day] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181015074356_new1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181015074356_new1', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181015080543_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181015080543_initial', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181015093147_n')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Phone');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [Phone] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181015093147_n')
BEGIN
    ALTER TABLE [appoinment] ADD [Require] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181015093147_n')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181015093147_n', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181015101617_m')
BEGIN
    ALTER TABLE [appoinment] ADD [Details] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181015101617_m')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181015101617_m', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016052734_update')
BEGIN
    EXEC sp_rename N'[appoinment].[Require]', N'WorkPlace', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016052734_update')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Day');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [Day] datetime2 NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016052734_update')
BEGIN
    ALTER TABLE [appoinment] ADD [Borrow] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016052734_update')
BEGIN
    ALTER TABLE [appoinment] ADD [Due] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016052734_update')
BEGIN
    ALTER TABLE [appoinment] ADD [Gender] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016052734_update')
BEGIN
    ALTER TABLE [appoinment] ADD [Job] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016052734_update')
BEGIN
    ALTER TABLE [appoinment] ADD [MeetingAddress] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016052734_update')
BEGIN
    ALTER TABLE [appoinment] ADD [MeetingDay] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016052734_update')
BEGIN
    ALTER TABLE [appoinment] ADD [Place] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016052734_update')
BEGIN
    ALTER TABLE [appoinment] ADD [Price] float NOT NULL DEFAULT 0E0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016052734_update')
BEGIN
    ALTER TABLE [appoinment] ADD [Product] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016052734_update')
BEGIN
    ALTER TABLE [appoinment] ADD [Purpose] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016052734_update')
BEGIN
    ALTER TABLE [appoinment] ADD [Requires] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016052734_update')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181016052734_update', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016061736_up')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'WorkPlace');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [WorkPlace] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016061736_up')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Place');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [Place] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016061736_up')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Job');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [Job] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016061736_up')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Email');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [Email] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016061736_up')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Cmnd');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [Cmnd] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016061736_up')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181016061736_up', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016065237_upn')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Borrow');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [Borrow] bit NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181016065237_upn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181016065237_upn', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018005506_mm')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Borrow');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [appoinment] DROP COLUMN [Borrow];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018005506_mm')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Due');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [appoinment] DROP COLUMN [Due];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018005506_mm')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'MeetingAddress');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [appoinment] DROP COLUMN [MeetingAddress];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018005506_mm')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'MeetingDay');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [appoinment] DROP COLUMN [MeetingDay];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018005506_mm')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'fromTime');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [appoinment] DROP COLUMN [fromTime];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018005506_mm')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'toTime');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [appoinment] DROP COLUMN [toTime];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018005506_mm')
BEGIN
    ALTER TABLE [appoinment] ADD [Money] float NOT NULL DEFAULT 0E0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018005506_mm')
BEGIN
    ALTER TABLE [appoinment] ADD [Number] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018005506_mm')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181018005506_mm', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018031623_mmm')
BEGIN
    ALTER TABLE [appoinment] ADD [Cash] float NOT NULL DEFAULT 0E0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018031623_mmm')
BEGIN
    ALTER TABLE [appoinment] ADD [DType] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018031623_mmm')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181018031623_mmm', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018061551_mmmm')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Requires');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [Requires] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018061551_mmmm')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Details');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [Details] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018061551_mmmm')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181018061551_mmmm', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018084544_mmmmm')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Product');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [appoinment] DROP COLUMN [Product];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018084544_mmmmm')
BEGIN
    EXEC sp_rename N'[appoinment].[Number]', N'NSHH', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018084544_mmmmm')
BEGIN
    ALTER TABLE [appoinment] ADD [NCH1] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018084544_mmmmm')
BEGIN
    ALTER TABLE [appoinment] ADD [NCH2] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018084544_mmmmm')
BEGIN
    ALTER TABLE [appoinment] ADD [NCH3] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018084544_mmmmm')
BEGIN
    ALTER TABLE [appoinment] ADD [NMS] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018084544_mmmmm')
BEGIN
    ALTER TABLE [appoinment] ADD [NSH] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181018084544_mmmmm')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181018084544_mmmmm', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181019062440_nmnm')
BEGIN
    ALTER TABLE [appoinment] ADD [HKTT] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181019062440_nmnm')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181019062440_nmnm', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181019095707_uuu')
BEGIN
    ALTER TABLE [appoinment] ADD [password] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181019095707_uuu')
BEGIN
    ALTER TABLE [appoinment] ADD [sale] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181019095707_uuu')
BEGIN
    CREATE TABLE [sale] (
        [ID] int NOT NULL IDENTITY,
        [name] nvarchar(max) NOT NULL,
        [phone] nvarchar(max) NOT NULL,
        [email] nvarchar(max) NOT NULL,
        [pass] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_sale] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181019095707_uuu')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181019095707_uuu', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181019180137_top')
BEGIN
    ALTER TABLE [appoinment] ADD [SaleID] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181019180137_top')
BEGIN
    CREATE INDEX [IX_appoinment_SaleID] ON [appoinment] ([SaleID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181019180137_top')
BEGIN
    ALTER TABLE [appoinment] ADD CONSTRAINT [FK_appoinment_sale_SaleID] FOREIGN KEY ([SaleID]) REFERENCES [sale] ([ID]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181019180137_top')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181019180137_top', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181022090426_ii')
BEGIN
    ALTER TABLE [appoinment] ADD [Contract] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181022090426_ii')
BEGIN
    ALTER TABLE [appoinment] ADD [Priority] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181022090426_ii')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181022090426_ii', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181022105038_jj')
BEGIN
    ALTER TABLE [appoinment] ADD [Confirm] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181022105038_jj')
BEGIN
    ALTER TABLE [appoinment] ADD [cTime] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181022105038_jj')
BEGIN
    ALTER TABLE [appoinment] ADD [dTime] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181022105038_jj')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181022105038_jj', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181022150859_kj')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'dTime');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [dTime] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181022150859_kj')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'cTime');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [cTime] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181022150859_kj')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181022150859_kj', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181022164559_admin')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181022164559_admin', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181022165454_iu')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181022165454_iu', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181024094536_newest')
BEGIN
    EXEC sp_rename N'[appoinment].[Priority]', N'pshh', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181024094536_newest')
BEGIN
    ALTER TABLE [sale] ADD [info] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181024094536_newest')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'sale');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [sale] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181024094536_newest')
BEGIN
    ALTER TABLE [appoinment] ADD [SaleDetails] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181024094536_newest')
BEGIN
    ALTER TABLE [appoinment] ADD [ph] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181024094536_newest')
BEGIN
    ALTER TABLE [appoinment] ADD [pms] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181024094536_newest')
BEGIN
    ALTER TABLE [appoinment] ADD [psh] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181024094536_newest')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181024094536_newest', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181101022547_newww')
BEGIN
    ALTER TABLE [sale] ADD [display] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181101022547_newww')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181101022547_newww', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181101032423_wtf')
BEGIN
    ALTER TABLE [appoinment] ADD [Deposit] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181101032423_wtf')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181101032423_wtf', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181101085101_wtff')
BEGIN
    ALTER TABLE [appoinment] ADD [OldContract] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181101085101_wtff')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181101085101_wtff', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181104203321_nb')
BEGIN
    EXEC sp_rename N'[appoinment].[OldContract]', N'Note', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181104203321_nb')
BEGIN
    ALTER TABLE [appoinment] ADD [Official] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181104203321_nb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181104203321_nb', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181106020738_zxc')
BEGIN
    ALTER TABLE [appoinment] ADD [New] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181106020738_zxc')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181106020738_zxc', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181107103024_old')
BEGIN
    ALTER TABLE [appoinment] ADD [OldContract] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181107103024_old')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181107103024_old', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181109102738_transaction')
BEGIN
    CREATE TABLE [transactions] (
        [ID] int NOT NULL IDENTITY,
        [Hieuthietbi] nvarchar(max) NULL,
        [Sohieudv] nvarchar(max) NULL,
        [Diachi] nvarchar(max) NULL,
        [Loaithe] nvarchar(max) NULL,
        [Ngaygd] nvarchar(max) NULL,
        [Giogd] nvarchar(max) NULL,
        [Ngayxl] nvarchar(max) NULL,
        [Sothe] nvarchar(max) NULL,
        [Machuanchi] nvarchar(max) NULL,
        [Solo] nvarchar(max) NULL,
        [Tiengd] nvarchar(max) NULL,
        [Phi] nvarchar(max) NULL,
        [VAT] nvarchar(max) NULL,
        [Tylephantram] nvarchar(max) NULL,
        [unknow] nvarchar(max) NULL,
        CONSTRAINT [PK_transactions] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181109102738_transaction')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181109102738_transaction', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115083203_ns')
BEGIN
    EXEC sp_rename N'[transactions].[unknow]', N'Sothamchieu', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115083203_ns')
BEGIN
    ALTER TABLE [appoinment] ADD [NCH21] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115083203_ns')
BEGIN
    ALTER TABLE [appoinment] ADD [NS] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115083203_ns')
BEGIN
    ALTER TABLE [appoinment] ADD [pns] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181115083203_ns')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181115083203_ns', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181121083909_manager')
BEGIN
    CREATE TABLE [Manager] (
        [ID] int NOT NULL IDENTITY,
        [FullName] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Portrait] nvarchar(max) NULL,
        [Password] nvarchar(max) NULL,
        CONSTRAINT [PK_Manager] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181121083909_manager')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181121083909_manager', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181124004818_supporter')
BEGIN
    ALTER TABLE [appoinment] ADD [supporter] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181124004818_supporter')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181124004818_supporter', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181201090420_active')
BEGIN
    ALTER TABLE [appoinment] ADD [IsActive] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181201090420_active')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181201090420_active', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181203041604_orion')
BEGIN
    CREATE TABLE [Loggers] (
        [ID] int NOT NULL IDENTITY,
        [Browser] nvarchar(max) NULL,
        [Device] nvarchar(max) NULL,
        [Ip_Address] nvarchar(max) NULL,
        [Log_Time] nvarchar(max) NULL,
        [Customer] nvarchar(max) NULL,
        CONSTRAINT [PK_Loggers] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181203041604_orion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181203041604_orion', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181204080807_travist')
BEGIN
    ALTER TABLE [sale] ADD [address] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181204080807_travist')
BEGIN
    ALTER TABLE [sale] ADD [birthday] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181204080807_travist')
BEGIN
    ALTER TABLE [sale] ADD [gender] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181204080807_travist')
BEGIN
    ALTER TABLE [sale] ADD [portrait] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181204080807_travist')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181204080807_travist', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181208034342_atom')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[sale]') AND [c].[name] = N'birthday');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [sale] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [sale] ALTER COLUMN [birthday] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181208034342_atom')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181208034342_atom', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181210045957_nova')
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[sale]') AND [c].[name] = N'portrait');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [sale] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [sale] DROP COLUMN [portrait];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181210045957_nova')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181210045957_nova', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181210050103_supernova')
BEGIN
    ALTER TABLE [sale] ADD [portrait] varbinary(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181210050103_supernova')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181210050103_supernova', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    ALTER TABLE [appoinment] DROP CONSTRAINT [FK_appoinment_sale_SaleID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    DROP TABLE [sale];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    DROP INDEX [IX_appoinment_SaleID] ON [appoinment];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'SaleID');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [appoinment] DROP COLUMN [SaleID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    ALTER TABLE [appoinment] ADD [SaleId] uniqueidentifier NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] uniqueidentifier NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [DOB] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [Info] nvarchar(max) NULL,
        [Display] nvarchar(max) NULL,
        [Gender] nvarchar(max) NULL,
        [Type] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [Portrait] varbinary(max) NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] uniqueidentifier NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] uniqueidentifier NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] uniqueidentifier NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] uniqueidentifier NOT NULL,
        [RoleId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    ALTER TABLE [appoinment] ADD CONSTRAINT [FK_appoinment_AspNetUsers_SaleId] FOREIGN KEY ([SaleId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181215023727_identity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181215023727_identity', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181217104517_jupiter')
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'sale');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [appoinment] DROP COLUMN [sale];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181217104517_jupiter')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181217104517_jupiter', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181218084753_supermoon')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Members] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181218084753_supermoon')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181218084753_supermoon', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181219024122_bloodmoon')
BEGIN
    ALTER TABLE [appoinment] ADD [SEmail] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181219024122_bloodmoon')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181219024122_bloodmoon', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181219075220_withdraw')
BEGIN
    ALTER TABLE [appoinment] ADD [WDay] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181219075220_withdraw')
BEGIN
    ALTER TABLE [appoinment] ADD [WMoney] float NOT NULL DEFAULT 0E0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181219075220_withdraw')
BEGIN
    ALTER TABLE [appoinment] ADD [WType] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181219075220_withdraw')
BEGIN
    ALTER TABLE [appoinment] ADD [WithdrawCode] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181219075220_withdraw')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181219075220_withdraw', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181222022304_photon')
BEGIN
    ALTER TABLE [appoinment] ADD [Photo] varbinary(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181222022304_photon')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181222022304_photon', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181225081813_feedback')
BEGIN
    CREATE TABLE [Feedbacks] (
        [Id] uniqueidentifier NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [SaleId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Feedbacks] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Feedbacks_AspNetUsers_SaleId] FOREIGN KEY ([SaleId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181225081813_feedback')
BEGIN
    CREATE INDEX [IX_Feedbacks_SaleId] ON [Feedbacks] ([SaleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181225081813_feedback')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181225081813_feedback', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181226020601_storage')
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[appoinment]') AND [c].[name] = N'Photo');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [appoinment] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [appoinment] ALTER COLUMN [Photo] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181226020601_storage')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181226020601_storage', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181228063724_galileo')
BEGIN
    ALTER TABLE [appoinment] ADD [NSH1] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181228063724_galileo')
BEGIN
    ALTER TABLE [appoinment] ADD [psh1] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181228063724_galileo')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181228063724_galileo', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190104050435_andromera')
BEGIN
    CREATE TABLE [Request] (
        [Id] uniqueidentifier NOT NULL,
        [RequestName] nvarchar(max) NULL,
        [Subject] nvarchar(max) NULL,
        [Contents] nvarchar(max) NULL,
        [Status] int NOT NULL,
        [OwnerId] uniqueidentifier NULL,
        CONSTRAINT [PK_Request] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Request_AspNetUsers_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190104050435_andromera')
BEGIN
    CREATE INDEX [IX_Request_OwnerId] ON [Request] ([OwnerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190104050435_andromera')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190104050435_andromera', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190105032958_gemini')
BEGIN
    ALTER TABLE [Request] DROP CONSTRAINT [FK_Request_AspNetUsers_OwnerId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190105032958_gemini')
BEGIN
    ALTER TABLE [Request] DROP CONSTRAINT [PK_Request];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190105032958_gemini')
BEGIN
    EXEC sp_rename N'[Request]', N'Requests';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190105032958_gemini')
BEGIN
    EXEC sp_rename N'[Requests].[IX_Request_OwnerId]', N'IX_Requests_OwnerId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190105032958_gemini')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [PK_Requests] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190105032958_gemini')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_AspNetUsers_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190105032958_gemini')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190105032958_gemini', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190105073902_Triangum')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [NOfFeedbacks] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190105073902_Triangum')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [NOfMeetings] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190105073902_Triangum')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [NOfRequests] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190105073902_Triangum')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190105073902_Triangum', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190110044846_Betelgeuse')
BEGIN
    ALTER TABLE [appoinment] ADD [PlanId] uniqueidentifier NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190110044846_Betelgeuse')
BEGIN
    CREATE TABLE [Plans] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        [Location] nvarchar(max) NULL,
        [State] int NOT NULL,
        CONSTRAINT [PK_Plans] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190110044846_Betelgeuse')
BEGIN
    CREATE TABLE [Products] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        [Price] float NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190110044846_Betelgeuse')
BEGIN
    CREATE TABLE [ProductPlan] (
        [Id] uniqueidentifier NOT NULL,
        [ProductId] uniqueidentifier NULL,
        [PlanId] uniqueidentifier NULL,
        CONSTRAINT [PK_ProductPlan] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductPlan_Plans_PlanId] FOREIGN KEY ([PlanId]) REFERENCES [Plans] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ProductPlan_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190110044846_Betelgeuse')
BEGIN
    CREATE INDEX [IX_appoinment_PlanId] ON [appoinment] ([PlanId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190110044846_Betelgeuse')
BEGIN
    CREATE INDEX [IX_ProductPlan_PlanId] ON [ProductPlan] ([PlanId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190110044846_Betelgeuse')
BEGIN
    CREATE INDEX [IX_ProductPlan_ProductId] ON [ProductPlan] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190110044846_Betelgeuse')
BEGIN
    ALTER TABLE [appoinment] ADD CONSTRAINT [FK_appoinment_Plans_PlanId] FOREIGN KEY ([PlanId]) REFERENCES [Plans] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190110044846_Betelgeuse')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190110044846_Betelgeuse', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116025954_Mirach')
BEGIN
    CREATE TABLE [Grants] (
        [Id] uniqueidentifier NOT NULL,
        [Role] nvarchar(max) NULL,
        [Resource] nvarchar(max) NULL,
        [Operation] nvarchar(max) NULL,
        [Permission] nvarchar(max) NULL,
        CONSTRAINT [PK_Grants] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116025954_Mirach')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190116025954_Mirach', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116085812_Neptune')
BEGIN
    EXEC sp_rename N'[Grants].[Role]', N'RoleName', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116085812_Neptune')
BEGIN
    ALTER TABLE [Grants] ADD [Roles] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116085812_Neptune')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190116085812_Neptune', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116085912_Uranus')
BEGIN
    EXEC sp_rename N'[Grants].[Roles]', N'Role', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116085912_Uranus')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190116085912_Uranus', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116103907_Polaris')
BEGIN
    ALTER TABLE [Grants] ADD [CurrRoleId] uniqueidentifier NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116103907_Polaris')
BEGIN
    CREATE INDEX [IX_Grants_CurrRoleId] ON [Grants] ([CurrRoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116103907_Polaris')
BEGIN
    ALTER TABLE [Grants] ADD CONSTRAINT [FK_Grants_AspNetRoles_CurrRoleId] FOREIGN KEY ([CurrRoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116103907_Polaris')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190116103907_Polaris', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116104410_Ursa')
BEGIN
    ALTER TABLE [Grants] DROP CONSTRAINT [FK_Grants_AspNetRoles_CurrRoleId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116104410_Ursa')
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Grants]') AND [c].[name] = N'Role');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [Grants] DROP CONSTRAINT [' + @var28 + '];');
    ALTER TABLE [Grants] DROP COLUMN [Role];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116104410_Ursa')
BEGIN
    EXEC sp_rename N'[Grants].[CurrRoleId]', N'RoleId', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116104410_Ursa')
BEGIN
    EXEC sp_rename N'[Grants].[IX_Grants_CurrRoleId]', N'IX_Grants_RoleId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116104410_Ursa')
BEGIN
    ALTER TABLE [Grants] ADD CONSTRAINT [FK_Grants_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190116104410_Ursa')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190116104410_Ursa', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190117075835_Sirius')
BEGIN
    CREATE TABLE [Contacts] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NULL,
        [Note] nvarchar(max) NULL,
        [Condition] nvarchar(max) NULL,
        [CNumber] int NOT NULL,
        [PNumber] int NOT NULL,
        [Ch] nvarchar(max) NULL,
        [Price] float NOT NULL,
        [Policy] nvarchar(max) NULL,
        [Charges] float NOT NULL,
        [Totals] float NOT NULL,
        [PDate] datetime2 NOT NULL,
        [q4a] nvarchar(max) NULL,
        [q5a] bit NOT NULL,
        [q5b] bit NOT NULL,
        [q5c] bit NOT NULL,
        [q5d] bit NOT NULL,
        [q6a] bit NOT NULL,
        [q6b] bit NOT NULL,
        [q6c] bit NOT NULL,
        [q7a] bit NOT NULL,
        [q7b] bit NOT NULL,
        [q7c] bit NOT NULL,
        [q7d] bit NOT NULL,
        [q7e] bit NOT NULL,
        [q7f] bit NOT NULL,
        [q7g] bit NOT NULL,
        [q7h] bit NOT NULL,
        [q7i] bit NOT NULL,
        [q7j] bit NOT NULL,
        [q7k] bit NOT NULL,
        [q7l] bit NOT NULL,
        [q7m] bit NOT NULL,
        [SupporterId] uniqueidentifier NULL,
        [ProviderId] uniqueidentifier NULL,
        [Signed] bit NOT NULL,
        CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Contacts_AspNetUsers_ProviderId] FOREIGN KEY ([ProviderId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Contacts_AspNetUsers_SupporterId] FOREIGN KEY ([SupporterId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190117075835_Sirius')
BEGIN
    CREATE INDEX [IX_Contacts_ProviderId] ON [Contacts] ([ProviderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190117075835_Sirius')
BEGIN
    CREATE INDEX [IX_Contacts_SupporterId] ON [Contacts] ([SupporterId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190117075835_Sirius')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190117075835_Sirius', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190117101618_M31')
BEGIN
    ALTER TABLE [Contacts] DROP CONSTRAINT [FK_Contacts_AspNetUsers_SupporterId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190117101618_M31')
BEGIN
    DROP INDEX [IX_Contacts_SupporterId] ON [Contacts];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190117101618_M31')
BEGIN
    DECLARE @var29 sysname;
    SELECT @var29 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contacts]') AND [c].[name] = N'SupporterId');
    IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [Contacts] DROP CONSTRAINT [' + @var29 + '];');
    ALTER TABLE [Contacts] DROP COLUMN [SupporterId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190117101618_M31')
BEGIN
    ALTER TABLE [Contacts] ADD [Supporter] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190117101618_M31')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190117101618_M31', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190118042541_Whirlwind')
BEGIN
    ALTER TABLE [Contacts] ADD [AppoinmentId] uniqueidentifier NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190118042541_Whirlwind')
BEGIN
    CREATE INDEX [IX_Contacts_AppoinmentId] ON [Contacts] ([AppoinmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190118042541_Whirlwind')
BEGIN
    ALTER TABLE [Contacts] ADD CONSTRAINT [FK_Contacts_appoinment_AppoinmentId] FOREIGN KEY ([AppoinmentId]) REFERENCES [appoinment] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190118042541_Whirlwind')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190118042541_Whirlwind', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190118045546_Pluto')
BEGIN
    DECLARE @var30 sysname;
    SELECT @var30 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contacts]') AND [c].[name] = N'Supporter');
    IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [Contacts] DROP CONSTRAINT [' + @var30 + '];');
    ALTER TABLE [Contacts] DROP COLUMN [Supporter];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190118045546_Pluto')
BEGIN
    ALTER TABLE [Contacts] ADD [SupporterId] uniqueidentifier NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190118045546_Pluto')
BEGIN
    CREATE INDEX [IX_Contacts_SupporterId] ON [Contacts] ([SupporterId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190118045546_Pluto')
BEGIN
    ALTER TABLE [Contacts] ADD CONSTRAINT [FK_Contacts_AspNetUsers_SupporterId] FOREIGN KEY ([SupporterId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190118045546_Pluto')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190118045546_Pluto', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190118092934_Titan')
BEGIN
    ALTER TABLE [appoinment] ADD [IdType] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190118092934_Titan')
BEGIN
    ALTER TABLE [appoinment] ADD [IsForeigner] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190118092934_Titan')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190118092934_Titan', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190121225048_SagitTarius')
BEGIN
    ALTER TABLE [appoinment] ADD [Avatar] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190121225048_SagitTarius')
BEGIN
    ALTER TABLE [appoinment] ADD [DOB] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190121225048_SagitTarius')
BEGIN
    ALTER TABLE [appoinment] ADD [HouseholdPhoto] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190121225048_SagitTarius')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190121225048_SagitTarius', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123025707_Mercury')
BEGIN
    ALTER TABLE [Requests] ADD [ContractNumber] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123025707_Mercury')
BEGIN
    ALTER TABLE [Requests] ADD [Customer] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123025707_Mercury')
BEGIN
    ALTER TABLE [Requests] ADD [DOB] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123025707_Mercury')
BEGIN
    ALTER TABLE [Requests] ADD [Email] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123025707_Mercury')
BEGIN
    ALTER TABLE [Requests] ADD [LoanStatus] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123025707_Mercury')
BEGIN
    ALTER TABLE [Requests] ADD [MaritalStatus] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123025707_Mercury')
BEGIN
    ALTER TABLE [Requests] ADD [Nationality] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123025707_Mercury')
BEGIN
    ALTER TABLE [Requests] ADD [Note] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123025707_Mercury')
BEGIN
    ALTER TABLE [Requests] ADD [PhoneNumber] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123025707_Mercury')
BEGIN
    ALTER TABLE [Requests] ADD [Product] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123025707_Mercury')
BEGIN
    ALTER TABLE [Requests] ADD [Purpose] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123025707_Mercury')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190123025707_Mercury', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123110609_46P-Wirtanen')
BEGIN
    ALTER TABLE [Requests] ADD [CompleteTime] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123110609_46P-Wirtanen')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190123110609_46P-Wirtanen', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123111158_Scorpius')
BEGIN
    ALTER TABLE [Requests] ADD [SubmitTime] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190123111158_Scorpius')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190123111158_Scorpius', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190128014715_Sun')
BEGIN
    ALTER TABLE [Grants] ADD [UserId] uniqueidentifier NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190128014715_Sun')
BEGIN
    CREATE INDEX [IX_Grants_UserId] ON [Grants] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190128014715_Sun')
BEGIN
    ALTER TABLE [Grants] ADD CONSTRAINT [FK_Grants_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190128014715_Sun')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190128014715_Sun', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190129100910_EagleNebula')
BEGIN
    ALTER TABLE [Requests] ADD [ContractId] uniqueidentifier NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190129100910_EagleNebula')
BEGIN
    CREATE INDEX [IX_Requests_ContractId] ON [Requests] ([ContractId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190129100910_EagleNebula')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_appoinment_ContractId] FOREIGN KEY ([ContractId]) REFERENCES [appoinment] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190129100910_EagleNebula')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190129100910_EagleNebula', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190316003654_add document')
BEGIN
    CREATE TABLE [Documents] (
        [Id] int NOT NULL IDENTITY,
        [Create] datetime2 NOT NULL,
        [NumberOfDocuments] int NOT NULL,
        [Email] nvarchar(max) NULL,
        CONSTRAINT [PK_Documents] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190316003654_add document')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190316003654_add document', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190316014604_add view, floor, directin')
BEGIN
    ALTER TABLE [appoinment] ADD [Acreage] float NOT NULL DEFAULT 0E0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190316014604_add view, floor, directin')
BEGIN
    ALTER TABLE [appoinment] ADD [Direction] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190316014604_add view, floor, directin')
BEGIN
    ALTER TABLE [appoinment] ADD [Floor] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190316014604_add view, floor, directin')
BEGIN
    ALTER TABLE [appoinment] ADD [View] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190316014604_add view, floor, directin')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190316014604_add view, floor, directin', N'2.1.8-servicing-32085');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190326011200_add-quiz')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [LastScore] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190326011200_add-quiz')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190326011200_add-quiz', N'2.1.8-servicing-32085');
END;

GO

