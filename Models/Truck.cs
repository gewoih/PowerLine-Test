using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerLine_Test
{
	public class Truck : Vehicle
	{
		/// <summary>
		/// Грузоподъемность грузовика в тоннах
		/// </summary>
		private double CarryingCapacity { get; }

		public Truck(double fuelConsumption, double fuelCapacity, double speed, double carryingCapacity) : base(fuelConsumption, fuelCapacity, speed)
		{
			this.CarryingCapacity = carryingCapacity;
		}

		public override string GetVehicleInfo()
		{
			return base.GetVehicleInfo() + $"Грузоподъемность: {this.CarryingCapacity}т.";
		}

		public override double GetRemainingDistance()
		{
			double distance = base.GetRemainingDistance();
			for (int i = (int)(this.CarryingCapacity * 5); i > 0; i--)
				distance *= 0.96;

			return Math.Round(distance, 2);
		}

		public void TryLoadCapacity(int capacity)
		{
			if (capacity > this.CarryingCapacity)
				throw new Exception("Загружаемый объем больше грузоподъемности грузовика!");
		}
	}
}
