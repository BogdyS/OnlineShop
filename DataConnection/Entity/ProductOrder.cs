using System.ComponentModel.DataAnnotations;

namespace DataConnection.Entity;

public class ProductOrder
{
    public ProductOrder()
    { }
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    [Range(1,100)]
    public int ProductCount { get; set; }
    public Product Product { get; set; }
    public Order Order { get; set; }
}