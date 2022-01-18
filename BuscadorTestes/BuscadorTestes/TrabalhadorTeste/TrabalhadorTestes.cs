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
        public async Task DeveObterTrabalhadorEnderecoPorId()
        {
            //Arrange
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
            var repoTrabalhador = trabalhadorMock.Object;

            //Act
            var resultado = await repoTrabalhador.ObterTrabalhadorEndereco(id);

            //Assert
            Assert.IsType<Trabalhador>(resultado);
        }

        [Fact]
        public async Task DeveObterTrabalhadorEnderecoPorUserId()
        {
            //Arrange
            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();

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
                UserId = userId,
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

            trabalhadorMock.Setup(x => x.ObterTrabalhadorEnderecoPorUserId(userId)).ReturnsAsync(trabalhador);
            var repoTrabalhador = trabalhadorMock.Object;

            //Act
            var resultado = await repoTrabalhador.ObterTrabalhadorEnderecoPorUserId(userId);

            //Assert
            Assert.IsType<Trabalhador>(resultado);
        }
        [Fact]
        public async Task DeveAtualizarTrabalhadorEndere()
        {
            //Arrange
            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();

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
                UserId = userId,
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

            trabalhadorMock.Setup(x => x.ObterTrabalhadorEnderecoPorUserId(userId)).ReturnsAsync(trabalhador);
            var repoTrabalhador = trabalhadorMock.Object;

            //Act
            var resultado = await repoTrabalhador.ObterTrabalhadorEnderecoPorUserId(userId);

            //Assert
            Assert.Equal(trabalhador.Id, resultado.Id);
            Assert.Equal(trabalhador.Documento, resultado.Documento);
            Assert.Equal(trabalhador.UserId, resultado.UserId);
            Assert.Equal(trabalhador.EnderecoTrabalhador.Id, resultado.EnderecoTrabalhador.Id);
        }
    }
}