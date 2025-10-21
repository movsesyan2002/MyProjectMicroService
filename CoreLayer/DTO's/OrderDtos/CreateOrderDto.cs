using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTO_s.OrderDtos;

public class CreateOrderDto
{
    [DefaultValue("")]
    public int CarId { get; set; }
    [DataType(DataType.Date)]
    [DefaultValue("")]
    public DateTime OrderDate { get; set; }
    [DefaultValue("")]
    public decimal Price { get; set; }
    //public IEnumerable<int>? EngineIds { get; set; }
}