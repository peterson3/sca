using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using SCA.Barragens.API.DataStorage;
using SCA.Barragens.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCA.Barragens.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarragemController : ControllerBase
    {

        [HttpGet]
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
    }

    public class FiltroViewModel
    {
        public string filtro { get; set; }
    }
}
