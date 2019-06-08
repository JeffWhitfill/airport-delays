using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportProgram
{
    public class AirportDatabase
    {
        private readonly string _airportsFilePath;
    
        public AirportDatabase ()
        {
            var folderPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            _airportsFilePath = Path.Combine(folderPath, "americanairlines.json");
            Load();
        }

        public List<Airport> Airports { get; set; } 

        private void Load()
        {
            if (File.Exists(_airportsFilePath))
            {
                using (var reader = new StreamReader(_airportsFilePath))
                {
                    var americanairlinesJson = reader.ReadToEnd();
                    Airports = JsonConvert.DeserializeObject<List<Airport>>(americanairlinesJson);
                }
            }
        }

        public void SaveChanges()
        {
            var americanairlinesJson = JsonConvert.SerializeObject(Airports);
            var airportsFile = File.Create(_airportsFilePath);
            using (var writer = new StreamWriter(airportsFile))
            {
                writer.Write(americanairlinesJson);
            }
        }
    }
}
