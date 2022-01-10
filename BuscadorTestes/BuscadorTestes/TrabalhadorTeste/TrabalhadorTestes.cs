using Buscador.Interfaces;
using Buscador.Models;
using System;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace TestesDoBuscador.TrabalhadorTeste
{
    public class TrabalhadorTestes
    {
        //Mocks
        private readonly Mock<ITrabalhadorRepository> trabalhadorMock;

        public TrabalhadorTestes()
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
                Documento = "Descrição",
                TipoDeTrabalhador = TipoDeTrabalhador.PessoaFisica,
                Email = "",
                Profissao = "Doc",
                UserId = Guid.NewGuid(),
                EnderecoTrabalhador = new EnderecoTrabalhador()
            };

            //trabalhadorMock.Setup(x => x.ObterTrabalhadorEnderecoPorUserId(id)).ReturnsAsync(trabalhador);
            trabalhadorMock.Setup(x => x.ObterTrabalhadorEndereco(id)).ReturnsAsync(trabalhador);
            var re = trabalhadorMock.Object;

            var traba = await re.ObterTrabalhadorEndereco(id);
            //var result = trabalhadorMock.Verify(x => x.ObterPorId(id).)
            Assert.IsType<Trabalhador>(traba);
        }
    }
}