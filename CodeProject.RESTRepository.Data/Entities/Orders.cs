using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeProject.RESTRepository.Data.Entities
{
    [Table("Orders", Schema = "Sales")]
    public partial class Orders
    {
        public Orders()
        {
            Invoices = new HashSet<Invoices>();
            OrderLines = new HashSet<OrderLines>();
        }

        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("SalespersonPersonID")]
        public int SalespersonPersonId { get; set; }
        [Column("PickedByPersonID")]
        public int? PickedByPersonId { get; set; }
        [Column("ContactPersonID")]
        public int ContactPersonId { get; set; }
        [Column("BackorderOrderID")]
        public int? BackorderOrderId { get; set; }
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime ExpectedDeliveryDate { get; set; }
        [MaxLength(20)]
        public string CustomerPurchaseOrderNumber { get; set; }
        public bool IsUndersupplyBackordered { get; set; }
        public string Comments { get; set; }
        public string DeliveryInstructions { get; set; }
        public string InternalComments { get; set; }
        public DateTime? PickingCompletedWhen { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [InverseProperty("Order")]
        public virtual ICollection<Invoices> Invoices { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
        [ForeignKey("BackorderOrderId")]
        [InverseProperty("InverseBackorderOrder")]
        public virtual Orders BackorderOrder { get; set; }
        [InverseProperty("BackorderOrder")]
        public virtual ICollection<Orders> InverseBackorderOrder { get; set; }
        [ForeignKey("ContactPersonId")]
        [InverseProperty("OrdersContactPerson")]
        public virtual People ContactPerson { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("Orders")]
        public virtual Customers Customer { get; set; }
        [ForeignKey("LastEditedBy")]
        [InverseProperty("OrdersLastEditedByNavigation")]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey("PickedByPersonId")]
        [InverseProperty("OrdersPickedByPerson")]
        public virtual People PickedByPerson { get; set; }
        [ForeignKey("SalespersonPersonId")]
        [InverseProperty("OrdersSalespersonPerson")]
        public virtual People SalespersonPerson { get; set; }
    }
}
