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
using QiMata.DemoDevice.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace QiMata.DemoDevice
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private OnService _onService;
        private ButtonService _buttonService;
        private GatewayService _gatewayService;
        private ErrorService _errorService;

        public MainPage()
        {
            this.InitializeComponent();

            _onService = new OnService();
            _onService.Start();

            _buttonService = new ButtonService(OnButtonPressed);
            _gatewayService = new GatewayService(new Gateway("HostName=VirtualRealityandIoT.azure-devices.net;DeviceId=TopLeftButton;SharedAccessKey=lJccg9m6g6evjAygA6K64W3OURDeOdT9V87/wlWA580="));
            _errorService = new ErrorService();
        }

        private async Task OnButtonPressed()
        {
            try
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    TextBlock.Text = TextBlock.Text.Insert(0, $"Button Press Detected - {DateTime.Now:T}\n");
                });
                await _gatewayService.SendMessage(new ButtonPressedMessage
                {
                    RisingEdge = true
                });
            }
            catch (Exception)
            {
                _errorService.SendError();
            }
        }
    }
}
