using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportProgram
{
    public class AirportRepository
    {
        private readonly AirportDatabase _airportDatabase;

        public AirportRepository(AirportDatabase airportDatabase)
        {
            _airportDatabase = airportDatabase;
        }

        //get the list of airports
        public List<Airport> Get()
        {
            return _airportDatabase.Airports;
        }

        public Airport Get(int id)
        {
            return _airportDatabase.Airports.Single(c => c.id == id);
        }
        // add airport to database and save database
        public void Add (Airport Airport)
        {
            if (_airportDatabase.Airports.Any())
            {
                Airport.id = _airportDatabase.Airports.Max(c => c.id) + 1;
            }
            else
            {
                Airport.id = 101;
            }

            _airportDatabase.Airports.Add(Airport);
            _airportDatabase.SaveChanges();
        }

        // remove airport from database and save database
        public void Remove (int id)
        {
            var dbAirport = _airportDatabase.Airports.Single(c => c.id == id);
            _airportDatabase.Airports.Remove(dbAirport);
            _airportDatabase.SaveChanges();
        }
    }
}
