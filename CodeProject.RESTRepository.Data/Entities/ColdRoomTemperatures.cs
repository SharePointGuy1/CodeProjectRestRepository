using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("ColdRoomTemperatures", Schema = "Warehouse")]
    public partial class ColdRoomTemperatures
    {
        [Column("ColdRoomTemperatureID")]
        public long ColdRoomTemperatureId { get; set; }
        public int ColdRoomSensorNumber { get; set; }
        public DateTime RecordedWhen { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Temperature { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
