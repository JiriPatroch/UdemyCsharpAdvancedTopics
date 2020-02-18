using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section5_Generics_0 {

	internal class Program {

		private static void Main(string[] args) {
			//Console.WriteLine(AreEqual(true, true));

			//Using generic class Person
			Person p1 = new Person { Age = 20 };
			Person p2 = new Person { Age = 30 };
			Console.WriteLine("Compare two Person objects by Age");
			Console.WriteLine(AreEqual(p1, p2));

			//Custom generic list
			CustomList<int> myIntList = new CustomList<int>();

			myIntList.Add(1);
			myIntList.Add(2);
			myIntList.Add(3);
			myIntList.Add(4);
			myIntList.Add(5);
			myIntList.Add(6);

			//Console.WriteLine(myIntList.Capacity);
			//Console.WriteLine(myIntList.Count);

			//Need to add indexers to class CustomList before
			//Console.WriteLine(myIntList[0]);

			CustomList<int> myIntList2 = new CustomList<int>();
			myIntList2.Add(1);
			myIntList2.Add(2);
			myIntList2.Add(3);
			myIntList2.Add(4);
			myIntList2.Add(5);
			myIntList2.Add(6);

			// It needs to overload mathematical operator in customList class
			CustomList<int> result = myIntList + myIntList2;

			Console.WriteLine("Mathematical add one list to another");
			Console.WriteLine(result.ToString());

			Console.ReadKey();
		}

		public static bool AreEqual<T>(T num1, T num2) where T : IComparable<T> {
			return (num1.CompareTo(num2) == 0);
		}
	}
}