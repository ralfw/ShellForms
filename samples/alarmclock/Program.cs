using System;
using System.Threading;
using shellforms;
using shellforms.controls;

namespace alarmclock
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var sf = new ShellForms ();

			// build
			var ui = new MainWindow (sf);
			var clock = new Clock ();

			// bind
			clock.OnClockTick += ui.Display_time;

			// run
			using (clock) {
				clock.Start ();
				sf.Run (ui);
			};
		}
	}


}
