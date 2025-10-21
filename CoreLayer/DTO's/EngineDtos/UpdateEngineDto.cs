using System.ComponentModel;

namespace CoreLayer.DTO_s.EngineDtos;

public class UpdateEngineDto
{
    [DefaultValue("")]
    public string? EngineCode { get; set; }
    [DefaultValue("")]
    public int PowerHp { get; set; }
    [DefaultValue("")]
    public string? FuelType { get; set; }
}