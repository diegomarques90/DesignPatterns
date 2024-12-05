namespace DesignPatterns.Application.Models
{
    public class OrderInputModel : ICloneable
    {
        public OrderInputModel()
        {
            
        }

        public OrderInputModel(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }   
        public CustomerInputModel Customer { get; set; }
        public List<OrderItemInputModel> Items { get; set; }
        public DeliveryAddressInputModel DeliveryAddress { get; set; }
        public PaymentAddressInputModel PaymentAddress { get; set; }
        public PaymentInfoInputModel PaymentInfo { get; set; }
        public bool? IsInternational { get; set; }

        public object Clone()
        {
            return new OrderInputModel
            {
                Id = Guid.NewGuid(),
                Customer = Customer,
                Items = Items,
                DeliveryAddress = DeliveryAddress,
                PaymentAddress = PaymentAddress,
                PaymentInfo = PaymentInfo,
                IsInternational = IsInternational
            };
        }
    }
}
