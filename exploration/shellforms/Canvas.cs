using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms
{
	class Canvas {
		private List<Control> controls = new List<Control>();

		public void Initialize() {
			Clear ();
			Paint ();
		}

		public void ProcessKey(ConsoleKeyInfo key) {
			foreach (var c in this.controls)
				if (c.ProcessKey (key))
					break;				
			Paint ();
		}


		public void Add(Control control) {
			this.controls.Add (control);
		}

		public Control this[string name] {
			get { 
				return this.controls.First (c => c.Name == name);
			}
		}

		private void Paint() {
			foreach (var c in this.controls) {
				c.Paint ();
			}
		}

		public void Clear() {
			var emptyline = new string (' ', Console.WindowWidth);
			for (var row = 0; row < Console.WindowHeight; row++) {
				Console.CursorLeft = 0;
				Console.CursorTop = row;
				Console.Write (emptyline);
			}
		}
	}
	
}
