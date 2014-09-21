using System;
using System.Collections.Generic;
using System.Linq;
using shellforms.controls;

namespace shellforms.tests
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var sf = new ShellForms ();
		
			sf.Push (new Maindialog (sf) {Title = "Main"});

			sf.Run ();
		}
	}

	class Maindialog : Screen {
		public Maindialog(ShellForms sf) {
			var tb = new Textbox (2, 4, 15);
			tb.Text = "Hello, world!";
			base.Add (tb);

			var btn = new Button (2, 6, "Display");
			base.Add (btn);

			var lbl = new Label (15, 6, 15);
			lbl.Text = "Overwrite";
			base.Add (lbl);

			btn.OnPressed += _ => lbl.Text = tb.Text;

			var lst = new Listbox (2, 8, 3);
			lst.Items = new[]{ "multi", "selection", "listbox", "with", "scrolling" };
			lst.MultipleSelect = true;
			base.Add (lst);

			base.Add (new Label (2, 12){ Text = "No mammal?" });

			var rbg = new Radiobuttongroup (15, 12);
			rbg.Choices = new[]{ "dog", "cat", "mouse", "ant" };
			base.Add (rbg);


			var btn2 = new Button (2, 17, "Open new Dlg...");
			base.Add (btn2);

			btn2.OnPressed += _ => {
				sf.Push (new Nesteddialog (sf){Title = "Nested"});
				sf.Refresh ();
			};

			base.Add (new Label (2, 19){ Text = "Type command, hit Enter: " });

			var cmd = new Command (26, 19, 10);
			base.Add (cmd);

			cmd.OnOrdered += sender => new Messagebox ("Command entered", sender.Text).Show (sf);

			var mb = new Menubar (2, 21);
			mb.Menuitems = new[]{ "Show message box", "Reset command"};
			base.Add (mb);

			mb.OnSelected += (sender, i) => {
				switch(i) {
				case 0:
					new Messagebox ("Test", "A msg\nbox with a\nmulti-line message.").Show (sf);
					break;
				case 1:
					cmd.Text = "";
					break;
				}
			};
		}
	}

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
