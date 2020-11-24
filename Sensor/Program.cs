using SCA.IntegrationEvents.Sensor;
using Sensor.Communication;
using System;

namespace Sensor
{
    class Program
    {
        static void Main(string[] args)
        {

           var bus = new ServiceBus();
           while (true)
            {
                var info = SensorInfo.GenerateRandom();

                var evento = new SensorInfoAlteradoEvent()
                {
                    BarragemId = 38,
                    HorarioMedicao = DateTime.Now,
                    Pressao = info.Pressao,
                    Temperatura = info.Temperatura,
                    Volume = info.Volume
                };

                bus.PublicarEvento<SensorInfoAlteradoEvent>(evento);
                //ServicoInteg.Enviar(info);
                Console.WriteLine(info.ToString());
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
