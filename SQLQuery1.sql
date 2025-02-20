﻿CREATE TABLE [dbo].Customers (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (255) NOT NULL,
    [UpdatedBy]   INT            NULL,
    [CreatedBy]   INT            NULL,
    [DeletedBy]   INT            NULL,
    [CreatedDate] DATETIME2 (7)  NOT NULL,
    [DeletedDate] DATETIME2 (7)  NULL,
    [UpdatedDate] DATETIME2 (7)  NULL,
    [IsDeleted]   BIT            NOT NULL
);  