using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerLine_Test
{
	public abstract class Vehicle
	{
		/// <summary>
		/// Тип транспортного средства
		/// </summary>
		private Type VehicleType => this.GetType();

		/// <summary>
		/// Среднее потребление топлива транспортного средства в литрах на 100км.
		/// </summary>
		private double FuelConsumption { get; }

		/// <summary>
		/// Объем топливного бака транспортного средства в литрах
		/// </summary>
		private double FuelCapacity { get; }

		/// <summary>
		/// Скорость транспортного средства в км/ч
		/// </summary>
		private double Speed { get; }

		public Vehicle(double fuelConsumption, double fuelCapacity, double speed)
		{
			this.FuelConsumption = fuelConsumption;
			this.FuelCapacity = fuelCapacity;
			this.Speed = speed;
		}

		/// <summary>
		/// Подсчет расстояния, которое автомобиль может преодолеть на оставшемся топливе
		/// </summary>
		/// <returns>Расстояние в километрах</returns>
		public virtual double GetRemainingDistance()
		{
			return this.FuelCapacity * this.FuelConsumption;
		}
		
		/// <summary>
		/// Формирование строки состояния транспортного средства
		/// </summary>
		/// <returns>Общая информация о транспортном средстве</returns>
		public virtual string GetVehicleInfo()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine($"Тип транспортного средства: [{this.VehicleType}]");
			stringBuilder.AppendLine($"Оставшийся объем топлива: {this.FuelCapacity}л.");
			stringBuilder.AppendLine($"Текущая скорость: {this.Speed}км./ч.");
			stringBuilder.AppendLine($"Средний расход топлива: {this.FuelConsumption}л/100км.");

			return stringBuilder.ToString();
		}

		/// <summary>
		/// Подсчет времени, которое потребуется транспортному средству для преодоления заданного расстояния
		/// </summary>
		/// <param name="distance">Расстояние, которое должно преодолеть транспортное средство</param>
		/// <returns>Необходимое время</returns>
		public virtual TimeSpan CalculateTimeDestination(double distance)
		{
			if (this.GetRemainingDistance() < distance)
				throw new Exception("Недостаточно топлива для прохождения заданного расстояния!");
			else
				return TimeSpan.FromHours(distance / this.Speed);
		}
	}
}
