namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();
            List<Tire[]> tires = new List<Tire[]>();

            string[] inputTires;
            while (true)
            {
                inputTires = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputTires[0] == "No" && inputTires.Length == 3)
                {
                    break;
                }

                int tiresCount = 0;
                Tire[] tiresToAdd = new Tire[4];

                for (int i = 0; i < inputTires.Length - 1; i += 2)
                {
                    int year = int.Parse(inputTires[i]);
                    double pressure = double.Parse(inputTires[i + 1]);

                    Tire tire = new Tire(year, pressure);
                    tiresToAdd[tiresCount] = tire;
                    tiresCount++;
                }

                tires.Add(tiresToAdd);
            }

            string[] inputEngines;
            while (true)
            {
                inputEngines = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputEngines[0] == "Engines" && inputEngines.Length == 2)
                {
                    break;
                }

                int horsePower = int.Parse(inputEngines[0]);
                double cubicCapacity = double.Parse(inputEngines[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            string[] inputCarDetails;
            while (true)
            {
                inputCarDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputCarDetails[0] == "Show" && inputCarDetails.Length == 2)
                {
                    List<Car> specialCars = cars.Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330 &&
                    x.Tires.Select(y => y.Pressure).Sum() >= 9 && x.Tires.Select(y => y.Pressure).Sum() <= 10).ToList();

                    foreach (Car automobile in specialCars)
                    {
                        automobile.Drive(20);
                        Console.WriteLine($"Make: {automobile.Make}\nModel: {automobile.Model}\nYear: {automobile.Year}\nHorsePowers: {automobile.Engine.HorsePower}\nFuelQuantity: {automobile.FuelQuantity}");
                    }

                    break;
                }

                string make = inputCarDetails[0];
                string model = inputCarDetails[1];

                int yearOfProduction = int.Parse(inputCarDetails[2]);
                double fuelQuantity = double.Parse(inputCarDetails[3]);
                double fuelConsumption = double.Parse(inputCarDetails[4]);
                int engineIndex = int.Parse(inputCarDetails[5]);
                int tiresIndex = int.Parse(inputCarDetails[6]);

                Engine selectedEngine = engines[engineIndex];
                Tire[] selectedTires = tires[tiresIndex];

                Car car = new Car(make, model, yearOfProduction, fuelQuantity, fuelConsumption, selectedEngine, selectedTires);
                cars.Add(car);
            }
        }
    }
}