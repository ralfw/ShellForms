using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms
{
	// eine hierarchie von controls muss gezeichnet werden
	// womöglich aber auch nur ein teil, nämlich die, die sich verändert haben.
	// beim zeichnen volle fidelity: nicht nur text, sondern auch farben (vorder/hintergrund)
	// 

	class MessageLoop {
		public void Run() {
			OnStarted ();
			while (true) {
				var x = Console.CursorLeft;
				var y = Console.CursorTop;

				var key = Console.ReadKey ();

				Console.CursorLeft = x;
				Console.CursorTop = y;

				OnKey (key);
			}
		}

		public event Action OnStarted;
		public event Action<ConsoleKeyInfo> OnKey;
	}

	// device context bauen, auf dem man malen kann
	// der steht für ein char-array, das dann angezeigt wird
	
}
