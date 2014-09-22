using System;
using shellforms;
using shellforms.controls;

using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace csvviewer
{
	class Formatter {
		public IEnumerable<string> Format(IEnumerable<string> pageLines) {
			var records = Parse (pageLines);
			var colWidths = Determine_col_widths (records);
			var paddedRecords = Pad (records, colWidths);
			var tablizedRecords = paddedRecords.Select (r => string.Join ("|", r));
			return tablizedRecords;
		}

		IEnumerable<string[]> Parse(IEnumerable<string> recordLines) {
			return recordLines.Select (l => l.Split (';'));
		}

		int[] Determine_col_widths(IEnumerable<string[]> records) {
			var colWidths = new List<int> ();
			for (var i = 0; i < records.First ().Length; i++) {
				colWidths.Add (records.Max(r => r[i].Length));
			}
			return colWidths.ToArray ();
		}

		IEnumerable<string[]> Pad(IEnumerable<string[]> records, int[] colWidths) {
			return records.Select (r => {
				return colWidths.Select((w,i) => r[i].PadRight(w)).ToArray();
			});
		}
	}
}
