using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Models;

public class CarModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CarId { get; set; }
    [Required]
    public string? Name { get; set; } = default;
    [Required]
    public string? ModelName { get; set; } = default;
    [Required]
    public string? ModelCode { get; set; } // unique
    
    [DataType(DataType.Date)]
    [Column(TypeName = "timestamp with time zone")] 
    public DateTime? Year { get; set; }
    [Required]
    public decimal? Price { get; set; }
    [Required]
    public string? Color { get; set; }

    public virtual ICollection<EngineModel>? Engines { get; set; } // Many -> many
    public virtual ICollection<OrderModel>? Orders { get; set; } // One -> many
}