using System;
using System.Linq;
using System.Collections.Generic;

namespace consoledialogs
{
	// eine hierarchie von controls muss gezeichnet werden
	// womöglich aber auch nur ein teil, nämlich die, die sich verändert haben.
	// beim zeichnen volle fidelity: nicht nur text, sondern auch farben (vorder/hintergrund)
	// 

	// device context bauen, auf dem man malen kann
	// der steht für ein char-array, das dann angezeigt wird

	class Canvas {
		private List<Control> controls = new List<Control>();
		private int focusIndex;

		public void Initialize() {
			this.focusIndex = 0;
			this.controls[this.focusIndex].Focus();
			Paint ();
		}

		public void ProcessKey(ConsoleKeyInfo key) {
			if (!this.controls[this.focusIndex].ProcessKey (key)) {
				if (key.Key == ConsoleKey.Tab) {
					this.controls [this.focusIndex].Defocus ();

					var focusCandidateIndexSequence = new List<int> ();
					if (key.Modifiers == ConsoleModifiers.Shift) {
						var n = this.controls.Count;
						var i = this.focusIndex;
						while (n > 0) {
							i = i == 0 ? n - 1 : i - 1;
							focusCandidateIndexSequence.Add (i);
							n--;
						}
					} else {
						var n = this.controls.Count;
						var i = this.focusIndex;
						while (n > 0) {
							i = (i + 1) % n;
							focusCandidateIndexSequence.Add (i);
							n--;
						}
					}
						
					foreach (var i in focusCandidateIndexSequence)
						if (this.controls[i].CanHaveFocus) {
							this.focusIndex = i;
							break;
						}

					this.controls[this.focusIndex].Focus();
				} 
			}
				
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
			this.controls[this.focusIndex].Paint ();
		}
	}
	
}
