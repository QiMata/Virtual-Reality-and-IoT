﻿using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.SignalRConnector;
using Assets.SignalRConnector.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalR.Client._20.Hubs;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private HubConnection _connection;
    private IHubProxy _proxy;

    private MainThreadMarshallHelper _mainThreadMarshallHelper;
    private LampManager _lampManager;
    private RainManager _rainManager;
    private FireManager _fireManager;
    
    // Use this for initialization
    public void Start ()
    {
        _mainThreadMarshallHelper = new MainThreadMarshallHelper();
        _lampManager = new LampManager();
        _rainManager = new RainManager();
        _fireManager = new FireManager();

		_connection = new HubConnection("http://virtualrealityandiot.azurewebsites.net/");
        _proxy = _connection.CreateProxy("TopicHub");
        _proxy.Subscribe("NewData").Data += data =>
        {
            JToken dat = data[0] as JToken;

            if (dat["RisingEdge"] != null)
            {
                var buttonPressedMessage = dat.ToObject<ButtonPressedMessage>();
                if (buttonPressedMessage.RisingEdge)
                {
                    _mainThreadMarshallHelper.MarshallToMainThread(() => _lampManager.Toggle());
                }
            }

            if (dat["Temperature"] != null)
            {
                var tempAndHumidityMessage = dat.ToObject<TempAndHumidityReading>();
                _mainThreadMarshallHelper.MarshallToMainThread(() =>
                {
                    _rainManager.SetHumidity(tempAndHumidityMessage.Humidity);
                    _fireManager.AddTemperature(tempAndHumidityMessage.Temperature);
                });
            }
        };

        _connection.Start();
    }
    // Update is called once per frame
    public void Update ()
    {
		_mainThreadMarshallHelper.OnMainThread();
	}

    //Destroy is called when behaviour is destroyed
    public void OnDestroy()
    {
        if (_connection != null)
        {
            _connection.Stop();
        }
    }
}
