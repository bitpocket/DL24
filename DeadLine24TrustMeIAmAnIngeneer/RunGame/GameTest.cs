using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DL24
{
	class GameTest : IGame
	{
		private Credential credential = Credentials.CredentialTestGame1;
		public GameTest()
		{
			ServerTokens = new Dictionary<string, ProcessResponceFunction>();

			ServerTokens.Add("LOGIN", LOGIN_Responce);
			ServerTokens.Add("PASS", LOGIN_Password);
			ServerTokens.Add("OK", LOGIN_OK);
		}

		delegate string ProcessResponceFunction(string messageRecieved);

		Dictionary<string, ProcessResponceFunction> ServerTokens;

		public string ProcessResponce(string messageRecieved)
		{
			ProcessResponceFunction processResponceFunction;

			if (ServerTokens.TryGetValue(messageRecieved, out processResponceFunction))
			{
				string res = processResponceFunction(messageRecieved);
				return res;
			}
			else
			{
				//Log.Add($"{messageRecieved} is not implemented");
				return "";
			}
		}

		//public void Send(string message)
		//{
		//	stream.Write(bytesSent, 0, bytesSent.Length);
		//}

		string LOGIN_Responce(string message)
		{
			return credential.Login;
		}
		string LOGIN_Password(string message)
		{
			return credential.Password;
		}
		string LOGIN_OK(string message)
		{
			return "";
		}
	}
}
