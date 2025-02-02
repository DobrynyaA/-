using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace NikePro.Data
{
	// Add profile data for application users by adding properties to the ApplicationUser class
	public class ApplicationUser : IdentityUser
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic {  get; set; }
		public DateTime BirthdayDate { get; set; }
		public Client? Client { get; set; }
		public Employee? Employee { get; set; }
		public string Phone { get; set; }

	}

}
