using Carter;
using FluentValidation;
using MediatR;
using Service.API.Entities;
using Service.API.Interfaces;
using Service.API.Persistence.Database;

namespace Service.API.Features
{
    public class CreateProduct
    {
        public class Command : IRequest<Guid>
        {
            public Command(string name, decimal price)
            {
                Name = name;
                Price = price;
            }

            public string Name { get; private set; } = string.Empty;
            public decimal Price { get; private set; } = decimal.Zero;
        }

        internal sealed class Handler : IRequestHandler<Command, Guid>
        {
            private readonly SqlDBContext _context;
            private IValidator<Command> _validator;
            public Handler(SqlDBContext context, IValidator<Command> validator)
            {
                _context = context;
                _validator = validator;
            }

            public async Task<Guid> Handle(Command command, CancellationToken cancellationToken)
            {
                var validationResult = _validator.Validate(command);

                if (!validationResult.IsValid) throw new ArgumentException("Invalid command.");

                var product = new GetProdutResponse(command.Name, command.Price);

                _context.Add(product);

                await _context.SaveChangesAsync(cancellationToken);

                return product.Id;
            }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Name).NotEmpty();
                RuleFor(c => c.Price).NotEmpty();
            }
        }
    }

    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/product", async (CreateProductRequest request, ISender sender) =>
            {
                var command = new CreateProduct.Command(request.Name, request.Price);

                var productId = await sender.Send(command);

                return productId;
            });
        }
    }
}
