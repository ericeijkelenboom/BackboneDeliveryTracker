namespace BackboneDeliveryTracker.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public string Description { get; set; }
        public bool IsDelivered { get; set; }
    }
}