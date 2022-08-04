using DataConnection.Entity.Enums;

namespace Common.DTO.User;

public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Roles Role { get; set; }
}