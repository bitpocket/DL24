using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DL24
{
	class Program
	{
		static TcpClient tcpClient = new TcpClient();

		static void Main(string[] args)
		{
			Credential CredentialRoboty = new Credential()
			{
				Host = "universum.dl24",
				Port = 20000,
				Login = "team1",
				Password = "dweioirgdt"
			};

			//TcpClient tcpClient = new TcpClient();
			tcpClient.Connect(CredentialRoboty.Host, CredentialRoboty.Port);

			string[] res;

			do
			{
				res = Recieve();
				Log.AddFromServer(res);

				

				if (res[0] == "LOGIN")
				{
					Send(CredentialRoboty.Login);
				}

				if (res[0] == "PASS")
				{
					Send(CredentialRoboty.Password);
				}

			} while (res[0] != "OK");

			Send("DESCRIBE_WORLD");
			res = Recieve();
			Log.AddFromServer(res);

			Console.WriteLine("> finished.");
			Console.ReadKey();
		}

		public static string[] Recieve()
		{
			Socket socket = tcpClient.Client;
			socket.NoDelay = true;
			//byte[] buffer = new byte[12];  // length of the text "Hello world!"
			try
			{
				byte[] bytes = new byte[256];
				NetworkStream stream = tcpClient.GetStream();


				
				List<string> res4 = new List<string>();

				do
				{

				} while (!stream.DataAvailable);

				while (stream.DataAvailable)
				{
					List<string> res3 = new List<string>();
					do
					{
						
						var len = stream.DataAvailable;
						stream.Read(bytes, 0, bytes.Length);

						var ContentLength = 0;

						for (int i = 0; i < bytes.Length; i++)
						{
							if (bytes[i] == '\0')
							{
								ContentLength = i;
								break;
							}
						}

						string res = Encoding.UTF8.GetString(bytes, 0, ContentLength);
						string[] res2 = res.Split('\n');


						for (int i = 0; i < res2.Length; i++)
						{
							if (res2[i] != "")
							{
								res3.Add(res2[i]);
							}
						}
					} while (res3.Count == 0);

					res4.AddRange(res3);
                }

				return res4.ToArray();
				// receive data with timeout 10s
				//Tcp.Receive(socket, buffer, 0, buffer.Length, 10000, RecieveCallBack);
				//Tcp.Receive(socket, 10000, callback);
				//string str = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
				//Log.Add(str);
			}
			catch (Exception ex)
			{
				//Log.Add(ex.Message);
				return new string[1] { ex.Message };
			}
		}

		public static void Send(string msg)
		{
			//TcpClient tcpClient = new TcpClient();
			//tcpClient.Connect("", 80);
			Log.AddFromClient(msg);
			msg += "\n";

			Socket socket = tcpClient.Client;
			//string str = "Hello world!";

			try
			{
				// sends the text with timeout 10s
				Tcp.Send(socket, Encoding.UTF8.GetBytes(msg), 0, msg.Length, 10000);
			}
			catch (Exception ex)
			{
				//Log.Add(ex.Message);
			}
		}
	}
}
