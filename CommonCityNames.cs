using System.Collections.Generic;
using System;
using System.IO;

namespace Cities
{
    public class CommonCityNames
    {
        public static Dictionary<string, List<string>> cities = new Dictionary<string, List<string>>();

        public static void add(string city, string state) {
            if (cities.ContainsKey(city) && !cities[city].Contains(state))
            {
                cities[city].Add(state);
            } 
            else if (!cities.ContainsKey(city))
            {
                cities[city] = new List<string>();
                cities[city].Add(state);
            }
        }

        public static List<string> findcommon(List<string> states)
        {
            List<string> list = new List<string>();
            foreach (string city in cities.Keys)
            {
                if (cities[city] != null)
                {
                    bool hasStates = true;
                    foreach (string state in states)
                    {
                        if(!cities[city].Contains(state))
                        {
                            hasStates = false;
                        }
                    }
                    if (hasStates)
                    {
                        list.Add(city);
                    }
                }
            }
            return list;
        }

        public static void Answer(string File = "CommonCityNames.txt")
        {
            foreach (var city in ReadZipCodes.cities)
            {
                add(city.city, city.State);
            }

            try
            {
                StreamReader sr = new StreamReader("states.txt");
                List<string> states = new List<string>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    states.Add(line);
                }
                sr.Close();
                StreamWriter sw = new StreamWriter(File);
                List<string> list = findcommon(states);
                list.Sort();
                foreach (var city in list)
                {
                    sw.WriteLine(city);
                }
                sw.Close();
            }
            catch (Exception) {}
        }
    }
}
