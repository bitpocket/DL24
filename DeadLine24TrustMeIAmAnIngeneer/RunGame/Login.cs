using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DL24
{
	class Login
	{
		public static void StartRecieving(Credential credential, Tcp.RecieveCallback callback)
		{
			TcpClient tcpClient = new TcpClient();
			tcpClient.Connect(credential.Host, credential.Port);

			Socket socket = tcpClient.Client;
			socket.NoDelay = true;
			//byte[] buffer = new byte[12];  // length of the text "Hello world!"
			try
			{
				byte[] bytes = new byte[256];
				NetworkStream stream = tcpClient.GetStream();
				stream.Read(bytes, 0, bytes.Length);
				string res = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
				callback(res);
				// receive data with timeout 10s
				//Tcp.Receive(socket, buffer, 0, buffer.Length, 10000, RecieveCallBack);
				//Tcp.Receive(socket, 10000, callback);
				//string str = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
				//Log.Add(str);
			}
			catch (Exception ex)
			{
				Log.Add(ex.Message);
			}

		}

		public static void Send(string message)
		{
			TcpClient tcpClient = new TcpClient();
			tcpClient.Connect("", 80);

			Socket socket = tcpClient.Client;
			//string str = "Hello world!";

			try
			{
				// sends the text with timeout 10s
				Tcp.Send(socket, Encoding.UTF8.GetBytes(message), 0, message.Length, 10000);
			}
			catch (Exception ex)
			{
				Log.Add(ex.Message);
			}
		}

		public static void ProcesLogin()
		{
			
		}
	}
}
