using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("Cities", Schema = "Application")]
    public partial class Cities
    {
        public Cities()
        {
            CustomersDeliveryCity = new HashSet<Customers>();
            CustomersPostalCity = new HashSet<Customers>();
            SuppliersDeliveryCity = new HashSet<Suppliers>();
            SuppliersPostalCity = new HashSet<Suppliers>();
            SystemParametersDeliveryCity = new HashSet<SystemParameters>();
            SystemParametersPostalCity = new HashSet<SystemParameters>();
        }

        [Column("CityID")]
        public int CityId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CityName { get; set; }
        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [InverseProperty("DeliveryCity")]
        public virtual ICollection<Customers> CustomersDeliveryCity { get; set; }
        [InverseProperty("PostalCity")]
        public virtual ICollection<Customers> CustomersPostalCity { get; set; }
        [InverseProperty("DeliveryCity")]
        public virtual ICollection<Suppliers> SuppliersDeliveryCity { get; set; }
        [InverseProperty("PostalCity")]
        public virtual ICollection<Suppliers> SuppliersPostalCity { get; set; }
        [InverseProperty("DeliveryCity")]
        public virtual ICollection<SystemParameters> SystemParametersDeliveryCity { get; set; }
        [InverseProperty("PostalCity")]
        public virtual ICollection<SystemParameters> SystemParametersPostalCity { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("Cities")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("StateProvinceId")]
        [InverseProperty("Cities")]
        public virtual StateProvinces StateProvince { get; set; }
    }
}
