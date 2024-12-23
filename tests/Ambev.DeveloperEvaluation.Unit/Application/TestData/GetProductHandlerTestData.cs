using Ambev.DeveloperEvaluation.Application.Products.GetUser;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

public class GetProductHandlerTestData
{
    private static readonly Faker<GetProductCommand> getProductCommand = new Faker<GetProductCommand>()
        .RuleFor(u => u.Id, f => f.IndexFaker);

    public static GetProductCommand GetProductCommandFaker()
    {
        return getProductCommand.Generate();
    }
}