using System.Text.Json.Serialization;

namespace DataTables;
public class Column
{
    [JsonPropertyName("data")]
    public string Data { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("searchable")]
    public bool Searchable { get; set; }

    [JsonPropertyName("orderable")]
    public bool Orderable { get; set; }

    [JsonPropertyName("search")]
    public Search Search { get; set; }
}
