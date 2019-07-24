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

            // create interface menu

            var menuOption = MainMenu();

            while (menuOption <= 4)
            {
                switch (menuOption)
                {
                    // display all airports
                    case 1:
                        GetAllAirports();
                        break;
                    // add a new airport to the list
                    case 2:
                        AddAirport();
                        break;
                    // remove an airport from the list
                    case 3:
                        RemoveAirport();
                        break;
                    case 4:
                        break;
                    default:
                    // validate what the user input
                        Console.WriteLine("That was an invalid option");
                        Clear();
                        break;
                }

                if (menuOption != 4)
                {
                    menuOption = MainMenu();
                }
            }
        }

        // display menu
        static int MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine(" +---------------------------+");
            Console.WriteLine(" |   Main Menu               |");
            Console.WriteLine(" |   1.  Get all airports    |");
            Console.WriteLine(" |   2.  Add an airport      |");
            Console.WriteLine(" |   3.  Remove an airport   |");
            Console.WriteLine(" |   4.  Exit                |");
            Console.WriteLine(" +---------------------------+");
            Console.WriteLine();
            Console.WriteLine(" Enter an option");

            var option = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(option))
            {
                return 4;
            }

            return int.Parse(option);
        }

        //function to display all airports
        static void GetAllAirports()
        {
            var airports = _airportRepository.Get();
            

            // check to see if datafile is empty
            if (!airports.Any())
            {
                Console.WriteLine("No airports have been added.");
            }
            else
            // create line for each airport with their number of delays and the length of tthe delay
            {
                foreach (var airport in airports)
                {
                    if (airport.statistics != null)
                    {
                        Console.WriteLine($"{airport.code}: {airport.name}  had {airport.statistics.flights.delayed} flight delays for a total of {airport.statistics.minutesDelayed.total} minutes");
                    }
                   
                    
                }
                   
            }

            Clear();
        }

        //  function to add a new airport to datafile
        static void AddAirport()
        {
            var airports = _airportRepository.Get();

            //check to see if datafile is empty
            if (!airports.Any())
            {
                Console.Write("No airports have been added.");
            }
            else
            {
                //ask for name of new airport
                Console.Write("Airport Name: ");
                var airportName = Console.ReadLine();

                //ask for code and delays of new airport
                Console.Write("Enter the code of the airport: ");
                var airportCode = Console.ReadLine();
                Console.Write("Enter the number of delays of the airport: ");

                foreach (var airport in airports)
                {
                    Console.WriteLine($"{airport.code ?? "null"}: {airport.name ?? "null"}  had {airport.statistics?.flights?.delayed ?? -1} flight delays for a total of {airport.statistics?.minutesDelayed?.total ?? -1} minutes");
                }
                
               // create new instance of airport
                var newAirport = new Airport
                {
                    name = airportName,
                    code = airportCode,                    
                    
                };

                _airportRepository.Add(newAirport);

                // validate that new airport was added to datafile
                Console.WriteLine($"Airport {airportName} was added!");
            }

            Clear();
        }

        static void RemoveAirport()
        {
            var airports = _airportRepository.Get();

            if (!airports.Any())
            {
                Console.Write("No airports have been removed.");
            }
            else
            {
                // enter airport id to be removed
                Console.Write("Airport Id: ");
                var airportId = Console.ReadLine();
                try
                {
                    int id = Int32.Parse(airportId);
                    _airportRepository.Remove(id);
                }
               
                // throw exception if entry is not an integer
                catch (Exception)
                {

                    Console.WriteLine("{0} is not a valid id.  Please enter an integer.", airportId);
                }
                Console.Write("Airport Name: ");
                var airportName = Console.ReadLine();

                
                Console.WriteLine($"Airport {airportName} was removed!");
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
