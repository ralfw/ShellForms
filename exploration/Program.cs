using System;
using System.Linq;
using System.Collections.Generic;

namespace consoledialogs
{
	// eine hierarchie von controls muss gezeichnet werden
	// womöglich aber auch nur ein teil, nämlich die, die sich verändert haben.
	// beim zeichnen volle fidelity: nicht nur text, sondern auch farben (vorder/hintergrund)
	// 


	class MainClass
	{
		public static void Main() {
			var term = new Terminal ();
			var canv = new Canvas ();

			term.OnKey += canv.Process;
			term.OnStarted += canv.Initialize;
			canv.OnContentChanged += term.Update;

			Textbox tb;
			tb = new Textbox (5, 7, 10);
			tb.Text = "abc";
			canv.Add (tb);
		
			tb = new Textbox (5, 9, 15);
			tb.Text = "xy";
			canv.Add (tb);

			Button b;
			b = new Button (5, 12, "OK");
			b.On_pressed += () => Environment.Exit (0);
			canv.Add (b);


			term.Run ();
		}
	}



	class Terminal {
		public void Run() {
			OnStarted (Console.WindowWidth, Console.WindowHeight);
			while (true) {
				var key = Console.ReadKey ();
				OnKey (key);
			}
		}

		public void Update(ViewArea area) {
			for (var row = 0; row < area.Canvas.Length; row++) {
				Console.CursorLeft = area.X;
				Console.CursorTop = area.Y + row;
				Console.Write (area.Canvas [row]);
			}
		}

		public event Action<int,int> OnStarted;
		public event Action<ConsoleKeyInfo> OnKey;
	}


	class ViewArea {
		public int X;
		public int Y;
		public char[][] Canvas;
	}


	// device context bauen, auf dem man malen kann
	// der steht für ein char-array, das dann angezeigt wird

	class Canvas {
		private int width;
		private int height;
		private List<Control> controls = new List<Control>();
		private Control focus;


		public void Initialize(int width, int height) {
			this.width = width;
			this.height = height;
			focus = this.controls [0];
			Paint ();
		}

		public void Process(ConsoleKeyInfo key) {
			Paint ();
		}


		public void Add(Control control) {
			this.controls.Add (control);
		}


		private void Paint() {
			var viewArea = new ViewArea { X = 0, Y=0 };

			var canvas = new List<char[]> ();
			for (var row = 0; row < this.height; row++) {
				canvas.Add (new string ('.', this.width).ToCharArray ());
			}
			viewArea.Canvas = canvas.ToArray ();

			foreach (var c in this.controls) {
				c.Paint (viewArea);
			}


			OnContentChanged (viewArea);
		}


		public event Action<ViewArea> OnContentChanged;
	}




	abstract class Control {
		public abstract void Paint (ViewArea canvas);
	}


	class Button : Control {
		int col;
		int row;
		string label;

		public Button(int col, int row, string label) {
			this.label = label;
			this.row = row;
			this.col = col;
		}
			
		public override void Paint(ViewArea canvas) {
			var text = string.Format ("[{0}]", this.label).ToCharArray ();

			var line = canvas.Canvas [this.row];
			text.CopyTo (line, this.col);
		}


		public event Action On_pressed;
	}
		
	class Textbox : Control {
		int col;
		int row;
		int width;

		public Textbox(int col, int row, int width) {
			this.width = width;
			this.row = row;
			this.col = col;
		}

		public override void Paint(ViewArea canvas) {
			var text = (this.text + new string ('_', width - this.text.Length)).ToCharArray ();

			var line = canvas.Canvas [this.row];
			text.CopyTo (line, this.col);
		}


		private string text;
		public string Text { 
			get{ return this.text; }
			set { this.text = value; }
		}
	}
}
