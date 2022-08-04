using AutoMapper;
using Common.DTO.Order;
using DataConnection.Entity;

namespace BusinessLogic.Mapping;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDTO>()
            .ForMember(dto => dto.Id,
                memberOptions => memberOptions.MapFrom(o => o.Id))
            .ForMember(dto => dto.Address,
                memberOptions => memberOptions.MapFrom(o => o.Address))
            .ForMember(dto => dto.User,
                memberOptions => memberOptions.MapFrom(o => o.User))
            .ForMember(dto => dto.Status,
                memberOptions => memberOptions.MapFrom(o => o.Status));
    }
}