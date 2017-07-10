using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("Colors", Schema = "Warehouse")]
    public partial class Colors
    {
        public Colors()
        {
            StockItems = new HashSet<StockItems>();
        }

        [Column("ColorID")]
        public int ColorId { get; set; }
        [Required]
        [MaxLength(20)]
        public string ColorName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [InverseProperty("Color")]
        public virtual ICollection<StockItems> StockItems { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("Colors")]
        public virtual People LastEditedByNavigation { get; set; }
    }
}
