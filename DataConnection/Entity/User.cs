using DataConnection.Entity.Enums;
using Microsoft.AspNetCore.Identity;

namespace DataConnection.Entity;

public class User : IdentityUser
{
    public User() : base()
    {
        Orders = new List<Order>();
    }
    public ICollection<Order> Orders { get; set; }
}