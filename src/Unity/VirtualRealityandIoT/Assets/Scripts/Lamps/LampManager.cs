using System.Collections.Generic;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Lamps
{
    class LampManager
    {
        private LampMap _lamps;


        public LampManager()
        {
            _lamps = new LampMap();
            
            var backLeftLamp = GameObject.Find("torchere_1 (1)").GetComponentInChildren<Lamp>(true);
            var frontLeftLamp = GameObject.Find("torchere_1").GetComponentInChildren<Lamp>(true);
            var frontRightLamp = GameObject.Find("torchere_1 (2)").GetComponentInChildren<Lamp>(true);
            var backRightLamp = GameObject.Find("torchere_1 (3)").GetComponentInChildren<Lamp>(true);

            _lamps.AddLamp(new DeviceInfo
            {
                DeviceId = "TopLeftButton"
            }, backLeftLamp);

            _lamps.AddLamp(new DeviceInfo
            {
                DeviceId = "TopRightButton"
            }, backRightLamp);

            _lamps.AddLamp(new DeviceInfo
            {
                DeviceId = "BottomLeftButton"
            }, frontLeftLamp);

            _lamps.AddLamp(new DeviceInfo
            {
                DeviceId = "BottomRightButton"
            }, frontRightLamp);
        }

        public void TurnOn(DeviceInfo deviceInfo)
        {
            _lamps[deviceInfo].TurnOn();
        }

        public void TurnOn()
        {
            foreach (var lamp in _lamps)
            {
                lamp.TurnOn();
            }
        }

        public void TurnOff(DeviceInfo deviceInfo)
        {
            _lamps[deviceInfo].TurnOff();
        }

        public void TurnOff()
        {
            foreach (var lamp in _lamps)
            {
                lamp.TurnOff();
            }
        }

        public void Toggle(DeviceInfo deviceInfo)
        {
            _lamps[deviceInfo].Toggle();
        }

        public void Toggle()
        {
            foreach (var lamp in _lamps)
            {
                lamp.Toggle();
            }
        }
    }
}
