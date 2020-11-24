using System;
using System.Collections.Generic;
using System.Text;

namespace Sensor
{
    public class ServicoInteg
    {
        public static void Enviar(SensorInfo info)
        {
            string url = "";
            string sensorId = "";
            var client = new RestSharp.RestClient(url);
            var request = new RestSharp.RestRequest(sensorId);
            client.Execute(request);
        }
    }
}
