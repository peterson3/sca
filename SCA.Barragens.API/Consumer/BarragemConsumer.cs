using MassTransit;
using Microsoft.AspNetCore.SignalR;
using SCA.Barragens.API.DataStorage;
using SCA.Barragens.API.HubConfig;
using SCA.Barragens.API.Models;
using SCA.IntegrationEvents.Ativo;
using SCA.IntegrationEvents.Sensor;
using System;
using System.Threading.Tasks;

namespace SCA.Barragens.API.Consumer
{
    public class BarragemConsumer : IConsumer<AtivoAdicionadoEvent>
    {
        private readonly IHubContext<ChartHub> _hub;

        public BarragemConsumer(IHubContext<ChartHub> hub)
        {
            _hub = hub;
        }
        public Task Consume(ConsumeContext<AtivoAdicionadoEvent> context)
        {
            if (context.Message.TipoId == 1)
            {
                var msg = context.Message;
                //_hub.Clients.All.SendAsync("transferchartdata", msg);
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

        public Task Consume(ConsumeContext<SensorInfoAlteradoEvent> context)
        {
            var msg = context.Message;
            _hub.Clients.All.SendAsync("transfersensordata", msg);
            return Task.CompletedTask;
        }
    }
}
