using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section6_Delegates_2_Anonymous_methods {

	internal class Program {

		private static void Main(string[] args) {
			//Func - is a delegate (pointer) to a method, that takes zero, one or more input parameters, and returns a value (or reference).
			Func<int, int, bool> checkIntegers = (int i, int j) => i<8+j;

			//Run Func and Actions
			if(checkIntegers(1, 2)) Console.WriteLine("True");
			printSomething();
			sumOfTwoNums(1, 2);

			Console.ReadKey();
		}

		//Actions - is a delegate (pointer) to a method, that takes zero, one or more input parameters, but does not return anything.

		//Anonymous method w/ no parameters
		private static Action printSomething = () => { Console.WriteLine("Printing"); };

		//Anonymous method w/ parameters
		private static Action<int, int> sumOfTwoNums = (i, j) => {
			Console.WriteLine(i + j);
		};
	}
}