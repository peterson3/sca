using System;

namespace SCA.IntegrationEvents.Sensor
{
    public class SensorInfoAlteradoEvent
    {
        public int Temperatura { get; set; }
        public int Volume { get; set; }
        public int Pressao { get; set; }
        public int BarragemId { get; set; }
        public DateTime HorarioMedicao { get; set; }
    }
}
