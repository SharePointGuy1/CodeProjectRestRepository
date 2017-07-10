using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CodeProject.RESTRepository.Data.Entities;

namespace CodeProject.RESTRepository.Data
{
    public partial class WWIDataContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Password=P@ssw0rd1;Persist Security Info=True;User ID=sa;Initial Catalog=WideWorldImporters;Data Source=(local)");
        //}

        public WWIDataContext(DbContextOptions<WWIDataContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuyingGroups>(entity =>
            {
                entity.HasKey(e => e.BuyingGroupId)
                    .HasName("PK_Sales_BuyingGroups");

                entity.HasIndex(e => e.BuyingGroupName)
                    .HasName("UQ_Sales_BuyingGroups_BuyingGroupName")
                    .IsUnique();

                entity.Property(e => e.BuyingGroupId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[BuyingGroupID]");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK_Application_Cities");

                entity.HasIndex(e => e.StateProvinceId)
                    .HasName("FK_Application_Cities_StateProvinceID");

                entity.Property(e => e.CityId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[CityID]");
            });

            modelBuilder.Entity<ColdRoomTemperatures>(entity =>
            {
                entity.HasKey(e => e.ColdRoomTemperatureId)
                    .HasName("PK_Warehouse_ColdRoomTemperatures");

                entity.HasIndex(e => e.ColdRoomSensorNumber)
                    .HasName("IX_Warehouse_ColdRoomTemperatures_ColdRoomSensorNumber");
            });

            modelBuilder.Entity<Colors>(entity =>
            {
                entity.HasKey(e => e.ColorId)
                    .HasName("PK_Warehouse_Colors");

                entity.HasIndex(e => e.ColorName)
                    .HasName("UQ_Warehouse_Colors_ColorName")
                    .IsUnique();

                entity.Property(e => e.ColorId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[ColorID]");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK_Application_Countries");

                entity.HasIndex(e => e.CountryName)
                    .HasName("UQ_Application_Countries_CountryName")
                    .IsUnique();

                entity.HasIndex(e => e.FormalName)
                    .HasName("UQ_Application_Countries_FormalName")
                    .IsUnique();

                entity.Property(e => e.CountryId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[CountryID]");
            });

            modelBuilder.Entity<CustomerCategories>(entity =>
            {
                entity.HasKey(e => e.CustomerCategoryId)
                    .HasName("PK_Sales_CustomerCategories");

                entity.HasIndex(e => e.CustomerCategoryName)
                    .HasName("UQ_Sales_CustomerCategories_CustomerCategoryName")
                    .IsUnique();

                entity.Property(e => e.CustomerCategoryId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[CustomerCategoryID]");
            });

            modelBuilder.Entity<CustomerTransactions>(entity =>
            {
                entity.HasKey(e => e.CustomerTransactionId)
                    .HasName("PK_Sales_CustomerTransactions");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("FK_Sales_CustomerTransactions_CustomerID");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("FK_Sales_CustomerTransactions_InvoiceID");

                entity.HasIndex(e => e.IsFinalized)
                    .HasName("IX_Sales_CustomerTransactions_IsFinalized");

                entity.HasIndex(e => e.PaymentMethodId)
                    .HasName("FK_Sales_CustomerTransactions_PaymentMethodID");

                entity.HasIndex(e => e.TransactionTypeId)
                    .HasName("FK_Sales_CustomerTransactions_TransactionTypeID");

                entity.Property(e => e.CustomerTransactionId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[TransactionID]");

                entity.Property(e => e.IsFinalized)
                    .HasComputedColumnSql("case when [FinalizationDate] IS NULL then CONVERT([bit],(0)) else CONVERT([bit],(1)) end")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_Sales_Customers");

                entity.HasIndex(e => e.AlternateContactPersonId)
                    .HasName("FK_Sales_Customers_AlternateContactPersonID");

                entity.HasIndex(e => e.BuyingGroupId)
                    .HasName("FK_Sales_Customers_BuyingGroupID");

                entity.HasIndex(e => e.CustomerCategoryId)
                    .HasName("FK_Sales_Customers_CustomerCategoryID");

                entity.HasIndex(e => e.CustomerName)
                    .HasName("UQ_Sales_Customers_CustomerName")
                    .IsUnique();

                entity.HasIndex(e => e.DeliveryCityId)
                    .HasName("FK_Sales_Customers_DeliveryCityID");

                entity.HasIndex(e => e.DeliveryMethodId)
                    .HasName("FK_Sales_Customers_DeliveryMethodID");

                entity.HasIndex(e => e.PostalCityId)
                    .HasName("FK_Sales_Customers_PostalCityID");

                entity.HasIndex(e => e.PrimaryContactPersonId)
                    .HasName("FK_Sales_Customers_PrimaryContactPersonID");

                entity.HasIndex(e => new { e.PrimaryContactPersonId, e.IsOnCreditHold, e.CustomerId, e.BillToCustomerId })
                    .HasName("IX_Sales_Customers_Perf_20160301_06");

                entity.Property(e => e.CustomerId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[CustomerID]");
            });

            modelBuilder.Entity<DeliveryMethods>(entity =>
            {
                entity.HasKey(e => e.DeliveryMethodId)
                    .HasName("PK_Application_DeliveryMethods");

                entity.HasIndex(e => e.DeliveryMethodName)
                    .HasName("UQ_Application_DeliveryMethods_DeliveryMethodName")
                    .IsUnique();

                entity.Property(e => e.DeliveryMethodId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[DeliveryMethodID]");
            });

            modelBuilder.Entity<InvoiceLines>(entity =>
            {
                entity.HasKey(e => e.InvoiceLineId)
                    .HasName("PK_Sales_InvoiceLines");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("FK_Sales_InvoiceLines_InvoiceID");

                entity.HasIndex(e => e.PackageTypeId)
                    .HasName("FK_Sales_InvoiceLines_PackageTypeID");

                entity.HasIndex(e => e.StockItemId)
                    .HasName("FK_Sales_InvoiceLines_StockItemID");

                entity.Property(e => e.InvoiceLineId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[InvoiceLineID]");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.HasKey(e => e.InvoiceId)
                    .HasName("PK_Sales_Invoices");

                entity.HasIndex(e => e.AccountsPersonId)
                    .HasName("FK_Sales_Invoices_AccountsPersonID");

                entity.HasIndex(e => e.BillToCustomerId)
                    .HasName("FK_Sales_Invoices_BillToCustomerID");

                entity.HasIndex(e => e.ContactPersonId)
                    .HasName("FK_Sales_Invoices_ContactPersonID");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("FK_Sales_Invoices_CustomerID");

                entity.HasIndex(e => e.DeliveryMethodId)
                    .HasName("FK_Sales_Invoices_DeliveryMethodID");

                entity.HasIndex(e => e.OrderId)
                    .HasName("FK_Sales_Invoices_OrderID");

                entity.HasIndex(e => e.PackedByPersonId)
                    .HasName("FK_Sales_Invoices_PackedByPersonID");

                entity.HasIndex(e => e.SalespersonPersonId)
                    .HasName("FK_Sales_Invoices_SalespersonPersonID");

                entity.HasIndex(e => new { e.ConfirmedReceivedBy, e.ConfirmedDeliveryTime })
                    .HasName("IX_Sales_Invoices_ConfirmedDeliveryTime");

                entity.Property(e => e.InvoiceId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[InvoiceID]");

                entity.Property(e => e.ConfirmedDeliveryTime)
                    .HasComputedColumnSql("TRY_CONVERT([datetime2](7),json_value([ReturnedDeliveryData],N'$.DeliveredWhen'),(126))")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ConfirmedReceivedBy)
                    .HasComputedColumnSql("json_value([ReturnedDeliveryData],N'$.ReceivedBy')")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");
            });

            modelBuilder.Entity<OrderLines>(entity =>
            {
                entity.HasKey(e => e.OrderLineId)
                    .HasName("PK_Sales_OrderLines");

                entity.HasIndex(e => e.OrderId)
                    .HasName("FK_Sales_OrderLines_OrderID");

                entity.HasIndex(e => e.PackageTypeId)
                    .HasName("FK_Sales_OrderLines_PackageTypeID");

                entity.HasIndex(e => new { e.PickedQuantity, e.StockItemId })
                    .HasName("IX_Sales_OrderLines_AllocatedStockItems");

                entity.HasIndex(e => new { e.OrderId, e.PickedQuantity, e.StockItemId, e.PickingCompletedWhen })
                    .HasName("IX_Sales_OrderLines_Perf_20160301_02");

                entity.HasIndex(e => new { e.Quantity, e.StockItemId, e.PickingCompletedWhen, e.OrderId, e.OrderLineId })
                    .HasName("IX_Sales_OrderLines_Perf_20160301_01");

                entity.Property(e => e.OrderLineId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[OrderLineID]");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_Sales_Orders");

                entity.HasIndex(e => e.ContactPersonId)
                    .HasName("FK_Sales_Orders_ContactPersonID");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("FK_Sales_Orders_CustomerID");

                entity.HasIndex(e => e.PickedByPersonId)
                    .HasName("FK_Sales_Orders_PickedByPersonID");

                entity.HasIndex(e => e.SalespersonPersonId)
                    .HasName("FK_Sales_Orders_SalespersonPersonID");

                entity.Property(e => e.OrderId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[OrderID]");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");
            });

            modelBuilder.Entity<PackageTypes>(entity =>
            {
                entity.HasKey(e => e.PackageTypeId)
                    .HasName("PK_Warehouse_PackageTypes");

                entity.HasIndex(e => e.PackageTypeName)
                    .HasName("UQ_Warehouse_PackageTypes_PackageTypeName")
                    .IsUnique();

                entity.Property(e => e.PackageTypeId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[PackageTypeID]");
            });

            modelBuilder.Entity<PaymentMethods>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodId)
                    .HasName("PK_Application_PaymentMethods");

                entity.HasIndex(e => e.PaymentMethodName)
                    .HasName("UQ_Application_PaymentMethods_PaymentMethodName")
                    .IsUnique();

                entity.Property(e => e.PaymentMethodId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[PaymentMethodID]");
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK_Application_People");

                entity.HasIndex(e => e.FullName)
                    .HasName("IX_Application_People_FullName");

                entity.HasIndex(e => e.IsEmployee)
                    .HasName("IX_Application_People_IsEmployee");

                entity.HasIndex(e => e.IsSalesperson)
                    .HasName("IX_Application_People_IsSalesperson");

                entity.HasIndex(e => new { e.FullName, e.EmailAddress, e.IsPermittedToLogon, e.PersonId })
                    .HasName("IX_Application_People_Perf_20160301_05");

                entity.Property(e => e.PersonId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[PersonID]");

                entity.Property(e => e.OtherLanguages)
                    .HasComputedColumnSql("json_query([CustomFields],N'$.OtherLanguages')")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.SearchName)
                    .HasComputedColumnSql("concat([PreferredName],N' ',[FullName])")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<PurchaseOrderLines>(entity =>
            {
                entity.HasKey(e => e.PurchaseOrderLineId)
                    .HasName("PK_Purchasing_PurchaseOrderLines");

                entity.HasIndex(e => e.PackageTypeId)
                    .HasName("FK_Purchasing_PurchaseOrderLines_PackageTypeID");

                entity.HasIndex(e => e.PurchaseOrderId)
                    .HasName("FK_Purchasing_PurchaseOrderLines_PurchaseOrderID");

                entity.HasIndex(e => e.StockItemId)
                    .HasName("FK_Purchasing_PurchaseOrderLines_StockItemID");

                entity.HasIndex(e => new { e.OrderedOuters, e.ReceivedOuters, e.IsOrderLineFinalized, e.StockItemId })
                    .HasName("IX_Purchasing_PurchaseOrderLines_Perf_20160301_4");

                entity.Property(e => e.PurchaseOrderLineId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[PurchaseOrderLineID]");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");
            });

            modelBuilder.Entity<PurchaseOrders>(entity =>
            {
                entity.HasKey(e => e.PurchaseOrderId)
                    .HasName("PK_Purchasing_PurchaseOrders");

                entity.HasIndex(e => e.ContactPersonId)
                    .HasName("FK_Purchasing_PurchaseOrders_ContactPersonID");

                entity.HasIndex(e => e.DeliveryMethodId)
                    .HasName("FK_Purchasing_PurchaseOrders_DeliveryMethodID");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("FK_Purchasing_PurchaseOrders_SupplierID");

                entity.Property(e => e.PurchaseOrderId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[PurchaseOrderID]");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");
            });

            modelBuilder.Entity<SpecialDeals>(entity =>
            {
                entity.HasKey(e => e.SpecialDealId)
                    .HasName("PK_Sales_SpecialDeals");

                entity.HasIndex(e => e.BuyingGroupId)
                    .HasName("FK_Sales_SpecialDeals_BuyingGroupID");

                entity.HasIndex(e => e.CustomerCategoryId)
                    .HasName("FK_Sales_SpecialDeals_CustomerCategoryID");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("FK_Sales_SpecialDeals_CustomerID");

                entity.HasIndex(e => e.StockGroupId)
                    .HasName("FK_Sales_SpecialDeals_StockGroupID");

                entity.HasIndex(e => e.StockItemId)
                    .HasName("FK_Sales_SpecialDeals_StockItemID");

                entity.Property(e => e.SpecialDealId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[SpecialDealID]");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");
            });

            modelBuilder.Entity<StateProvinces>(entity =>
            {
                entity.HasKey(e => e.StateProvinceId)
                    .HasName("PK_Application_StateProvinces");

                entity.HasIndex(e => e.CountryId)
                    .HasName("FK_Application_StateProvinces_CountryID");

                entity.HasIndex(e => e.SalesTerritory)
                    .HasName("IX_Application_StateProvinces_SalesTerritory");

                entity.HasIndex(e => e.StateProvinceName)
                    .HasName("UQ_Application_StateProvinces_StateProvinceName")
                    .IsUnique();

                entity.Property(e => e.StateProvinceId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[StateProvinceID]");
            });

            modelBuilder.Entity<StockGroups>(entity =>
            {
                entity.HasKey(e => e.StockGroupId)
                    .HasName("PK_Warehouse_StockGroups");

                entity.HasIndex(e => e.StockGroupName)
                    .HasName("UQ_Warehouse_StockGroups_StockGroupName")
                    .IsUnique();

                entity.Property(e => e.StockGroupId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[StockGroupID]");
            });

            modelBuilder.Entity<StockItemHoldings>(entity =>
            {
                entity.HasKey(e => e.StockItemId)
                    .HasName("PK_Warehouse_StockItemHoldings");

                entity.Property(e => e.StockItemId).ValueGeneratedNever();

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");
            });

            modelBuilder.Entity<StockItemStockGroups>(entity =>
            {
                entity.HasKey(e => e.StockItemStockGroupId)
                    .HasName("PK_Warehouse_StockItemStockGroups");

                entity.HasIndex(e => new { e.StockGroupId, e.StockItemId })
                    .HasName("UQ_StockItemStockGroups_StockGroupID_Lookup")
                    .IsUnique();

                entity.HasIndex(e => new { e.StockItemId, e.StockGroupId })
                    .HasName("UQ_StockItemStockGroups_StockItemID_Lookup")
                    .IsUnique();

                entity.Property(e => e.StockItemStockGroupId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[StockItemStockGroupID]");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");
            });

            modelBuilder.Entity<StockItemTransactions>(entity =>
            {
                entity.HasKey(e => e.StockItemTransactionId)
                    .HasName("PK_Warehouse_StockItemTransactions");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("FK_Warehouse_StockItemTransactions_CustomerID");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("FK_Warehouse_StockItemTransactions_InvoiceID");

                entity.HasIndex(e => e.PurchaseOrderId)
                    .HasName("FK_Warehouse_StockItemTransactions_PurchaseOrderID");

                entity.HasIndex(e => e.StockItemId)
                    .HasName("FK_Warehouse_StockItemTransactions_StockItemID");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("FK_Warehouse_StockItemTransactions_SupplierID");

                entity.HasIndex(e => e.TransactionTypeId)
                    .HasName("FK_Warehouse_StockItemTransactions_TransactionTypeID");

                entity.Property(e => e.StockItemTransactionId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[TransactionID]");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");
            });

            modelBuilder.Entity<StockItems>(entity =>
            {
                entity.HasKey(e => e.StockItemId)
                    .HasName("PK_Warehouse_StockItems");

                entity.HasIndex(e => e.ColorId)
                    .HasName("FK_Warehouse_StockItems_ColorID");

                entity.HasIndex(e => e.OuterPackageId)
                    .HasName("FK_Warehouse_StockItems_OuterPackageID");

                entity.HasIndex(e => e.StockItemName)
                    .HasName("UQ_Warehouse_StockItems_StockItemName")
                    .IsUnique();

                entity.HasIndex(e => e.SupplierId)
                    .HasName("FK_Warehouse_StockItems_SupplierID");

                entity.HasIndex(e => e.UnitPackageId)
                    .HasName("FK_Warehouse_StockItems_UnitPackageID");

                entity.Property(e => e.StockItemId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[StockItemID]");

                entity.Property(e => e.SearchDetails)
                    .HasComputedColumnSql("concat([StockItemName],N' ',[MarketingComments])")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Tags)
                    .HasComputedColumnSql("json_query([CustomFields],N'$.Tags')")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<SupplierCategories>(entity =>
            {
                entity.HasKey(e => e.SupplierCategoryId)
                    .HasName("PK_Purchasing_SupplierCategories");

                entity.HasIndex(e => e.SupplierCategoryName)
                    .HasName("UQ_Purchasing_SupplierCategories_SupplierCategoryName")
                    .IsUnique();

                entity.Property(e => e.SupplierCategoryId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[SupplierCategoryID]");
            });

            modelBuilder.Entity<SupplierTransactions>(entity =>
            {
                entity.HasKey(e => e.SupplierTransactionId)
                    .HasName("PK_Purchasing_SupplierTransactions");

                entity.HasIndex(e => e.IsFinalized)
                    .HasName("IX_Purchasing_SupplierTransactions_IsFinalized");

                entity.HasIndex(e => e.PaymentMethodId)
                    .HasName("FK_Purchasing_SupplierTransactions_PaymentMethodID");

                entity.HasIndex(e => e.PurchaseOrderId)
                    .HasName("FK_Purchasing_SupplierTransactions_PurchaseOrderID");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("FK_Purchasing_SupplierTransactions_SupplierID");

                entity.HasIndex(e => e.TransactionTypeId)
                    .HasName("FK_Purchasing_SupplierTransactions_TransactionTypeID");

                entity.Property(e => e.SupplierTransactionId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[TransactionID]");

                entity.Property(e => e.IsFinalized)
                    .HasComputedColumnSql("case when [FinalizationDate] IS NULL then CONVERT([bit],(0)) else CONVERT([bit],(1)) end")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK_Purchasing_Suppliers");

                entity.HasIndex(e => e.AlternateContactPersonId)
                    .HasName("FK_Purchasing_Suppliers_AlternateContactPersonID");

                entity.HasIndex(e => e.DeliveryCityId)
                    .HasName("FK_Purchasing_Suppliers_DeliveryCityID");

                entity.HasIndex(e => e.DeliveryMethodId)
                    .HasName("FK_Purchasing_Suppliers_DeliveryMethodID");

                entity.HasIndex(e => e.PostalCityId)
                    .HasName("FK_Purchasing_Suppliers_PostalCityID");

                entity.HasIndex(e => e.PrimaryContactPersonId)
                    .HasName("FK_Purchasing_Suppliers_PrimaryContactPersonID");

                entity.HasIndex(e => e.SupplierCategoryId)
                    .HasName("FK_Purchasing_Suppliers_SupplierCategoryID");

                entity.HasIndex(e => e.SupplierName)
                    .HasName("UQ_Purchasing_Suppliers_SupplierName")
                    .IsUnique();

                entity.Property(e => e.SupplierId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[SupplierID]");
            });

            modelBuilder.Entity<SystemParameters>(entity =>
            {
                entity.HasKey(e => e.SystemParameterId)
                    .HasName("PK_Application_SystemParameters");

                entity.HasIndex(e => e.DeliveryCityId)
                    .HasName("FK_Application_SystemParameters_DeliveryCityID");

                entity.HasIndex(e => e.PostalCityId)
                    .HasName("FK_Application_SystemParameters_PostalCityID");

                entity.Property(e => e.SystemParameterId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[SystemParameterID]");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");
            });

            modelBuilder.Entity<TransactionTypes>(entity =>
            {
                entity.HasKey(e => e.TransactionTypeId)
                    .HasName("PK_Application_TransactionTypes");

                entity.HasIndex(e => e.TransactionTypeName)
                    .HasName("UQ_Application_TransactionTypes_TransactionTypeName")
                    .IsUnique();

                entity.Property(e => e.TransactionTypeId).HasDefaultValueSql("NEXT VALUE FOR [Sequences].[TransactionTypeID]");
            });

            modelBuilder.Entity<VehicleTemperatures>(entity =>
            {
                entity.HasKey(e => e.VehicleTemperatureId)
                    .HasName("PK_Warehouse_VehicleTemperatures");
            });

            modelBuilder.HasSequence<int>("BuyingGroupID", "Sequences").StartsAt(3);

            modelBuilder.HasSequence<int>("CityID", "Sequences").StartsAt(38187);

            modelBuilder.HasSequence<int>("ColorID", "Sequences").StartsAt(37);

            modelBuilder.HasSequence<int>("CountryID", "Sequences").StartsAt(242);

            modelBuilder.HasSequence<int>("CustomerCategoryID", "Sequences").StartsAt(9);

            modelBuilder.HasSequence<int>("CustomerID", "Sequences").StartsAt(1062);

            modelBuilder.HasSequence<int>("DeliveryMethodID", "Sequences").StartsAt(11);

            modelBuilder.HasSequence<int>("InvoiceID", "Sequences").StartsAt(70511);

            modelBuilder.HasSequence<int>("InvoiceLineID", "Sequences").StartsAt(228266);

            modelBuilder.HasSequence<int>("OrderID", "Sequences").StartsAt(73596);

            modelBuilder.HasSequence<int>("OrderLineID", "Sequences").StartsAt(231413);

            modelBuilder.HasSequence<int>("PackageTypeID", "Sequences").StartsAt(15);

            modelBuilder.HasSequence<int>("PaymentMethodID", "Sequences").StartsAt(5);

            modelBuilder.HasSequence<int>("PersonID", "Sequences").StartsAt(3262);

            modelBuilder.HasSequence<int>("PurchaseOrderID", "Sequences").StartsAt(2075);

            modelBuilder.HasSequence<int>("PurchaseOrderLineID", "Sequences").StartsAt(8368);

            modelBuilder.HasSequence<int>("SpecialDealID", "Sequences").StartsAt(3);

            modelBuilder.HasSequence<int>("StateProvinceID", "Sequences").StartsAt(54);

            modelBuilder.HasSequence<int>("StockGroupID", "Sequences").StartsAt(11);

            modelBuilder.HasSequence<int>("StockItemID", "Sequences").StartsAt(228);

            modelBuilder.HasSequence<int>("StockItemStockGroupID", "Sequences").StartsAt(443);

            modelBuilder.HasSequence<int>("SupplierCategoryID", "Sequences").StartsAt(10);

            modelBuilder.HasSequence<int>("SupplierID", "Sequences").StartsAt(14);

            modelBuilder.HasSequence<int>("SystemParameterID", "Sequences").StartsAt(2);

            modelBuilder.HasSequence<int>("TransactionID", "Sequences").StartsAt(336253);

            modelBuilder.HasSequence<int>("TransactionTypeID", "Sequences").StartsAt(14);
        }

        public virtual DbSet<BuyingGroups> BuyingGroups { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<ColdRoomTemperatures> ColdRoomTemperatures { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CustomerCategories> CustomerCategories { get; set; }
        public virtual DbSet<CustomerTransactions> CustomerTransactions { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<DeliveryMethods> DeliveryMethods { get; set; }
        public virtual DbSet<InvoiceLines> InvoiceLines { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<OrderLines> OrderLines { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PackageTypes> PackageTypes { get; set; }
        public virtual DbSet<PaymentMethods> PaymentMethods { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<PurchaseOrderLines> PurchaseOrderLines { get; set; }
        public virtual DbSet<PurchaseOrders> PurchaseOrders { get; set; }
        public virtual DbSet<SpecialDeals> SpecialDeals { get; set; }
        public virtual DbSet<StateProvinces> StateProvinces { get; set; }
        public virtual DbSet<StockGroups> StockGroups { get; set; }
        public virtual DbSet<StockItemHoldings> StockItemHoldings { get; set; }
        public virtual DbSet<StockItemStockGroups> StockItemStockGroups { get; set; }
        public virtual DbSet<StockItemTransactions> StockItemTransactions { get; set; }
        public virtual DbSet<StockItems> StockItems { get; set; }
        public virtual DbSet<SupplierCategories> SupplierCategories { get; set; }
        public virtual DbSet<SupplierTransactions> SupplierTransactions { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<SystemParameters> SystemParameters { get; set; }
        public virtual DbSet<TransactionTypes> TransactionTypes { get; set; }
        public virtual DbSet<VehicleTemperatures> VehicleTemperatures { get; set; }
    }
}