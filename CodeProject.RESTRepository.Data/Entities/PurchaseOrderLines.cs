using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("PurchaseOrderLines", Schema = "Purchasing")]
    public partial class PurchaseOrderLines
    {
        [Column("PurchaseOrderLineID")]
        public int PurchaseOrderLineId { get; set; }
        [Column("PurchaseOrderID")]
        public int PurchaseOrderId { get; set; }
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        public int OrderedOuters { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public int ReceivedOuters { get; set; }
        [Column("PackageTypeID")]
        public int PackageTypeId { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? ExpectedUnitPricePerOuter { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LastReceiptDate { get; set; }
        public bool IsOrderLineFinalized { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey("LastEditedBy")]
        [InverseProperty("PurchaseOrderLines")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("PackageTypeId")]
        [InverseProperty("PurchaseOrderLines")]
        public virtual PackageTypes PackageType { get; set; }
        [ForeignKey("PurchaseOrderId")]
        [InverseProperty("PurchaseOrderLines")]
        public virtual PurchaseOrders PurchaseOrder { get; set; }
        [ForeignKey("StockItemId")]
        [InverseProperty("PurchaseOrderLines")]
        public virtual StockItems StockItem { get; set; }
    }
}
