using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using QiMata.CloudGateway;
using QiMata.DemoDevice.Drivers;
using QiMata.DemoDevice.Messages;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace QiMata.DemoDevice
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Gateway _gateway;
        private ButtonDriver _buttonDriver;
        private DhtDriver _dhtDriver;

        private Task _dontCollectMeTask;

        public MainPage()
        {
            this.InitializeComponent();

            _gateway = new Gateway("{Your device connection string here}");
            _buttonDriver = new ButtonDriver(21);
            _dhtDriver = new DhtDriver(16);
            _buttonDriver.ButtonPressedObservable.Subscribe(async x =>
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
                {
                    TextBlock.Text = TextBlock.Text.Insert(0, $"Button Press Detected - {x.EventArgs.Edge} {DateTime.Now:T}\n");
                });
                await _gateway.Send(new ButtonPressedMessage
                {
                    RisingEdge = x.EventArgs.Edge == GpioPinEdge.RisingEdge
                });
            });
            _dontCollectMeTask = Task.Run(BackgroundTask);
        }

        public async Task BackgroundTask()
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                var reading = await _dhtDriver.GetReadingAsync();
                await Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
                {
                    TextBlock.Text = TextBlock.Text.Insert(0, $"New Dht11 Reading Detected - Humidity:{reading.Humidity}, Temperature:{reading.Temperature}, IsValid:{reading.IsValid}, Timedout:{reading.TimedOut} -  {DateTime.Now:T}\n");
                });
                if (reading.IsValid)
                {
                    await _gateway.Send(new TempAndHumidity
                    {
                        Humidity = reading.Humidity,
                        Temperature = reading.Temperature
                    });
                }
            }
        }
    }
}
