using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Models;

public class CarEngine // join tables Car->Engine
{ 
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int? CarId { get; set; }
    public CarModel? Car { get; set; }
    
    public int? EngineId { get; set; }
    public EngineModel? Engine { get; set; }

}