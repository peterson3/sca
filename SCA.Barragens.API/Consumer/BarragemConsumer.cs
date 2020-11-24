using MassTransit;
using Microsoft.AspNetCore.SignalR;
using MongoDB.Driver;
using SCA.Barragens.API.DataStorage;
using SCA.Barragens.API.HubConfig;
using SCA.Barragens.API.Models;
using SCA.IntegrationEvents.Ativo;
using SCA.IntegrationEvents.Sensor;
using System;
using System.Threading.Tasks;

namespace SCA.Barragens.API.Consumer
{
    public class BarragemConsumer : IConsumer<AtivoAdicionadoEvent>, IConsumer<AtivoAlteradoEvent>, IConsumer<AtivoExcluidoEvent>
    {

        public Task Consume(ConsumeContext<AtivoAdicionadoEvent> context)
        {
            if (context.Message.TipoId == 1)
            {
                var msg = context.Message;
                MongoDbContext dbContext = new MongoDbContext();

                var barragem = new Barragem()
                {
                    Id = context.Message.Id,
                    Nome = context.Message.Nome
                };

                dbContext.Barragens.InsertOne(barragem);
            }


            return Task.CompletedTask;
        }

        public Task Consume(ConsumeContext<AtivoExcluidoEvent> context)
        {
            var msg = context.Message;
            MongoDbContext dbContext = new MongoDbContext();

            var filter = Builders<Barragem>.Filter.Eq(b => b.Id, msg.Id);

            dbContext.Barragens.DeleteOne(filter);

            return Task.CompletedTask;

        }

        public Task Consume(ConsumeContext<AtivoAlteradoEvent> context)
        {
            
            if (context.Message.TipoId == 1)
            {
                var msg = context.Message;
                MongoDbContext dbContext = new MongoDbContext();

                var barragem = new Barragem()
                {
                    Id = context.Message.Id,
                    Nome = context.Message.Nome
                };

                var updateDefinition = Builders<Barragem>.Update
                    .Set(u => u.Nome, msg.Nome );

                var filter = Builders<Barragem>.Filter.Eq(b => b.Id, msg.Id);

                dbContext.Barragens.UpdateOne(filter, updateDefinition);
            }

            return Task.CompletedTask;
        }
    }
}
