using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms
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

		public override bool CanHaveFocus { get { return false; } }
		public override void Focus () {  }
		public override void Defocus() {  }

		public override bool ProcessKey(ConsoleKeyInfo key) {
			return false;
		}

		public override void Paint() {
			var text = string.Format ("{0}", this.text);
			if (this.maxWidth > 0) {
				if (text.Length > this.maxWidth)
					text = text.Substring (0, maxWidth);
				else
					text = text.PadRight (this.maxWidth);
			}
				
			Console.CursorLeft = this.col;
			Console.CursorTop = this.row;

			Console.Write (text);
		}

		private string text;
		public string Text { 
			get{ return this.text; }
			set { this.text = value; }
		}
	}
}
