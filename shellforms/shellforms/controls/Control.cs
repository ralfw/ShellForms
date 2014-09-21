using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms.controls
{
	/*
	 * Controls to implement:
	 * - listbox: multi-select
	 * - multi-line textbox (no scrolling)
	 * 
	 * Enable/disable controls, start with Button.
	 * 
	 * Make it easier to build a dialog, e.g. as a list of properties.
	 * 
	 * Separate focus display from Paint().
	 * 
	 * Also introduce invalidation when properties are changed by the environment.
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
