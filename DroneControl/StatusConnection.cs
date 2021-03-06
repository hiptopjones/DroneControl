﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.Networking.Connectivity;

// From the SDK documents:

// Controlling the AR.Drone is done through 3 main communication services.

// Controlling and configuring the drone is done by sending AT commands on UDP port 5556.
// The transmission latency of the control commands is critical to the user experience. Those
// commands are to be sent on a regular basis (usually 30 times per second). The list of available
// commands and their syntax is discussed in chapter 6.

// Information about the drone (like its status, its position, speed, engine rotation speed, etc.),
// called navdata, are sent by the drone to its client on UDP port 5554. These navdata also include
// tags detection information that can be used to create augmented reality games. They are sent
// approximatively 15 times per second in demo mode, and 200 times per second in full (debug)
// mode.

// A video stream is sent by the AR.Drone to the client device on port 5555 (UDP for AR.Drone
// 1.0 , TCP for AR.Drone 2.0 ). Images from this video stream can be decoded using the codec
// included in this SDK. Its encoding format is discussed in section 7.2.

// A fourth communication channel, called control port, can be established on TCP port 5559 to
// transfer critical data, by opposition to the other data that can be lost with no dangerous effect.
// It is used to retrieve configuration data, and to acknowledge important information such as the
// sending of configuration information.

namespace DroneControl
{
    class StatusConnection
    {
        private const int StatusPort = 5554;
        private UdpConnection TransportConnection { get; set; }

        public bool IsConnected
        {
            get
            {
                return TransportConnection.IsConnected;
            }
        }

        public StatusConnection(string ipAddress)
        {
            TransportConnection = new UdpConnection(ipAddress, StatusPort);
            TransportConnection.MessageReceivedHandler = OnMessageReceived;
        }

        public async Task Connect()
        {
            await TransportConnection.Connect();
        }

        public async Task StartStatusStream()
        {
            await SendKeepAlive();
        }

        public async Task SendKeepAlive()
        {
            byte[] bytes = BitConverter.GetBytes(1);
            await TransportConnection.Send(bytes);
        }

        public void Close()
        {
            TransportConnection.Close();
        }

        private void OnMessageReceived(byte[] buffer)
        {
            Console.WriteLine("Status info received from drone: {0} bytes", buffer.Length);
        }
    }
}
