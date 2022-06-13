using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Core;

public static class PingHelper
{
    public static async Task<bool> PingIPAsync(string host,CancellationToken token)
    {
        try
        {
            var ping = new System.Net.NetworkInformation.Ping();
            var reply = await ping.SendPingAsync(host).WaitAsync(token);
            if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }

    public static async Task PingPortAsync(string host,string port, CancellationToken token)
    {
        try
        {
            System.Net.IPAddress iPAddress = System.Net.IPAddress.Parse(host);
            System.Net.IPEndPoint ep = new System.Net.IPEndPoint(iPAddress, Convert.ToInt32(port));
            using (var socket=new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork,System.Net.Sockets.SocketType.Stream,System.Net.Sockets.ProtocolType.Tcp))
            {
                await socket.ConnectAsync(ep,token);
            }
        }
        catch 
        {

        }
    }
}

