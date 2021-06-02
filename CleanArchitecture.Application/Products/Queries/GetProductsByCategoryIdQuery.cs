using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Products.Queries
{
    public class GetProductsByCategoryIdQuery : IRequest<IEnumerable<Product>>
    {
        public int CategoryId { get; set; }

        public GetProductsByCategoryIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
