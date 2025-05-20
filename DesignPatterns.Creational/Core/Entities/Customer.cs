using DesignPatterns.Core.Enums;

namespace DesignPatterns.Core.Entities
{
    public class Customer
    {
        public Customer(Guid id, string fullName, DateTime birthDate)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
        }

        public Guid Id { get; set; }
        public string FullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public CustomerStatus Status { get; private set; }

        public bool IsAllowedToBuy()
        {
            return Status != CustomerStatus.Blocked;
        }
    }
}
