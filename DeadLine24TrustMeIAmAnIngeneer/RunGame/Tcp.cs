using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DL24
{
	class Tcp
	{
		public static void Send(Socket socket, byte[] buffer, int offset, int size, int timeout)
		{
			int startTickCount = Environment.TickCount;
			int sent = 0;  // how many bytes is already sent
			do
			{
				if (Environment.TickCount > startTickCount + timeout)
					throw new Exception("Timeout.");
				try
				{
					sent += socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
				}
				catch (SocketException ex)
				{
					if (ex.SocketErrorCode == SocketError.WouldBlock ||
						ex.SocketErrorCode == SocketError.IOPending ||
						ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
					{
						// socket buffer is probably full, wait and try again
						Thread.Sleep(30);
					}
					else
						throw ex;  // any serious error occurr
				}
			} while (sent < size);
		}

		public delegate void RecieveCallback(string message);

		public static void Receive(Socket socket, int timeout, RecieveCallback callback)
		{
			int size = 256;
			byte[] buffer = new byte[size];
			int startTickCount = Environment.TickCount;
			int received = 0;  // how many bytes is already received
			do
			{
				if (Environment.TickCount > startTickCount + timeout)
					throw new Exception("Timeout.");
				try
				{
					received += socket.Receive(buffer, received, size - received, SocketFlags.None);
					string mstrMessage = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
					callback(mstrMessage);
				}
				catch (SocketException ex)
				{
					if (ex.SocketErrorCode == SocketError.WouldBlock ||
						ex.SocketErrorCode == SocketError.IOPending ||
						ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
					{
						// socket buffer is probably empty, wait and try again
						Thread.Sleep(30);
					}
					else
						throw ex;  // any serious error occurr
				}
			} while (received < size);
		}

		//public static void Receive(Socket socket, byte[] buffer, int offset, int size, int timeout, RecieveCallback callback)
		//{
		//	int startTickCount = Environment.TickCount;
		//	int received = 0;  // how many bytes is already received
		//	do
		//	{
		//		if (Environment.TickCount > startTickCount + timeout)
		//			throw new Exception("Timeout.");
		//		try
		//		{
		//			received += socket.Receive(buffer, offset + received, size - received, SocketFlags.None);
		//			string mstrMessage = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
		//			callback(mstrMessage);
		//		}
		//		catch (SocketException ex)
		//		{
		//			if (ex.SocketErrorCode == SocketError.WouldBlock ||
		//				ex.SocketErrorCode == SocketError.IOPending ||
		//				ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
		//			{
		//				// socket buffer is probably empty, wait and try again
		//				Thread.Sleep(30);
		//			}
		//			else
		//				throw ex;  // any serious error occurr
		//		}
		//	} while (received < size);
		//}


	}
}
