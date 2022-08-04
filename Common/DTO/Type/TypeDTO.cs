using System.Text.Json.Nodes;

namespace Common.DTO.Type;

public class TypeDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public JsonObject Properties { get; set; }
}