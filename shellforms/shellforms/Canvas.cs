using System;
using System.Linq;
using System.Collections.Generic;

using shellforms.controls;


namespace shellforms
{
	public class Canvas {
		private Stack<Control> controls = new Stack<Control>();


		public void ProcessKey(ConsoleKeyInfo key) {
			this.controls.Peek ().ProcessKey (key);
			Paint ();
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


		private void Paint() {
			this.controls.Peek ().Paint ();
		}
	}
	
}
