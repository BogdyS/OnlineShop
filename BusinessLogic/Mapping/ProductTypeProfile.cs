using System.Text.Json.Nodes;
using AutoMapper;
using Common.DTO.Type;
using DataConnection.Entity;

namespace BusinessLogic.Mapping;

public class ProductTypeProfile : Profile
{
    public ProductTypeProfile()
    {
        CreateMap<ProductType, TypeDTO>()
            .ForMember(dto => dto.Id,
                memberOptions => memberOptions.MapFrom(t => t.Id))
            .ForMember(dto => dto.Name,
                memberOptions => memberOptions.MapFrom(t => t.Name))
            .ForMember(dto => dto.Properties,
                memberOptions => memberOptions.MapFrom(
                    t => JsonNode.Parse(t.Parameters, null, default)));
    }
}