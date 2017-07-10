using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("PackageTypes", Schema = "Warehouse")]
    public partial class PackageTypes
    {
        public PackageTypes()
        {
            InvoiceLines = new HashSet<InvoiceLines>();
            OrderLines = new HashSet<OrderLines>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLines>();
            StockItemsOuterPackage = new HashSet<StockItems>();
            StockItemsUnitPackage = new HashSet<StockItems>();
        }

        [Column("PackageTypeID")]
        public int PackageTypeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string PackageTypeName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [InverseProperty("PackageType")]
        public virtual ICollection<InvoiceLines> InvoiceLines { get; set; }
        [InverseProperty("PackageType")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
        [InverseProperty("PackageType")]
        public virtual ICollection<PurchaseOrderLines> PurchaseOrderLines { get; set; }
        [InverseProperty("OuterPackage")]
        public virtual ICollection<StockItems> StockItemsOuterPackage { get; set; }
        [InverseProperty("UnitPackage")]
        public virtual ICollection<StockItems> StockItemsUnitPackage { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("PackageTypes")]
        public virtual People LastEditedByNavigation { get; set; }
    }
}
