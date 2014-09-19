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


	class MainClass
	{
		public static void Main() {
			var term = new MessageLoop ();
			var canv = new Canvas ();

			term.OnKey += canv.ProcessKey;
			term.OnStarted += canv.Initialize;

			Textbox tb;
			tb = new Textbox (5, 7, 5);
			tb.Name = "anrede";
			tb.Text = "Herr";
			canv.Add (tb);
		
			tb = new Textbox (5, 8, 20);
			tb.Name = "nachname";
			tb.Text = "Klöbner";
			canv.Add (tb);

			Button b;
			b = new Button (5, 10, "Begrüßen");
			b.OnPressed += () => {
				(canv["gruß"] as Label).Text = string.Format("Hallo, {0} {1}!", 
														   (canv["anrede"] as Textbox).Text, 
														   (canv["nachname"] as Textbox).Text);
			};
			canv.Add (b);


			Label lb;
			lb = new Label (5, 12) { Text = "Gruß: " };
			canv.Add (lb);

			lb = new Label (11, 12);
			lb.Name = "gruß";
			canv.Add (lb);

			term.Run ();
		}
	}
		
}
