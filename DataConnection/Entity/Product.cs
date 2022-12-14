namespace DataConnection.Entity;

public class Product
{
    public Product()
    {
        ProductOrders = new List<ProductOrder>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int TypeId { get; set; }
    public string Parameters { get; set; }
    public int ManufacturerId { get; set; }
    public ProductType Type { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public ICollection<ProductOrder> ProductOrders { get; set; }
}