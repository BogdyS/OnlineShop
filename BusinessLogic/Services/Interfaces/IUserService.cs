using Common.DTO.User;

namespace BusinessLogic.Services.Interfaces;

public interface IUserService
{
    Task<UserDTO> GetAsync(int id);
}