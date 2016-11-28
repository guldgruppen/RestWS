using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace WCFServiceWebRole1
{
    public class UdpServerHandler
    {
        private static UdpServerHandler _instance;
        public static UdpServerHandler Instance = _instance ?? new UdpServerHandler();
        private UdpClient _udpClient;
        private IPEndPoint _endPoint;
        private UdpServerHandler()
        {
            _udpClient = new UdpClient(8888);
            _endPoint = new IPEndPoint(IPAddress.Any, 8888);
        }
        public string GetDataFromUdp()
        {

            Byte[] receiveBytes = _udpClient.Receive(ref _endPoint);
            string receivedData = Encoding.ASCII.GetString(receiveBytes);
            return receivedData;
        }
    }
}