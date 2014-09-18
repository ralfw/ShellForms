using System;
using System.Linq;
using System.Collections.Generic;

namespace consoledialogs
{
	// eine hierarchie von controls muss gezeichnet werden
	// womöglich aber auch nur ein teil, nämlich die, die sich verändert haben.
	// beim zeichnen volle fidelity: nicht nur text, sondern auch farben (vorder/hintergrund)
	// 

	// device context bauen, auf dem man malen kann
	// der steht für ein char-array, das dann angezeigt wird

	class Canvas {
		private int width;
		private int height;
		private List<Control> controls = new List<Control>();
		private Control focus;

		public void Initialize() {
			this.width = Console.WindowWidth;
			this.height = Console.WindowHeight;
			focus = this.controls [0];
			Paint ();
		}

		public void Process(ConsoleKeyInfo key) {
			Paint ();
		}

		public void Add(Control control) {
			this.controls.Add (control);
		}

		private void Paint() {
			foreach (var c in this.controls) {
				c.Paint ();
			}
		}
	}
	
}
