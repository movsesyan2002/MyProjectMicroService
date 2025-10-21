using System.ComponentModel;

namespace CoreLayer.DTO_s.CarDtos;

public class UpdateCarDto
{
    [DefaultValue("")]
    public decimal Price { get; set; }
    public IEnumerable<int>? EngineIds { get; set; }
}