using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("DeliveryMethods", Schema = "Application")]
    public partial class DeliveryMethods : IEntity
    {
        public DeliveryMethods()
        {
            Customers = new HashSet<Customers>();
            Invoices = new HashSet<Invoices>();
            PurchaseOrders = new HashSet<PurchaseOrders>();
            Suppliers = new HashSet<Suppliers>();
        }

        [Column("DeliveryMethodID")]
        public int DeliveryMethodId { get; set; }
        [Required]
        [MaxLength(50)]
        public string DeliveryMethodName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [InverseProperty("DeliveryMethod")]
        public virtual ICollection<Customers> Customers { get; set; }
        [InverseProperty("DeliveryMethod")]
        public virtual ICollection<Invoices> Invoices { get; set; }
        [InverseProperty("DeliveryMethod")]
        public virtual ICollection<PurchaseOrders> PurchaseOrders { get; set; }
        [InverseProperty("DeliveryMethod")]
        public virtual ICollection<Suppliers> Suppliers { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("DeliveryMethods")]
        public virtual People LastEditedByNavigation { get; set; }
    }
}
