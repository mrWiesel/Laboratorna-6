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
        public string Brand { get; set; }
        public int Speed { get; set; }

        public Vehicle(string brand, int speed)
        {
            Brand = brand;
            Speed = speed;
        }
        public abstract void Move();
    }

    // Клас Car
    public class Car : Vehicle, IRefuelable
    {
        public Car(string brand, int speed) : base(brand, speed) { }

        public override void Move()
        {
            Console.WriteLine($"[Автомобіль] {Brand} їде по трасі зі швидкістю {Speed} км/год.");
        }

        public void Refill()
        {
            Console.WriteLine($"   -> Заправка автомобіля {Brand} бензином або дизелем...");
        }
    }

    // Клас Airplane
    public class Airplane : Vehicle, IRefuelable
    {
        public Airplane(string brand, int speed) : base(brand, speed) { }

        public override void Move()
        {
            Console.WriteLine($"[Літак] {Brand} летить у хмарах зі швидкістю {Speed} км/год.");
        }

        public void Refill()
        {
            Console.WriteLine($"   -> Заправка літака {Brand} авіаційним паливом...");
        }
    }

    // Клас Bicycle
    public class Bicycle : Vehicle
    {
        public Bicycle(string brand, int speed) : base(brand, speed) { }

        public override void Move()
        {
            Console.WriteLine($"[Велосипед] {Brand} їде по велодоріжці зі швидкістю {Speed} км/год.");
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
            Random rnd4 = new Random();

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Car("Таврія", rnd.Next(0, 121)),
                new Bicycle("Біцигля", rnd1.Next(0, 21)),
                new Airplane("МіГ 29", rnd2.Next(200, 2501)),
                new Airplane("МіГ 29 М1", rnd3.Next(200, 2501)),
                new Car("Satsuma", rnd4.Next(0, 201))
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
                    Console.WriteLine("   -> Цей транспорт не потребує пального.");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}