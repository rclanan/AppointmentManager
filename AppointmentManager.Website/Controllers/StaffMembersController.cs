using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AppointmentManager.Core.Interfaces;

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
            IOrderedEnumerable<IStaff> staffMembers = _staffService.GetStaffMembers().OrderBy(s => s.LastName);

            return staffMembers;
        }
    }
}