using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Models;

public class EngineModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EngineId { get; set; }
        
    public string? EngineCode { get; set; }
    public int? PowerHp { get; set; }
    public string? FuelType { get; set; }
        
        
    public virtual ICollection<CarModel>? Cars { get; set; } // Many -> many
}