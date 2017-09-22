using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.Foundation;

namespace QiMata.DemoDevice.Drivers
{
    class ButtonDriver
    {
        private GpioPin _pin;

        public ButtonDriver(int pinNumber)
        {
            _pin = GpioController.GetDefault().OpenPin(pinNumber, GpioSharingMode.Exclusive);
            _pin.SetDriveMode(_pin.IsDriveModeSupported(GpioPinDriveMode.InputPullUp)
                ? GpioPinDriveMode.InputPullUp
                : GpioPinDriveMode.Input);
            _pin.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            var observerable = WindowsObservable.FromEventPattern<GpioPin, GpioPinValueChangedEventArgs>(
                x => _pin.ValueChanged += x,
                x => _pin.ValueChanged -= x);
        }

        public IObservable<EventPattern<GpioPin, GpioPinValueChangedEventArgs>> ButtonPressedObservable => WindowsObservable.FromEventPattern<GpioPin, GpioPinValueChangedEventArgs>(
            x => _pin.ValueChanged += x,
            x => _pin.ValueChanged -= x)
            .Throttle(TimeSpan.FromSeconds(1));
    }
}
