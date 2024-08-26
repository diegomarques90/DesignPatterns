using DesignPatterns.Creational.Core.Enums;

namespace DesignPatterns.Creational.Application.Models
{
    public class PaymentInfoInputModel
    {
        public PaymentMethod PaymentMethod { get; set; }
        public string CardNumber { get; set; }
        public string FullName { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
    }
}
