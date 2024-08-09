using System;

namespace _06_Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {

            {
                string movie = Console.ReadLine();
                int seats = int.Parse(Console.ReadLine());
                int totalTickets = 0;
                int studentTickets = 0;
                int standardTickets = 0;
                int kidsTickets = 0;

                while (movie != "Finish")
                {
                    int soldTickets = 0;

                    while (soldTickets < seats)
                    {
                        string ticketType = Console.ReadLine();

                        if (ticketType == "End")
                        {
                            break;
                        }

                        switch (ticketType)
                        {
                            case "student":
                                studentTickets++;
                                break;
                            case "standard":
                                standardTickets++;
                                break;
                            case "kid":
                                kidsTickets++;
                                break;
                            default:
                                break;
                        }

                        soldTickets++;
                        totalTickets++;
                    }

                    double percentageFull = 100.0 * soldTickets / seats;
                    Console.WriteLine($"{movie} - {percentageFull:F2}% full.");

                    movie = Console.ReadLine();

                    if (movie != "Finish")
                    {
                        seats = int.Parse(Console.ReadLine());
                    }
                }

                double percentageStudent = 100.0 * studentTickets / totalTickets;
                double percentageStandard = 100.0 * standardTickets / totalTickets;
                double percentageKids = 100.0 * kidsTickets / totalTickets;

                Console.WriteLine($"Total tickets: {totalTickets}");
                Console.WriteLine($"{percentageStudent:F2}% student tickets.");
                Console.WriteLine($"{percentageStandard:F2}% standard tickets.");
                Console.WriteLine($"{percentageKids:F2}% kids tickets.");
            }
        }


    }
}

