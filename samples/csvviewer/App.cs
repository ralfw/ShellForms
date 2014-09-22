using System;
using shellforms;
using shellforms.controls;

using System.IO;

namespace csvviewer
{

	class App {
		public App(MainDlg dlg, Entrypoints ep) {
			this.start = ep.Start;
			dlg.OnFirstPageRequested += ep.Show_first_page;
			dlg.OnLastPageRequested += ep.Show_last_page;
			dlg.OnExitRequested += ep.Exit;
			ep.OnPage += dlg.Display_page;
		}

		Action start;
		public void Start() {
			this.start ();
		}
	}

}
