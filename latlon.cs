using System;
using System.Collections.Generic;
using System.IO;

namespace Cities
{
    public class LatLon
    {
        public static void Answer(string File = "LatLon.txt")
        {
            try
            {
                StreamReader sr = new StreamReader("zips.txt");
                List<int> zips = new List<int>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    zips.Add(int.Parse(line));
                }
                sr.Close();
                List<(float, float)> latlons = new List<(float, float)>();
                foreach (int zip in zips) {
                    foreach (var city in ReadZipCodes.cities)
                    {
                        if (city.ZipCode == zip)
                        {
                            latlons.Add((city.Latitude, city.Longitude));
                            break;
                        }
                    }
                }
                StreamWriter sw = new StreamWriter(File);
                foreach (var latlon in latlons)
                {
                    sw.WriteLine($"{latlon.Item1} {latlon.Item2}");
                }
                sw.Close();
            }
            catch (Exception) {}
        }
    }
}