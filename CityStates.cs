using System;
using System.Collections.Generic;
using System.IO;

namespace Cities
{
    public class CityStates
    {
        public static void Answer(string File = "CityStates.txt")
        {
            try
            {
                List<string> cities = new List<string>();
                string line;
                StreamReader sr = new StreamReader("cities.txt");
                while ((line = sr.ReadLine()) != null)
                {
                    cities.Add(line.ToUpper());
                }
                sr.Close();
                StreamWriter sw = new StreamWriter(File);
                foreach (string city in cities)
                {
                    List<string> states = CommonCityNames.cities[city];
                    states.Sort();
                    sw.WriteLine(string.Join(" ", states));
                }
                sw.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}