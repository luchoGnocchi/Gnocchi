USE [BetizagastiGnocchi]
GO
SET IDENTITY_INSERT [dbo].[ActionOperations] ON 

INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (1, N'User.CreateUser')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (2, N'User.UpdateById')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (3, N'User.DeleteById')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (4, N'Batch.DeleteById')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (5, N'Batch.UpdateById')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (6, N'Batch.AddVehicle')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (7, N'Batch.Add')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (8, N'Vehicle.Add')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (11, N'Inspection.Add')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (12, N'Inspection.UpdateById
')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (13, N'Inspection.DeleteById
')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (15, N'Inspection.AddDamage')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (16, N'Vehicle.UpdateById
')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (17, N'Vehicle.DeleteById
')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (19, N'Zone.Add')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (20, N'Zone.UpdateById
')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (21, N'Zone.DeleteById
')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (22, N'Zone.AddVehicle')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (23, N'BatchTransport.UpdateById')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (24, N'BatchTransport.DeleteById')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (139, N'BatchTransport.Add')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (140, N'BatchTransport.AddBatch')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (141, N'BatchTransport.StrartTravel')
INSERT [dbo].[ActionOperations] ([Id], [Name]) VALUES (142, N'BatchTransport.FinishTravel')
SET IDENTITY_INSERT [dbo].[ActionOperations] OFF
SET IDENTITY_INSERT [dbo].[UserRols] ON 

INSERT [dbo].[UserRols] ([Id], [UType]) VALUES (1, 1)
INSERT [dbo].[UserRols] ([Id], [UType]) VALUES (2, 2)
INSERT [dbo].[UserRols] ([Id], [UType]) VALUES (3, 3)
INSERT [dbo].[UserRols] ([Id], [UType]) VALUES (4, 4)
INSERT [dbo].[UserRols] ([Id], [UType]) VALUES (5, 5)
INSERT [dbo].[UserRols] ([Id], [UType]) VALUES (6, 0)
INSERT [dbo].[UserRols] ([Id], [UType]) VALUES (7, 0)
INSERT [dbo].[UserRols] ([Id], [UType]) VALUES (8, 0)
INSERT [dbo].[UserRols] ([Id], [UType]) VALUES (9, 0)
INSERT [dbo].[UserRols] ([Id], [UType]) VALUES (10, 0)
SET IDENTITY_INSERT [dbo].[UserRols] OFF
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 1)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 2)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 3)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 4)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 5)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 6)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 7)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 8)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 11)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 12)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 13)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 15)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 16)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 17)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 19)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 20)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 21)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 22)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 23)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 24)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 139)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 140)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 141)
INSERT [dbo].[UserRolActionOperations] ([UserRol_Id], [ActionOperation_Id]) VALUES (1, 142)
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [Password], [Token], [Rol_Id], [Salt]) VALUES (3, N'SuperAdmin', N'4O5hvvOpWJouv8nCiBpFZY+yU6n4RgwWEj2lCI+ev10=', N'fc32769b-0a38-4d76-b945-f42a63367874', 1, N'1ShW1TTK1b6zKNMFe2uICw==')
SET IDENTITY_INSERT [dbo].[Users] OFF
