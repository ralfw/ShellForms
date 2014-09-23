using System;
using shellforms;
using shellforms.controls;

namespace alarmclock
{

	class MainWindow : Screen {
		ShellForms parent;
		Label lblTime;

		public MainWindow(ShellForms parent) {
			this.parent = parent;
			this.Title = "Alarm Clock";

			base.Add (new Label (2, 2) { Text = "Wake-up time: " });

			var txtWakeupTime = new Textbox (16, 2, 5);
			txtWakeupTime.Text = DateTime.Now.AddMinutes (1).ToString ("HH:mm");
			base.Add (txtWakeupTime);

			var btnStartStop = new Button (22, 2, "Start");
			base.Add (btnStartStop);

			this.lblTime = new Label (2, 4, 8);
			base.Add (this.lblTime);
		}


		public void Display_time(DateTime time) {
			this.lblTime.Text = time.ToString ("HH:mm:ss");
			this.lblTime.Paint ();
		}
	}
}
