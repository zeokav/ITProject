CREATE TABLE [dbo].[MedicineMaster] (
    [Med_ID]       INT          IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Trade_Name]   VARCHAR (50) NOT NULL,
    [Gen_Name]     VARCHAR (50) NOT NULL,
    [Manufacturer] VARCHAR (50) NOT NULL,
    [Vendor_ID]    INT          NOT NULL,
    [Med_Price] FLOAT NOT NULL, 
    CONSTRAINT [FK_MedicineMaster_Vendor] FOREIGN KEY ([Vendor_ID]) REFERENCES [Vendor] ([Vendor_ID])
);

