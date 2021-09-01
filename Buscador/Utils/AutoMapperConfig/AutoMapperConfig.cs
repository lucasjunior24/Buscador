using AutoMapper;
using Buscador.Models;
using Buscador.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.Utils.AutoMapperConfig
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Trabalhador, TrabalhadorViewModel>().ReverseMap();
            CreateMap<EnderecoCliente, EnderecoClienteViewModel>().ReverseMap();
            CreateMap<EnderecoTrabalhador, EnderecoTrabalhadorViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<TipoDeServico, TipoDeServicoViewModel>().ReverseMap();
        }
    }
}
