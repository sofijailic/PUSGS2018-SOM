﻿using Microsoft.AspNet.Identity.EntityFramework;
using RentApp.Migrations;
using RentApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentApp.Persistance
{
    public class RADBContext : IdentityDbContext<RAIdentityUser>
    {
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Review> Reviews { get; set; } 

        public RADBContext() : base("name=RADB")
        {
        }

        public static RADBContext Create()
        {
            return new RADBContext();
        }
    }
}