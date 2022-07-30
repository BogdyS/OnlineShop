using System.Text.Json.Nodes;
using DataConnection.Entity;
using Type = DataConnection.Entity.Type;

namespace Common.DTO;

public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public Type Type { get; set; }
    public JsonObject Parameters { get; set; }
    public Manufacturer Manufacturer { get; set; }
}