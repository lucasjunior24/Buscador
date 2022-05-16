using Buscador.Models.Entitiies;
using Buscador.Models.Interfaces;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestesDoBuscador.ClienteTeste
{
    public class ClienteTestes
    {
        //Mocks
        private readonly Mock<IClienteRepository> clienteMock;

        public ClienteTestes()
        {
            this.clienteMock = new Mock<IClienteRepository>();
        }

        [Fact]
        public async Task ObterCliienteEnderecoPorId()
        {
            //Arrange
            var id = Guid.NewGuid();

            var cliente = new Cliente()
            {
                Id = id,
                Nome = "Teste",
                Telefone = "Teste",
                Email = "",
                UserId = Guid.NewGuid(),
                EnderecoCliente = new EnderecoCliente()
                {
                    ClienteId = id,
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

            clienteMock.Setup(x => x.ObterClienteEndereco(id)).ReturnsAsync(cliente);
            var clienteRepo = clienteMock.Object;

            //Act
            var resultado = await clienteRepo.ObterClienteEndereco(id);

            //Assert
            Assert.IsType<Cliente>(resultado);
        }
    }
}