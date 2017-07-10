using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("StockItemStockGroups", Schema = "Warehouse")]
    public partial class StockItemStockGroups
    {
        [Column("StockItemStockGroupID")]
        public int StockItemStockGroupId { get; set; }
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        [Column("StockGroupID")]
        public int StockGroupId { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey("LastEditedBy")]
        [InverseProperty("StockItemStockGroups")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("StockGroupId")]
        [InverseProperty("StockItemStockGroups")]
        public virtual StockGroups StockGroup { get; set; }
        [ForeignKey("StockItemId")]
        [InverseProperty("StockItemStockGroups")]
        public virtual StockItems StockItem { get; set; }
    }
}
