using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section5_Generics_0 {

	internal class Person: IComparable<Person> {
		public int Age { get; set; }

		//Implemented interface IComparable
		public int CompareTo(Person other) {
			if(this.Age < other.Age) {
				return -1;
			}
			else if(this.Age == other.Age) {
				return 0;
			}
			else {
				return 1;
			}
		}
	}
}