namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            string make = Console.ReadLine();
            string model = Console.ReadLine();

            int yearOfProduction = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            cars.Add(firstCar);

            Car secondCar = new Car(make, model, yearOfProduction);
            cars.Add(secondCar);

            Car thirdCar = new Car(make, model, yearOfProduction, fuelQuantity, fuelConsumption);
            cars.Add(thirdCar);

            foreach (Car car in cars)
            {
                Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nFuel: {car.FuelQuantity:F2}\nFuel Consumption: {car.FuelConsumption:F2}\n");
            }
        }
    }
}