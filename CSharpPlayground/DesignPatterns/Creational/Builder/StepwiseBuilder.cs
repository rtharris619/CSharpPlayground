using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.Creational.Builder
{
    public class StepwiseBuilder
    {
        public void Driver()
        {
            var car = CarBuilder.Create()   // ISpecifyCarType
                .OfType(CarType.Crossover)  // ISpecifyWheelSize 
                .WithWheels(18)             // IBuildCar
                .Build();                   // Car
        }
    }

    public enum CarType
    {
        Sedan, Crossover
    }

    public class Car
    {
        public CarType CarType;
        public int WheelSize;
    }

    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }

    public interface ISpecifyWheelSize
    {
        IBuildCar WithWheels(int size);
    }

    public interface IBuildCar
    {
        public Car Build();
    }

    public class CarBuilder
    {
        private class Impl : ISpecifyCarType, ISpecifyWheelSize, IBuildCar
        {
            private Car car = new Car();
            public Car Build()
            {
                return car;
            }

            public ISpecifyWheelSize OfType(CarType type)
            {
                car.CarType = type;
                return this;
            }

            public IBuildCar WithWheels(int size)
            {
                switch (car.CarType)
                {
                    case CarType.Crossover when size < 17 || size > 20:
                    case CarType.Sedan when size < 15 || size > 17:
                        throw new ArgumentException($"Wrong size of wheel for {car.CarType}");
                }
                car.WheelSize = size;
                return this;
            }
        }
        public static ISpecifyCarType Create()
        {
            return new Impl();
        }
    }
}
