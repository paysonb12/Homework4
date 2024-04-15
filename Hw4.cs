

/* 
  Homework#4

  Add your name here: Payson briggs

  You are free to create as many classes within the Hw4.cs file or across 
  multiple files as you need. However, ensure that the Hw4.cs file is the 
  only one that contains a Main method. This method should be within a 
  class named hw4. This specific setup is crucial because your instructor 
  will use the hw4 class to execute and evaluate your work.
  */
  // BONUS POINT:
  // => Used Pointers from lines 10 to 15 <=
  // => Used Pointers from lines 40 to 63 <=
  

using system;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LatLonMap = System.Collections.Generic.Dictionary<string, System.Tuple<double, double>>;

public class Hw4
{
    public static void Main(string[] args)
    {
        // Capture the start time
        // Must be the first line of this method
        DateTime startTime = DateTime.Now; // Do not change
        // ============================
        // Do not add or change anything above, inside the 
        // Main method
        // ============================





        // TODO: your code goes here
      // Read states and cities
       string zipCodesFile = "zipcodes.txt";
            string zipsFile = "zips.txt";

            // Read data files
            List<string> zipCodesData = File.ReadAllLines(zipCodesFile).ToList();
            List<string> zipsData = File.ReadAllLines(zipsFile).ToList();

            // Process data
            var zipCodeLocations = ProcessZipCodes(zipCodesData);
            var latLonMap = GenerateLatLonMap(zipsData, zipCodeLocations);

            // Write output file
            WriteToFile("LatLon.txt", latLonMap);
        }

        // Method to process zip code data
        public static List<ZipCodeLocation> ProcessZipCodes(List<string> zipCodesData)
        {
            List<ZipCodeLocation> zipCodeLocations = new List<ZipCodeLocation>();

            foreach (var line in zipCodesData.Skip(1)) // Skip header line
            {
                string[] parts = line.Split('\t');
                string zipCode = parts[1]; // Zipcode is the second field

                // Add error handling for latitude and longitude parsing
                double latitude, longitude;
                if (!double.TryParse(parts[6], out latitude) || !double.TryParse(parts[7], out longitude))
                {
                    Console.WriteLine($"Error parsing latitude or longitude for zip code {zipCode}. Skipping this entry.");
                    continue; // Skip this entry and move to the next one
                }

                zipCodeLocations.Add(new ZipCodeLocation(zipCode, latitude, longitude));
            }

            return zipCodeLocations;
        }

        // Method to generate latitude-longitude map
        public static LatLonMap GenerateLatLonMap(List<string> zipsData, List<ZipCodeLocation> zipCodeLocations)
        {
            LatLonMap latLonMap = new LatLonMap();

            foreach (var zipCode in zipsData)
            {
                // Skip 
                var location = zipCodeLocations.FirstOrDefault(z => z.ZipCode == zipCode);
                if (location == null)
                {
                    Console.WriteLine($"Location data not found for zip code: {zipCode}. Skipping.");
                    continue;
                }

                // Add latitude and longitude to the map
                latLonMap.Add(zipCode, Tuple.Create(location.Latitude, location.Longitude));
            }

            return latLonMap;
        }

        // Method to write latitude-longitude map to file
        public static void WriteToFile(string fileName, LatLonMap latLonMap)
        {
            var lines = latLonMap.Select(kv => $"{kv.Key} {kv.Value.Item1} {kv.Value.Item2}");
            File.WriteAllLines(fileName, lines);
        }
    }
public class ZipCodeLocation
    {
        public string ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // Constructor
        public ZipCodeLocation(string zipCode, double latitude, double longitude)
        {
            ZipCode = zipCode;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
      

     





        

        // ============================
        // Do not add or change anything below, inside the 
        // Main method
        // ============================

        // Capture the end time
        DateTime endTime = DateTime.Now;  // Do not change
        
        // Calculate the elapsed time
        TimeSpan elapsedTime = endTime - startTime; // Do not change
        
        // Display the elapsed time in milliseconds
        Console.WriteLine($"Elapsed Time: {elapsedTime.TotalMilliseconds} ms");
    }
}
