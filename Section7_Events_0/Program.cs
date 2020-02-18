using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Section7_Events_0 {

	internal class Program {
		private static int score = 0;

		private static void Main(string[] args) {
			Shooter shooter = new Shooter();

			// Publisher 2) Subscribing events
			shooter.KillingCompleted += KilledEnemy;
			shooter.KillingCompleted += AddScore;

			// Publisher 3) Raise the Event
			shooter.OnShoot();
		}

		// Subscriber 1) Method with matching delegate signature
		public static void KilledEnemy(object sender, EventArgs e) {
			var tempSender = sender as Shooter;

			Console.WriteLine($"I killed an enemy and my name is {tempSender.Name}");
			Console.WriteLine($"Score is {score}");
		}

		public static void AddScore(object sender, EventArgs e) {
			score++;
		}
	}

	//Publisher
	internal class Shooter {
		private Random rng = new Random();
		public string Name { get; set; } = "TestName";

		// Publisher 1) Delegate matching the Event signature
		public delegate void KillingHandler(object sender, EventArgs e);

		// Publisher 2) Event of the same type as the Delegate
		public event KillingHandler KillingCompleted;

		public void OnShoot() {
			while(true) {
				if(rng.Next(0, 100) % 2 == 0) {
					//if(KillingCompleted != null) {
					//	KillingCompleted.Invoke(this, EventArgs.Empty);
					//}

					KillingCompleted?.Invoke(this, EventArgs.Empty);
				}
				else {
					Console.WriteLine("I missed");
				}
				Thread.Sleep(500);
			}
		}
	}
}