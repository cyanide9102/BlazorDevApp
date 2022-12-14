using System.Text.Json.Serialization;

namespace DataTables;
public class Response<T>
{
    [JsonPropertyName("draw")]
    public int Draw { get; set; }

    [JsonPropertyName("recordsTotal")]
    public int RecordsTotal { get; set; }

    [JsonPropertyName("recordsFiltered")]
    public int RecordsFiltered { get; set; }

    [JsonPropertyName("data")]
    public IEnumerable<T> Data { get; set; }

    [JsonPropertyName("error")]
    public string Error { get; set; }
}
