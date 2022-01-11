using Buscador.Interfaces;
using Buscador.Models;
using System;
using System.Threading.Tasks;
using Xunit;
using Moq;

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
            var repo = clienteMock.Object;

            var clienteRepo = await repo.ObterClienteEndereco(id);

            Assert.IsType<Cliente>(clienteRepo);
        }
    }
}