using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services.Interfaces;
using Common.DTO.Type;
using Common.Exceptions;

namespace BusinessLogic.Services.Implementations;

public class TypeService : ITypeService
{
    private readonly ITypeRepository _typeRepository;

    public async Task<IEnumerable<TypeDTO>> GetAllAsync()
    {
        return await _typeRepository.GetAllAsync();
    }

    public async Task<TypeDTO> GetByIdAsync(int id)
    {
        var type = await _typeRepository.GetAsync(id);

        if (type == null)
        {
            throw new NotFoundException("Type not found");
        }

        return type;
    }
}