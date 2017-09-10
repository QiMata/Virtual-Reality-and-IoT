using System.Collections;
using System.Collections.Generic;
using Assets.SignalRConnector;
using Newtonsoft.Json.Linq;
using SignalR.Client._20.Hubs;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private HubConnection _connection;
    private IHubProxy _proxy;

    private MainThreadMarshallHelper _mainThreadMarshallHelper;
    
    // Use this for initialization
    void Start ()
    {
        _mainThreadMarshallHelper = new MainThreadMarshallHelper();

		_connection = new HubConnection("http://virtualrealityandiot.azurewebsites.net");
        _proxy = _connection.CreateProxy("TopicHub");
        _proxy.Subscribe("NewData").Data += data =>
        {
            JToken dat = data[0] as JToken;
        };
    }

    // Update is called once per frame
    void Update ()
    {
		_mainThreadMarshallHelper.OnMainThread();
	}

    //Destroy is called when behaviour is destroyed
    void OnDestroy()
    {
        if (_connection != null)
        {
            _connection.Stop();
        }
    }
}
