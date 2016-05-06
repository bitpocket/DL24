using System.Net;

namespace DL24
{
	public class Credential
	{
		public string Host;
		public int Port;
		public string Login;
		public string Password;

		public IPAddress AddressIP
		{
			get
			{
				return Dns.GetHostEntry(Host).AddressList[0];

			}
		}

	}
}