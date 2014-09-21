using System;
using shellforms;
using shellforms.controls;

using System.IO;
using System.Linq;

namespace csvviewer
{
	class CommandlineProvider {
		public string Get_filename() {
			return System.Environment.GetCommandLineArgs ()[1];
		}
	}
}
