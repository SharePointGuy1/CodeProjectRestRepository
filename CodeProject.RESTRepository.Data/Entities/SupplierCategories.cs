using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("SupplierCategories", Schema = "Purchasing")]
    public partial class SupplierCategories
    {
        public SupplierCategories()
        {
            Suppliers = new HashSet<Suppliers>();
        }

        [Column("SupplierCategoryID")]
        public int SupplierCategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string SupplierCategoryName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [InverseProperty("SupplierCategory")]
        public virtual ICollection<Suppliers> Suppliers { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("SupplierCategories")]
        public virtual People LastEditedByNavigation { get; set; }
    }
}
