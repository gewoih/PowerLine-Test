using System;

namespace PowerLine_Test
{
	class Program
	{
		static void Main(string[] args)
		{
			Car c = new Car(6.6, 60, 110, 5);
			Console.WriteLine($"Информация о транспортном средстве:\n{c.GetVehicleInfo()}");
			Console.WriteLine($"Запас хода: {c.GetRemainingDistance()}км.");
			Console.WriteLine($"Осталось ехать: {c.CalculateTimeDestination(c.GetRemainingDistance())}\n\n");

			Truck t = new Truck(18.5, 200, 40, 15);
			Console.WriteLine($"Информация о транспортном средстве:\n{t.GetVehicleInfo()}");
			Console.WriteLine($"Запас хода: {t.GetRemainingDistance()}км.");
			Console.WriteLine($"Осталось ехать: {t.CalculateTimeDestination(t.GetRemainingDistance())}");
		}
	}
}
