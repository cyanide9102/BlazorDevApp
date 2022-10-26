using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorDevApp.Web.Models;
public class ProductModel
{
    [Required, StringLength(256)]
    public string Name { get; set; }
    [Required, StringLength(1024)]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
}
