using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section4_ExtensionMethods_0 {

	internal static class Program {

		private static void Main(string[] args) {
			int[] array = { 5, 3, 2, 1, 9, 100, 1 };
			string[] arrayNames = { "test1", "test2" };

			array.Sort();

			Console.WriteLine(string.Join(", ", array));
			Console.ReadKey();
		}

		public static void Sort(this int[] array) {
			Sort(array);
		}
	}
}