using System;
using System.Collections.Generic;
using System.Linq;
using shellforms.controls;

namespace shellforms.tests
{

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

			var lst = new Listbox (2, 8, 20, 3);
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
			mb.Menuitems = new[]{ "Show message box", "Reset command", "Exit"};
			base.Add (mb);

			mb.OnSelected += (sender, i) => {
				switch(i) {
				case 0:
					if (new Messagebox ("Test", "A msg\nbox with a\nmulti-line message.", Messagebox.ConfirmationButtons.OkCancel).Show (sf) == Messagebox.Confirmations.Cancel)
						new Messagebox("Test", "Oh, cancellation?").Show(sf);
					break;
				case 1:
					cmd.Text = "";
					break;
				case 2:
					Environment.Exit(0);
					break;
				}
			};


			var cb = new Checkbox (2, 23, "The red pill?");
			cb.Checked = true;
			base.Add (cb);


			base.Add (new Label (2, 25){ Text = "Password: " });

			var txtPwd = new Textbox (11, 25, 8);
			txtPwd.Text = "geheim";
			txtPwd.IsPassword = true;
			base.Add (txtPwd);

			btn = new Button (21, 25, "Show Password...");
			base.Add (btn);

			btn.OnPressed += sender => new Messagebox ("Password", txtPwd.Text).Show (sf);


			base.Add (new Label (2, 27){ Text = "Progress percent (0..100): " });

			var cmdPercent = new Command (29, 27, 5) { Text = "30" };
			cmdPercent.Name = "tbPercent";
			base.Add (cmdPercent);

			var pb = new Progressbar (35, 27, 12);
			base.Add (pb);

			cmdPercent.OnOrdered += _ => pb.Percent = Single.Parse(cmdPercent.Text);
		}
	}

}
