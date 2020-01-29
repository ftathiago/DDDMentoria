using AutoMapper;
using Application.Venda.Models;
using Dominio.Venda.DTO;

namespace Application.Venda.Modules
{
    public static class AutoMapperConfig
    {
        public static IMapper PegarMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VendaModel, VendaDTO>();
                cfg.CreateMap<VendaItemModel, VendaItemDTO>();
                cfg.CreateMap<ClienteModel, ClienteDTO>();
            });
            return config.CreateMapper();
        }
    }
}