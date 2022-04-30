using AutoMapper;
using Buscador.Models;
using Buscador.ViewModels;

namespace Buscador.Utils.AutoMapperConfig
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Trabalhador, TrabalhadorViewModel>().ReverseMap();
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<EnderecoCliente, EnderecoClienteViewModel>().ReverseMap();
            CreateMap<EnderecoTrabalhador, EnderecoTrabalhadorViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<TipoDeServico, TipoDeServicoViewModel>().ReverseMap();

            CreateMap<Solicitacao, SolicitacaoViewModel>().ReverseMap();
        }
    }
}
