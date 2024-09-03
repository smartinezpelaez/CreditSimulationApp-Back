using AutoMapper;
using CreditSimulationApp.DAL.Models;

namespace CreditSimulationApp.BLL.DTOs
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Credito, CreditoDTO>().ReverseMap();
        }
    }
}
