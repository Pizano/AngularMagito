USE [RecepcionMSW]
GO

IF NOT Exists(select * from sys .columns where Name = N'LadaFijo' and Object_ID = Object_ID(N'Persona'))

BEGIN
ALTER TABLE [dbo].[Persona]
ADD LadaFijo nvarchar(10) null default(0)


END