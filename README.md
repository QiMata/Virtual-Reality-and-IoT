# Virtual-Reality-and-IoT

<a href="https://azuredeploy.net/" target="_blank"><img src="http://azuredeploy.net/deploybutton.png"/></a>
<a href="https://www.qimata.com/wp-content/uploads/2017/03/Azure-IoT-Stream-Analytics-SignalR-.pptx" target="_blank"><img src="https://www.qimata.com/wp-content/uploads/2017/09/PowerPoint.png" height="60" width="60" /></a>

# Resources

<a href="https://developer.microsoft.com/en-us/windows/iot/downloads">IoT Dashboard (to create Windows IoT images)</a>

<a href="https://www.visualstudio.com/downloads">Visual Studio</a>

<a href="https://unity3d.com/get-unity/download">Unity 3d</a>

# Guides

<a href="https://developer.microsoft.com/en-us/windows/iot/getstarted">Getting started with Windows IoT</a>

<a href="https://developer.microsoft.com/en-us/windows/iot/samples/helloworld">UWP Hello world for Win IoT</a>

<a href="https://microsoft.hackster.io/en-US">IoT Projects</a>

<a href="https://azure.microsoft.com/en-us/develop/iot/">Azure IoT getting started guide</a>

<a href="https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-dotnet-how-to-use-topics-subscriptions">Azure Service Bus Topics</a>

<a href="https://unity3d.com/learn">Unity Documentation</a>

# Special Thanks

A special thanks to the <a href="https://github.com/oising/nivot.signalr.client.net35">SignalR client port for .NET 3.5, for v1.x and v2.x SignalR server</a>

# Abstract

Whether it’s called mixed reality, augmented reality, or virtual reality; changing the perceived reality of the user is here. This presentation will look at how to create IoT devices, pipe the data created by them through the cloud, and use that data to drive a virtual or mixed reality experience. Creating applications that interact with the data created by the user’s environment should become straightforward after this introduction.

# Description

Using IoT Devices, powered by Windows 10 IoT and Raspian, we can collect data from the world surrounding us. That data can be used to create interactive environments for mixed reality, augmented reality, or virtual reality. To move the captured data from the devices to the interactive environment, the data will travel through Microsoft’s Azure. First it will be ingested through the Azure IoT Hub. The IoT Hub provides the security, bi-directional communication, and input rates needed for the solution. We will move the data directly from the IoT Hub to an Azure Service Bus Topic. The Topic allows for data to be sent to every Subscription listening for the data that was input. Azure Web Apps subscribe to the Topics and forward the data through a SignalR Hub that forwards the data to a client. For this demo, the client is a Unity Application that creates a Virtual Reality simulation showcasing that data. 
Once finished with this introduction to these technologies, utilizing each component of this technology stack should be approachable. Before seeing the pieces come together, the technologies used in this demonstration may not seem useful to a developer. When combined, they create a powerful tool to share nearly unlimited amounts of incoming data across multiple channels.


