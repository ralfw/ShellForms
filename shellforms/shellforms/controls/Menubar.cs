using System;
using System.Collections.Generic;
using System.Linq;
using shellforms.controls;

namespace shellforms.controls
{
	public class Menubar : Control {
		int col;
		int row;
		bool hasFocus;
		int selectedIndex;

		public Menubar(int col, int row) {
			this.row = row;
			this.col = col;
			this.CanHaveFocus = true;
		}

		public override bool ProcessKey (ConsoleKeyInfo key)
		{
			if (key.Key == ConsoleKey.Enter) {
				if (this.OnSelected != null)
					this.OnSelected (this, this.selectedIndex);
				return true;
			} else if (key.Key == ConsoleKey.LeftArrow) {
				this.selectedIndex = this.selectedIndex > 0 ? this.selectedIndex - 1 : this.menuitems.Length - 1;
				return true;
			} else if (key.Key == ConsoleKey.RightArrow) {
				this.selectedIndex = this.selectedIndex < this.menuitems.Length-1 ? this.selectedIndex + 1 : 0;
				return true;
			}
			return false;
		}

		public override bool CanHaveFocus { get; set; }
		public override void Focus () { hasFocus = true; }
		public override void Defocus() { hasFocus = false; }

		private string[] menuitems;
		public string[] Menuitems {
			get { return menuitems; }
			set { this.menuitems = value; this.selectedIndex = 0; }
		}

		public override void Paint ()
		{
			Console.SetCursorPosition (this.col, this.row);
			Console.Write ("[");

			for(var i=0; i<this.menuitems.Length; i++) {
				if (i > 0) Console.Write (" | ");

				if (this.hasFocus && i == this.selectedIndex)
					Console.BackgroundColor = ConsoleColor.Gray;
					
				Console.Write (this.menuitems[i]);

				Console.ResetColor ();
			}
			Console.Write ("]");
		}

		public event Action<Menubar,int> OnSelected;
	}
}
