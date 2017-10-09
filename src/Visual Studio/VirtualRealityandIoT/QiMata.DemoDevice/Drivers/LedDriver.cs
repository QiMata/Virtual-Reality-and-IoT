using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace QiMata.DemoDevice.Drivers
{
    class LedDriver
    {
        private readonly GpioPin _gpioPin;

        public LedDriver(int pinNumber)
        {
            _gpioPin = GpioController.GetDefault().OpenPin(pinNumber, GpioSharingMode.Exclusive);
            _gpioPin.SetDriveMode(GpioPinDriveMode.Output);
        }

        public void TurnOn()
        {
            _gpioPin.Write(GpioPinValue.High);
        }

        public void TurnOff()
        {
            _gpioPin.Write(GpioPinValue.Low);
        }

        public void Toggle()
        {
            var mode = _gpioPin.Read();

            if (mode == GpioPinValue.High)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }
        }
    }
}
