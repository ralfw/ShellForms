using System;
using System.Linq;
using System.Collections.Generic;

namespace consoledialogs
{
	// eine hierarchie von controls muss gezeichnet werden
	// womöglich aber auch nur ein teil, nämlich die, die sich verändert haben.
	// beim zeichnen volle fidelity: nicht nur text, sondern auch farben (vorder/hintergrund)
	// ein pfad von controls im baum hat den fokus. der muss controlspezifisch angezeigt werden.

	// device context bauen, auf dem man malen kann
	// der steht für ein char-array, das dann angezeigt wird
		
	class Textbox : Control {
		int col;
		int row;
		int width;

		public Textbox(int col, int row, int width) {
			this.width = width;
			this.row = row;
			this.col = col;
		}

		public override void Paint(ViewArea canvas) {
			var text = (this.text + new string ('_', width - this.text.Length)).ToCharArray ();

			var line = canvas.Canvas [this.row];
			text.CopyTo (line, this.col);
		}

		private string text;
		public string Text { 
			get{ return this.text; }
			set { this.text = value; }
		}
	}
}
