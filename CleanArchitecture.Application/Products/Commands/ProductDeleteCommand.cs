using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Products.Commands
{
    public class ProductDeleteCommand : IRequest<Product>
    {
        public int Id { get; set; }

        public ProductDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
