using LibreCommerce.Application.Products.GetUser;
using LibreCommerce.Domain.Entities;
using LibreCommerce.Domain.Repositories;
using LibreCommerce.Unit.Domain;
using AutoMapper;
using Bogus;
using FluentAssertions;
using NSubstitute;
using Xunit;
using ValidationException = FluentValidation.ValidationException;

namespace LibreCommerce.Unit.Application;

public class GetProductCommandHandlerTest
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductCommandHandlerTest()
    {
        _productRepository = Substitute.For<IProductRepository>();
        _mapper = Substitute.For<IMapper>();
    }

    [Fact]
    public async Task Handle_ValidRequest_ReturnSuccessResponse()
    {
        var handler = new GetProductCommandHandler(_productRepository, _mapper); // Criar o handler com os mocks injetados 
        var command = GetProductHandlerTestData.GetProductCommandFaker(); // Gerar um comando válido (mock de dados)

        var mockProduct = new Product { Id = Guid.NewGuid(), ProductId = new Faker().IndexFaker };
        _productRepository.GetProductByIdAsync(command.Id)
            .Returns(Task.FromResult(mockProduct));

        var expectedResponse = new GetProductCommandResult
        {
            Id = mockProduct.ProductId,
            Title = new Faker().Commerce.ProductName(),
            Price = Convert.ToDecimal(new Faker().Commerce.Price()),
            Description = new Faker().Commerce.ProductDescription(),
            Category = new Faker().Commerce.Categories(1)[0],
            Image = new Faker().Internet.Url(),
            Rating = new GetProductCommandResult.RatingData()
            {
                Rate = new Faker().Random.Decimal(10),
                Count = new Faker().Random.Number(1, 100),
            }
        };
        _mapper.Map<GetProductCommandResult>(mockProduct).Returns(expectedResponse);

        var result = await handler.Handle(command, CancellationToken.None);

        result.Should().NotBeNull();

        await _productRepository.Received(1).GetProductByIdAsync(command.Id);
        _mapper.Received(1).Map<GetProductCommandResult>(mockProduct);
    }
    
    [Fact]
    public async Task Handle_ProductNotFound_ShouldReturnNull()
    {
        var handler = new GetProductCommandHandler(_productRepository, _mapper);
        var command = GetProductHandlerTestData.GetProductCommandFaker();

        _productRepository.GetProductByIdAsync(command.Id)
            .Returns(Task.FromResult<Product>(null));

        var act = async() => await handler.Handle(command, CancellationToken.None);

        await act.Should().ThrowAsync<KeyNotFoundException>();
    }

    [Fact]
    public async Task Handle_NullCommand_ShouldThrowArgumentNullException()
    {
        var handler = new GetProductCommandHandler(_productRepository, _mapper);

        var act = async () => await handler.Handle(null, CancellationToken.None);

        await act.Should().ThrowAsync<ArgumentNullException>();
    }
    
    [Fact]
    public async Task Handle_CancellationTokenTriggered_ShouldThrowTaskCanceledException()
    {
        var handler = new GetProductCommandHandler(_productRepository, _mapper);
        var command = GetProductHandlerTestData.GetProductCommandFaker();
        var cancellationTokenSource = new CancellationTokenSource();
    
        cancellationTokenSource.Cancel();
        
        var act = async () => await handler.Handle(command, cancellationTokenSource.Token);

        await act.Should().ThrowAsync<OperationCanceledException>();
    }
    
    [Fact]
    public async Task Handle_ValidProduct_ShouldUseMapperCorrectly()
    {
        var handler = new GetProductCommandHandler(_productRepository, _mapper);
        var command = GetProductHandlerTestData.GetProductCommandFaker();

        var mockProduct = new Product { ProductId = new Faker().IndexFaker };
        _productRepository.GetProductByIdAsync(command.Id).Returns(Task.FromResult(mockProduct));

        await handler.Handle(command, CancellationToken.None);

        _mapper.Received(1).Map<GetProductCommandResult>(mockProduct);
    }
}