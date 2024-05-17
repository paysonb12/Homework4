using Internal;
using System.Collections.Generic;
using System;
using System.IO;

namespace Cities {

    public class ReadZipCodes
    {
        public static string WholeFile {get; set;}
        public static List<City> cities {get; set;}

        public static void init(string File)
        {
            try {
                if (File == null)
                {
                    throw new ArgumentNullException("Need file");
                }

                StreamReader sr = new StreamReader(File);
                WholeFile = sr.ReadToEnd();
                sr.Close();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            cities = new List<City>();
        }

        public static void FindCities(string File = "zipcodes.txt")
        {
            init(File);
            string[] lines = WholeFile.Split('\n');
            foreach (string line in lines)
            {
                try
                {
                    string[] vars = line.Split('\t');
                    cities.Add(new City(
                        vars[0],
                        vars[1],
                        vars[3],
                        vars[4],
                        vars[6],
                        vars[7]
                    ));
                }
                catch (Exception) {}
            }
        }
    }
}
