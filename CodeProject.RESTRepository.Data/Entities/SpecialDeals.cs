using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("SpecialDeals", Schema = "Sales")]
    public partial class SpecialDeals
    {
        [Column("SpecialDealID")]
        public int SpecialDealId { get; set; }
        [Column("StockItemID")]
        public int? StockItemId { get; set; }
        [Column("CustomerID")]
        public int? CustomerId { get; set; }
        [Column("BuyingGroupID")]
        public int? BuyingGroupId { get; set; }
        [Column("CustomerCategoryID")]
        public int? CustomerCategoryId { get; set; }
        [Column("StockGroupID")]
        public int? StockGroupId { get; set; }
        [Required]
        [MaxLength(30)]
        public string DealDescription { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? DiscountAmount { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? DiscountPercentage { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? UnitPrice { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey("BuyingGroupId")]
        [InverseProperty("SpecialDeals")]
        public virtual BuyingGroups BuyingGroup { get; set; }
        [ForeignKey("CustomerCategoryId")]
        [InverseProperty("SpecialDeals")]
        public virtual CustomerCategories CustomerCategory { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("SpecialDeals")]
        public virtual Customers Customer { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("SpecialDeals")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("StockGroupId")]
        [InverseProperty("SpecialDeals")]
        public virtual StockGroups StockGroup { get; set; }
        [ForeignKey("StockItemId")]
        [InverseProperty("SpecialDeals")]
        public virtual StockItems StockItem { get; set; }
    }
}
