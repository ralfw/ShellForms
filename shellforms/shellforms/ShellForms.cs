using System;
using System.Linq;
using System.Collections.Generic;

using shellforms.controls;
using System.Threading;

namespace shellforms
{
	public class ShellForms {
		private Stack<Screen> screens = new Stack<Screen>();
		private bool looping;

		public void Run(Screen screen) {
			this.Push (screen);
			Console.Clear ();
			this.Run ();
		}

		public void Run() {
			this.Paint ();

			this.looping = true;
			while (looping) {
				ConsoleKeyInfo key;

				var x = Console.CursorLeft;
				var y = Console.CursorTop;

				key = Console.ReadKey ();

				Console.CursorLeft = x;
				Console.CursorTop = y;
		
				ProcessKey (key);
			}
		}


		public void Stop () {
			this.looping = false;
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


		private void Paint() {
			var titles = this.screens.Select (c => c.Title).Reverse ();
			var breadcrumps = string.Join ("/", titles);
			Console.CursorLeft = Console.WindowWidth / 2 - breadcrumps.Length / 2;
			Console.CursorTop = 0;
			Console.Write (breadcrumps);

			this.screens.Peek ().Paint ();
		}


		private void ProcessKey(ConsoleKeyInfo key) {
			this.screens.Peek ().ProcessKey (key);
			Paint ();
		}
	}
}
