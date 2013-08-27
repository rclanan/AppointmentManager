using System.Collections.Generic;
using System.Linq;
using AppointmentManager.Core.Interfaces;
using AppointmentManager.Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppointmentManager.UnitTests.Infrastructure
{
    [TestClass]
    public class StaffServiceTest
    {
        [TestMethod]
        public void GetStaffMembersHasData()
        {
            var service = new StaffService();

            List<IStaff> staffMembers = service.GetStaffMembers();

            Assert.IsNotNull(staffMembers);
            Assert.IsTrue(staffMembers.Any());
            Assert.IsNotNull(staffMembers.First());

            // Check data items needed for GetStaffAppointments
            Assert.IsNotNull(staffMembers.First().Id);
            Assert.IsNotNull(staffMembers.First().FirstName);
            Assert.IsNotNull(staffMembers.First().LastName);
        }
    }
}