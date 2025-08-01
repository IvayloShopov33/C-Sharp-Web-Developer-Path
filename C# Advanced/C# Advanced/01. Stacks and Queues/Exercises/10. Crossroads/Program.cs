namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int greenLightDuration = int.Parse(Console.ReadLine());
            int initialGreenLightDuration = greenLightDuration;

            int freeWindowDuration = int.Parse(Console.ReadLine());
            string commandOrCar = Console.ReadLine();

            int carsPassed = 0;
            bool isThereACrash = false;

            while (commandOrCar != "END")
            {
                if (!isThereACrash)
                {

                    if (commandOrCar == "green")
                    {
                        greenLightDuration = initialGreenLightDuration;
                        while (cars.Count > 0)
                        {
                            string car = cars.Dequeue();
                            if (car.Length < greenLightDuration)
                            {
                                carsPassed++;
                                greenLightDuration -= car.Length;
                            }
                            else if (car.Length == greenLightDuration)
                            {
                                carsPassed++;
                                break;
                            }
                            else if (car.Length > greenLightDuration)
                            {
                                int remainingCharsInTheCrossRoads = car.Length - greenLightDuration;
                                if (remainingCharsInTheCrossRoads <= freeWindowDuration)
                                {
                                    carsPassed++;
                                    break;
                                }
                                else
                                {
                                    char crashingCharacter = car[freeWindowDuration + greenLightDuration];
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{car} was hit at {crashingCharacter}.");

                                    isThereACrash = true;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        cars.Enqueue(commandOrCar);
                    }
                }
                
                commandOrCar = Console.ReadLine();
            }

            if (!isThereACrash)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
            }
        }
    }
}