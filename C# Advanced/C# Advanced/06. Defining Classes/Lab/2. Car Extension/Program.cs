namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            string input = string.Empty;
            while (true)
            {
                input = Console.ReadLine();

                if (input == "End")
                {
                    foreach (Car item in cars)
                    {
                        Console.WriteLine($"Make: {item.Make}\nModel: {item.Model}\nYear: {item.Year}\nFuel: {item.FuelQuantity:F2}\nFuel Consumption: {item.FuelConsumption:F2}");
                    }

                    break;
                }

                if (!input.StartsWith("Drive") && !input.StartsWith("Print last car's details"))
                {
                    string[] carDetails = input.Split(' ');
                    Car car = new Car();
                    string make = carDetails[0];
                    string model = carDetails[1];
                    int yearOfProduction = int.Parse(carDetails[2]);
                    double fuelQuantity = double.Parse(carDetails[3]);
                    double fuelConsumption = double.Parse(carDetails[4]);

                    car.Make = make;
                    car.Model = model;
                    car.Year = yearOfProduction;
                    car.FuelQuantity = fuelQuantity;
                    car.FuelConsumption = fuelConsumption;

                    if (car.CheckTheGivenNumericValues() && !cars.Contains(car))
                    {
                        cars.Add(car);
                    }
                    else
                    {
                        Console.WriteLine("Invalid action! Either this car has already been added to the list or the given parameters are invalid.");
                    }
                }
                else
                {
                    Car lastAddedCar = cars.LastOrDefault();
                    if (lastAddedCar != null)
                    {
                        if (input.StartsWith("Drive"))
                        {
                            string[] drivenCarDetails = input.Split(" ");
                            double distanceToTravel = double.Parse(drivenCarDetails[1]);
                            lastAddedCar.Drive(distanceToTravel);
                        }
                        else
                        {
                            Console.WriteLine(lastAddedCar.WhoAmI());
                        }
                    }
                }
            }
        }
    }
}