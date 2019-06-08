using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportProgram
{
    class Program
    {
        private static AirportRepository _airportRepository;

        static void Main(string[] args)
        {
            var airportDatabase = new AirportDatabase();
            _airportRepository = new AirportRepository(airportDatabase);

            var menuOption = MainMenu();

            while (menuOption <= 3)
            {
                switch (menuOption)
                {
                    case 1:
                        GetAllAirports();
                        break;
                    case 2:
                        AddAirport();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("That was an invalid option");
                        Clear();
                        break;
                }

                if (menuOption != 3)
                {
                    menuOption = MainMenu();
                }
            }
        }

        static int MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine(" +---------------------------+");
            Console.WriteLine(" |   Main Menu               |");
            Console.WriteLine(" |   1.  Get all airports    |");
            Console.WriteLine(" |   2.  Add an airport      |");
            Console.WriteLine(" |   3.  Exit                |");
            Console.WriteLine(" +---------------------------+");
            Console.WriteLine();
            Console.WriteLine(" Enter an option");

            var option = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(option))
            {
                return 3;
            }

            return int.Parse(option);
        }

        static void GetAllAirports()
        {
            var airports = _airportRepository.Get();

            if (!airports.Any())
            {
                Console.WriteLine("No airports have been added.");
            }
            else
            {
                foreach(var airport in airports)
                {
                    Console.WriteLine($"{airport.code}: {airport.name}");
                }
            }

            Clear();
        }

        static void AddAirport()
        {
            var airports = _airportRepository.Get();

            if (!airports.Any())
            {
                Console.Write("No airports have been added.");
            }
            else
            {
                Console.Write("Airport Name: ");
                var airportName = Console.ReadLine();

                foreach (var airport in airports)
                {
                    Console.WriteLine($"    {airport.code}: {airport.name}");
                }
                Console.Write("Enter the code of the airport: ");
                var airportCode = Console.ReadLine();

                var newAirport = new Airport
                {
                    name = airportName,
                    code = airportCode
                };

                _airportRepository.Add(newAirport);
                Console.WriteLine($"Airport {airportName} was added!");
            }

            Clear();
        }
        
        static void Clear()
        {
            Console.Write("Press <enter> to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
