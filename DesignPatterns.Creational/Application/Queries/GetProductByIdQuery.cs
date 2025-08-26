using DesignPatterns.Application.Mediator;

namespace DesignPatterns.Application.Queries
{
    public class GetProductByIdQuery : IQuery
    {
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
