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
}
