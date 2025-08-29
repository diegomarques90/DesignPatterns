using DesignPatterns.Application.Models;

namespace DesignPatterns.Application.Mementos
{
    // Originator representa o momento atual do objeto
    public interface IShoppingCartOriginator
    {
        Guid CustomerId { get; }
        List<KeyValuePair<Guid, int>> Items { get; }
        void Restore(IShoppingCartMemento memento);
        void UpdateCart(List<OrderItemInputModel> items);
        IShoppingCartMemento SaveSnapShot();
    }
    public class ShoppingCartOriginator : IShoppingCartOriginator
    {
        public ShoppingCartOriginator(Guid customerId, List<OrderItemInputModel> items)
        {
            CustomerId = customerId;
            Items = [.. items.Select(i => new KeyValuePair<Guid, int>(i.ProductId, i.Quantity))];
        }

        public Guid CustomerId { get; private set; }

        public List<KeyValuePair<Guid, int>> Items { get; private set; }

        public void Restore(IShoppingCartMemento memento)
        {
            var concreteMemento = memento as ShoppingCartMemento;
            Items = concreteMemento.Items;
        }

        public IShoppingCartMemento SaveSnapShot() => new ShoppingCartMemento(CustomerId, Items);

        public void UpdateCart(List<OrderItemInputModel> items)
        {
            Items = [.. items.Select(i => new KeyValuePair<Guid, int>(i.ProductId, i.Quantity))];
        }
    }
}
