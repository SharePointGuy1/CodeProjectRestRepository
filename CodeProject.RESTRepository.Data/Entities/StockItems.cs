using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("StockItems", Schema = "Warehouse")]
    public partial class StockItems: IEntity
    {
        public StockItems()
        {
            InvoiceLines = new HashSet<InvoiceLines>();
            OrderLines = new HashSet<OrderLines>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLines>();
            SpecialDeals = new HashSet<SpecialDeals>();
            StockItemStockGroups = new HashSet<StockItemStockGroups>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
        }

        [Column("StockItemID")]
        public int StockItemId { get; set; }
        [Required]
        [MaxLength(100)]
        public string StockItemName { get; set; }
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Column("ColorID")]
        public int? ColorId { get; set; }
        [Column("UnitPackageID")]
        public int UnitPackageId { get; set; }
        [Column("OuterPackageID")]
        public int OuterPackageId { get; set; }
        [MaxLength(50)]
        public string Brand { get; set; }
        [MaxLength(20)]
        public string Size { get; set; }
        public int LeadTimeDays { get; set; }
        public int QuantityPerOuter { get; set; }
        public bool IsChillerStock { get; set; }
        [MaxLength(50)]
        public string Barcode { get; set; }
        [Column(TypeName = "decimal")]
        public decimal TaxRate { get; set; }
        [Column(TypeName = "decimal")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? RecommendedRetailPrice { get; set; }
        [Column(TypeName = "decimal")]
        public decimal TypicalWeightPerUnit { get; set; }
        public string MarketingComments { get; set; }
        public string InternalComments { get; set; }
        public byte[] Photo { get; set; }
        public string CustomFields { get; set; }
        public string Tags { get; set; }
        [Required]
        public string SearchDetails { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [InverseProperty("StockItem")]
        public virtual ICollection<InvoiceLines> InvoiceLines { get; set; }
        [InverseProperty("StockItem")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
        [InverseProperty("StockItem")]
        public virtual ICollection<PurchaseOrderLines> PurchaseOrderLines { get; set; }
        [InverseProperty("StockItem")]
        public virtual ICollection<SpecialDeals> SpecialDeals { get; set; }
        [InverseProperty("StockItem")]
        public virtual StockItemHoldings StockItemHoldings { get; set; }
        [InverseProperty("StockItem")]
        public virtual ICollection<StockItemStockGroups> StockItemStockGroups { get; set; }
        [InverseProperty("StockItem")]
        public virtual ICollection<StockItemTransactions> StockItemTransactions { get; set; }
        [ForeignKey("ColorId")]
        [InverseProperty("StockItems")]
        public virtual Colors Color { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("StockItems")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("OuterPackageId")]
        [InverseProperty("StockItemsOuterPackage")]
        public virtual PackageTypes OuterPackage { get; set; }
        [ForeignKey("SupplierId")]
        [InverseProperty("StockItems")]
        public virtual Suppliers Supplier { get; set; }
        [ForeignKey("UnitPackageId")]
        [InverseProperty("StockItemsUnitPackage")]
        public virtual PackageTypes UnitPackage { get; set; }
    }
}
