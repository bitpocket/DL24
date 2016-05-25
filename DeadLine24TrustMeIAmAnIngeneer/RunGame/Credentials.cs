using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL24
{
	public class Credentials
	{
		public static Credential CredentialRoboty = new Credential()
		{
			Host = "universum.dl24",
			Port = 20003,
			Login = "team1",
			Password = "dweioirgdt"
		};

		public static Credential CredentialTestGame1 = new Credential()
		{
			Host = "dl24-lite.fp.lan",
			Port = 80,
			Login = "team1",
			Password = "dweioirgdt"
		};

		public static Credential CredentialTestGame2 = new Credential()
		{
			Host = "127.0.0.1",
			Port = 1302,
			Login = "team1",
			Password = "dweioirgdt"
		};
	}
}
