using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("VehicleTemperatures", Schema = "Warehouse")]
    public partial class VehicleTemperatures
    {
        [Column("VehicleTemperatureID")]
        public long VehicleTemperatureId { get; set; }
        [Required]
        [MaxLength(20)]
        public string VehicleRegistration { get; set; }
        public int ChillerSensorNumber { get; set; }
        public DateTime RecordedWhen { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Temperature { get; set; }
        public bool IsCompressed { get; set; }
        [MaxLength(1000)]
        public string FullSensorData { get; set; }
        public byte[] CompressedSensorData { get; set; }
    }
}
