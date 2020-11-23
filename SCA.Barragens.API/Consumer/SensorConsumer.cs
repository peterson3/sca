using MassTransit;
using Microsoft.AspNetCore.SignalR;
using MongoDB.Driver;
using SCA.Barragens.API.DataStorage;
using SCA.Barragens.API.HubConfig;
using SCA.Barragens.API.Models;
using SCA.IntegrationEvents.Sensor;
using System.Threading.Tasks;

namespace SCA.Barragens.API.Consumer
{
    public class SensorConsumer : IConsumer<SensorInfoAlteradoEvent>
    {
        private readonly IHubContext<SensorHub> _hub;

        public SensorConsumer(IHubContext<SensorHub> hub)
        {
            _hub = hub;
        }

        public Task Consume(ConsumeContext<SensorInfoAlteradoEvent> context)
        {
            var msg = context.Message;
            MongoDbContext dbContext = new MongoDbContext();
            dbContext.Barragens.FindOneAndUpdateAsync(
                Builders<Barragem>.Filter.Where(b => b.Id == msg.BarragemId),
                Builders<Barragem>.Update.Push(x => x.EventoSensores, context.Message)
            );

            _hub.Clients.All.SendAsync("transfersensordata", msg);
            return Task.CompletedTask;  
        }
    }
}
