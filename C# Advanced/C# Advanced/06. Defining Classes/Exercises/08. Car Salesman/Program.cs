namespace _08._Car_Salesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= enginesCount; i++)
            {
                string[] engineDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string engineModel = engineDetails[0];
                int enginePower = int.Parse(engineDetails[1]);
                Engine engine = null;

                if (engineDetails.Length == 2)
                {
                    engine = new Engine(engineModel, enginePower);
                }
                else if (engineDetails.Length == 3 && char.IsDigit(engineDetails[2][0]))
                {
                    int engineDisplacement = int.Parse(engineDetails[2]);
                    engine = new Engine(engineModel, enginePower, engineDisplacement);
                }
                else if (engineDetails.Length == 3 && char.IsLetter(engineDetails[2][0]))
                {
                    int displacement = 0;
                    string engineEfficiency = engineDetails[2];

                    engine = new Engine(engineModel, enginePower, displacement, engineEfficiency);
                }
                else if (engineDetails.Length == 4)
                {
                    int engineDisplacement = int.Parse(engineDetails[2]);
                    string engineEfficiency = engineDetails[3];

                    engine = new Engine(engineModel, enginePower, engineDisplacement, engineEfficiency);
                }

                if (engine != null)
                {
                    engines.Add(engine);
                }
            }

            List<Car> cars = new List<Car>();
            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= carsCount; i++)
            {
                string[] carDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = carDetails[0];
                string carEngine = carDetails[1];

                Engine engine = engines.FirstOrDefault(x => x.Model == carEngine);
                Car car = null;

                if (carDetails.Length == 2)
                {
                    car = new Car(carModel, engine);
                }
                else if (carDetails.Length == 3 && char.IsDigit(carDetails[2][0]))
                {
                    int carWeight = int.Parse(carDetails[2]);
                    car = new Car(carModel, engine, carWeight);
                }
                else if (carDetails.Length == 3 && char.IsLetter(carDetails[2][0]))
                {
                    int weight = 0;
                    string carColor = carDetails[2];

                    car = new Car(carModel, engine, weight, carColor);
                }
                else if (carDetails.Length == 4)
                {
                    int carWeight = int.Parse(carDetails[2]);
                    string carColor = carDetails[3];

                    car = new Car(carModel, engine, carWeight, carColor);
                }

                if (car != null)
                {
                    cars.Add(car);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}