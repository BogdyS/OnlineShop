using System.Text.Json.Nodes;
using Common.DTO.Manufacturer;
using DataConnection.Entity;

namespace Common.DTO.Product;

public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public ProductType Type { get; set; }
    public JsonObject Parameters { get; set; }
    public ManufacturerDTO Manufacturer { get; set; }
}