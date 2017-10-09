using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Models;
using JetBrains.Annotations;

namespace Assets.Scripts.Lamps
{
    class LampMap : IEnumerable<Lamp>
    {
        private IDictionary<DeviceInfo, Lamp> _lamps;

        public LampMap()
        {
            _lamps = new Dictionary<DeviceInfo, Lamp>(DeviceInfo.DeviceIdComparer);
        }

        public void AddLamp([NotNull] DeviceInfo deviceInfo,[NotNull] Lamp lamp)
        {
            _lamps.Add(deviceInfo,lamp);
        }

        public Lamp GetLamp([NotNull] DeviceInfo deviceInfo)
        {
            return _lamps[deviceInfo];
        }

        public Lamp this[[NotNull] DeviceInfo deviceInfo]
        {
            get { return _lamps[deviceInfo]; }
            set { _lamps[deviceInfo] = value; }
        }

        public IEnumerator<Lamp> GetEnumerator()
        {
            return _lamps.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
