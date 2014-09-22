using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms.controls
{
	public abstract class Control {
		public abstract bool ProcessKey (ConsoleKeyInfo key);

		public abstract bool CanHaveFocus { get; set; }
		public abstract void Focus ();
		public abstract void Defocus();

		public abstract void Paint ();

		public string Name;
	}


}
