using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QiMata.CloudGateway;
using QiMata.DemoDevice.Drivers;

namespace QiMata.DemoDevice.Services
{
    class GatewayService
    {
        private LedDriver _webCallIndicator;
        private Gateway _gateway;

        public GatewayService(LedDriver webCallIndicator, Gateway gateway)
        {
            _webCallIndicator = webCallIndicator;
            _webCallIndicator.TurnOff();

            _gateway = gateway;
        }

        public GatewayService(Gateway gateway)
            : this(Driver.WebCallIndicator,gateway)
        {}

        public async Task SendMessage<T>(T message, IDictionary<string, string> properties = null)
        {
            _webCallIndicator.TurnOn();
            await _gateway.Send(message,properties);
            _webCallIndicator.TurnOff();
        }
    }
}
