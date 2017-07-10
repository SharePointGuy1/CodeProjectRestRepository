using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("InvoiceLines", Schema = "Sales")]
    public partial class InvoiceLines
    {
        [Column("InvoiceLineID")]
        public int InvoiceLineId { get; set; }
        [Column("InvoiceID")]
        public int InvoiceId { get; set; }
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
        [Column(TypeName = "decimal")]
        public decimal TaxAmount { get; set; }
        [Column(TypeName = "decimal")]
        public decimal LineProfit { get; set; }
        [Column(TypeName = "decimal")]
        public decimal ExtendedPrice { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey("InvoiceId")]
        [InverseProperty("InvoiceLines")]
        public virtual Invoices Invoice { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("InvoiceLines")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("PackageTypeId")]
        [InverseProperty("InvoiceLines")]
        public virtual PackageTypes PackageType { get; set; }
        [ForeignKey("StockItemId")]
        [InverseProperty("InvoiceLines")]
        public virtual StockItems StockItem { get; set; }
    }
}
