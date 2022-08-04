using Common.DTO.Type;

namespace BusinessLogic.Repositories.Interfaces;

public interface ITypeRepository : IDisposable
{
    Task<IEnumerable<TypeDTO>> GetAllAsync();
    Task<TypeDTO?> GetAsync(int id);
}