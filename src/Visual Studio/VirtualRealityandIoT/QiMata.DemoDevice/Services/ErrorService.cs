using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QiMata.DemoDevice.Drivers;

namespace QiMata.DemoDevice.Services
{
    class ErrorService
    {
        private LedDriver _errorIndicator;
        private bool _sendingError;

        public ErrorService(LedDriver errorIndicator)
        {
            _errorIndicator = errorIndicator;
            _errorIndicator.TurnOff();
        }

        public ErrorService()
            : this(Driver.ErrorIndicator)
        {}

        public void SendError()
        {
            if (!_sendingError)
            {
                SendErrorBackground();
            }
        }

        private async Task SendErrorBackground()
        {
            _sendingError = true;
            _errorIndicator.TurnOn();
            await Task.Delay(TimeSpan.FromSeconds(1));
            _sendingError = false;
            _errorIndicator.TurnOff();
        }
    }
}
