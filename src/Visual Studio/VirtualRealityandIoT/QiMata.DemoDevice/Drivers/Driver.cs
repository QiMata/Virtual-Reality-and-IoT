using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.DemoDevice.Drivers
{
    static class Driver
    {
        private static ButtonDriver _buttonDriver;
        public static ButtonDriver ButtonDriver => _buttonDriver ?? (_buttonDriver = new ButtonDriver(21));

        private static DhtDriver _dhtDriver;
        public static DhtDriver DhtDriver => _dhtDriver ?? (_dhtDriver = new DhtDriver(16));

        private static LedDriver _onIndicator;
        public static LedDriver OnIndicator => _onIndicator ?? (_onIndicator = new LedDriver(2));

        private static LedDriver _errorIndicator;
        public static LedDriver ErrorIndicator => _errorIndicator ?? (_errorIndicator = new LedDriver(3));

        private static LedDriver _buttonPressIndicator;

        public static LedDriver ButtonPressIndicator =>
            _buttonPressIndicator ?? (_buttonPressIndicator = new LedDriver(20));

        private static LedDriver _webCallIndicator;
        public static LedDriver WebCallIndicator => _webCallIndicator ?? (_webCallIndicator = new LedDriver(4));
    }
}
