	-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE CustomersInsert
	-- Add the parameters for the stored procedure here
	@customerId int = Null Out,
	@customerName [nvarchar](100) NOT NULL,
	@billToCustomerID [int] NOT NULL,
	@customerCategoryID [int] NOT NULL,
	@buyingGroupID [int] NULL,
	@primaryContactPersonID [int] NOT NULL,
	@alternateContactPersonID [int] NULL,
	@deliveryMethodID [int] NOT NULL,
	@deliveryCityID [int] NOT NULL,
	@postalCityID [int] NOT NULL,
	@accountOpenedDate [date] NOT NULL,
	@standardDiscountPercentage [decimal](18, 3) NOT NULL,
	@isStatementSent [bit] NOT NULL,
	@isOnCreditHold [bit] NOT NULL,
	@paymentDays [int] NOT NULL,
	@phoneNumber [nvarchar](20) NOT NULL,
	@faxNumber [nvarchar](20) NOT NULL,
	@websiteURL [nvarchar](256) NOT NULL,
	@deliveryAddressLine1 [nvarchar](60) NOT NULL,
	@deliveryAddressLine2 [nvarchar](60) NULL,
	@deliveryPostalCode [nvarchar](10) NOT NULL,
	@postalAddressLine1 [nvarchar](60) NOT NULL,
	@postalAddressLine2 [nvarchar](60) NULL,
	@postalPostalCode [nvarchar](10) NOT NULL,
	@lastEditedBy [int] NOT NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Insert Into db.Customers Columns 
	[
	[CustomerName],
	[BillToCustomerID],
	[CustomerCategoryID],
	[BuyingGroupID],
	[PrimaryContactPersonID],
	[AlternateContactPersonID],
	[DeliveryMethodID],
	[DeliveryCityID],
	[PostalCityID],
	[CreditLimit],
	[AccountOpenedDate],
	[StandardDiscountPercentage],
	[IsStatementSent],
	[IsOnCreditHold],
	[PaymentDays],
	[PhoneNumber],
	[FaxNumber],
	[DeliveryRun],
	[RunPosition],
	[WebsiteURL],
	[DeliveryAddressLine1],
	[DeliveryAddressLine2],
	[DeliveryPostalCode],
	[DeliveryLocation],
	[PostalAddressLine1],
	[PostalAddressLine2],
	[PostalPostalCode],
	[LastEditedBy]
	]

    -- Insert statements for procedure here
	Select @customerId = SCOPE_IDENTITY()
END
GO
