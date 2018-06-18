﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RentApp.Models.Entities;
using RentApp.Persistance;
using RentApp.Persistance.UnitOfWork;

namespace RentApp.Controllers
{
    [RoutePrefix("api/AdditionalUserOps")]
    public class AppUsersController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public AppUsersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [Route("GetUnbannedManagers")]
        public IEnumerable<AppUser> GetUnbannedManagers()
        {
            return unitOfWork.AppUserRepository.GetUnbannedManagers();
        }

        [Route("GetBannedManagers")]
        public IEnumerable<AppUser> GetBannedManagers()
        {
            return unitOfWork.AppUserRepository.GetBannedManagers();
        }

        [Route("GetAwaitingClients")]
        public IEnumerable<AppUser> GetAwaitingClients()
        {
            return unitOfWork.AppUserRepository.GetAwaitingClients();
        }

        [Route("AuthorizeUser")]
        public string AuthorizeUser([FromBody]string Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState).ToString();
            }
            //Get user data, and update activated to true
            AppUser current = unitOfWork.AppUserRepository.Get(Int32.Parse(Id));
            current.Activated = true;

            try
            {
                unitOfWork.AppUserRepository.Update(current);
                unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest().ToString();
            }

            return "Ok";
        }
    }
}