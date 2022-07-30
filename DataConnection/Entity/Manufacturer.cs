namespace DataConnection.Entity;

public class Manufacturer
{
    public Manufacturer()
    {
        Products = new List<Product>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}