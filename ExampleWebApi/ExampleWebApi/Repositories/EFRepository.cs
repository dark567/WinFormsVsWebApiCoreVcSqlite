using ExampleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebApi.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class EFRepository : IRepository
    {
        private EFDBContext Context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EFRepository(EFDBContext context)
        {
            Context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAllUsers()
        {
            var users = Context.User.ToList();
            return users;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<City> GetAllCities()
        {
            var cities = Context.City.ToList();
            return cities;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void CreateUser(User item)
        {
            Context.User.Add(item);
            Context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void CreateCity(City item)
        {
            Context.City.Add(item);
            Context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User DeleteUser(int id)
        {
            User userItem = GetUser(id);

            if (userItem != null)
            {
                Context.User.Remove(userItem);
                Context.SaveChanges();
            }

            return userItem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public City DeleteCity(int id)
        {
            City cityItem = GetCity(id);

            if (cityItem != null)
            {
                Context.City.Remove(cityItem);
                Context.SaveChanges();
            }

            return cityItem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id)
        {
            return Context.User.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public City GetCity(int id)
        {
            return Context.City.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void UpdateUser(User item)
        {
            User currentItem = GetUser(item.Id);
            currentItem.Name = item.Name;
            currentItem.CityId = item.CityId;

            Context.User.Update(currentItem);
            Context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void UpdateCity(City item)
        {
            City currentItem = GetCity(item.Id);
            currentItem.Name = item.Name;

            Context.City.Update(currentItem);
            Context.SaveChanges();
        }
    }
}
