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
				if (this.selectedItemsIndexes.Contains (this.focusedItemIndex))
					this.selectedItemsIndexes.Remove (this.focusedItemIndex);
				else if (this.MultipleSelect)
					this.selectedItemsIndexes.Add (this.focusedItemIndex);
				else {
					this.selectedItemsIndexes.Clear ();
					this.selectedItemsIndexes.Add (this.focusedItemIndex);
				}
				if (OnSelectionChanged != null)
					OnSelectionChanged (this, this.focusedItemIndex);
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

				if (this.selectedItemsIndexes.Contains (itemIndex)) {
					if (this.focusedItemIndex == itemIndex && this.hasFocus)
						Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Cyan;
				}
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
				this.selectedItemsIndexes = new List<int>();
			}
		}

		private List<int> selectedItemsIndexes = new List<int> ();
		public int[] SelectedItemsIndexes {
			get { return this.selectedItemsIndexes.ToArray(); }
			set { 
				if (!this.MultipleSelect && value.Length > 1)
					throw new InvalidOperationException ("Listbox does not allow multiple selections!");
				if (value.Any(i => i<0 || i>=this.items.Length))
					throw new InvalidOperationException ("At least one of selected items indexes out of range!");
				this.selectedItemsIndexes = new List<int>(value); 
			}
		}


		public bool MultipleSelect;


		public event Action<Listbox,int> OnSelectionChanged;
	}
}
