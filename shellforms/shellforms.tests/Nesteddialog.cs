using System;
using System.Collections.Generic;
using System.Linq;
using shellforms.controls;

namespace shellforms.tests
{

	class Nesteddialog : Screen {
		public Nesteddialog(ShellForms sf) {
			base.Add (new Label (5, 5){ Text = "A nested dialog!" });

			var btn = new Button(5, 7, "Close...");
			base.Add(btn);

			btn.OnPressed += _ => {
				sf.Pop ();
				sf.Refresh ();
			};
		}
	}

}
