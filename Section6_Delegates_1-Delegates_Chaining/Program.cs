using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section6_Delegates_1_Delegates_Chaining {

	// Declaring delegates
	public delegate void Printer(string message);

	public delegate int Filter(string item);

	internal class Program {

		private static void Main(string[] args) {
			// Chain delegates
			Printer p = Print;
			p += PrintTwice;
			p += PrintTwice;
			p -= PrintTwice;

			// Invoke delegates - Basic Way
			p("Some Text");

			Console.WriteLine("Press key to get info about subscribers");
			Console.ReadKey();

			// Get info about all subscribers
			foreach(var del in p.GetInvocationList()) {
				Console.WriteLine(del.Method);
			}

			// Get invocation list
			//Delegate[] delegates = p.GetInvocationList();

			//----------------------Invoke delegates-Generic-------------------------------
			//
			Console.WriteLine("Press key to get results from CatchAllResults function");
			Console.ReadKey();

			// Chain delegates
			Printer p1 = PrintTwice;
			p1 += Print;
			p1 += Print;

			// Invoke delegates and save them to list
			List<string> results = CatchAllResults<string>(p1, "CatchFunctionText");

			Console.WriteLine(string.Join(", ", results));
			//
			//----------------------Invoke delegates-Generic------------------------------

			Console.ReadKey();
		}

		#region Functions

		public static void PrintTwice(string message) {
			Console.WriteLine(message + "1");
			Console.WriteLine(message + "2");
		}

		public static void Print(string message) {
			Console.WriteLine(message);
		}

		#endregion Functions

		//----------------------Invoke delegates-Generic-------------------------------
		public static List<T> CatchAllResults<T>(Delegate del, object parameter = null) {
			List<T> result = del.GetInvocationList()
								.Select(d => (T)d.DynamicInvoke(parameter))
								.ToList();

			return result;
		}

		//----------------------Invoke delegates-Generic-------------------------------
	}
}