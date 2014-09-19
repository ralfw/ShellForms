using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms.controls
{
	public class Listbox : Control {
		int col;
		int row;
		int height;
		int width;
		bool hasFocus;
		int topVisibleItemIndex;
		int focusedItemIndex;

		public Listbox(int col, int row) : this(col,row,0){}
		public Listbox(int col, int row, int height) {
			this.row = row;
			this.col = col;
			this.height = height;
		}

		public override bool CanHaveFocus { get { return true; } }
		public override void Focus () { hasFocus = true; }
		public override void Defocus() { hasFocus = false; }

		public override bool ProcessKey(ConsoleKeyInfo key) {
			if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar) {
				this.selectedItemIndex = this.selectedItemIndex == this.focusedItemIndex ? -1 : this.focusedItemIndex;
				if (OnPressed != null)
					OnPressed (this);
				return true;
			} else if (key.Key == ConsoleKey.DownArrow) {
				if (this.focusedItemIndex < this.items.Length - 1)
					this.focusedItemIndex++;
				if (this.focusedItemIndex >= this.topVisibleItemIndex + this.height)
					this.topVisibleItemIndex++;
				return true;
			} else if (key.Key == ConsoleKey.UpArrow) {
				if (this.focusedItemIndex > 0)
					this.focusedItemIndex--;
				if (this.focusedItemIndex < this.topVisibleItemIndex)
					this.topVisibleItemIndex = this.focusedItemIndex;
				return true;
			}
			return false;
		}

		public override void Paint() {
			for (var i = 0; i < this.height; i++) {
				Console.CursorLeft = this.col;
				Console.CursorTop = this.row+i;

				var itemIndex = this.topVisibleItemIndex + i;

				var text = new string (' ', this.width-1);
				if (itemIndex < this.items.Length)
					text = string.Format ("{0}", this.items[itemIndex].PadRight(this.width-1));

				if (i == 0 && itemIndex > 0) text += "\u2191";
				else if (i == this.height - 1 && itemIndex < this.items.Length - 1)	text += "\u2193";
				else text += " ";

				if (this.selectedItemIndex == itemIndex)
					Console.BackgroundColor = ConsoleColor.Cyan;
				else if (this.focusedItemIndex == itemIndex && this.hasFocus)
					Console.BackgroundColor = ConsoleColor.Gray;

				Console.Write (text);

				Console.ResetColor ();
			}
		}

		private string[] items;
		public string[] Items {
			get { return this.items; }
			set { 
				this.items = value; 
				if (this.height == 0) this.height = value.Length;
				this.width = value.Max (item => item.Length) + 1;
				this.topVisibleItemIndex = 0;
				this.selectedItemIndex = -1;
			}
		}

		private int selectedItemIndex;
		public int SelectedItemIndex {
			get { return this.selectedItemIndex; }
			set { 
				if (value < 0 || value >= this.items.Length)
					throw new InvalidOperationException ("Index of selected choice out of range!");
				this.selectedItemIndex = value; 
			}
		}

		public event Action<Control> OnPressed;
	}
}
