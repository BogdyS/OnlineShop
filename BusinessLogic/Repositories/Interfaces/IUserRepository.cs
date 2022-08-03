using Common.DTO.User;

namespace BusinessLogic.Repositories.Interfaces;

public interface IUserRepository
{
    Task<UserDTO?> GetAsync(int id);
}