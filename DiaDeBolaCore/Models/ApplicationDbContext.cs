﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiaDeBolaCore.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> WebsiteUsers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerInTeam> PlayersInTeam { get; set; }
        public DbSet<TeamInEvent> TeamsInEvent { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
