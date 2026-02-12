using System.Text;
namespace VehicleSimulation
{
    public interface IRefuelable
    {
        void Refill();
    }

    // Абстрактний базовий клас
    public abstract class Vehicle
    {
        public string Trans { get; set; }
        public int Spid { get; set; }

        public Vehicle(string car, int speed)
        {
            Trans = car;
            Spid = speed;
        }
        public abstract void Move();
    }

    // Клас Car
    public class Car : Vehicle, IRefuelable
    {
        public Car(string brand, int speed) : base(brand, speed) { }
        public override void Move()
        {
            Console.WriteLine($"{Trans} їде по трасі зі швидкістю {Spid} км/год.");
        }
        public void Refill()
        {
            Console.WriteLine($">>>Заправка автомобіля {Trans} бензином або дизелем...");
        }
    }

    // Клас Airplane
    public class Airplane : Vehicle, IRefuelable
    {
        public Airplane(string plane, int speed) : base(plane, speed) { }
        public override void Move()
        {
            Console.WriteLine($"{Trans} летить зі швидкістю {Spid} км/год.");
        }
        public void Refill()
        {
            Console.WriteLine($">>>Заправка літака {Trans} авіаційним паливом...");
        }
    }

    // Клас Bicycle
    public class Bicycle : Vehicle
    {
        public Bicycle(string brand, int speed) : base(brand, speed) { }

        public override void Move()
        {
            Console.WriteLine($"[Велосипед] {Trans} їде по велодоріжці зі швидкістю {Spid} км/год.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Random rnd = new Random();
            Random rnd1 = new Random();
            Random rnd2 = new Random();
            Random rnd3 = new Random();

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Car("Таврія", rnd.Next(1, 121)),
                new Bicycle("Біцигля", rnd1.Next(1, 26)),
                new Airplane("МіГ 29", rnd2.Next(200, 2501)),
                new Airplane("МіГ 29 М1", rnd2.Next(200, 2501)),
                new Car("Satsuma", rnd3.Next(1, 201))
            };

            Console.WriteLine("Початок симуляції руху\n");

            foreach (var vehicle in vehicles)
            {
                vehicle.Move();

                if (vehicle is IRefuelable refuelableVehicle)
                {
                    refuelableVehicle.Refill();
                }
                else
                {
                    Console.WriteLine("Цей транспорт не потребує пального.");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}