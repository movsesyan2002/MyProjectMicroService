using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Models;

public class OrderModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }
    
    public int? CarId { get; set; }
    public CarModel? Car { get; set; }
    
    // public int? CustomerId { get; set; }
    // public CustomerModel? Customer { get; set; }
    
    [DataType(DataType.Date)]
    [Column(TypeName = "timestamp with time zone")] 
    public DateTime? OrderDate { get; set; }
    public decimal? Price { get; set; }
}