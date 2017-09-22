using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Sensors.Dht;

namespace QiMata.DemoDevice.Drivers
{
    class DhtDriver
    {
        private IDht _dht;

        public DhtDriver(int pinNumber)
        {
            _dht = new Dht11(GpioController.GetDefault().OpenPin(pinNumber, GpioSharingMode.Exclusive),
                GpioPinDriveMode.Input);
        }

        public Task<DhtReading> GetReadingAsync()
        {
            return _dht.GetReadingAsync().AsTask();
        }
    }
}
