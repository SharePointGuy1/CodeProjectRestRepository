using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("StockItemTransactions", Schema = "Warehouse")]
    public partial class StockItemTransactions
    {
        [Column("StockItemTransactionID")]
        public int StockItemTransactionId { get; set; }
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        [Column("TransactionTypeID")]
        public int TransactionTypeId { get; set; }
        [Column("CustomerID")]
        public int? CustomerId { get; set; }
        [Column("InvoiceID")]
        public int? InvoiceId { get; set; }
        [Column("SupplierID")]
        public int? SupplierId { get; set; }
        [Column("PurchaseOrderID")]
        public int? PurchaseOrderId { get; set; }
        public DateTime TransactionOccurredWhen { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Quantity { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("StockItemTransactions")]
        public virtual Customers Customer { get; set; }
        [ForeignKey("InvoiceId")]
        [InverseProperty("StockItemTransactions")]
        public virtual Invoices Invoice { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("StockItemTransactions")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("PurchaseOrderId")]
        [InverseProperty("StockItemTransactions")]
        public virtual PurchaseOrders PurchaseOrder { get; set; }
        [ForeignKey("StockItemId")]
        [InverseProperty("StockItemTransactions")]
        public virtual StockItems StockItem { get; set; }
        [ForeignKey("SupplierId")]
        [InverseProperty("StockItemTransactions")]
        public virtual Suppliers Supplier { get; set; }
        [ForeignKey("TransactionTypeId")]
        [InverseProperty("StockItemTransactions")]
        public virtual TransactionTypes TransactionType { get; set; }
    }
}
