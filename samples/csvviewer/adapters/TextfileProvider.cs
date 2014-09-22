using System;
using shellforms;
using shellforms.controls;

using System.IO;
using System.Linq;

namespace csvviewer
{
	class TextfileProvider() {
		public string[] Load_raw_lines(string filename) {
			var lines = File.ReadAllLines (filename);
			return lines.Select (l => l.Replace ('\t', ';')).ToArray ();
		}
	}
}
