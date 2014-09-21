using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms.controls
{
	public class Command : Textbox {
		public Command(int col, int row, int width) : base(col, row, width) {}

		public override bool ProcessKey (ConsoleKeyInfo key)
		{
			if (base.ProcessKey (key)) return true;

			if (key.Key == ConsoleKey.Enter) {
				if (this.OnOrdered != null)
					this.OnOrdered (this);
				return true;
			}
			return false;
		}

		public event Action<Command> OnOrdered;
	}
}
