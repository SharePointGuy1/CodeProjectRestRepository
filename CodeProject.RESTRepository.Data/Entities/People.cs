using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("People", Schema = "Application")]
    public partial class People
    {
        public People()
        {
            BuyingGroups = new HashSet<BuyingGroups>();
            Cities = new HashSet<Cities>();
            Colors = new HashSet<Colors>();
            Countries = new HashSet<Countries>();
            CustomerCategories = new HashSet<CustomerCategories>();
            CustomersAlternateContactPerson = new HashSet<Customers>();
            CustomersLastEditedByNavigation = new HashSet<Customers>();
            CustomersPrimaryContactPerson = new HashSet<Customers>();
            CustomerTransactions = new HashSet<CustomerTransactions>();
            DeliveryMethods = new HashSet<DeliveryMethods>();
            InvoiceLines = new HashSet<InvoiceLines>();
            InvoicesAccountsPerson = new HashSet<Invoices>();
            InvoicesContactPerson = new HashSet<Invoices>();
            InvoicesLastEditedByNavigation = new HashSet<Invoices>();
            InvoicesPackedByPerson = new HashSet<Invoices>();
            InvoicesSalespersonPerson = new HashSet<Invoices>();
            OrderLines = new HashSet<OrderLines>();
            OrdersContactPerson = new HashSet<Orders>();
            OrdersLastEditedByNavigation = new HashSet<Orders>();
            OrdersPickedByPerson = new HashSet<Orders>();
            OrdersSalespersonPerson = new HashSet<Orders>();
            PackageTypes = new HashSet<PackageTypes>();
            PaymentMethods = new HashSet<PaymentMethods>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLines>();
            PurchaseOrdersContactPerson = new HashSet<PurchaseOrders>();
            PurchaseOrdersLastEditedByNavigation = new HashSet<PurchaseOrders>();
            SpecialDeals = new HashSet<SpecialDeals>();
            StateProvinces = new HashSet<StateProvinces>();
            StockGroups = new HashSet<StockGroups>();
            StockItemHoldings = new HashSet<StockItemHoldings>();
            StockItems = new HashSet<StockItems>();
            StockItemStockGroups = new HashSet<StockItemStockGroups>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
            SupplierCategories = new HashSet<SupplierCategories>();
            SuppliersAlternateContactPerson = new HashSet<Suppliers>();
            SuppliersLastEditedByNavigation = new HashSet<Suppliers>();
            SuppliersPrimaryContactPerson = new HashSet<Suppliers>();
            SupplierTransactions = new HashSet<SupplierTransactions>();
            SystemParameters = new HashSet<SystemParameters>();
            TransactionTypes = new HashSet<TransactionTypes>();
        }

        [Column("PersonID")]
        public int PersonId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(50)]
        public string PreferredName { get; set; }
        [Required]
        [MaxLength(101)]
        public string SearchName { get; set; }
        public bool IsPermittedToLogon { get; set; }
        [MaxLength(50)]
        public string LogonName { get; set; }
        public bool IsExternalLogonProvider { get; set; }
        public byte[] HashedPassword { get; set; }
        public bool IsSystemUser { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsSalesperson { get; set; }
        public string UserPreferences { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [MaxLength(20)]
        public string FaxNumber { get; set; }
        [MaxLength(256)]
        public string EmailAddress { get; set; }
        public byte[] Photo { get; set; }
        public string CustomFields { get; set; }
        public string OtherLanguages { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<BuyingGroups> BuyingGroups { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<Cities> Cities { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<Colors> Colors { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<Countries> Countries { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<CustomerCategories> CustomerCategories { get; set; }
        [InverseProperty("AlternateContactPerson")]
        public virtual ICollection<Customers> CustomersAlternateContactPerson { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<Customers> CustomersLastEditedByNavigation { get; set; }
        [InverseProperty("PrimaryContactPerson")]
        public virtual ICollection<Customers> CustomersPrimaryContactPerson { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<CustomerTransactions> CustomerTransactions { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<DeliveryMethods> DeliveryMethods { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<InvoiceLines> InvoiceLines { get; set; }
        [InverseProperty("AccountsPerson")]
        public virtual ICollection<Invoices> InvoicesAccountsPerson { get; set; }
        [InverseProperty("ContactPerson")]
        public virtual ICollection<Invoices> InvoicesContactPerson { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<Invoices> InvoicesLastEditedByNavigation { get; set; }
        [InverseProperty("PackedByPerson")]
        public virtual ICollection<Invoices> InvoicesPackedByPerson { get; set; }
        [InverseProperty("SalespersonPerson")]
        public virtual ICollection<Invoices> InvoicesSalespersonPerson { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
        [InverseProperty("ContactPerson")]
        public virtual ICollection<Orders> OrdersContactPerson { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<Orders> OrdersLastEditedByNavigation { get; set; }
        [InverseProperty("PickedByPerson")]
        public virtual ICollection<Orders> OrdersPickedByPerson { get; set; }
        [InverseProperty("SalespersonPerson")]
        public virtual ICollection<Orders> OrdersSalespersonPerson { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<PackageTypes> PackageTypes { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<PaymentMethods> PaymentMethods { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<PurchaseOrderLines> PurchaseOrderLines { get; set; }
        [InverseProperty("ContactPerson")]
        public virtual ICollection<PurchaseOrders> PurchaseOrdersContactPerson { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<PurchaseOrders> PurchaseOrdersLastEditedByNavigation { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<SpecialDeals> SpecialDeals { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<StateProvinces> StateProvinces { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<StockGroups> StockGroups { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<StockItemHoldings> StockItemHoldings { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<StockItems> StockItems { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<StockItemStockGroups> StockItemStockGroups { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<StockItemTransactions> StockItemTransactions { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<SupplierCategories> SupplierCategories { get; set; }
        [InverseProperty("AlternateContactPerson")]
        public virtual ICollection<Suppliers> SuppliersAlternateContactPerson { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<Suppliers> SuppliersLastEditedByNavigation { get; set; }
        [InverseProperty("PrimaryContactPerson")]
        public virtual ICollection<Suppliers> SuppliersPrimaryContactPerson { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<SupplierTransactions> SupplierTransactions { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<SystemParameters> SystemParameters { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<TransactionTypes> TransactionTypes { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("InverseLastEditedByNavigation")]
        public virtual People LastEditedByNavigation { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<People> InverseLastEditedByNavigation { get; set; }
    }
}
