using ExampleWebApi.Models;
using ExampleWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : Controller
    {
        private readonly IRepository _db;

        private readonly ILogger<CitiesController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        [ActivatorUtilitiesConstructor]
        public CitiesController(IRepository db)
        {
            _db = db;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public CitiesController(ILogger<CitiesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Cities
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<City> GetCities()
        {
            var allCities = _db?.GetAllCities();
            if (allCities == null)
            {
                return null;
            }

            return allCities;
        }

        /// <summary>
        /// save user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void Create([FromBody] City cityItem)
        {
            _db.CreateCity(cityItem);
        }
    }
}
