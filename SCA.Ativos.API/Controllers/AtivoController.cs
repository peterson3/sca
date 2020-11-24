using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCA.Ativos.API.Communication;
using SCA.Ativos.API.Model;
using SCA.IntegrationEvents.Ativo;

namespace SCA.Ativos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "admin, engenheiro, consultor, analista")]
    public class AtivoController : ControllerBase
    {
        private readonly ILogger<AtivoController> _logger;
        private readonly IAtivoRepository _ativoRepository;
        private readonly ServiceBus _bus;

        public AtivoController(ILogger<AtivoController> logger,
                                IAtivoRepository ativoRepository)
        {
            _logger = logger;
            _ativoRepository = ativoRepository;
            _bus = new ServiceBus();
        }

        [HttpGet]
        [AllowAnonymous]
        public Task<IEnumerable<Ativo>> RecuperarTodos()
        {
            return  _ativoRepository.ObterTodos();
        }


        [HttpGet]
        [Route("TipoAtivo")]
        public Task<IEnumerable<TipoAtivo>> RecuperarTodosTiposAtivos()
        {
            return _ativoRepository.ObterTodosTipos();
        }

        [HttpGet]
        [Route("{id}")]
        public Task<Ativo> RecuperarPorId(int id)
        {
            var qmE = User.Identity.Name;
            var oqE = User.Claims;

            return _ativoRepository.ObterPorId(id);
        }

        [HttpGet]
        [Route("filtro")]
        public Task<IEnumerable<Ativo>> RecuperarFiltrado([FromQuery] FiltroViewModel viewModel)
        {
            return _ativoRepository.ObterComFiltro(viewModel.filtro);
        }

        [HttpPost]
        public void Cadastrar([FromBody]Ativo ativo)
        {
            _ativoRepository.Adicionar(ativo);
            var ativoAdicionadoEvent = new AtivoAdicionadoEvent()
            {
                Id = ativo.Id,
                Nome = ativo.Nome,
                Categoria = ativo.Categoria,
                DataCompra = ativo.DataCompra,
                DataUltimaManutencao = ativo.DataUltimaManutencao,
                Fornecedor = ativo.Fornecedor,
                Identificador = ativo.Identificador,
                Modelo = ativo.Modelo,
                TipoId = ativo.TipoId
            };
            _bus.PublicarEvento<AtivoAdicionadoEvent>(ativoAdicionadoEvent);
            
        }

        [HttpPut]
        public void Alterar([FromBody] Ativo ativo)
        {
            _ativoRepository.Alterar(ativo);
            var ativoAlteradoEvent = new AtivoAlteradoEvent()
            {
                Id = ativo.Id,
                Nome = ativo.Nome,
                Categoria = ativo.Categoria,
                DataCompra = ativo.DataCompra,
                DataUltimaManutencao = ativo.DataUltimaManutencao,
                Fornecedor = ativo.Fornecedor,
                Identificador = ativo.Identificador,
                Modelo = ativo.Modelo,
                TipoId = ativo.TipoId
            };
            _bus.PublicarEvento<AtivoAlteradoEvent>(ativoAlteradoEvent);

        }

        [HttpDelete]
        [Route("{id}")]
        public void Remover(int id)
        {
            _ativoRepository.Remover(id);
            var ativoAlteradoEvent = new AtivoExcluidoEvent()
            {
                Id = id
            };

            _bus.PublicarEvento<AtivoExcluidoEvent>(ativoAlteradoEvent);

        }
    }

    public class FiltroViewModel
    {
        public string filtro { get; set; }
    }
}
