CREATE TABLE [dbo].[SalesInfo]
(
	[Sales_ID] INT NOT NULL, 
    [Med_ID] INT NOT NULL,
	[Quantity] INT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_SalesInfo_Sales] FOREIGN KEY ([Sales_ID]) REFERENCES [Sales]([Sales_ID]), 
    CONSTRAINT [FK_SalesInfo_MedicineMaster] FOREIGN KEY ([Med_ID]) REFERENCES [MedicineMaster]([Med_ID])
)
