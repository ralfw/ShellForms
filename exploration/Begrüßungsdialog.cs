using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms
{
	class Begrüßungsdialog : Dialog {
		public Begrüßungsdialog() {
			Textbox tb;
			tb = new Textbox (5, 7, 5);
			tb.Name = "txtAnrede";
			tb.Text = "Herr";
			base.Add (tb);

			tb = new Textbox (5, 8, 20);
			tb.Name = "txtNachname";
			tb.Text = "Klöbner";
			base.Add (tb);

			Button b;
			b = new Button (5, 10, "Begrüßen");
			b.Name = "btnBegrüßen";
			b.OnPressed += btnBegrüßen_pressed;
			base.Add (b);

			Label lb;
			lb = new Label (5, 12) { Text = "Gruß: " };
			base.Add (lb);

			lb = new Label (11, 12, 20);
			lb.Name = "lblGruß";
			base.Add (lb);
		}

		private void btnBegrüßen_pressed() {
			Begrüßung_angefordert((base["txtAnrede"] as Textbox).Text, (base["txtNachname"] as Textbox).Text);
		}

		public void Gruß_anzeigen(string gruß) {
			(base["lblGruß"] as Label).Text = gruß;
		}

		public event Action<string,string> Begrüßung_angefordert;
	}
}
