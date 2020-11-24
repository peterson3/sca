using MassTransit;
using System;
using System.Threading.Tasks;

namespace Sensor.Communication
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
