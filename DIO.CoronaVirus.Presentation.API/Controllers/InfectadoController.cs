using DIO.CoronaVirus.Domain.Entitites;
using DIO.CoronaVirus.Domain.Models.Request;
using DIO.CoronaVirus.Domain.Models.Response;
using DIO.CoronaVirus.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.CoronaVirus.Presentation.API.Controllers
{
    /// <summary>
    /// Recurso para controlar Infectados pelo corona Virus
    /// </summary>
    [ApiController]
    [Route("Api/[Controller]")]
    public class InfectadoController : ControllerBase
    {
        private readonly ILogger<InfectadoController> logger;
        private readonly IInfectadoRepository infectadoRepository;


        public InfectadoController(ILogger<InfectadoController> logger, IInfectadoRepository infectadoRepository)
        {
            this.logger = logger;
            this.infectadoRepository = infectadoRepository;
        }

        /// <summary>
        /// Busca todos os infectados cadastrados
        /// </summary>
        /// <returns>Todos infectados</returns>
        [HttpGet]
        public IActionResult Buscar()
        {
            var models = this.infectadoRepository.Buscar().Select(x => (InfectadoResponse)x);

            return Ok(models);
        }

        /// <summary>
        /// Busca um infectado pelo Identidicador úniconico
        /// </summary>
        /// <param name="ID">Identidicador único do infectado</param>
        /// <returns>Um Infectado</returns>
        [HttpGet("{ID}")]
        public IActionResult Buscar(Guid ID)
        {
            var model = this.infectadoRepository.Buscar(ID);

            return Ok(model);
        }

        /// <summary>
        /// Adiciona um infectado a base de dados
        /// </summary>
        /// <param name="model">Dados do Infectado</param>
        /// <returns>O Infectado cadastrado</returns>
        [HttpPost]
        public IActionResult Adicionar([FromBody] InfectadoRequest model)
        {
            Infectado infectado = model;

            InfectadoResponse response = this.infectadoRepository.Adicionar(infectado);

            return Created("Objeto Criado com sucesso", response);
        }

        /// <summary>
        /// Adiciona uma lista de infectados a base de dados
        /// </summary>
        /// <param name="models">Lista de Infectados</param>
        /// <returns>Os Infectados cadastrados</returns>
        [HttpPost("BulkInsert")]
        public IActionResult Adicionar([FromBody] List<InfectadoRequest> models)
        {
            List<Infectado> infectados = models.Select(x => (Infectado)x).ToList();

            var responseList = this.infectadoRepository.Adicionar(infectados).Select(x => (InfectadoResponse)x);

            return Created("Objeto Criado com sucesso", responseList);
        }

        /// <summary>
        /// Atualiza ou modifica os dados de um infectado
        /// </summary>
        /// <param name="model">Infectado com dados modificados ou atualizados</param>
        /// <returns>Infectado atualizado ou modificado</returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody] InfectadoRequest model)
        {
            Infectado infectado = model;

            this.infectadoRepository.Atualizar(infectado);

            return Ok();
        }

        /// <summary>
        /// Exclui um infectado da base de dados
        /// </summary>
        /// <param name="ID">Identidicador único do infectado</param>
        /// <returns></returns>
        [HttpDelete("{ID}")]
        public IActionResult Deletar(Guid ID)
        {
            this.infectadoRepository.Deletar(ID);

            return Ok();
        }

        /// <summary>
        /// Exclui uma lista de infectados da base de dados
        /// </summary>
        /// <param name="IDs">Lista com os identificadores únicos dos infectados</param>
        /// <returns></returns>
        [HttpDelete("BulkDelete")]
        public IActionResult Deletar([FromBody] List<Guid> IDs)
        {
            this.infectadoRepository.Deletar(IDs);

            return Ok();
        }
    }
}
