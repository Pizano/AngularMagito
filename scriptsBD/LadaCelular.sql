USE [RecepcionMSW]
GO

IF NOT Exists(select * from sys .columns where Name = N'LadaCelular' and Object_ID = Object_ID(N'Persona'))

BEGIN
ALTER TABLE [dbo].[Persona]
ADD LadaCelular nvarchar(10) null default(0)


END
