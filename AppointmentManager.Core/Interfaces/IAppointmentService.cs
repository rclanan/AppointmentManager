using System;
using System.Collections.Generic;

namespace AppointmentManager.Core.Interfaces
{
    public interface IAppointmentService
    {
        List<IAppointment> GetAppointments(long staffId, DateTime appointmentDate);
    }
}