
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;

namespace Mirror.Tcp
{ 
    public class TcpTransport : Transport
    {
        private TcpListener listener;
        public int Port = 7777;

        public override IEnumerable<string> Scheme => new[] { "tcp4" };

        public override bool Supported => Application.platform != RuntimePlatform.WebGLPlayer;

        public override Task ListenAsync()
        {
            listener = TcpListener.Create(Port);
            listener.Server.NoDelay = true;
            listener.Start();
            return Task.CompletedTask;
        }

        public override void Disconnect()
        {
            listener?.Stop();
        }

        public override async Task<IConnection> ConnectAsync(Uri uri)
        {
            string host = uri.Host;
            int port = uri.IsDefaultPort ? Port : uri.Port;

            var client = new TcpClient(AddressFamily.InterNetworkV6);
            // works with IPv6 and IPv4
            client.Client.DualMode = true;

            // NoDelay disables nagle algorithm. lowers CPU% and latency
            // but increases bandwidth
            client.NoDelay = true;
            client.LingerState = new LingerOption(true, 10);

            await client.ConnectAsync(host, port);

            return new TcpConnection(client);
        }

        public override async Task<IConnection> AcceptAsync()
        {
            try
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                return new TcpConnection(client);
            }
            catch (ObjectDisposedException)
            {
                // expected,  the connection was closed
                return null;
            }
        }

        public override IEnumerable<Uri> ServerUri()
        {
            var builder = new UriBuilder
            {
                Host = Dns.GetHostName(),
                Port = this.Port,
                Scheme = "tcp4"
            };

            return new[] { builder.Uri } ;
        }

        public void OnApplicationQuit()
        {
            listener?.Stop();
        }
    }
}
