using System;
using shellforms;
using shellforms.controls;

using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace csvviewer
{

	class Pager {
		const int PAGE_SIZE = 20;

		public IEnumerable<string> Extract_first_page(string[] allLines) {
			return allLines.Take (PAGE_SIZE+1);
		}
	
		public IEnumerable<string> Extract_last_page(string[] allLines) {
			return new[]{allLines[0]}.Concat(allLines.Skip (allLines.Length - PAGE_SIZE));
		}
	}
}
