using System;
using System.Linq;
using System.Collections.Generic;

namespace shellforms.controls
{
	public abstract class ContainerControl : Control {
		protected List<Control> controls = new List<Control>();

		public void Add(Control control) {
			this.controls.Add (control);
		}

		public Control this[string name] {
			get { 
				return this.controls.First (c => c.Name == name);
			}
		}

		public override void Paint() {
			foreach (var c in this.controls) {
				c.Paint ();
			}
		}
	}


}
