using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section8_Asynchronous_programming {

	internal class Program {

		private static void Main(string[] args) {
			int count = 200000;
			char charToConcatenate = '1';

			//Async that can return a value
			Task<string> t = ConcatenateCharsAsync(charToConcatenate, count);

			Console.WriteLine("In progress");

			Console.WriteLine("The length of the result is " + t.Result.Length);
			Console.ReadKey();
		}

		private static string ConcatenateChars(char charToConcatenate, int count) {
			string concatenatedString = string.Empty;

			for(int i = 0; i < count; i++) {
				concatenatedString += charToConcatenate;
			}

			return concatenatedString;
		}

		private async static Task<string> ConcatenateCharsAsync(char charToConcatenate, int count) {
			return await Task<string>.Factory.StartNew(() => ConcatenateChars(charToConcatenate, count));
		}
	}
}