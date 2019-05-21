using System;
using StorageMaster.IO.Contracts;

namespace StorageMaster.IO
{
	public class ConsoleReader : IReader
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}
	}
}
