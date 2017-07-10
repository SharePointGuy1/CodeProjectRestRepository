using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("StockGroups", Schema = "Warehouse")]
    public partial class StockGroups
    {
        public StockGroups()
        {
            SpecialDeals = new HashSet<SpecialDeals>();
            StockItemStockGroups = new HashSet<StockItemStockGroups>();
        }

        [Column("StockGroupID")]
        public int StockGroupId { get; set; }
        [Required]
        [MaxLength(50)]
        public string StockGroupName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [InverseProperty("StockGroup")]
        public virtual ICollection<SpecialDeals> SpecialDeals { get; set; }
        [InverseProperty("StockGroup")]
        public virtual ICollection<StockItemStockGroups> StockItemStockGroups { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("StockGroups")]
        public virtual People LastEditedByNavigation { get; set; }
    }
}
