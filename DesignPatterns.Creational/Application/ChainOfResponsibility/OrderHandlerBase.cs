using DesignPatterns.Application.Models;

namespace DesignPatterns.Application.ChainOfResponsibility
{
    public abstract class OrderHandlerBase : IOrderHandler
    {
        private IOrderHandler? _nextHandler;

        public virtual bool Handle(OrderInputModel model)
        {
            if (_nextHandler is null)
                return true;

            var result = _nextHandler.Handle(model);

            return result;
        }

        public IOrderHandler SetNext(IOrderHandler nextHandler)
        {
            _nextHandler = nextHandler;

            return nextHandler;
        }
    }
}
