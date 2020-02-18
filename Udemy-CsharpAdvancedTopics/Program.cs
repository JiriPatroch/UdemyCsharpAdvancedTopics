using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Section6_Delegates_0 {

	internal class Program {

		// Declaring delegate
		public delegate bool Filters(string item);

		private static void Main(string[] args) {
			string[] names = { "Alice", "John", "Bobby", "Kyle", "Scott", "Tod", "Sharon", "Armin" };

			//Function as (delegate) parameter
			List<string> lessThenFiveChars = NamesFilter(names, MoreThanFive);
			//Lambda as (delegate) parameter
			List<string> exactlyFiveChars = NamesFilter(names, item => item.Length == 5);

			Console.WriteLine("Names with length less than 5 characters (Function LessThanFive())");
			Console.WriteLine(string.Join(",", lessThenFiveChars));
			Console.WriteLine("Names with length exactly with 5 characters (Lambda)");
			Console.WriteLine(string.Join(",", exactlyFiveChars));
			Console.ReadKey();
		}

		#region Functions

		public static bool LessThanFive(string name) {
			return name.Length < 5;
		}

		public static bool MoreThanFive(string name) {
			return name.Length > 5;
		}

		public static bool EqualsToFive(string name) {
			return name.Length == 5;
		}

		#endregion Functions

		/// <summary>
		/// Function where is delegate used
		/// </summary>
		/// <param name="items">Array of items</param>
		/// <param name="filter">Delegate - Function or Lambda</param>
		/// <returns></returns>
		public static List<string> NamesFilter(string[] items, Filters filter) {
			List<string> result = new List<string>();
			foreach(var item in items) {
				if(filter(item)) {
					result.Add(item);
				}
			}
			return result;
		}
	}
}