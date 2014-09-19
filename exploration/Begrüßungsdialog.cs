using System;
using System.Linq;
using System.Collections.Generic;

using shellforms.controls;


namespace consoledialogs
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

			var lst = new Listbox (5, 9, 3);
			lst.Name = "lstNamen";
			lst.Items = new[]{ "Kent", "Parker", "Müller-Lüdenscheid", "Oin", "Gloin", "Gimly" };
			base.Add (lst);

			var tb = new Textbox (5, 12, 20);
			tb.Name = "txtNachname";
			tb.Text = "";
			base.Add (tb);

			Button b;
			b = new Button (5, 14, "Begrüßen");
			b.Name = "btnBegrüßen";
			b.OnPressed += btnBegrüßen_pressed;
			base.Add (b);

			Label lb;
			lb = new Label (5, 16) { Text = "Gruß: " };
			base.Add (lb);

			lb = new Label (11, 16, 30);
			lb.Name = "lblGruß";
			base.Add (lb);
		}

		private void btnBegrüßen_pressed(Control sender) {
			var lst = (base ["lstNamen"] as Listbox);
			var nachname = (base ["txtNachname"] as Textbox).Text;
			if (lst.SelectedItemIndex >= 0)
				nachname = lst.Items[lst.SelectedItemIndex];

			Begrüßung_angefordert(
				(base["chkAnrede"] as Checkbox).Checked, 
				(base["rbSprache"] as Radiobuttongroup).SelectedChoiceIndex,
				nachname);
		}

		public void Gruß_anzeigen(string gruß) {
			(base["lblGruß"] as Label).Text = gruß;
		}

		public event Action<bool,int,string> Begrüßung_angefordert;
	}
}
