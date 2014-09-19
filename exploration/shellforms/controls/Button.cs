using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms
{
	class Button : Control {
		int col;
		int row;
		string label;
		bool hasFocus;

		public Button(int col, int row, string label) {
			this.label = label;
			this.row = row;
			this.col = col;
		}

		public override bool CanHaveFocus { get { return true; } }
		public override void Focus () { hasFocus = true; }
		public override void Defocus() { hasFocus = false; }


		public override bool ProcessKey(ConsoleKeyInfo key) {
			if (key.Key == ConsoleKey.Enter) {
				OnPressed ();
				return true;
			}
			return false;
		}
			

		public override void Paint() {
			var text = string.Format ("[{0}]", this.label);

			Console.CursorLeft = this.col;
			Console.CursorTop = this.row;

			if (this.hasFocus)
				Console.BackgroundColor = ConsoleColor.Yellow;

			Console.Write (text);

			Console.ResetColor ();
		}


		public event Action OnPressed;
	}

}
