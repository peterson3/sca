using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCA.Barragens.API.Communication
{
    public class ServiceBus
    {
        public ServiceBus()
        {

        }
        public Task PublicarEvento<T>(T evento) where T : class
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost"), host =>
                {
                    host.Username("guest");
                    host.Password("guest");
                });
            });

            busControl.Start();

            busControl.Publish(evento).Wait();

            busControl.Stop();

            return Task.CompletedTask;
        }
    }
}
