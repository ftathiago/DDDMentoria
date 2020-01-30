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
                cfg.CreateMap<VendaModel, VendaDTO>()
                    .ForMember(destination => destination.FormaDePagamento,
                        opt =>
                            opt.MapFrom(source => FormaDePagamento.GetName(typeof(FormaDePagamento), source.FormaDePagamento))
                        );
                cfg.CreateMap<VendaItemModel, VendaItemDTO>();
                cfg.CreateMap<ClienteModel, ClienteDTO>();
            });
            return config.CreateMapper();
        }
    }
}