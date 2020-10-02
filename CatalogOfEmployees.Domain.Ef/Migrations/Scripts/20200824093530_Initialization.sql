USE [EmployeesContext]
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [LastName], [FirstName], [MiddleName], [MobilePhone], [Email], [State]) VALUES (1, N'Александров', N'Кирилл', N'Родионович', N'', N'test1@mail.ru', N'Директор')
INSERT [dbo].[Employees] ([Id], [LastName], [FirstName], [MiddleName], [MobilePhone], [Email], [State]) VALUES (2, N'Егоров', N'Дмитрий', N'Тимофеевич', N'+7(999)9999999', N'test2@mail.ru', N'Менеджер')
INSERT [dbo].[Employees] ([Id], [LastName], [FirstName], [MiddleName], [MobilePhone], [Email], [State]) VALUES (3, N'Кузнецова', N'Елизавета', N'Владиславовна', N'+7(999)8888888', N'test3@mail.ru', N'Программист')
INSERT [dbo].[Employees] ([Id], [LastName], [FirstName], [MiddleName], [MobilePhone], [Email], [State]) VALUES (4, N'Федорова', N'Анна', N'Максимовна', N'+7(999)7798889', N'test4@mail.ru', N'Маркетолог')
INSERT [dbo].[Employees] ([Id], [LastName], [FirstName], [MiddleName], [MobilePhone], [Email], [State]) VALUES (5, N'Фокина', N'Яна', N'Данииловна', N'+7(999)8977799', N'test5@mail.ru', N'Бухгалтер')
INSERT [dbo].[Employees] ([Id], [LastName], [FirstName], [MiddleName], [MobilePhone], [Email], [State]) VALUES (6, N'Яковлев', N'Александр', N'Ярославович', N'+7(999)9555999', N'test6@mail.ru', N'Финансовый директор')
INSERT [dbo].[Employees] ([Id], [LastName], [FirstName], [MiddleName], [MobilePhone], [Email], [State]) VALUES (7, N'Михайлова', N'София', N'Артуровна', N'+7(999)9555999', N'test6@mail.ru', N'Дизайнер')
SET IDENTITY_INSERT [dbo].[Employees] OFF
