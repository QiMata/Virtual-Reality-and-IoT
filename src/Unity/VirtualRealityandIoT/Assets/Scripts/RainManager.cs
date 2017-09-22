using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigitalRuby.RainMaker;
using UnityEngine;

namespace Assets.Scripts
{
    class RainManager
    {
        private RainScript _rainScript;

        public RainManager()
        {
            _rainScript = GameObject.Find("RainPrefab").GetComponent<RainScript>();
        }

        public void SetHumidity(decimal humidity)
        {
            var modifiedHumidity = humidity - 25;
            if (modifiedHumidity < 0)
            {
                modifiedHumidity = 0;
            }

            var rainIntensity = modifiedHumidity / 10;
            if (rainIntensity > 1)
            {
                rainIntensity = 1;
            }

            _rainScript.RainIntensity = (float)rainIntensity;
        }
    }
}
