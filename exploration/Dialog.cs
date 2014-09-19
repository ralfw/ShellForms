using System;
using System.Linq;
using System.Collections.Generic;

namespace consoledialogs
{
	// eine hierarchie von controls muss gezeichnet werden
	// womöglich aber auch nur ein teil, nämlich die, die sich verändert haben.
	// beim zeichnen volle fidelity: nicht nur text, sondern auch farben (vorder/hintergrund)
	// 

	// device context bauen, auf dem man malen kann
	// der steht für ein char-array, das dann angezeigt wird

	class Dialog {
		Canvas canv;

		public Dialog(Canvas canv) {
			this.canv = canv;

			Textbox tb;
			tb = new Textbox (5, 7, 5);
			tb.Name = "txtAnrede";
			tb.Text = "Herr";
			canv.Add (tb);

			tb = new Textbox (5, 8, 20);
			tb.Name = "txtNachname";
			tb.Text = "Klöbner";
			canv.Add (tb);

			Button b;
			b = new Button (5, 10, "Begrüßen");
			b.Name = "btnBegrüßen";
			b.OnPressed += btnBegrüßen_pressed;
			canv.Add (b);

			Label lb;
			lb = new Label (5, 12) { Text = "Gruß: " };
			canv.Add (lb);

			lb = new Label (11, 12);
			lb.Name = "lblGruß";
			canv.Add (lb);
		}

		private void btnBegrüßen_pressed() {
			Begrüßung_angefordert((canv["txtAnrede"] as Textbox).Text, (canv["txtNachname"] as Textbox).Text);
		}

		public void Gruß_anzeigen(string gruß) {
			(canv ["lblGruß"] as Label).Text = gruß;
		}

		public event Action<string,string> Begrüßung_angefordert;
	}
}
