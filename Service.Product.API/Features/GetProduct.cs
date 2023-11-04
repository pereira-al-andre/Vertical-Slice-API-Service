using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Service.API.Entities;
using Service.API.Persistence.Database;
using Service.API.Response;

namespace Service.API.Features
{
    public static class GetProduct
    {
        public class Query : IRequest<ProductResponse>
        {
            public Guid Id { get; set; }
        }

        internal sealed class Handler : IRequestHandler<Query, ProductResponse>
        {
            private readonly SqlDBContext _context;

            public Handler(SqlDBContext sqlDBContext)
            {
                _context = sqlDBContext;
            }

            public async Task<ProductResponse> Handle(Query query, CancellationToken cancellationToken)
            {
                var productResponse = await _context.Product
                    .Where(p => p.Id == query.Id)
                    .Select(p => new ProductResponse
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price
                    }).FirstOrDefaultAsync();


                if (productResponse is null) throw new Exception("Product not found.");

                return productResponse;
            }
        }
    }

    public class GetProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/products/{id}", async (Guid id, ISender sender) =>
            {
                var query = new GetProduct.Query { Id = id };

                var result = await sender.Send(query);

                if (result is null) throw new Exception("Product not found.");

                return result;
            });
        }
    }
}
