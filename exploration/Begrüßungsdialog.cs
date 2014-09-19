using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms
{
	class Begrüßungsdialog : Dialog {
		public Begrüßungsdialog() {
			var cb = new Checkbox (5, 7, "Frau");
			cb.Name = "chkAnrede";
			cb.Checked = true;
			base.Add (cb);

			var rb = new Radiobuttongroup (30, 7);
			rb.Name = "rbSprache";
			rb.Choices = new[]{ "Deutsch", "English", "Français" };
			base.Add (rb);

			var tb = new Textbox (5, 8, 20);
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

			lb = new Label (11, 12, 30);
			lb.Name = "lblGruß";
			base.Add (lb);
		}

		private void btnBegrüßen_pressed() {
			Begrüßung_angefordert(
				(base["chkAnrede"] as Checkbox).Checked, 
				(base["rbSprache"] as Radiobuttongroup).SelectedChoiceIndex,
				(base["txtNachname"] as Textbox).Text);
		}

		public void Gruß_anzeigen(string gruß) {
			(base["lblGruß"] as Label).Text = gruß;
		}

		public event Action<bool,int,string> Begrüßung_angefordert;
	}
}
