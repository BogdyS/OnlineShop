using System.Text.Json.Nodes;
using AutoMapper;
using Common.DTO;
using DataConnection.Entity;

namespace BusinessLogic.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDTO>()
            .ForMember(dto => dto.Id,
                memberOptions => memberOptions.MapFrom(p => p.Id))
            .ForMember(dto => dto.Manufacturer,
                memberOptions => memberOptions.MapFrom(p => p.Manufacturer))
            .ForMember(dto => dto.Name,
                memberOptions => memberOptions.MapFrom(p => p.Name))
            .ForMember(dto => dto.Type,
                memberOptions => memberOptions.MapFrom(p => p.Type))
            .ForMember(dto => dto.Parameters,
                memberOptions => memberOptions.MapFrom(
                    p => JsonNode.Parse(p.Parameters, null, default)))
            .ForMember(dto => dto.Price,
                memberOptions => memberOptions.MapFrom(p => p.Price));
    }
}