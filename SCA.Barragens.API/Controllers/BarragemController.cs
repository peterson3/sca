using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using SCA.Barragens.API.Communication;
using SCA.Barragens.API.DataStorage;
using SCA.Barragens.API.Models;
using SCA.IntegrationEvents.Alert;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCA.Barragens.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BarragemController : ControllerBase
    {
        private readonly ServiceBus _bus;

        public BarragemController()
        {
            _bus = new ServiceBus();

        }


        [HttpGet]
        [AllowAnonymous]
        public Task<List<Barragem>> Get()
        {
            MongoDbContext dbContext = new MongoDbContext();
            return Task.FromResult(dbContext.Barragens.FindSync(new BsonDocument()).ToList());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("filtro")]
        public Task<List<Barragem>> RecuperarFiltrado([FromQuery] FiltroViewModel viewModel)
        {
            MongoDbContext dbContext = new MongoDbContext();
            var filter = Builders<Barragem>.Filter.Where(b => b.Nome.Contains(viewModel.filtro));
            return Task.FromResult(dbContext.Barragens.FindSync(filter).ToList());
        }


        [HttpPut]
        [AllowAnonymous]
        public void Alterar([FromBody]Barragem barragem)
        {
            MongoDbContext dbContext = new MongoDbContext();
            var updateDefinition = Builders<Barragem>.Update
            .Set(u => u.VolumeMax, barragem.VolumeMax)
            .Set(u => u.Lat, barragem.Lat)
            .Set(u => u.Long, barragem.Long);

            var filter = Builders<Barragem>.Filter.Eq(b => b.Id, barragem.Id);

            dbContext.Barragens.UpdateOne(filter, updateDefinition);

        }

        [HttpPost("alertar")]
        [AllowAnonymous]
        public void Alertar([FromBody] AlertaViewModel viewModel)
        {
            var alertarCommand = new AlertarCommand() { Mensagem = viewModel.Mensagem };
            _bus.PublicarEvento(alertarCommand);
        }

    }

    public class AlertaViewModel
    {
        public string Mensagem { get; set; }
    }

    public class FiltroViewModel
    {
        public string filtro { get; set; }
    }
}
