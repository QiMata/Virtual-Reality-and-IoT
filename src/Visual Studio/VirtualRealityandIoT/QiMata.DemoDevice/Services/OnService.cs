using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QiMata.DemoDevice.Drivers;

namespace QiMata.DemoDevice.Services
{
    class OnService
    {
        private LedDriver _onIndicator;
        private Task _backgroundTask;

        private bool _keepGoing;

        public OnService(LedDriver onIndicator)
        {
            _onIndicator = onIndicator;
        }

        public OnService()
        {
            _onIndicator = Driver.OnIndicator;
        }

        public void Start()
        {
            _keepGoing = true;
            if (_backgroundTask == null || _backgroundTask.IsCompleted)
            {
                _backgroundTask = Background();
            }
        }

        public void Stop()
        {
            _keepGoing = false;
        }

        private async Task Background()
        {
            while (_keepGoing)
            {
                _onIndicator.Toggle();
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}
