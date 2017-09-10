using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

namespace QiMata.CloudGateway
{
    public class Gateway
    {
        private readonly DeviceClient _deviceClient;

        public Gateway(string connectionString)
        {
            _deviceClient = DeviceClient.CreateFromConnectionString(connectionString);
        }

        public async Task Send<T>(T obj,IDictionary<string,string> properties = null)
        {
            var messageString = JsonConvert.SerializeObject(obj);
            var message = new Message(Encoding.ASCII.GetBytes(messageString));

            if (properties != null)
            {
                foreach (var property in properties)
                {
                    message.Properties[property.Key] = property.Value;
                }
            }

            await _deviceClient.SendEventAsync(message);
        }
    }
}
