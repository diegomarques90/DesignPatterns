using DesignPatterns.Application.Models;

namespace DesignPatterns.Application.ChainOfResponsibility
{
    public interface IOrderHandler
    {
        bool Handle(OrderInputModel model);
        IOrderHandler SetNext(IOrderHandler nextHandler);
    }
}
