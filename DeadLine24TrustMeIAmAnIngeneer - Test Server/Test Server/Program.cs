using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestServer
{
	class Program
	{
		static void Main(string[] args)
		{
			//TcpListener server = new TcpListener(DL24.Credentials.TestCredential.AddressIP, DL24.Credentials.TestCredential.Port);
			//server.Start();
			//TcpClient client = server.AcceptTcpClient();

			createListener();

			//server.Stop();
		}

		public static void createListener()
		{
			// Create an instance of the TcpListener class.
			TcpListener tcpListener = null;
			//IPAddress ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
			try
			{
				// Set the listener on the local IP address 
				// and specify the port.
				tcpListener = new TcpListener(1302);//DL24.Credentials.TestCredential.AddressIP, DL24.Credentials.TestCredential.Port);

				tcpListener.Start();
				Console.WriteLine("Waiting for a connection...");
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: " + e.ToString());
				//MessageBox.Show(output);
				return;
			}

			//while (true)
			{
				// Always use a Sleep call in a while(true) loop 
				// to avoid locking up your CPU.
				Thread.Sleep(10);
				// Create a TCP socket. 
				// If you ran this server on the desktop, you could use 
				// Socket socket = tcpListener.AcceptSocket() 
				// for greater flexibility.
				TcpClient tcpClient = tcpListener.AcceptTcpClient();
				NetworkStream stream = tcpClient.GetStream();

				byte[] bytesSent = Encoding.ASCII.GetBytes("LOGIN\n");
				stream.Write(bytesSent, 0, bytesSent.Length);
				Console.WriteLine("LOGIN sended");

				byte[] bytes = new byte[256];
				stream.Read(bytes, 0, bytes.Length);

				bytesSent = Encoding.ASCII.GetBytes("PASS\n");
				stream.Write(bytesSent, 0, bytesSent.Length);
				Console.WriteLine("PASS sended");

				stream.Read(bytes, 0, bytes.Length);

				bytesSent = Encoding.ASCII.GetBytes("OK\n");
				stream.Write(bytesSent, 0, bytesSent.Length);
				Console.WriteLine("OK sended");


				/*
				// Read the data stream from the client. 
				byte[] bytes = new byte[256];
				NetworkStream stream = tcpClient.GetStream();
				stream.Read(bytes, 0, bytes.Length);
				SocketHelper helper = new SocketHelper();
				helper.processMsg(tcpClient, stream, bytes);
				*/

				Console.ReadLine();
			}
		}

		class SocketHelper
		{
			TcpClient mscClient;
			string mstrMessage;
			string mstrResponse;
			byte[] bytesSent;
			public void processMsg(TcpClient client, NetworkStream stream, byte[] bytesReceived)
			{
				// Handle the message received and  
				// send a response back to the client.
				mstrMessage = Encoding.ASCII.GetString(bytesReceived, 0, bytesReceived.Length);
				mscClient = client;
				mstrMessage = mstrMessage.Substring(0, 5);
				if (mstrMessage.Equals("Hello"))
				{
					mstrResponse = "Goodbye";
				}
				else
				{
					mstrResponse = "What?";
				}
				bytesSent = Encoding.ASCII.GetBytes(mstrResponse);
				stream.Write(bytesSent, 0, bytesSent.Length);
			}
		}
	}
}
