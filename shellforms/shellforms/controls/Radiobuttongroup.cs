using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms.controls
{

	public class Radiobuttongroup : Control {
		int col;
		int row;
		bool hasFocus;
		int focusedChoice;

		public Radiobuttongroup(int col, int row) {
			this.row = row;
			this.col = col;
		}

		public override bool CanHaveFocus { get { return true; } }
		public override void Focus () { hasFocus = true; }
		public override void Defocus() { hasFocus = false; }

		public override bool ProcessKey(ConsoleKeyInfo key) {
			if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar) {
				this.selectedChoiceIndex = this.focusedChoice;
				if (OnPressed != null)
					OnPressed ();
				return true;
			} else if (key.Key == ConsoleKey.DownArrow) {
				if (this.focusedChoice < this.choices.Length - 1)
					this.focusedChoice++;
				return true;
			} else if (key.Key == ConsoleKey.UpArrow) {
				if (this.focusedChoice > 0)
					this.focusedChoice--;
				return true;
			}
			return false;
		}

		public override void Paint() {
			for (var i = 0; i < this.choices.Length; i++) {
				Console.CursorLeft = this.col;
				Console.CursorTop = this.row+i;

				var text = string.Format ("({0}) {1}", this.selectedChoiceIndex == i ? "*" : " " , this.choices[i]);

				if (this.hasFocus && this.focusedChoice == i)
					Console.BackgroundColor = ConsoleColor.Gray;

				Console.Write (text);

				Console.ResetColor ();
			}
		}

		private string[] choices;
		public string[] Choices {
			get { return this.choices; }
			set { this.choices = value; }
		}

		private int selectedChoiceIndex;
		public int SelectedChoiceIndex {
			get { return this.selectedChoiceIndex; }
			set { 
				if (value < 0 || value >= this.choices.Length)
					throw new InvalidOperationException ("Index of selected choice out of range!");
				this.selectedChoiceIndex = value; 
			}
		}

		public event Action OnPressed;
	}
}
