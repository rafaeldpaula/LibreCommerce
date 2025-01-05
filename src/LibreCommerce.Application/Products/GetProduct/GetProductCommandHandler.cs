using LibreCommerce.Domain.Entities;
using LibreCommerce.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace LibreCommerce.Application.Products.GetUser;

public class GetProductCommandHandler : IRequestHandler<GetProductCommand, GetProductCommandResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetProductCommandResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetProductCommandValidator();
        var validationResults = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResults.IsValid)
            throw new ValidationException(validationResults.Errors);

        var product = await _productRepository.GetProductByIdAsync(request.Id);
        if (product == null)
            throw new KeyNotFoundException($"Product with id: {request.Id} does not exist");

        return _mapper.Map<GetProductCommandResult>(product);
    }
}