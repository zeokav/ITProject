CREATE TABLE [dbo].[BatchInfo]
(
	[Batch_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Expiry_Date] DATE NOT NULL, 
    [Buy_Date] DATE NOT NULL, 
    [Med_ID] INT NOT NULL, 
    CONSTRAINT [FK_BatchInfo_MedicineMaster] FOREIGN KEY ([Med_ID]) REFERENCES [MedicineMaster]([Med_ID])
)
