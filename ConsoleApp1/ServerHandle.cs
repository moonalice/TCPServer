using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // This is a part you deal with Server when it receives message from client.
    class ServerHandle
    {
        public static string _info;
        public static int _clientIdCheck;

        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            _clientIdCheck = _packet.ReadInt();
            _info = _packet.ReadString();

            Console.WriteLine($"\n{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");
            Console.WriteLine($"\nServer Info : {_info}");


            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"Player \"{_info}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
            }

        }
        
        public static void receivedMessageTest(int _toClient, Packet _packet)
        {
            _info = _packet.ReadString();
            Console.WriteLine($"\n{Server.clients[_toClient].tcp.socket.Client.RemoteEndPoint}에게 보냅니다..");
            Console.WriteLine($"\nReceived: {_info}");

        }



        public static void ButtonClick(int _fromClient, Packet _packet)     //클라이언트가 보낸 패킷 형태의 데이터를 받는다.
        {
            _info = _packet.ReadString();
            Console.WriteLine($"\nServer Info Name : {_info}");

            ServerSend.SendUserInfoToAll(_fromClient, "received data");     //데이터를 해석하고 ServerSend를 이용하여 다시 클라이언트에게 데이터를 받았다는 메세지 전달.
        }
    }

}
