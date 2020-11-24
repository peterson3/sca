using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Sensor
{
    public class SensorInfo
    {
        public int Temperatura { get; set; }
        public int Volume { get; set; }
        public int Pressao { get; set; }

        public static SensorInfo GenerateRandom()
        {
            Random rnd = new Random();
            return new SensorInfo()
            {
                Temperatura = rnd.Next(1, 13), // creates a number between 1 and 12
                Volume = rnd.Next(1, 7), // creates a number between 1 and 6
                Pressao = rnd.Next(52) // creates a number between 0 and 51
            };

        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }


}
