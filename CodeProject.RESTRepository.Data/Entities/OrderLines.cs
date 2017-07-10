using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("OrderLines", Schema = "Sales")]
    public partial class OrderLines
    {
        [Column("OrderLineID")]
        public int OrderLineId { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Column("PackageTypeID")]
        public int PackageTypeId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? UnitPrice { get; set; }
        [Column(TypeName = "decimal")]
        public decimal TaxRate { get; set; }
        public int PickedQuantity { get; set; }
        public DateTime? PickingCompletedWhen { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey("LastEditedBy")]
        [InverseProperty("OrderLines")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("OrderId")]
        [InverseProperty("OrderLines")]
        public virtual Orders Order { get; set; }
        [ForeignKey("PackageTypeId")]
        [InverseProperty("OrderLines")]
        public virtual PackageTypes PackageType { get; set; }
        [ForeignKey("StockItemId")]
        [InverseProperty("OrderLines")]
        public virtual StockItems StockItem { get; set; }
    }
}
