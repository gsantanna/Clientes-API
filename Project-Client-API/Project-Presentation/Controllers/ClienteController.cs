using Microsoft.AspNetCore.Mvc;
using Project.Application.Commands.Cliente;
using Project.Application.Interfaces;
using System;

namespace Project_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplicationService clienteApplicationService;

        public ClienteController(IClienteApplicationService clienteApplicationService)
        {
            this.clienteApplicationService = clienteApplicationService;
        }

        [HttpPost]
        public IActionResult Post(CreateClienteCommand command)
        {
            try
            {
                clienteApplicationService.Add(command);

                return Ok(new { Message = "Cliente cadastrado com sucesso" });
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message); ;
            }
        }

        [HttpPut]
        public IActionResult Put(UpdadeClienteCommand command)
        {
            try
            {
                clienteApplicationService.Update(command);

                return Ok(new { Message = "Cliente atualizado com sucesso" });
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message); ;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var command = new DeleteClienteCommand { Id = id };

                clienteApplicationService.Remove(command);

                return Ok(new { Message = "Cliente excluido com sucesso." });
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = clienteApplicationService.GetAll();

                return Ok(result);
            }
            catch (Exception e)
            {

                new Exception("Erro ao selecionar o Aluno", e);
                return this.BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var result = clienteApplicationService.GetById(id);

                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}
