using DataAccessLayer;
using DataAccessLayer.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access_library.Services
{
	public class User
	{
		private ApplicationDbContext context;

		public User(ApplicationDbContext context) 
		{ 
			this.context = context; 
		}

		public void AddUser(string username, string email, string password)
		{
			if (context.Users.Any(u => u.UserName.ToLower().Equals(username.ToLower())))
				throw new ArgumentException("Username '"+ username + "' is already in use.  Please pick a unique username.");
			else
			{
				if (context.Users.Any(u => u.Email.ToLower().Equals(email.ToLower())))
					throw new ArgumentException("Email '"+ email + "' is already in use.  Please pick a unique Email.");
				else
				{
					var userStore = new UserStore<ApplicationUser>(context);
					var userManager = new UserManager<ApplicationUser>(userStore);
					var userToInsert = new ApplicationUser { UserName = username, Email = email };
					userManager.Create(userToInsert, password);
				}
			}
		}
	}
}
