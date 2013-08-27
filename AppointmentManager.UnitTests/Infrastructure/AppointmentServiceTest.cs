using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentManager.Core.Interfaces;
using AppointmentManager.Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppointmentManager.UnitTests.Infrastructure
{
    [TestClass]
    public class AppointmentServiceTest
    {
        private IStaff _staff;

        [TestInitialize]
        public void Setup()
        {
            var service = new StaffService();

            _staff = service.GetStaffMembers().First();
        }

        [TestMethod]
        public void GetAppointmentsHasData()
        {
            var service = new AppointmentService();

            DateTime appointmentDate = DateTime.ParseExact("2012-01-03", "yyyy-MM-dd", null);

            List<IAppointment> appointments = service.GetAppointments(_staff, appointmentDate);

            Assert.IsNotNull(appointments);
            Assert.IsTrue(appointments.Any());
            Assert.IsNotNull(appointments.First());
        }
    }
}