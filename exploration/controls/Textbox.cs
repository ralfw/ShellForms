using System;
using System.Linq;
using System.Collections.Generic;

namespace consoledialogs
{
	class Textbox : Control {
		int col;
		int row;
		int width;
		int cursorCol;
		bool hasFocus;

		public Textbox(int col, int row, int width) {
			this.width = width;
			this.row = row;
			this.col = col;
			this.cursorCol = col;
		}


		public override bool CanHaveFocus { get { return true; } }
		public override void Focus () { hasFocus = true; }
		public override void Defocus() { hasFocus = false; }


		public override bool ProcessKey(ConsoleKeyInfo key) {
			if (key.KeyChar >= ' ') {
				if (this.text.Length < this.width) {
					this.text += key.KeyChar;
					if (this.text.Length < this.width) this.cursorCol++;
				} else {
					this.text = this.text.Substring (0, this.text.Length - 1) + key.KeyChar;
				}
				return true;
			}
			return false;
		}


		public override void Paint() {
			var text = (this.text + new string ('_', width - this.text.Length)).ToCharArray ();

			Console.CursorLeft = this.col;
			Console.CursorTop = this.row;

			if (this.hasFocus)
				Console.BackgroundColor = ConsoleColor.Cyan;

			Console.Write (text);

			if (this.hasFocus)
				Console.CursorLeft = this.cursorCol;

			Console.ResetColor ();
		}


		private string text;
		public string Text { 
			get{ return this.text; }
			set { this.text = value; this.cursorCol = this.col + value.Length; }
		}
	}
}
