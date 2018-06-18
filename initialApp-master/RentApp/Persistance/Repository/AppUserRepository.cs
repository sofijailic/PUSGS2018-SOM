﻿using RentApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net;
using System.Net.Http;

namespace RentApp.Persistance.Repository
{
    public class AppUserRepository : Repository<AppUser, int>, IAppUserRepository
    {
        public AppUserRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<AppUser> GetAll(int pageIndex, int pageSize)
        {
            return Context.AppUsers.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        // Vraca sve menadzere koji nisu banovani
        [Route("GetUnbannedManagers")]
        public IEnumerable<AppUser> GetUnbannedManagers()
        {
            return new List<AppUser>() { new AppUser() { FullName = "Onaj koji nije banovan" }, new AppUser() { FullName = "Onaj koji nije banovan 2" } };
        }

        // Vraca sve menadzere koji su banovani
        [Route("GetBannedManagers")]
        public IEnumerable<AppUser> GetBannedManagers()
        {
            return new List<AppUser>() { new AppUser() { FullName = "Banovan menadzer 1" } };
        }

        // Vraca sve usere koji cekaju odobrenje naloga
        [Route("GetAwaitingClients")]
        public IEnumerable<AppUser> GetAwaitingClients()
        {
            return Context.AppUsers.Where(a => a.Activated == false).ToList();
        }

        [Route("GetUser")]
        public AppUser GetUser(int Id)
        {
            return Context.AppUsers.SingleOrDefault(u => u.Id == Id);
        }

        protected RADBContext Context { get { return RADBContext.Create(); } }
    }
}