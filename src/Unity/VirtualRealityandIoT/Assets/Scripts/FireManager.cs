using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigitalRuby.PyroParticles;
using UnityEngine;

namespace Assets.Scripts
{
    class FireManager
    {
        private GameObject _gameObject;

        public FireManager()
        {
            _gameObject = GameObject.Find("SmallFires");
            _gameObject.SetActive(false);
        }

        public void AddTemperature(decimal temperature)
        {
            _gameObject.SetActive(temperature >= 30);
            if (temperature >= 30)
            {
                _gameObject.GetComponent<FireConstantBaseScript>().Start();
            }
            else
            {
                _gameObject.GetComponent<FireConstantBaseScript>().Stop();
            }
        }
    }
}
