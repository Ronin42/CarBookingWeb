﻿using CarBooking.Models;
using Microsoft.AspNetCore.Identity;
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
	public class ApplicationDBcontext : IdentityDbContext<IdentityUser>
	{
		public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
		{

		}

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Seat> Seats { get; set; }
    }
}
