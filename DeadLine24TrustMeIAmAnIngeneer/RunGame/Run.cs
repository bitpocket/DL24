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
		private static IGame testGame;

		public static void RunGame()
		{
			testGame = new GameTest();

			Login.StartRecieving(Credentials.CredentialTestGame2, Recieved);
			//Login.Send("Hello World");
		}

		private static void Recieved(string messageRecieved)
		{
			Log.Add(messageRecieved);
			string responce = testGame.ProcessResponce(messageRecieved);

			Login.StartRecieving(Credentials.CredentialTestGame2, Recieved);
		}
	}
}
