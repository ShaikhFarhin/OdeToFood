using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Tests
{
    public class SpyUserStore : IUserStore
    {
        private static int Counter { get; set; }

        public SpyUserStore()
        {
            Counter = 0;
        }

        public string GetUserRole(string username)
        {

            if (Counter >= 1)
                throw new Exception("Function called more than once");

            Counter++;

            if (username == "admin")
                return "administrator";
            else
                return "contributor";
        }
    }

}
