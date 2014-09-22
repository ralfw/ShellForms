using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms.controls
{

	public class Progressbar : Control {
		int col;
		int row;
		int width;

		public Progressbar(int col, int row, int width) {
			this.width = width;
			this.row = row;
			this.col = col;
			this.CanHaveFocus = false;
			this.Percent = 0.0;
		}

		public override bool CanHaveFocus { get; set; }
		public override void Focus () { }
		public override void Defocus() { }

		public override bool ProcessKey (ConsoleKeyInfo key)
		{
			return false;
		}

		public override void Paint ()
		{
			Console.SetCursorPosition (this.col, this.row);
			Console.Write ("[");

			var text = this.ShowPercent ? string.Format ("{0:##0.0}%", this.Percent).PadRight (this.width - 2)
										: new string (' ', this.width - 2);
			var headLen = this.Percent <= 0 ? 0 : (int)(text.Length * this.Percent / 100);
			if (headLen > text.Length)
				headLen = text.Length;

			Console.BackgroundColor = ConsoleColor.Cyan;
			Console.Write (text.Substring(0, headLen));

			Console.ResetColor ();
			Console.Write(text.Substring(headLen));

			Console.Write ("]");
		}

		public double Percent { get; set; }
		public bool ShowPercent = true;
	}
}
