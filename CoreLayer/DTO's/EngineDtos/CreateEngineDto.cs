using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTO_s.EngineDtos;

public class CreateEngineDto
{
    [DefaultValue("")]
    [Required]
    public string? EngineCode { get; set; }
    [DefaultValue("")]
    [Required]
    public int PowerHp { get; set; }
    [DefaultValue("")]
    [Required]
    public string? FuelType { get; set; }
    
    
}