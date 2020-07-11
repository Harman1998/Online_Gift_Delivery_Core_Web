SET IDENTITY_INSERT [dbo].[Gift] ON
INSERT INTO [dbo].[Gift] ([Id], [ItemName], [ItemPrice]) VALUES (1, N'Large Teddy Bear', CAST(50.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Gift] ([Id], [ItemName], [ItemPrice]) VALUES (2, N'Remote Control Toy Helicopter ', CAST(100.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Gift] ([Id], [ItemName], [ItemPrice]) VALUES (3, N'Smart Watch', CAST(250.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Gift] OFF
SET IDENTITY_INSERT [dbo].[GiftSender] ON
INSERT INTO [dbo].[GiftSender] ([Id], [SenderName], [MobileNumber]) VALUES (1, N'John Timothy', N'0213334567')
INSERT INTO [dbo].[GiftSender] ([Id], [SenderName], [MobileNumber]) VALUES (2, N'Harry Johnson', N'0223456789')
SET IDENTITY_INSERT [dbo].[GiftSender] OFF
SET IDENTITY_INSERT [dbo].[ShippingMethod] ON
INSERT INTO [dbo].[ShippingMethod] ([Id], [Name], [Charge]) VALUES (1, N'Expedite ', CAST(10.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[ShippingMethod] ([Id], [Name], [Charge]) VALUES (2, N'Normal', CAST(5.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ShippingMethod] OFF
SET IDENTITY_INSERT [dbo].[GiftPurchase] ON
INSERT INTO [dbo].[GiftPurchase] ([Id], [GiftSenderId], [GiftId], [ShippingMethodId], [Reciever], [RecieverAddress]) VALUES (2, 2, 3, 1, N'Frank Jason', N'230 Swanson Street, Auckland')
INSERT INTO [dbo].[GiftPurchase] ([Id], [GiftSenderId], [GiftId], [ShippingMethodId], [Reciever], [RecieverAddress]) VALUES (3, 1, 2, 2, N'John Samson', N'233 Victoria Street, Auckland')
SET IDENTITY_INSERT [dbo].[GiftPurchase] OFF
