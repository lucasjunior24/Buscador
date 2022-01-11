using Buscador.Interfaces;
using Buscador.Models;
using System;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace TestesDoBuscador.TrabalhadorTeste
{
    public class ClienteTestes
    {
        //Mocks
        private readonly Mock<ITrabalhadorRepository> trabalhadorMock;

        public ClienteTestes()
        {
            this.trabalhadorMock = new Mock<ITrabalhadorRepository>();
        }

        [Fact]
        public async Task ObterTrabalhadorEnderecoPorId()
        {
            var id = Guid.NewGuid();

            var trabalhador = new Trabalhador()
            {
                Id = id,
                Nome = "Teste",
                Telefone = "Teste",
                Documento = "Descrição",
                TipoDeServico = new TipoDeServico(),
                TipoDeTrabalhador = TipoDeTrabalhador.PessoaFisica,
                Email = "",
                Profissao = "Doc",
                UserId = Guid.NewGuid(),
                EnderecoTrabalhador = new EnderecoTrabalhador()
                {
                    TrabalhadorId = id,
                    Estado = "RO",
                    Cidade = "TESTE",
                    Bairro = "TESTE",
                    Logradouro = "TESTE",
                    Cep = "TESTE",
                    Id = new Guid(),
                    Complemento = "TESTE",
                    Numero = "TESTE",
                }
            };

            trabalhadorMock.Setup(x => x.ObterTrabalhadorEndereco(id)).ReturnsAsync(trabalhador);
            var re = trabalhadorMock.Object;

            var traba = await re.ObterTrabalhadorEndereco(id);

            Assert.IsType<Trabalhador>(traba);
        }
    }
}