using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("SupplierTransactions", Schema = "Purchasing")]
    public partial class SupplierTransactions
    {
        [Column("SupplierTransactionID")]
        public int SupplierTransactionId { get; set; }
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Column("TransactionTypeID")]
        public int TransactionTypeId { get; set; }
        [Column("PurchaseOrderID")]
        public int? PurchaseOrderId { get; set; }
        [Column("PaymentMethodID")]
        public int? PaymentMethodId { get; set; }
        [MaxLength(20)]
        public string SupplierInvoiceNumber { get; set; }
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

        [ForeignKey("LastEditedBy")]
        [InverseProperty("SupplierTransactions")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("PaymentMethodId")]
        [InverseProperty("SupplierTransactions")]
        public virtual PaymentMethods PaymentMethod { get; set; }
        [ForeignKey("PurchaseOrderId")]
        [InverseProperty("SupplierTransactions")]
        public virtual PurchaseOrders PurchaseOrder { get; set; }
        [ForeignKey("SupplierId")]
        [InverseProperty("SupplierTransactions")]
        public virtual Suppliers Supplier { get; set; }
        [ForeignKey("TransactionTypeId")]
        [InverseProperty("SupplierTransactions")]
        public virtual TransactionTypes TransactionType { get; set; }
    }
}
