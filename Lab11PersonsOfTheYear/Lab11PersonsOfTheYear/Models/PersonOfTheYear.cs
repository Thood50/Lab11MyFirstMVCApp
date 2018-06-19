using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Lab11PersonsOfTheYear.Models
{
    public class PersonOfTheYear
    {
        /// <summary>
        /// This holds the year of when the person got the award
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// This is the honor that is given
        /// </summary>
        public string Honor { get; set; }
        /// <summary>
        /// This is the name of the person who got the honor
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// This is the country of the person
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// This is the year that the person is born
        /// </summary>
        public int Birth_Year { get; set; }
        /// <summary>
        /// This is the year that the person died
        /// </summary>
        public int DeathYear { get; set; }
        /// <summary>
        /// This is the title of the person
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// This is the category they got the honor in
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// This is the context behind the honor
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// This is an empty constructor for the person of the year class
        /// </summary>
        public PersonOfTheYear()
        {

        }

        /// <summary>
        /// This method finds the PoTY that are between the start year and the end year.
        /// </summary>
        /// <param name="startYear">The start year of the search</param>
        /// <param name="endYear">The end year of the search</param>
        /// <returns>A list of all the people of the year between the two years</returns>
        public List<PersonOfTheYear> RetrievePoTY (int startYear, int endYear)
        {
            // This creates a new list of PersonOfTheYear objects named people.
            List<PersonOfTheYear> people = new List<PersonOfTheYear>();
            // This sets a path to the directory where this application lives.
            // This is done so if there are other paths needed we can use this and add onto it
            string path = Environment.CurrentDirectory;
            // This creates the absolute path to the person of the year csv file
            // This is done by combining the directory of where the app lives with the location where the file lives in the application.
            string pathPoTY = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            // This creates a string array to hold all the information in the person of the year csv file.
            string[] allPoTY = File.ReadAllLines(pathPoTY);

            // The for loop starts at i = 1 because the first line in the csv file contains the headers for the file (ie. Year, Name, etc...)
            // This information is not what we want and some of it might not be able to be converted.
            for (int i = 1; i < allPoTY.Length; i ++)
            {
                // This creates a string array holding all the values for a single PoTY.
                // It is split with single quotes (') because that denotes looking for a single character instead of double quotes (") which looks for multiple.
                string[] fields = allPoTY[i].Split(',');
                // This adds a new PoTY to the List of PoTY named people.
                people.Add(new PersonOfTheYear
                {
                    // This sets the year of the new PoTY to be the value at index 0 of the PoTY read from the csv file.
                    // This value is converted to an int from a string since Year takes int, and is used for comparisons.
                    Year = Convert.ToInt32(fields[0]),
                    // This sets the honor of the new PoTY to be the value at index 1 string array that was split from the current PoTY.
                    Honor = fields[1],
                    // This sets the Name of the new PoTY to be the value at index 2 string array that was split from the current PoTY.
                    Name = fields[2],
                    // This sets the Country of the new PoTY to be the value at index 3 string array that was split from the current PoTY.
                    Country = fields[3],
                    // This uses a tertiary operator to see if there is a birth year;
                    // if there isn't then it sets the birth year to be 0, 
                    // otherwise it converts the value to be an integer and sets it to birth year.
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    // This uses a tertiary operato to see if the PoTY has died
                    // If there is no value, then we set the death year to be 0,
                    // otherwise it converts the value to be an integer and sets it to the death year.
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    // This sets the Title to be the corresponding title in the current PoTY.
                    Title = fields[6],
                    // This sets the Category for this PoTY to be the corresponding category of the PoTY.
                    Category = fields[7],
                    // This sets the context for the PoTY to be the corresponding context from this PoTY.
                    Context = fields[8],
                });
            }
            // This uses a lambda expression to take the people list of all PoTY 
            // and searches for where the year is greater than or equal to the start year
            // and less than or equal to the end year.
            // It then outputs the result as a list of PoTY.
            List<PersonOfTheYear> resultPoTY = people.Where(p => (p.Year >= startYear) && (p.Year <= endYear)).ToList();
            // This returns the list of PoTY that was found using the lambda expression.
            return resultPoTY;
        }
    }
}
