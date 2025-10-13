namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.Cars = new List<Car>();
            this.capacity = capacity;
        }

        public List<Car> Cars { get { return cars; } set { cars = value; } }

        public int Count => this.Cars.Count;

        public string AddCar(Car car)
        {
            if (this.Cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.capacity == this.Cars.Count)
            {
                return "Parking is full!";
            }

            this.Cars.Add(car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (this.Cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                Car carToRemove = this.Cars.First(x => x.RegistrationNumber == registrationNumber);
                this.Cars.Remove(carToRemove);

                return $"Successfully removed {registrationNumber}";
            }

            return "Car with that registration number, doesn't exist!";
        }

        public Car GetCar(string registrationNumber)
        {
            return this.Cars.First(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string registrationNumber in registrationNumbers)
            {
                if (this.Cars.Any(x => x.RegistrationNumber == registrationNumber))
                {
                    Car carToRemove = this.Cars.First(x => x.RegistrationNumber == registrationNumber);
                    this.Cars.Remove(carToRemove);
                }
            }
        }
    }
}