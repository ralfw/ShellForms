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
			var sf = new ShellForms ();

			var dlg = new Begrüßungsdialog ();
			sf.Canvas.Add (dlg);

			dlg.Begrüßung_angefordert += (istFrau, nachname) => {
				var gruß = string.Format("Hallo, {0} {1}!", istFrau ? "Frau" : "Herr", nachname);
				dlg.Gruß_anzeigen(gruß);
			};

			sf.Run ();
		}
	}
}
