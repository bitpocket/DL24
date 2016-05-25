using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DL24
{
	internal class Run
	{
		private static GameTest testGame;

		public static void RunGame()
		{
			testGame = new GameTest();



			//Login.StartRecieving(Credentials.CredentialRoboty, Recieved);
			//Login.Send("Hello World");
		}

		private static void Recieved(string messageRecieved)
		{
			//Log.Add(messageRecieved);
			string myResponce = testGame.ProcessResponce(messageRecieved);

			//testGame.Send(myResponce);

			Login.StartRecieving(Credentials.CredentialRoboty, Recieved);
		}
	}
}
