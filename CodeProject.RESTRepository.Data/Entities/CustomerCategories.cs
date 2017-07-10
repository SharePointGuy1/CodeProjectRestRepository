using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("CustomerCategories", Schema = "Sales")]
    public partial class CustomerCategories
    {
        public CustomerCategories()
        {
            Customers = new HashSet<Customers>();
            SpecialDeals = new HashSet<SpecialDeals>();
        }

        [Column("CustomerCategoryID")]
        public int CustomerCategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerCategoryName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [InverseProperty("CustomerCategory")]
        public virtual ICollection<Customers> Customers { get; set; }
        [InverseProperty("CustomerCategory")]
        public virtual ICollection<SpecialDeals> SpecialDeals { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("CustomerCategories")]
        public virtual People LastEditedByNavigation { get; set; }
    }
}
