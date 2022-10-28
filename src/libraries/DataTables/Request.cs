using System.Text.Json.Serialization;

namespace DataTables;
public class Request
{
    [JsonPropertyName("draw")]
    public int Draw { get; set; }

    [JsonPropertyName("start")]
    public int Start { get; set; }

    [JsonPropertyName("length")]
    public int Length { get; set; }

    [JsonPropertyName("search")]
    public Search Search { get; set; }

    [JsonPropertyName("order")]
    public Order[] Order { get; set; }

    [JsonPropertyName("columns")]
    public Column[] Columns { get; set; }
}
