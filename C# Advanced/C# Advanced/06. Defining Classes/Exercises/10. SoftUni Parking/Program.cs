namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car("Mazda", "Miata", 70, "CC1857BG");
            Car car2 = new Car("Lamborghini", "Huracan", 600, "EB9999MN");

            Console.WriteLine(car.ToString());
            Parking parking = new Parking(5);

            Console.WriteLine(parking.AddCar(car));
            Console.WriteLine(parking.AddCar(car));
            Console.WriteLine(parking.AddCar(car2));
            Console.WriteLine(parking.GetCar("EB9999MN").ToString());
            Console.WriteLine(parking.RemoveCar("EB9999MN"));

            List<string> registrationNumbers = new List<string>
            {
                "CC1857BG"
            };

            parking.RemoveSetOfRegistrationNumber(registrationNumbers);
            Console.WriteLine(parking.Count);
        }
    }
}