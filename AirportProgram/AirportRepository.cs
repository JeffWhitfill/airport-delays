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

        public List<Airport> Get()
        {
            return _airportDatabase.Airports;
        }

        public Airport Get(int id)
        {
            return _airportDatabase.Airports.Single(c => c.id == id);
        }

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

        public void Remove (int id)
        {
            var dbAirport = _airportDatabase.Airports.Single(c => c.id == id);
            _airportDatabase.Airports.Remove(dbAirport);
            _airportDatabase.SaveChanges();
        }
    }
}
