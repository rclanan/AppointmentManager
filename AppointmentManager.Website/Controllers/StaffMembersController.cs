using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppointmentManager.Core.Interfaces;
using AppointmentManager.Infrastructure.Models;

namespace AppointmentManager.Website.Controllers
{
    public class StaffMembersController : ApiController
    {
        private readonly IStaffService _staffService;

        public StaffMembersController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public IEnumerable<IStaff> Get()
        {
            var staffMembers = _staffService.GetStaffMembers().OrderBy(s => s.LastName);

            return staffMembers;
        }
    }
}
