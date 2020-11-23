using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using SCA.Barragens.API.DataStorage;
using SCA.Barragens.API.Models;
using System;

namespace SCA.Barragens.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarragemController : ControllerBase
    {


        public IActionResult Get()
        {
            //Random rnd = new Random();


            MongoDbContext dbContext = new MongoDbContext();
            //var Barragem = new Barragem()
            //{
            //    Id = rnd.Next(1, 50),
            //    CapacidadeTotal = rnd.Next(1000, 100000)
            //};

            //dbContext.Barragens.InsertOne(Barragem);


            return Ok(dbContext.Barragens.FindSync(new BsonDocument()).ToList());
        }
    }
}
