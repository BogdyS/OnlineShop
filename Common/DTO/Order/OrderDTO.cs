using DataConnection.Entity;
using DataConnection.Entity.Enums;

namespace Common.DTO.Order;

public class OrderDTO
{
    public int Id { get; set; }
    public string Address { get; set; }
    public Statuses Status { get; set; }
    public User User { get; set; }
}