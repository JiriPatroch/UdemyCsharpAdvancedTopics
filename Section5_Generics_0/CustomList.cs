using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section5_Generics_0 {

	internal class CustomList<T> {
		private T[] items;
		private int count;
		private int capacity;

		//Adding indexer
		public T this[int index] {
			get {
				return this.items[index];
			}
			private set {
				this.items[index] = value;
			}
		}

		public int Count {
			get {
				return this.count;
			}
			private set {
				this.count = value;
			}
		}

		public int Capacity {
			get {
				return this.capacity;
			}
			private set {
				this.capacity = value;
			}
		}

		public CustomList() {
			this.items = new T[2];
			this.Capacity = 2;
			this.Count = 0;
		}

		public void Add(T item) {
			if(this.capacity == this.count) {
				T[] clone = (T[])items.Clone();
				this.capacity *= 2;
				this.items = new T[this.capacity];

				Array.Copy(clone, this.items, clone.Length);
			}
			this.items[this.count] = item;
			this.count++;
		}

		public static CustomList<T> operator +(CustomList<T> list1, CustomList<T> list2) {
			CustomList<T> result = new CustomList<T>();

			if(list1.count != list2.count) {
				throw new InvalidOperationException("Lists are of different sizes!");
			}
			else {
				for(int i = 0; i < list1.count; i++) {
					result.Add((dynamic)list1[i] + list2[i]);
				}
			}

			return result;
		}

		public override string ToString() {
			//This will write also empty zero numbers because of capacity
			//return string.Join(",", this.items);

			string tempString = string.Empty;

			//Prevent from writting empty zero numbers from capacity
			for(int i = 0; i < this.count; i++) {
				if(i <this.count -1) {
					tempString += this.items[i] + ", ";
				}
				else {
					tempString += this.items[i];
				}
			}

			return tempString;
		}
	}
}