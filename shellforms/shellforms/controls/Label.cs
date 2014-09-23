using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms.controls
{
	public class Label : Control {
		int col;
		int row;
		int maxWidth;

		public Label(int col, int row) : this(col, row, 0){}
	
		public Label(int col, int row, int maxWidth) {
			this.maxWidth = maxWidth;
			this.row = row;
			this.col = col;
		}

		public override bool CanHaveFocus { get { return false; } set { } }
		public override void Focus () {  }
		public override void Defocus() {  }

		public override bool ProcessKey(ConsoleKeyInfo key) {
			return false;
		}

		public override void Paint() {
			var text = this.text.Split ('\n');
			text = text.Select (l => {
				if (this.maxWidth > 0) {
					if (l.Length > this.maxWidth)
						return l.Substring (0, maxWidth);
					else
						return l.PadRight (this.maxWidth);
				}
				else
					return l;
			}).ToArray ();

			for (var i = 0; i < text.Length; i++) {
				Console.SetCursorPosition (this.col, this.row + i);
				Console.Write (text [i]);
			}
		}

		private string text = "";
		public string Text { 
			get{ return this.text; }
			set { this.text = value; }
		}
	}
}
