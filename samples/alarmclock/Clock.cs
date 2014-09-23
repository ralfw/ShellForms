using System;
using System.Threading;
using shellforms;
using shellforms.controls;

namespace alarmclock
{

	class Clock : IDisposable {
		private bool ticking;

		public void Start() {
			this.ticking = true;

			ThreadPool.QueueUserWorkItem (_ => {
				while(ticking) {
					if (OnClockTick != null)
						OnClockTick(DateTime.Now);
					Thread.Sleep(1000);
				}
			});
		}

		public event Action<DateTime> OnClockTick;

		#region IDisposable implementation
		public void Dispose () {
			this.ticking = false;
		}
		#endregion
	}
}
