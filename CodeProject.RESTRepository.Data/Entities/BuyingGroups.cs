using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("BuyingGroups", Schema = "Sales")]
    public partial class BuyingGroups
    {
        public BuyingGroups()
        {
            Customers = new HashSet<Customers>();
            SpecialDeals = new HashSet<SpecialDeals>();
        }

        [Column("BuyingGroupID")]
        public int BuyingGroupId { get; set; }
        [Required]
        [MaxLength(50)]
        public string BuyingGroupName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [InverseProperty("BuyingGroup")]
        public virtual ICollection<Customers> Customers { get; set; }
        [InverseProperty("BuyingGroup")]
        public virtual ICollection<SpecialDeals> SpecialDeals { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("BuyingGroups")]
        public virtual People LastEditedByNavigation { get; set; }
    }
}
