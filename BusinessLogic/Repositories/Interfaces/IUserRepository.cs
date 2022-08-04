using Common.DTO.User;

namespace BusinessLogic.Repositories.Interfaces;

public interface IUserRepository : IDisposable
{
    Task<UserDTO?> GetAsync(int id);
}