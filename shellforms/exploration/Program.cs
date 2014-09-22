using System;

namespace exploration
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			while (true) {
				Console.CursorVisible = false;
				for (var row = 0; row < Console.WindowHeight - 1; row++) {
					Console.SetCursorPosition (0, row);
					Console.Write (new String ((DateTime.Now.Second % 9).ToString () [0], Console.WindowWidth - 1));
				}
				Console.CursorVisible = false;
				Console.Read ();
			}
		}
	}
}
