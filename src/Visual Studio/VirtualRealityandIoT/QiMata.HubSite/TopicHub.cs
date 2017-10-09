using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            using (var stream = obj.GetBody<Stream>())
            {
                var bytes = ReadFully(stream);
                var str = Encoding.UTF8.GetString(bytes);
                var deserializedObject = JToken.Parse(str);


                deserializedObject[$"Headers.{nameof(BrokeredMessage.ContentType)}"] = obj.ContentType;
                deserializedObject[$"Headers.{nameof(BrokeredMessage.CorrelationId)}"] = obj.CorrelationId;
                deserializedObject[$"Headers.{nameof(BrokeredMessage.Label)}"] = obj.Label;
                deserializedObject[$"Headers.{nameof(BrokeredMessage.MessageId)}"] = obj.MessageId;
                deserializedObject[$"Headers.{nameof(BrokeredMessage.SessionId)}"] = obj.SessionId;
                deserializedObject[$"Headers.{nameof(BrokeredMessage.Size)}"] = obj.Size;
                foreach (KeyValuePair<string, object> keyValuePair in obj.Properties)
                {
                    deserializedObject[$"Headers.Properties.{keyValuePair.Key}"] =
                        JToken.FromObject(keyValuePair.Value);
                }

                Clients.All.NewData(deserializedObject);
            }
        }

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}