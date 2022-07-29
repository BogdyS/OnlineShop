using DataConnection.Entity.Enums;

namespace DataConnection.Entity;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Address { get; set; }
    public Statuses Status { get; set; } 
    public User User { get; set; }
    public ICollection<ProductOrder> ProductOrders { get; set; }
}