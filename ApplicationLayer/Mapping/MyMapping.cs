using AutoMapper;
using CoreLayer.DTO_s.CarDtos;
// using CoreLayer.DTO_s.CustomerDtos;
using CoreLayer.DTO_s.EngineDtos;
using CoreLayer.DTO_s.OrderDtos;
using CoreLayer.Models;

namespace ApplicationLayer.Mapping;

public class MyMapping : Profile
{
    public MyMapping()
    {
        // Cars
        CreateMap<CarModel, CarDto>()
            .ForMember(dest => dest.EngineDtos, opt => opt.MapFrom(src => src.Engines));
        CreateMap<CreateCarDto, CarModel>()
            .ForMember(dest => dest.Engines, opt => opt.Ignore());
        CreateMap<CarModel, UpdateCarDto>().ReverseMap();
        
        // Engines
        CreateMap<EngineModel, EngineDto>().ReverseMap();
        CreateMap<EngineModel, CreateEngineDto>().ReverseMap();
        CreateMap<EngineModel, UpdateEngineDto>().ReverseMap();
        
        
        // Orders
        CreateMap<OrderModel, OrderDto>()
            .ForMember(dest => dest.Car, opt => opt.MapFrom(src => src.Car));
        CreateMap<OrderModel, CreateOrderDto>().ReverseMap();
        CreateMap<OrderModel, UpdateOrderDto>().ReverseMap();

    }
}