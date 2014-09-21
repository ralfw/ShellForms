using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms.controls
{
	public class Textbox : Control {
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
			this.CanHaveFocus = true;
		}


		public override bool CanHaveFocus { get; set; }
		public override void Focus () { hasFocus = true; }
		public override void Defocus() { hasFocus = false; }


		public override bool ProcessKey(ConsoleKeyInfo key) {
			if (key.KeyChar >= ' ') {
				if (this.text.Length < this.width) {
					if ((this.cursorCol - this.col) >= this.text.Length) {
						this.text += key.KeyChar;
					} else {
						this.text = this.text.Insert (this.cursorCol - this.col, key.KeyChar.ToString ());
					}
				} else {
					this.text = this.text.Substring (0, this.cursorCol - this.col)
								+ key.KeyChar.ToString ()
								+ this.text.Substring (this.cursorCol - this.col+1);
				}

				if (this.cursorCol < this.col + this.width -1)
					this.cursorCol++;

				return true;
			} else if (key.Key == ConsoleKey.Backspace) {
				if (this.cursorCol > this.col) {
					if (this.cursorCol >= this.col + this.text.Length) {
						this.text = this.text.Substring (0, this.text.Length - 1);
					} else {
						this.text = this.text.Substring(0, this.cursorCol - this.col - 1)
							        + this.text.Substring (this.cursorCol - this.col);
					}
					this.cursorCol--;
					return true;
				}
			} else if (key.Key == ConsoleKey.LeftArrow) {
				if (this.cursorCol > this.col) {
					this.cursorCol--;
					return true;
				}
			} else if (key.Key == ConsoleKey.RightArrow) {
				if (this.cursorCol < (this.col + this.text.Length)) {
					this.cursorCol++;
					return true;
				}
			}
			return false;
		}


		public override void Paint() {
			var text = (this.text + new string ('_', width - this.text.Length)).ToCharArray ();

			Console.CursorLeft = this.col;
			Console.CursorTop = this.row;

			if (this.hasFocus)
				Console.BackgroundColor = ConsoleColor.Gray;

			Console.Write (text);

			if (this.hasFocus)
				Console.CursorLeft = this.cursorCol;
			Console.ResetColor ();
		}


		private string text = "";
		public string Text { 
			get{ return this.text; }
			set { this.text = value; this.cursorCol = this.col + value.Length; }
		}
	}


}
