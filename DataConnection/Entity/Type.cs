namespace DataConnection.Entity;

public class Type
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string[] Parameters { get; set; }
    public ICollection<Product> Products { get; set; }
}