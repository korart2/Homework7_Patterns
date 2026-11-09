using System;

namespace AbstractFactory
{
    public class AbstractFactoryProgram
    {
        public abstract class Car
        {
            public abstract void Info();
        }

        public class Ford : Car
        {
            public override void Info()
            {
                Console.WriteLine("Ford");
            }
        }

        public class Toyota : Car
        {
            public override void Info()
            {
                Console.WriteLine("Toyota");
            }
        }

        public class Mersedes : Car
        {
            public override void Info()
            {
                Console.WriteLine("Mersedes");
            }
        }

        public abstract class Engine
        {
            public virtual void GetPower()
            {
            }
        }

        public class FordEngine : Engine
        {
            public override void GetPower()
            {
                Console.WriteLine("Ford Engine 4.4");
            }
        }

        public class ToyotaEngine : Engine
        {
            public override void GetPower()
            {
                Console.WriteLine("Toyota Engine 3.2");
            }
        }

        public class MersedesEngine : Engine
        {
            public override void GetPower()
            {
                Console.WriteLine("Mersedes Engine 5.5");
            }
        }

        public interface ICarFactory
        {
            Car CreateCar();
            Engine CreateEngine();
        }

        public class FordFactory : ICarFactory
        {
            Car ICarFactory.CreateCar()
            {
                return new Ford();
            }

            Engine ICarFactory.CreateEngine()
            {
                return new FordEngine();
            }
        }

        public class ToyotaFactory : ICarFactory
        {
            Car ICarFactory.CreateCar()
            {
                return new Toyota();
            }

            Engine ICarFactory.CreateEngine()
            {
                return new ToyotaEngine();
            }
        }

        public class MersedesFactory : ICarFactory
        {
            Car ICarFactory.CreateCar()
            {
                return new Mersedes();
            }

            Engine ICarFactory.CreateEngine()
            {
                return new MersedesEngine();
            }
        }

        static void Main(string[] args)
        {
            ICarFactory carFactory = new ToyotaFactory();
            Car myCar = carFactory.CreateCar();
            myCar.Info();
            Engine myEngine = carFactory.CreateEngine();
            myEngine.GetPower();

            carFactory = new FordFactory();
            myCar = carFactory.CreateCar();
            myCar.Info();
            myEngine = carFactory.CreateEngine();
            myEngine.GetPower();

            carFactory = new MersedesFactory();
            myCar = carFactory.CreateCar();
            myCar.Info();
            myEngine = carFactory.CreateEngine();
            myEngine.GetPower();
        }
    }
}
