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
            Console.WriteLine("Informe o Id da Barragem:");
            var idBarragem = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe o intervalo de envio de dados:");
            var tempoIntervaloSensoresSeg = Convert.ToInt32(Console.ReadLine());
           while (true)
            {
                var info = SensorInfo.GenerateRandom();

                var evento = new SensorInfoAlteradoEvent()
                {
                    BarragemId = idBarragem,
                    HorarioMedicao = DateTime.Now,
                    Pressao = info.Pressao,
                    Temperatura = info.Temperatura,
                    Volume = info.Volume
                };

                bus.PublicarEvento<SensorInfoAlteradoEvent>(evento);

                Console.WriteLine(info.ToString());
                System.Threading.Thread.Sleep(tempoIntervaloSensoresSeg*1000);
            }
        }
    }
}
