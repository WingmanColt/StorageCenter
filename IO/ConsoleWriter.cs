using System;
using StorageMaster.IO.Contracts;

namespace StorageMaster.IO
{
	public class ConsoleWriter : IWriter
	{
		public void WriteLine(string message)
		{
			Console.WriteLine(message);
		}
	}
}