using System;
using System.Collections.Generic;
using System.Linq;
using shellforms.controls;

namespace shellforms.tests
{
	public class Messagebox : Screen {
		public enum ConfirmationButtons {
			Ok,
			OkCancel
		}

		public enum Confirmations {
			Ok,
			Cancel
		}
			
		private ShellForms owner;
		private Confirmations confirmation;


		public Messagebox(string title, string message, ConfirmationButtons confirmationbuttons = ConfirmationButtons.Ok) : this(title, new[]{message}, confirmationbuttons) {}

		public Messagebox(string title, IEnumerable<string> message, ConfirmationButtons confirmationbuttons = ConfirmationButtons.Ok) {
			this.owner = new ShellForms ();

			this.Title = title;

			message = message.SelectMany (l => l.Split (new[]{'\n'}));

			var messageWidth = message.Max (l => l.Length);
			var width = messageWidth + 4;
			var height = message.Count() + 4;
			var left = Console.WindowWidth / 2 - width / 2;
			var top = Console.WindowHeight / 2 - height / 2;

			var lblFrame = new Label (left, top);
			lblFrame.Text = "+" + new string('-', width-2) + "+";
			for (var i = 1; i < height; i++)
				lblFrame.Text += "\n" + "|" + new string(' ', width-2) + "|";
			lblFrame.Text += "\n" + "+" + new string('-', width-2) + "+";
			base.Add (lblFrame);

			var lblMsg = new Label (left + 2, top + 2);
			lblMsg.Text = string.Join ("\n", message);
			base.Add (lblMsg);


			if (confirmationbuttons == ConfirmationButtons.Ok) {
				var btnOk = new Button (left + width / 2 - 2, top + height - 1, "Ok");
				base.Add (btnOk);

				btnOk.OnPressed += _ => {
					this.confirmation = Confirmations.Ok;
					this.owner.Stop();
				};
			}

			owner.Push (this);
		}


		public Confirmations Show(ShellForms parent) {
			owner.Run ();
			parent.Refresh ();
			return this.confirmation;
		}
	}
}
