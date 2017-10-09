using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using QiMata.DemoDevice.Drivers;

namespace QiMata.DemoDevice.Services
{
    class ButtonService
    {
        private LedDriver _buttonIndicator;
        private ButtonDriver _button;

        public ButtonService(LedDriver buttonIndicator, ButtonDriver button, Func<Task> onButtonPressed)
        {
            _buttonIndicator = buttonIndicator;
            _buttonIndicator.TurnOff();
            _button = button;

            _button.ButtonPressedObservable
                .Where(x => x.EventArgs.Edge == GpioPinEdge.RisingEdge)
                .Subscribe(async x =>
            {
                DateTime startTime = DateTime.Now;
                _buttonIndicator.TurnOn();
                await onButtonPressed();
                var timeToWait = TimeSpan.FromSeconds(1) - (DateTime.Now - startTime);
                if (timeToWait > TimeSpan.Zero)
                {
                    await Task.Delay(timeToWait);
                }
                _buttonIndicator.TurnOff();
            });
        }

        public ButtonService(Func<Task> onButtonPressed)
            :this(Driver.ButtonPressIndicator,Driver.ButtonDriver, onButtonPressed)
        {}


    }
}
