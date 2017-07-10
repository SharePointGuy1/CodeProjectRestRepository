using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CodeProject.RESTRepository.Data.Entities;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("Customers", Schema = "Sales")]
    public partial class Customers: IEntity
    {
        public Customers()
        {
            CustomerTransactions = new HashSet<CustomerTransactions>();
            InvoicesBillToCustomer = new HashSet<Invoices>();
            InvoicesCustomer = new HashSet<Invoices>();
            Orders = new HashSet<Orders>();
            SpecialDeals = new HashSet<SpecialDeals>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
        }

        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [Column("BillToCustomerID")]
        public int BillToCustomerId { get; set; }
        [Column("CustomerCategoryID")]
        public int CustomerCategoryId { get; set; }
        [Column("BuyingGroupID")]
        public int? BuyingGroupId { get; set; }
        [Column("PrimaryContactPersonID")]
        public int PrimaryContactPersonId { get; set; }
        [Column("AlternateContactPersonID")]
        public int? AlternateContactPersonId { get; set; }
        [Column("DeliveryMethodID")]
        public int DeliveryMethodId { get; set; }
        [Column("DeliveryCityID")]
        public int DeliveryCityId { get; set; }
        [Column("PostalCityID")]
        public int PostalCityId { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? CreditLimit { get; set; }
        [Column(TypeName = "date")]
        public DateTime AccountOpenedDate { get; set; }
        [Column(TypeName = "decimal")]
        public decimal StandardDiscountPercentage { get; set; }
        public bool IsStatementSent { get; set; }
        public bool IsOnCreditHold { get; set; }
        public int PaymentDays { get; set; }
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(20)]
        public string FaxNumber { get; set; }
        [MaxLength(5)]
        public string DeliveryRun { get; set; }
        [MaxLength(5)]
        public string RunPosition { get; set; }
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

        [InverseProperty("Customer")]
        public virtual ICollection<CustomerTransactions> CustomerTransactions { get; set; }
        [InverseProperty("BillToCustomer")]
        public virtual ICollection<Invoices> InvoicesBillToCustomer { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Invoices> InvoicesCustomer { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Orders> Orders { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<SpecialDeals> SpecialDeals { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<StockItemTransactions> StockItemTransactions { get; set; }
        [ForeignKey("AlternateContactPersonId")]
        [InverseProperty("CustomersAlternateContactPerson")]
        public virtual People AlternateContactPerson { get; set; }
        [ForeignKey("BillToCustomerId")]
        [InverseProperty("InverseBillToCustomer")]
        public virtual Customers BillToCustomer { get; set; }
        [InverseProperty("BillToCustomer")]
        public virtual ICollection<Customers> InverseBillToCustomer { get; set; }
        [ForeignKey("BuyingGroupId")]
        [InverseProperty("Customers")]
        public virtual BuyingGroups BuyingGroup { get; set; }
        [ForeignKey("CustomerCategoryId")]
        [InverseProperty("Customers")]
        public virtual CustomerCategories CustomerCategory { get; set; }
        [ForeignKey("DeliveryCityId")]
        [InverseProperty("CustomersDeliveryCity")]
        public virtual Cities DeliveryCity { get; set; }
        [ForeignKey("DeliveryMethodId")]
        [InverseProperty("Customers")]
        public virtual DeliveryMethods DeliveryMethod { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("CustomersLastEditedByNavigation")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("PostalCityId")]
        [InverseProperty("CustomersPostalCity")]
        public virtual Cities PostalCity { get; set; }
        [ForeignKey("PrimaryContactPersonId")]
        [InverseProperty("CustomersPrimaryContactPerson")]
        public virtual People PrimaryContactPerson { get; set; }
    }
}
