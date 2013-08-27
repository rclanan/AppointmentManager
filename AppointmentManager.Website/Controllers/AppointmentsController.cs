using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppointmentManager.Core.Interfaces;

namespace AppointmentManager.Website.Controllers
{
    public class AppointmentsController : ApiController
    {
        private readonly IAppointmentService _appointmentService;
        
        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IEnumerable<IAppointment> Get(long staffId, DateTime appointmentDate)
        {
            var appointments = _appointmentService.GetAppointments(staffId, appointmentDate).OrderByDescending(a => a.AppointmentDate);

            return appointments;
        }
    }
}
