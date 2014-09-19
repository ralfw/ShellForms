using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms
{
	// eine hierarchie von controls muss gezeichnet werden
	// womöglich aber auch nur ein teil, nämlich die, die sich verändert haben.
	// beim zeichnen volle fidelity: nicht nur text, sondern auch farben (vorder/hintergrund)
	// 

	// device context bauen, auf dem man malen kann
	// der steht für ein char-array, das dann angezeigt wird


	class MainClass
	{
		public static void Main() {
			var term = new MessageLoop ();
			var canv = new Canvas ();

			term.OnKey += canv.ProcessKey;
			term.OnStarted += canv.Initialize;

			var dlg = new Begrüßungsdialog ();
			canv.Add (dlg);

			dlg.Begrüßung_angefordert += (anrede, nachname) => {
				var gruß = string.Format("Hallo, {0} {1}!", anrede, nachname);
				dlg.Gruß_anzeigen(gruß);
			};

			term.Run ();
		}
	}
		

}
