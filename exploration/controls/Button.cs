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

	class Button : Control {
		int col;
		int row;
		string label;

		public Button(int col, int row, string label) {
			this.label = label;
			this.row = row;
			this.col = col;
		}
			
		public override void Paint() {
			var text = string.Format ("[{0}]", this.label).ToCharArray ();

			Console.CursorLeft = this.col;
			Console.CursorTop = this.row;
			Console.Write (text);
		}

		public event Action On_pressed;
	}
	
}
