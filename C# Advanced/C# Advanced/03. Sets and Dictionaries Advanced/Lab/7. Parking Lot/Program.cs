namespace _7._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();
            string[] commands;
            while (true)
            {
                commands = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                //check if the command is "END" which means the program should stop working
                if (commands[0] == "END")
                {
                    //check if the parking lot is empty
                    if (parkingLot.Count == 0)
                    {
                        Console.WriteLine("Parking Lot is Empty");
                    }
                    else
                    {
                        //print the vehicles' numbers which are still in the parking lot (numbers which are in the hashset)
                        Console.WriteLine(string.Join(Environment.NewLine, parkingLot));
                    }

                    //stop the program
                    break;
                }

                //check if the direction is "IN" or "OUT"
                if (commands[0] == "IN")
                {
                    //add the vehicle's number to the hashset
                    parkingLot.Add(commands[1]);
                }
                else if (commands[0] == "OUT")
                {
                    //remove the vehicle's number from the hashset
                    parkingLot.Remove(commands[1]);
                }
            }
        }
    }
}