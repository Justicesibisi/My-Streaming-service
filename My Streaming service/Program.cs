using System;
using System.Collections.Generic;

namespace GuptasBiskop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\u001b[44m\u001b[37mWelcome to Gupta's Biskop - Your Family Cinema!\u001b[0m");
            Console.WriteLine("\u001b[44m------------------------------------------------\u001b[0m");

            Dictionary<string, int> movieTickets = new Dictionary<string, int>();

            while (true)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("\u001b[34m1. Book tickets");
                Console.WriteLine("2. View booked tickets");
                Console.WriteLine("3. Exit\u001b[0m");

                Console.Write("\u001b[37mEnter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BookTickets(movieTickets);
                        break;
                    case "2":
                        ViewBookedTickets(movieTickets);
                        break;
                    case "3":
                        Console.WriteLine("\u001b[44m\u001b[37mThank you for choosing Gupta's Biskop. Have a great day!\u001b[0m");
                        return;
                    default:
                        Console.WriteLine("\u001b[31mInvalid choice. Please try again.\u001b[0m");
                        break;
                }
            }
        }

        static void BookTickets(Dictionary<string, int> movieTickets)
        {
            Console.WriteLine("\nAvailable Movies:");
            Console.WriteLine("\u001b[34m1. Avengers: Endgame");
            Console.WriteLine("2. The Lion King");
            Console.WriteLine("3. Frozen II\u001b[0m");

            Console.Write("\u001b[37mEnter the movie number: ");
            string movie = Console.ReadLine();

            if (movie != "1" && movie != "2" && movie != "3")
            {
                Console.WriteLine("\u001b[31mInvalid movie selection.\u001b[0m");
                return;
            }

            Console.Write("Enter the number of tickets: ");
            if (!int.TryParse(Console.ReadLine(), out int tickets))
            {
                Console.WriteLine("\u001b[31mInvalid input for number of tickets.\u001b[0m");
                return;
            }

            if (tickets <= 0)
            {
                Console.WriteLine("\u001b[31mNumber of tickets must be greater than zero.\u001b[0m");
                return;
            }

            string movieName = GetMovieName(movie);
            if (!movieTickets.ContainsKey(movieName))
            {
                movieTickets[movieName] = tickets;
            }
            else
            {
                movieTickets[movieName] += tickets;
            }

            Console.WriteLine($"\u001b[32m{tickets} ticket(s) booked for {movieName}.\u001b[0m");
        }

        static void ViewBookedTickets(Dictionary<string, int> movieTickets)
        {
            if (movieTickets.Count == 0)
            {
                Console.WriteLine("\u001b[31mNo tickets booked yet.\u001b[0m");
                return;
            }

            Console.WriteLine("\nBooked Tickets:");
            foreach (var entry in movieTickets)
            {
                Console.WriteLine($"\u001b[34m{entry.Value} ticket(s) for {entry.Key}\u001b[0m");
            }
        }

        static string GetMovieName(string movieNumber)
        {
            switch (movieNumber)
            {
                case "1":
                    return "Avengers: Endgame";
                case "2":
                    return "The Lion King";
                case "3":
                    return "Frozen II";
                default:
                    return "Unknown";
            }
        }
    }
}
