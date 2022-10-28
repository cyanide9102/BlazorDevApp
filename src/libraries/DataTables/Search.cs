using System.Text.Json.Serialization;

namespace DataTables;
public class Search
{
    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("regex")]
    public bool Regex { get; set; }
}
