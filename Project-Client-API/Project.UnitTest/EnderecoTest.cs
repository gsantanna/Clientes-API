using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Project.Application.Commands.Endereco;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project.UnitTest
{
    public class EnderecoTest
    {
        private readonly HttpClient httpClient;

        public EnderecoTest()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            TestServer testeServer = new TestServer(new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<Project_Presentation.Startup>());

            httpClient = testeServer.CreateClient();
        }

        public async Task Get_ObterEnderecoTest()
        {
            #region Arrange

            var resource = $"api/Endereco";

            #endregion

            #region Act

            var response = await httpClient.GetAsync(resource);

            #endregion

            #region Assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            #endregion
        }

        [Fact]
        public async Task Post_CadastrarEnderecoTest()
        {
            #region Arrange

            var resource = $"api/Endereco";

            var command = new CreateEnderecoCommand
            {
                Logradouro = "Rua XPTO",
                Bairro = "Fonseca",
                Cidade = "Niterói",
                Estado = "RJ"
            };

            #endregion

            #region Act

            var request = new StringContent(JsonConvert.SerializeObject(command),
                Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(resource, request);

            #endregion

            #region Assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            #endregion
        }

        [Fact]
        public async Task Update_AtualizarEnderecoTest()
        {
            #region Arrange

            var resource = $"api/Endereco";

            var command = new UpdateEnderecoCommand
            {
                Id = 1,
                Logradouro = "Estrada de Itaipuaçu 255",
                Bairro = "Itaipuaçu - Itaocaia",
                Cidade = "Rio do Ouro",
                Estado = "PR"
            };

            #endregion

            #region Act

            var request = new StringContent(JsonConvert.SerializeObject(command),
                Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(resource, request);

            #endregion

            #region Assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            #endregion
        }

        [Fact]
        public async Task Delete_ExcluirEnderecoTest()
        {
            #region Arrange

            var id = 1;
            var resource = $"api/Cliente/{id}";

            #endregion

            #region Act

            var response = await httpClient.DeleteAsync(resource);

            #endregion

            #region Assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            #endregion
        }
    }
}
