namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= carsCount; i++)
            {
                Console.WriteLine("Write the details of your car: Make, Model, Year of production, Fuel quantity and consumption, Engine- horsepower and cubic capacity, 4 tires- years of use and pressure");
                string[] carDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = carDetails[0];
                string model = carDetails[1];
                int yearOfProduction = int.Parse(carDetails[2]);
                double fuelQuantity = double.Parse(carDetails[3]);
                double fuelConsumption = double.Parse(carDetails[4]);
                int horsePower = int.Parse(carDetails[5]);
                double cubicCapacity = double.Parse(carDetails[6]);
                Engine engine = new Engine(horsePower, cubicCapacity);
                Tire[] tires = new Tire[4];
                for (int j = 0; j < tires.Length; j++)
                {
                    int year = int.Parse(carDetails[7 + j]);
                    double pressure = double.Parse(carDetails[8 + j]);
                    tires[j] = new Tire(year, pressure);
                }

                Car car = new Car(make, model, yearOfProduction, fuelQuantity, fuelConsumption, engine, tires);
                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nFuel: {car.FuelQuantity:F2}\nFuel Consumption: {car.FuelConsumption:F2}\nEngine: {car.Engine.HorsePower} horsepower, {car.Engine.CubicCapacity:F2} cubic capacity");
                Console.WriteLine("Tires:");
                foreach (Tire tire in car.Tires)
                {
                    Console.WriteLine($"Years of use: {tire.Year}");
                    Console.WriteLine($"Pressure: {tire.Pressure}");
                }
                Console.WriteLine();
            }
        }
    }
}