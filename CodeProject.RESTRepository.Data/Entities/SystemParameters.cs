using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("SystemParameters", Schema = "Application")]
    public partial class SystemParameters
    {
        [Column("SystemParameterID")]
        public int SystemParameterId { get; set; }
        [Required]
        [MaxLength(60)]
        public string DeliveryAddressLine1 { get; set; }
        [MaxLength(60)]
        public string DeliveryAddressLine2 { get; set; }
        [Column("DeliveryCityID")]
        public int DeliveryCityId { get; set; }
        [Required]
        [MaxLength(10)]
        public string DeliveryPostalCode { get; set; }
        [Required]
        [MaxLength(60)]
        public string PostalAddressLine1 { get; set; }
        [MaxLength(60)]
        public string PostalAddressLine2 { get; set; }
        [Column("PostalCityID")]
        public int PostalCityId { get; set; }
        [Required]
        [MaxLength(10)]
        public string PostalPostalCode { get; set; }
        [Required]
        public string ApplicationSettings { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey("DeliveryCityId")]
        [InverseProperty("SystemParametersDeliveryCity")]
        public virtual Cities DeliveryCity { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("SystemParameters")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("PostalCityId")]
        [InverseProperty("SystemParametersPostalCity")]
        public virtual Cities PostalCity { get; set; }
    }
}
