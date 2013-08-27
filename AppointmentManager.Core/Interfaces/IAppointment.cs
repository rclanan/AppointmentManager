using System;

namespace AppointmentManager.Core.Interfaces
{
    public interface IAppointment
    {
        long? Id { get; set; }
        DateTime? AppointmentDate { get; set; }
        DateTime? StartTime { get; set; }
        DateTime? EndTime { get; set; }
        string ClientName { get; set; }
        string SessionType { get; set; }
    }
}