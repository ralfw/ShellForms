using System;
using System.Linq;
using System.Collections.Generic;

using shellforms.controls;

namespace shellforms
{
	public class ShellForms {
		private Stack<Control> controls = new Stack<Control>();


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
			

		public void Push(Control control) {
			this.controls.Push (control);
			control.Focus ();
		}

		public void Pop() {
			this.controls.Pop ();
		}


		public void Refresh() {
			var emptyline = new string (' ', Console.WindowWidth);
			for (var row = 0; row < Console.WindowHeight; row++) {
				Console.CursorLeft = 0;
				Console.CursorTop = row;
				Console.Write (emptyline);
			}
			Paint ();
		}


		private void ProcessKey(ConsoleKeyInfo key) {
			this.controls.Peek ().ProcessKey (key);
			Paint ();
		}
			
		private void Paint() {
			this.controls.Peek ().Paint ();
		}
	}
}
