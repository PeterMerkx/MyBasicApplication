using MyBasicApplication.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBasicApplication.Library
{
    public class DataAccess
    {
        Random rnd = new Random();
        string[] streetAddresses = new string[] { "101 State Street", "425 Oak Avenue", "7 Wallace Way", "928 Edwards Court", "29 Main Avenue" };
        string[] cities = new string[] { "Springfield", "Wilshire", "Alexandria", "Franklin", "Clinton", "Fairview", "Madison" };
        string[] states = new string[] { "WI", "GA", "PA", "TX", "CA", "IL", "WA", "VA", "FL", "OK", "AZ" };
        string[] zipCodes = new string[] { "14121", "08904", "84732", "23410", "60095", "60618", "10456", "00926", "08701", "90280", "92335", "79936" };

        string[] firstNames = new string[] { "Bob", "Sue", "Carla", "Frank", "Monique", "Carlton", "Miguel", "Daniel", "Santiago", "John", "Robert" };
        string[] lastNames = new string[] { "Smith", "Jones", "Garcia", "Miller", "Thomas", "Lee", "Taylor", "Wilson", "Martinez", "Davis", "Hernandez" };
        bool[] aliveStatuses = new bool[] { true, false };
        DateTime lowEndDate = new DateTime(1943, 1, 1);
        int daysFromLowDate;

        public DataAccess()
        {
            daysFromLowDate = (DateTime.Today - lowEndDate).Days;
        }

        public List<DatabaseModel> GetPeople(int total = 10)
        {
            List<DatabaseModel> output = new List<DatabaseModel>();

            for (int i = 0; i < total; i++)
            {

                output.Add(GetPerson(i + 1));
            }

            return output;
        }

        private DatabaseModel GetPerson(int id)
        {
            DatabaseModel output = new DatabaseModel();

            output.DBId = id;
            output.FirstName = GetRandomItem(firstNames);
            output.LastName = GetRandomItem(lastNames);
            output.DateOfBirth = GetRandomDate();
            output.Age = GetAgeInYears(output.DateOfBirth);


            return output;
        }

        private AddressModel GetAddress(int id)
        {
            AddressModel output = new AddressModel();

            output.AddressId = id;
            output.StreetAddress = GetRandomItem(streetAddresses);
            output.City = GetRandomItem(cities);
            output.State = GetRandomItem(states);
            output.ZipCode = GetRandomItem(zipCodes);

            return output;
        }

        private T GetRandomItem<T>(T[] data)
        {
            return data[rnd.Next(0, data.Length)];
        }

        private DateTime GetRandomDate()
        {
            return lowEndDate.AddDays(rnd.Next(daysFromLowDate));
        }

        private int GetAgeInYears(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age))
            {
                age--;
            }

            return age;
        }

    }
}
