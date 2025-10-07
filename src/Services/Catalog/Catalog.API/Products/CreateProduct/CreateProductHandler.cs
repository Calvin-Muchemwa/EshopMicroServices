using BuildingBlocks.CQRS;
using Catalog.API.Models;
namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price) :ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductCommandHandler:ICommandHandler<CreateProductCommand,CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand createProductCommand,CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var product = new Product()
        {
            Id = Guid.NewGuid(),
            Name = createProductCommand.Name,
            Category = createProductCommand.Category,
            Description = createProductCommand.Description,
            ImageFile = createProductCommand.ImageFile,
            Price = createProductCommand.Price,
        };

        // Some business Logic
        return await Task.Run(()=> new CreateProductResult(Guid.NewGuid()));
    }
}