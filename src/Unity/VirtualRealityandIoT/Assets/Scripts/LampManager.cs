using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class LampManager
    {
        private IEnumerable<Lamp> _lamps;


        public LampManager()
        {
            _lamps = GameObject.Find("Lamps").GetComponentsInChildren<Lamp>(true);
        }

        public void TurnOn()
        {
            foreach (var lamp in _lamps)
            {
                lamp.TurnOn();
            }
        }

        public void TurnOff()
        {
            foreach (var lamp in _lamps)
            {
                lamp.TurnOff();
            }
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
