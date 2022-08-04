using AutoMapper;
using Common.DTO.User;
using DataConnection.Entity;

namespace BusinessLogic.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>()
            .ForMember(dto => dto.Id,
                memberOptions => memberOptions.MapFrom(u => u.Id))
            .ForMember(dto => dto.Name,
                memberOptions => memberOptions.MapFrom(u => u.Name))
            .ForMember(dto => dto.Email,
                memberOptions => memberOptions.MapFrom(u => u.Email))
            .ForMember(dto => dto.Role,
                memberOptions => memberOptions.MapFrom(u => u.Role));
    }
}