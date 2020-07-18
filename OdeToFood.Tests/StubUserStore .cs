using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Tests
{
	public class StubUserStore : IUserStore
	{
		public string GetUserRole(string username)
		{
			return "contributor";
		}

		public List<UserDetail> GetAllUsers()
		{
			return new List<UserDetail>()
		{
			new UserDetail{ Role = "administrator", Name = "admin"},
			new UserDetail(){ Role = "contributor", Name = "User 1"}
		};

		}
	}
	public interface IUserStore
	{
		string GetUserRole(string username);
	}

	public class UserDetail
	{
		public string Name { get; set; }
		public string Role { get; set; }
	}

}
