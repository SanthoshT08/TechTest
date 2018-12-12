using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;

namespace TechTestNAB
{
    class Program
    {
        static string jsonDataFile = ConfigurationManager.AppSettings["JsonDataFilePath"].ToString();

        static void Main(string[] args)
        {
            LoadDisplayJsonData();
        }

        public static void LoadDisplayJsonData()
        {
            List<Person> personsList = new List<Person>();
            using (StreamReader sr = new StreamReader(jsonDataFile))
            {
                string jsonData = sr.ReadToEnd();
                var jsonArray = JsonConvert.DeserializeObject<IEnumerable<Person>>(jsonData);
                foreach (var item in jsonArray)
                {
                    if (item.Pets != null)
                    {
                        personsList.Add(new Person
                        {
                            Name = item.Name,
                            Gender = item.Gender,
                            Age = item.Age,
                            Pets = item.Pets
                        });
                    }
                }
            }
            DisplayDetails(personsList);
        }

        public static void DisplayDetails(List<Person> personsList)
        {
            var maleList = personsList.Where(m => m.Gender == Gender.Male);
            var femaleList = personsList.Where(f => f.Gender == Gender.Female);

            List<string> maleCatsList = new List<string>();
            List<string> femaleCatsList = new List<string>();

            foreach (var maleItem in maleList)
            {
                foreach (var petItem in maleItem.Pets.Where(p => p.Type == PetType.Cat).ToList())
                {
                    maleCatsList.Add(petItem.Name);
                }
            }
            
            foreach (var femaleItem in femaleList)
            {
                foreach (var petItem in femaleItem.Pets.Where(p => p.Type == PetType.Cat).ToList())
                {
                    femaleCatsList.Add(petItem.Name);
                }
            }

            Console.WriteLine(Gender.Male.ToString());
            foreach (var item in maleCatsList.OrderBy(m => m))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine(Gender.Female.ToString());
            foreach (var item in femaleCatsList.OrderBy(f => f))
            {
                Console.WriteLine(item);
            }
        }
    }
}
