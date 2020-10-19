using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Project.Application.Commands.Cliente;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project.UnitTest
{
    public class ClienteTest
    {

        //RestSharp
        private readonly HttpClient httpClient;

        public ClienteTest()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            TestServer testeServer = new TestServer(new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<Project_Presentation.Startup>());

            httpClient = testeServer.CreateClient();
        }

        [Fact]
        public async Task Get_ObterClienteTest()
        {
            #region Arrange

            var resource = $"api/Cliente";

            #endregion

            #region Act

            var response = await httpClient.GetAsync(resource);

            #endregion

            #region Assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            #endregion
        }

        [Fact]
        public async Task Post_CadastrarClienteTest()
        {
            #region Arrange

            var resource = $"api/Cliente";

            var command = new CreateClienteCommand
            {
                Nome = "Gustavo Santanna",
                Cpf = "00425718719",
                Idade = 46,
                DataNascimento = new DateTime(1974, 06, 25)
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
        public async Task Update_AtualizarClienteTest()
        {
            #region Arrange

            var resource = $"api/Cliente";

            var command = new UpdadeClienteCommand
            {
                Id = 1004,
                Nome = "Gustavo C. Santanna",
                Cpf = "00425718719",
                Idade = 46,
                DataNascimento = new DateTime(1974, 06, 25)
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
        public async Task Delete_ExcluirClienteTest()
        {
            #region Arrange

            var id = 1002;
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
