using System;
using System.Linq;
using System.Collections.Generic;

using shellforms.controls;

namespace shellforms
{
	public class ShellForms {
		private Stack<Screen> screens = new Stack<Screen>();


		public void Run(Screen screen) {
			this.Push (screen);
			this.Run ();
		}

		public void Run() {
			Refresh ();

			while (true) {
				var x = Console.CursorLeft;
				var y = Console.CursorTop;

				var key = Console.ReadKey ();

				Console.CursorLeft = x;
				Console.CursorTop = y;

				ProcessKey (key);
			}
		}
			

		public void Push(Screen screen) {
			this.screens.Push (screen);
			screen.Focus ();
		}

		public void Pop() {
			this.screens.Pop ();
		}


		public void Refresh() {
			Console.Clear ();
			Paint ();
		}


		private void ProcessKey(ConsoleKeyInfo key) {
			this.screens.Peek ().ProcessKey (key);
			Paint ();
		}
			
		private void Paint() {
			var titles = this.screens.Select (c => c.Title).Reverse ();
			var breadcrumps = string.Join ("/", titles);
			Console.CursorLeft = Console.WindowWidth / 2 - breadcrumps.Length / 2;
			Console.CursorTop = 0;
			Console.Write (breadcrumps);

			this.screens.Peek ().Paint ();
		}
	}
}
