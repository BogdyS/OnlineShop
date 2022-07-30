using DataConnection.Entity.Enums;

namespace DataConnection.Entity;

public class User
{
    public User()
    {
        Orders = new List<Order>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Roles Role { get; set; }
    public ICollection<Order> Orders { get; set; }
}