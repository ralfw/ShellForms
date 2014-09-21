using System;
using shellforms;
using shellforms.controls;

using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace csvviewer
{

	class Entrypoints {
		CommandlineProvider cmd;
		TextfileProvider txt;
		Pager pager;
		Formatter formatter;


		public Entrypoints(CommandlineProvider cmd, TextfileProvider txt, Pager pager, Formatter formatter) {
			this.formatter = formatter;
			this.pager = pager;
			this.txt = txt;
			this.cmd = cmd;
		}

		public void Start() {
			this.Show_first_page ();
		}


		public void Show_first_page() {
			var filename = this.cmd.Get_filename ();
			var lines = this.txt.Load_raw_lines (filename);
			var pagelines = this.pager.Extract_first_page (lines);
			var formattedPageLines = this.formatter.Format (pagelines);
			OnPage (formattedPageLines);
		}


		public void Show_last_page() {
			var filename = this.cmd.Get_filename ();
			var lines = this.txt.Load_raw_lines (filename);
			var pagelines = this.pager.Extract_last_page (lines);
			var formattedPageLines = this.formatter.Format (pagelines);
			OnPage (formattedPageLines);
		}


		public void Exit() {
			Environment.Exit (0);
		}


		public event Action<IEnumerable<string>> OnPage;
	}

}
