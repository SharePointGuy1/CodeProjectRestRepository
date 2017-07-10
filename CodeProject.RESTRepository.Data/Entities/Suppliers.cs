using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("Suppliers", Schema = "Purchasing")]
    public partial class Suppliers
    {
        public Suppliers()
        {
            PurchaseOrders = new HashSet<PurchaseOrders>();
            StockItems = new HashSet<StockItems>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
            SupplierTransactions = new HashSet<SupplierTransactions>();
        }

        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Required]
        [MaxLength(100)]
        public string SupplierName { get; set; }
        [Column("SupplierCategoryID")]
        public int SupplierCategoryId { get; set; }
        [Column("PrimaryContactPersonID")]
        public int PrimaryContactPersonId { get; set; }
        [Column("AlternateContactPersonID")]
        public int AlternateContactPersonId { get; set; }
        [Column("DeliveryMethodID")]
        public int? DeliveryMethodId { get; set; }
        [Column("DeliveryCityID")]
        public int DeliveryCityId { get; set; }
        [Column("PostalCityID")]
        public int PostalCityId { get; set; }
        [MaxLength(20)]
        public string SupplierReference { get; set; }
        [MaxLength(50)]
        public string BankAccountName { get; set; }
        [MaxLength(50)]
        public string BankAccountBranch { get; set; }
        [MaxLength(20)]
        public string BankAccountCode { get; set; }
        [MaxLength(20)]
        public string BankAccountNumber { get; set; }
        [MaxLength(20)]
        public string BankInternationalCode { get; set; }
        public int PaymentDays { get; set; }
        public string InternalComments { get; set; }
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(20)]
        public string FaxNumber { get; set; }
        [Required]
        [Column("WebsiteURL")]
        [MaxLength(256)]
        public string WebsiteUrl { get; set; }
        [Required]
        [MaxLength(60)]
        public string DeliveryAddressLine1 { get; set; }
        [MaxLength(60)]
        public string DeliveryAddressLine2 { get; set; }
        [Required]
        [MaxLength(10)]
        public string DeliveryPostalCode { get; set; }
        [Required]
        [MaxLength(60)]
        public string PostalAddressLine1 { get; set; }
        [MaxLength(60)]
        public string PostalAddressLine2 { get; set; }
        [Required]
        [MaxLength(10)]
        public string PostalPostalCode { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [InverseProperty("Supplier")]
        public virtual ICollection<PurchaseOrders> PurchaseOrders { get; set; }
        [InverseProperty("Supplier")]
        public virtual ICollection<StockItems> StockItems { get; set; }
        [InverseProperty("Supplier")]
        public virtual ICollection<StockItemTransactions> StockItemTransactions { get; set; }
        [InverseProperty("Supplier")]
        public virtual ICollection<SupplierTransactions> SupplierTransactions { get; set; }
        [ForeignKey("AlternateContactPersonId")]
        [InverseProperty("SuppliersAlternateContactPerson")]
        public virtual People AlternateContactPerson { get; set; }
        [ForeignKey("DeliveryCityId")]
        [InverseProperty("SuppliersDeliveryCity")]
        public virtual Cities DeliveryCity { get; set; }
        [ForeignKey("DeliveryMethodId")]
        [InverseProperty("Suppliers")]
        public virtual DeliveryMethods DeliveryMethod { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("SuppliersLastEditedByNavigation")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("PostalCityId")]
        [InverseProperty("SuppliersPostalCity")]
        public virtual Cities PostalCity { get; set; }
        [ForeignKey("PrimaryContactPersonId")]
        [InverseProperty("SuppliersPrimaryContactPerson")]
        public virtual People PrimaryContactPerson { get; set; }
        [ForeignKey("SupplierCategoryId")]
        [InverseProperty("Suppliers")]
        public virtual SupplierCategories SupplierCategory { get; set; }
    }
}
