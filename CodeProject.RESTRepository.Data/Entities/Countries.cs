using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("Countries", Schema = "Application")]
    public partial class Countries
    {
        public Countries()
        {
            StateProvinces = new HashSet<StateProvinces>();
        }

        [Column("CountryID")]
        public int CountryId { get; set; }
        [Required]
        [MaxLength(60)]
        public string CountryName { get; set; }
        [Required]
        [MaxLength(60)]
        public string FormalName { get; set; }
        [MaxLength(3)]
        public string IsoAlpha3Code { get; set; }
        public int? IsoNumericCode { get; set; }
        [MaxLength(20)]
        public string CountryType { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        [Required]
        [MaxLength(30)]
        public string Continent { get; set; }
        [Required]
        [MaxLength(30)]
        public string Region { get; set; }
        [Required]
        [MaxLength(30)]
        public string Subregion { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [InverseProperty("Country")]
        public virtual ICollection<StateProvinces> StateProvinces { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("Countries")]
        public virtual People LastEditedByNavigation { get; set; }
    }
}
