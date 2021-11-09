using ExampleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebApi.Repositories
{
    public interface IRepository
    {
        IEnumerable<User> GetAllUsers();
        IEnumerable<City> GetAllCities();
        User GetUser(int id);
        City GetCity(int id);
        void CreateUser(User item);
        void CreateCity(City item);
        void UpdateUser(User item);
        void UpdateCity(City item);
        User DeleteUser(int id);
        City DeleteCity(int id);
    }
}
