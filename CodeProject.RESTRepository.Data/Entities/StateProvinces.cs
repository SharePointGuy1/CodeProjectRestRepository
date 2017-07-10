using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("StateProvinces", Schema = "Application")]
    public partial class StateProvinces
    {
        public StateProvinces()
        {
            Cities = new HashSet<Cities>();
        }

        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        [Required]
        [MaxLength(5)]
        public string StateProvinceCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string StateProvinceName { get; set; }
        [Column("CountryID")]
        public int CountryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string SalesTerritory { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [InverseProperty("StateProvince")]
        public virtual ICollection<Cities> Cities { get; set; }
        [ForeignKey("CountryId")]
        [InverseProperty("StateProvinces")]
        public virtual Countries Country { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("StateProvinces")]
        public virtual People LastEditedByNavigation { get; set; }
    }
}
