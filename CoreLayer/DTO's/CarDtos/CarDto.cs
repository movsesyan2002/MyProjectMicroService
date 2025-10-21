using System.ComponentModel.DataAnnotations;
using CoreLayer.DTO_s.EngineDtos;

namespace CoreLayer.DTO_s.CarDtos;

public class CarDto
{
    public int CarId { get; set; }
    public string? Name { get; set; }
    public string? ModelName { get; set; }
    public string? ModelCode { get; set; }
    public string? Color { get; set; }
    public decimal Price { get; set; }
    [DataType(DataType.Date)]
    public DateTime Year { get; set; }
    public IEnumerable<EngineDto>? EngineDtos { get; set; }
    
}