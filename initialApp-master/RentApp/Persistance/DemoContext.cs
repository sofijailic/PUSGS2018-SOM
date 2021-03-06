﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RentApp.Models.Entities;

namespace RentApp.Persistance
{
    public class DemoContext : DbContext
    {
        public virtual DbSet<Rent> Rents { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<BranchOffice> BranchOffices { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }


        public DemoContext() : base("name=DemoConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }
    }
}