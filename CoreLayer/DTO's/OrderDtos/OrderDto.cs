using System.ComponentModel.DataAnnotations;
using CoreLayer.DTO_s.CarDtos;
using CoreLayer.Models;

namespace CoreLayer.DTO_s.OrderDtos;

public class OrderDto
{
    public int OrderId { get; set; }
    [DataType(DataType.Date)]
    public DateTime OrderDate { get; set; }
    public decimal Price { get; set; }
    public int UserId { get; set; }
    public int CarId { get; set; }
    public CarDto? Car { get; set; } 
}