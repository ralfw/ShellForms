using System;
using shellforms;
using shellforms.controls;

using System.IO;

namespace csvviewer
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// build
			var dlg = new MainDlg ();
			var cmd = new CommandlineProvider ();
			var txt = new TextfileProvider ();
			var pager = new Pager ();
			var formatter = new Formatter ();
			var ep = new Entrypoints (cmd, txt, pager, formatter);
			var app = new App (dlg, ep);

			// run
			app.Start ();

			var sf = new ShellForms ();
			sf.Run (dlg);
		}
	}
}
