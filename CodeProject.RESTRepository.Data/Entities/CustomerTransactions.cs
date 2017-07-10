using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("CustomerTransactions", Schema = "Sales")]
    public partial class CustomerTransactions
    {
        [Column("CustomerTransactionID")]
        public int CustomerTransactionId { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("TransactionTypeID")]
        public int TransactionTypeId { get; set; }
        [Column("InvoiceID")]
        public int? InvoiceId { get; set; }
        [Column("PaymentMethodID")]
        public int? PaymentMethodId { get; set; }
        [Column(TypeName = "date")]
        public DateTime TransactionDate { get; set; }
        [Column(TypeName = "decimal")]
        public decimal AmountExcludingTax { get; set; }
        [Column(TypeName = "decimal")]
        public decimal TaxAmount { get; set; }
        [Column(TypeName = "decimal")]
        public decimal TransactionAmount { get; set; }
        [Column(TypeName = "decimal")]
        public decimal OutstandingBalance { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FinalizationDate { get; set; }
        public bool? IsFinalized { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("CustomerTransactions")]
        public virtual Customers Customer { get; set; }
        [ForeignKey("InvoiceId")]
        [InverseProperty("CustomerTransactions")]
        public virtual Invoices Invoice { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("CustomerTransactions")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("PaymentMethodId")]
        [InverseProperty("CustomerTransactions")]
        public virtual PaymentMethods PaymentMethod { get; set; }
        [ForeignKey("TransactionTypeId")]
        [InverseProperty("CustomerTransactions")]
        public virtual TransactionTypes TransactionType { get; set; }
    }
}
