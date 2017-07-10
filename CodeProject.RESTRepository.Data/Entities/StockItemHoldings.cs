using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("StockItemHoldings", Schema = "Warehouse")]
    public partial class StockItemHoldings
    {
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        public int QuantityOnHand { get; set; }
        [Required]
        [MaxLength(20)]
        public string BinLocation { get; set; }
        public int LastStocktakeQuantity { get; set; }
        [Column(TypeName = "decimal")]
        public decimal LastCostPrice { get; set; }
        public int ReorderLevel { get; set; }
        public int TargetStockLevel { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey("LastEditedBy")]
        [InverseProperty("StockItemHoldings")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("StockItemId")]
        [InverseProperty("StockItemHoldings")]
        public virtual StockItems StockItem { get; set; }
    }
}
