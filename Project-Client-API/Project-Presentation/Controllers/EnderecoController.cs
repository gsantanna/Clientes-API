using Microsoft.AspNetCore.Mvc;
using Project.Application.Commands.Endereco;
using Project.Application.Interfaces;
using Project.Domain.Interfaces;
using System;

namespace Project_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoApplicationService enderecoApplicationService;

        public EnderecoController(IEnderecoApplicationService enderecoApplicationService)
        {
            this.enderecoApplicationService = enderecoApplicationService;
        }

        [HttpPost]
        public IActionResult Post(CreateEnderecoCommand command)
        {
            try
            {
                enderecoApplicationService.Add(command);

                return Ok(new { Message = "Endereço cadastrado com sucesso" });
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message); ;
            }
        }

        [HttpPut]
        public IActionResult Put(UpdateEnderecoCommand command)
        {
            try
            {
                enderecoApplicationService.Update(command);

                return Ok(new { Message = "Endereço atualizado com sucesso" });
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
                var command = new DeleteEnderecoCommand { Id = id };

                enderecoApplicationService.Remove(command);

                return Ok(new { Message = "Endereço excluido com sucesso." });
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = enderecoApplicationService.GetAll();

                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                var result = enderecoApplicationService.GetById(id);

                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}
