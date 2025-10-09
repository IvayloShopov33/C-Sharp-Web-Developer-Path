namespace _07._Raw_Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= carsCount; i++)
            {
                string[] carDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carDetails[0];
                int engineSpeed = int.Parse(carDetails[1]);
                int enginePower = int.Parse(carDetails[2]);
                int cargoWeight = int.Parse(carDetails[3]);
                string cargoType = carDetails[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                List<Tire> tires = new List<Tire>();
                
                for (int j = 5; j < carDetails.Length; j += 2)
                {
                    double tirePressure = double.Parse(carDetails[j]);
                    int tireAge = int.Parse(carDetails[j + 1]);
                    
                    Tire tire = new Tire(tireAge, tirePressure);
                    tires.Add(tire);
                }

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string commandOfCargoType = Console.ReadLine();
            cars = cars.Where(x => x.Cargo.Type == commandOfCargoType).ToList();

            if (commandOfCargoType == "fragile")
            {
                foreach (Car car in cars)
                {
                    foreach (Tire tire in car.Tires)
                    {
                        if (tire.Pressure < 1)
                        {
                            Console.WriteLine(car.Model);
                            break;
                        }
                    }
                }
            }
            else if (commandOfCargoType == "flammable")
            {
                cars = cars.Where(x => x.Engine.Power > 250).ToList();
                foreach (Car car in cars)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
