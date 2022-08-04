using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services.Interfaces;
using Common.DTO.User;
using Common.Exceptions;

namespace BusinessLogic.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDTO> GetAsync(int id)
    {
        var user = await _userRepository.GetAsync(id);

        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        return user;
    }
}