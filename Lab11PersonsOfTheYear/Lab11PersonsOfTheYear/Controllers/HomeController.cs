using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab11PersonsOfTheYear.Models;

namespace Lab11PersonsOfTheYear.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// This shows the Index page on load
        /// </summary>
        /// <returns>This is the view of the index page</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This retrieves the data from the form on the Index page and has it redirected to the results page
        /// </summary>
        /// <param name="startYear">The corresponding value of the start year the user input</param>
        /// <param name="endYear">The corresponding value of the end year that the user input</param>
        /// <returns>The redirecting to the results page</returns>
        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            return RedirectToAction("Result", new { startYear, endYear });
            
        }

        /// <summary>
        /// This shows the results page with the information provided
        /// </summary>
        /// <param name="startYear">The start year that was given from the redirect</param>
        /// <param name="endYear">The end year taht was given from the redirect</param>
        /// <returns>The results page with the list of people of the year</returns>
        public IActionResult Result(int startYear, int endYear)
        {
            PersonOfTheYear person = new PersonOfTheYear();
            List<PersonOfTheYear> peopleBetweenTheYears = person.RetrievePoTY(startYear, endYear);
            
            return View(peopleBetweenTheYears);
        }
    }
}
