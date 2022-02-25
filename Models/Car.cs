using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerLine_Test
{
	public class Car : Vehicle
	{
		/// <summary>
		/// Количество сидячих мест в автомобиле
		/// </summary>
		private ushort Seats { get; }

		public Car(double fuelConsumption, double fuelCapacity, double speed, ushort seats) : base(fuelConsumption, fuelCapacity, speed)
		{
			this.Seats = seats;
		}

		public override string GetVehicleInfo()
		{
			return base.GetVehicleInfo() + $"Количество сидячих мест: {this.Seats}";
		}

		public override double GetRemainingDistance()
		{
			double distance = base.GetRemainingDistance();
			for (int i = this.Seats; i > 0; i--)
				distance *= 0.94;

			return Math.Round(distance, 2);
		}

		public void TryBoardPassangers(int passengers)
		{
			if (passengers > this.Seats)
				throw new Exception("Число пассажиров превышает количество сидячих мест в автомобиле!");
		}
	}
}
