namespace _06._Speed_Racing
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
                double fuelAmount = double.Parse(carDetails[1]);
                double fuelConsumptionPerOneKilometer = double.Parse(carDetails[2]);
                Car car = new Car(model, fuelAmount, fuelConsumptionPerOneKilometer);
                cars.Add(car);
            }

            string command = string.Empty;
            while (true)
            {
                command = Console.ReadLine();

                if (command == "End")
                {
                    foreach (Car car in cars)
                    {
                        Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
                    }

                    break;
                }

                string[] commandDetails = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (commandDetails[0] == "Drive")
                {
                    string carModel = commandDetails[1];
                    double distance = double.Parse(commandDetails[2]);
                    Car selectedCar = cars.FirstOrDefault(x => x.Model == carModel);
                    if (selectedCar != null)
                    {
                        selectedCar.DriveCar(distance);
                    }
                }
            }
        }
    }
}