using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTO_s.CarDtos;

public class CreateCarDto
{
    [Required]
    [DefaultValue("")]
    public string? Name { get; set; }
    [Required]
    [DefaultValue("")]
    public string? ModelName { get; set; }
    [Required]
    [DefaultValue("")]
    public string? ModelCode { get; set; }
    [Required]
    [DefaultValue("")]
    public decimal Price { get; set; }
    [Required]
    [DefaultValue("")]
    public string? Color { get; set; }

    [DataType(DataType.Date)]
    [DefaultValue("")]
    public DateTime Year { get; set; }
    [Required]
    public IEnumerable<int>? Engines { get; set; }
}