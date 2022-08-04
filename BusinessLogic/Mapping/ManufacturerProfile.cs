using AutoMapper;
using Common.DTO.Manufacturer;
using DataConnection.Entity;

namespace BusinessLogic.Mapping;

public class ManufacturerProfile : Profile
{
    public ManufacturerProfile()
    {
        CreateMap<Manufacturer, ManufacturerDTO>()
            .ForMember(dto => dto.Id,
                memberOptions => memberOptions.MapFrom(m => m.Id))
            .ForMember(dto => dto.Name,
                memberOptions => memberOptions.MapFrom(m => m.Name));
    }
}