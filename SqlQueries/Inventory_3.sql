CREATE TABLE [dbo].[Inventory]
(
	[Med_ID] INT NOT NULL PRIMARY KEY, 
    [Med_Remaining] INT NOT NULL , 
    [Med_Threshold] INT NOT NULL, 
    CONSTRAINT [FK_Inventory_MedicineMaster] FOREIGN KEY ([Med_ID]) REFERENCES [MedicineMaster]([Med_ID])
)
