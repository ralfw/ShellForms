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

			term.OnKey += canv.Process;
			term.OnStarted += canv.Initialize;

			Textbox tb;
			tb = new Textbox (5, 7, 10);
			tb.Text = "abc";
			canv.Add (tb);
		
			tb = new Textbox (5, 9, 15);
			tb.Text = "xy";
			canv.Add (tb);

			Button b;
			b = new Button (5, 12, "OK");
			b.On_pressed += () => Environment.Exit (0);
			canv.Add (b);


			term.Run ();
		}
	}
		
}
