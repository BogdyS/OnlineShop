using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLogic.Repositories.Interfaces;
using Common.DTO.User;
using DataConnection;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public UserRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<UserDTO?> GetAsync(int id)
    {
        return await _dataContext.Users
            .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(u => u.Id == id);
    }
}