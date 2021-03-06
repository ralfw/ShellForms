using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms.controls
{
	public class Checkbox : Control {
		int col;
		int row;
		string label;
		bool hasFocus;

		public Checkbox(int col, int row, string label) {
			this.label = label;
			this.row = row;
			this.col = col;
			this.CanHaveFocus = true;
		}

		public override bool CanHaveFocus { get; set; }
		public override void Focus () { hasFocus = true; }
		public override void Defocus() { hasFocus = false; }

		public override bool ProcessKey(ConsoleKeyInfo key) {
			if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar) {
				this.@checked = !this.@checked;
				if (OnSelectionChanged != null) OnSelectionChanged (this);
				return true;
			}
			return false;
		}

		public override void Paint() {
			var text = string.Format ("[{0}] {1}", this.@checked ? "X" : " ", this.label);

			Console.CursorLeft = this.col;
			Console.CursorTop = this.row;

			if (this.hasFocus)
				Console.BackgroundColor = ConsoleColor.Gray;

			Console.Write (text);

			Console.ResetColor ();
		}


		private bool @checked;
		public bool Checked {
			get { return this.@checked; }
			set { this.@checked = value; }
		}


		public event Action<Checkbox> OnSelectionChanged;
	}

}
