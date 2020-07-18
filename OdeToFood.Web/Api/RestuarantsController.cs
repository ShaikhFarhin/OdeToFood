using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.Web.Api
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData db;    
        private readonly SqlRestaurantData sqlRestaurant;

        public RestaurantsController(IRestaurantData db,SqlRestaurantData sqlRestaurant)
        {
            this.db = db;
            this.sqlRestaurant = sqlRestaurant;
        }

        public IEnumerable<Restaurant> Get()
        {
            var model = sqlRestaurant.GetAll();
            return model;
        }
    }
}
