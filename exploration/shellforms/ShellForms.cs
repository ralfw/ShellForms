using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms
{
	// eine hierarchie von controls muss gezeichnet werden
	// womöglich aber auch nur ein teil, nämlich die, die sich verändert haben.
	// beim zeichnen volle fidelity: nicht nur text, sondern auch farben (vorder/hintergrund)
	// 

	// device context bauen, auf dem man malen kann
	// der steht für ein char-array, das dann angezeigt wird

	class ShellForms {
		public void Run() {
			this.canvas.Initialize ();

			while (true) {
				var x = Console.CursorLeft;
				var y = Console.CursorTop;

				var key = Console.ReadKey ();

				Console.CursorLeft = x;
				Console.CursorTop = y;

				this.canvas.ProcessKey (key);
			}
		}

		private Canvas canvas = new Canvas();
		public Canvas Canvas {
			get { return this.canvas; }
		}
	}

}
