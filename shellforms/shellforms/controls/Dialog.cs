using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms.controls
{

	public class Dialog : ContainerControl {
		private int focusIndex;

		public override bool ProcessKey(ConsoleKeyInfo key) {
			if (this.focusIndex >= 0 && this.controls [this.focusIndex].ProcessKey (key))
				return true;

			if (key.Key == ConsoleKey.Tab) {
				Move_focus (key.Modifiers != ConsoleModifiers.Shift);
				return true;
			}

			return false;

		}
			
		private void Move_focus(bool forward) {
			if (this.focusIndex >= 0) this.controls [this.focusIndex].Defocus ();

			var focusCandidateIndexSequence = new List<int> ();

			var n = this.controls.Count;
			var i = this.focusIndex;
			while (n > 0) {
				if (forward)
					i = (i + 1) % this.controls.Count;
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

			if (this.focusIndex >= 0)
				this.controls[this.focusIndex].Focus();
		}


		public override bool CanHaveFocus { get { return true; } }

		public override void Focus () { 
			this.focusIndex = -1;
			Move_focus (true);
		}

		public override void Defocus() { 
			foreach (var c in this.controls)
				c.Defocus ();
		}


		public override void Paint() {
			base.Paint ();
			if (this.focusIndex >= 0)
				this.controls [this.focusIndex].Paint ();
		}
	}
}
