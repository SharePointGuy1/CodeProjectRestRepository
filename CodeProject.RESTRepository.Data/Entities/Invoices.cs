using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("Invoices", Schema = "Sales")]
    public partial class Invoices
    {
        public Invoices()
        {
            CustomerTransactions = new HashSet<CustomerTransactions>();
            InvoiceLines = new HashSet<InvoiceLines>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
        }

        [Column("InvoiceID")]
        public int InvoiceId { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("BillToCustomerID")]
        public int BillToCustomerId { get; set; }
        [Column("OrderID")]
        public int? OrderId { get; set; }
        [Column("DeliveryMethodID")]
        public int DeliveryMethodId { get; set; }
        [Column("ContactPersonID")]
        public int ContactPersonId { get; set; }
        [Column("AccountsPersonID")]
        public int AccountsPersonId { get; set; }
        [Column("SalespersonPersonID")]
        public int SalespersonPersonId { get; set; }
        [Column("PackedByPersonID")]
        public int PackedByPersonId { get; set; }
        [Column(TypeName = "date")]
        public DateTime InvoiceDate { get; set; }
        [MaxLength(20)]
        public string CustomerPurchaseOrderNumber { get; set; }
        public bool IsCreditNote { get; set; }
        public string CreditNoteReason { get; set; }
        public string Comments { get; set; }
        public string DeliveryInstructions { get; set; }
        public string InternalComments { get; set; }
        public int TotalDryItems { get; set; }
        public int TotalChillerItems { get; set; }
        [MaxLength(5)]
        public string DeliveryRun { get; set; }
        [MaxLength(5)]
        public string RunPosition { get; set; }
        public string ReturnedDeliveryData { get; set; }
        public DateTime? ConfirmedDeliveryTime { get; set; }
        public string ConfirmedReceivedBy { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [InverseProperty("Invoice")]
        public virtual ICollection<CustomerTransactions> CustomerTransactions { get; set; }
        [InverseProperty("Invoice")]
        public virtual ICollection<InvoiceLines> InvoiceLines { get; set; }
        [InverseProperty("Invoice")]
        public virtual ICollection<StockItemTransactions> StockItemTransactions { get; set; }
        [ForeignKey("AccountsPersonId")]
        [InverseProperty("InvoicesAccountsPerson")]
        public virtual People AccountsPerson { get; set; }
        [ForeignKey("BillToCustomerId")]
        [InverseProperty("InvoicesBillToCustomer")]
        public virtual Customers BillToCustomer { get; set; }
        [ForeignKey("ContactPersonId")]
        [InverseProperty("InvoicesContactPerson")]
        public virtual People ContactPerson { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("InvoicesCustomer")]
        public virtual Customers Customer { get; set; }
        [ForeignKey("DeliveryMethodId")]
        [InverseProperty("Invoices")]
        public virtual DeliveryMethods DeliveryMethod { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("InvoicesLastEditedByNavigation")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("OrderId")]
        [InverseProperty("Invoices")]
        public virtual Orders Order { get; set; }
        [ForeignKey("PackedByPersonId")]
        [InverseProperty("InvoicesPackedByPerson")]
        public virtual People PackedByPerson { get; set; }
        [ForeignKey("SalespersonPersonId")]
        [InverseProperty("InvoicesSalespersonPerson")]
        public virtual People SalespersonPerson { get; set; }
    }
}
