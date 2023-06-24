using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CarBooking.Models; 

namespace CarBooking.DataAccess.data
{
	public class ApplicationDBcontext : IdentityDbContext
	{
		public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
		{

		}
		

	}
}
