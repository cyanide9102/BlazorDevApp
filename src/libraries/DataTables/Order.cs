using System.Text.Json.Serialization;

namespace DataTables;
public class Order
{
    [JsonPropertyName("column")]
    public int Column { get; set; }

    [JsonPropertyName("dir")]
    public string Dir { get; set; }
}
