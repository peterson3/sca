using SCA.IntegrationEvents.Sensor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCA.Barragens.API.Models
{
    public class Barragem
    {
        public Barragem()
        {
            EventoSensores = new List<SensorInfoAlteradoEvent>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public int VolumeMax { get; set; }

        public double Lat { get; set; }
        public double Long { get; set; }

        public IEnumerable<SensorInfoAlteradoEvent> EventoSensores { get; set; }
    }
}
