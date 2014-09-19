using System;
using System.Linq;
using System.Collections.Generic;

namespace consoledialogs
{
	class Label : Control {
		int col;
		int row;

		public Label(int col, int row) {
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
			var text = string.Format ("{0}", this.text).ToCharArray ();

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
