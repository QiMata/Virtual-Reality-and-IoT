using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Lamp : MonoBehaviour
    {
        private Renderer _renderer;
        private Color _initialColor;

        // Use this for initialization
        void Start()
        {
            _renderer = this.gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>();
            _initialColor = _renderer.material.color;
        }

        public void TurnOn()
        {
            _renderer.material.color = Color.yellow;
        }

        public void TurnOff()
        {
            _renderer.material.color = _initialColor;
        }

        public void Toggle()
        {
            if (_renderer.material.color == Color.yellow)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }
        }
    }
}
