using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms.controls
{
	/*
	 * Controls to implement:
	 * - mask char for textbox
	 * - multi-line textbox
	 * 
	 * Enable/disable controls, start with Button.
	 * 
	 * Make it easier to build a dialog, e.g. as a list of properties.
	 * 
	 * Also introduce invalidation when properties are changed by the environment.
	 * 
	 * Make cursor invisible during Paint() if possible.
	 */
	public abstract class Control {
		public abstract bool ProcessKey (ConsoleKeyInfo key);

		public abstract bool CanHaveFocus { get; set; }
		public abstract void Focus ();
		public abstract void Defocus();

		public abstract void Paint ();

		public string Name;
	}
}
