USE [scadb.auth]
GO

INSERT INTO [dbo].[Usuarios] ([Username],[Password],[Role])  VALUES ('admin', 'admin123', 'admin')
INSERT INTO [dbo].[Usuarios] ([Username],[Password],[Role])  VALUES ('engenheiro', 'engenheiro123', 'engenheiro')
INSERT INTO [dbo].[Usuarios] ([Username],[Password],[Role])  VALUES ('consultor', 'consultor123', 'consultor')
INSERT INTO [dbo].[Usuarios] ([Username],[Password],[Role])  VALUES ('analista', 'analista123', 'analista')

GO


