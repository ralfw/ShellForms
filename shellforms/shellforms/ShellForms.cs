using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms
{
	public class ShellForms {
		public void Run() {
			this.canvas.Initialize ();

			while (true) {
				var x = Console.CursorLeft;
				var y = Console.CursorTop;

				var key = Console.ReadKey ();

				Console.CursorLeft = x;
				Console.CursorTop = y;

				this.canvas.ProcessKey (key);
			}
		}

		private Canvas canvas = new Canvas();
		public Canvas Canvas {
			get { return this.canvas; }
		}
	}
}
