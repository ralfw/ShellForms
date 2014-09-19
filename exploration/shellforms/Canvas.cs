using System;
using System.Linq;
using System.Collections.Generic;

namespace consoledialogs
{
	class Canvas {
		private List<Control> controls = new List<Control>();
		private int focusIndex;

		public void Initialize() {
			this.focusIndex = -1;
			Move_focus (true);
			Clear ();
			Paint ();
		}

		public void ProcessKey(ConsoleKeyInfo key) {
			if (!this.controls[this.focusIndex].ProcessKey (key)) {
				if (key.Key == ConsoleKey.Tab)
					Move_focus (key.Modifiers != ConsoleModifiers.Shift);
			}
				
			Paint ();
		}

		private void Move_focus(bool forward) {
			if (this.focusIndex >= 0) this.controls [this.focusIndex].Defocus ();

			var focusCandidateIndexSequence = new List<int> ();

			var n = this.controls.Count;
			var i = this.focusIndex;
			while (n > 0) {
				if (forward)
					i = (i + 1) % n;
				else
					i = i == 0 ? n - 1 : i - 1;
				focusCandidateIndexSequence.Add (i);
				n--;
			}

			foreach (var ci in focusCandidateIndexSequence)
				if (this.controls[ci].CanHaveFocus) {
					this.focusIndex = ci;
					break;
				}

			this.controls[this.focusIndex].Focus();
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
			this.controls[this.focusIndex].Paint ();
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
