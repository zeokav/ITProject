CREATE TABLE [dbo].[Vendor]
(
	[Vendor_ID] INT IDENTITY(1,1) PRIMARY KEY, 
    [Vendor_Address] VARCHAR(500) NOT NULL, 
    [Vendor_Name] VARCHAR(50) NOT NULL
)
