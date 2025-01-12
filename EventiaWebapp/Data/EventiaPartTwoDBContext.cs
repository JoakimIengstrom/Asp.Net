﻿using EventiaWebapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Data
{
    public class EventiaPartTwoDBContext : IdentityDbContext<EventiaUser, IdentityRole, string>
    {
        public DbSet<EventPartTwo> Events { get; set; }

        public EventiaPartTwoDBContext(DbContextOptions<EventiaPartTwoDBContext> options) : base(options) { }

    }
}




