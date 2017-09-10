using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.ServiceBus.Messaging;

namespace QiMata.HubSite
{
    public class TopicHub : Hub
    {
        private const string TopicConnectionString =
                "Endpoint=sb://virtualrealityandiot.servicebus.windows.net/;SharedAccessKeyName=admin;SharedAccessKey=/taHNNLG70LImDw1UNGNZLHr+eaKJX7pDsN/kF0P24k="
            ;

        private SubscriptionClient _subscriptionClient;

        public TopicHub()
        {
            _subscriptionClient = SubscriptionClient.CreateFromConnectionString(TopicConnectionString, "virtualrealityandiot", "virtualrealityandiot");
            _subscriptionClient.OnMessage(DataRecieved);
        }

        private void DataRecieved(BrokeredMessage obj)
        {
            Clients.All.NewData(obj.GetBody<object>());
        }
    }
}