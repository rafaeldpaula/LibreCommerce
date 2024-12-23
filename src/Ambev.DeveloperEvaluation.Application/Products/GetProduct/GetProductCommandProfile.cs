using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetUser;

public class GetProductCommandProfile : Profile
{
    public GetProductCommandProfile()
    {
        CreateMap<Product, GetProductCommandResult>();
    }
}