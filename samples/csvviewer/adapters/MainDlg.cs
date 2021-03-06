using System;
using System.Collections.Generic;
using System.Linq;
using shellforms;
using shellforms.controls;

namespace csvviewer
{
	class MainDlg : Screen {
		Listbox lstTable;

		public MainDlg() {
			this.Title = "CSV Viewer";

			this.lstTable = new Listbox (2, 2, Console.WindowWidth - 5, Console.WindowHeight - 5);
			lstTable.CanHaveFocus = false;
			base.Add (lstTable);

			var mb = new Menubar (2, Console.WindowHeight - 2);
			mb.Menuitems = new[]{ "First", "Last", "Exit"};
			mb.OnSelected += Menuitem_selected;
			base.Add (mb);
		}


		private void Menuitem_selected(Menubar menu, int selectedItemIndex) {
			switch (selectedItemIndex) {
			case 0:
				OnFirstPageRequested ();
				break;
			case 1:
				OnLastPageRequested ();
				break;
			case 2:
				OnExitRequested ();
				break;
			}
		}


		public void Display_page(IEnumerable<string> pagelines) {
			this.lstTable.Items = pagelines.ToArray();
		}


		public event Action OnFirstPageRequested;
		public event Action OnLastPageRequested;
		public event Action OnExitRequested;
	}
}
