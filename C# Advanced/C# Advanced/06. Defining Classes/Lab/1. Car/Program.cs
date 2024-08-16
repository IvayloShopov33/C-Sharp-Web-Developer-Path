namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            string carsDetails = string.Empty;
            while (true)
            {
                carsDetails = Console.ReadLine();
                if (carsDetails == "End")
                {
                    foreach (Car item in cars)
                    {
                        Console.WriteLine($"Make: {item.Make}\nModel: {item.Model}\nYear: {item.Year}\n");
                    }

                    break;
                }

                string[] newDetails = carsDetails.Split(' ');
                string make = newDetails[0];
                string model = newDetails[1];
                int yearOfProduction = int.Parse(newDetails[2]);

                Car car = new Car();
                car.Make = make;
                car.Model = model;
                car.Year = yearOfProduction;

                if (car.CheckIfTheYearIsValid())
                {
                    cars.Add(car);
                }
                else
                {
                    Console.WriteLine("Invalid year of production!");
                }
            }

        }
    }
}