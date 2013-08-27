using System;
using AppointmentManager.Core.Interfaces;

namespace AppointmentManager.Infrastructure.Models
{
    public class AppointmentModel : IAppointment
    {
        public long? Id { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string ClientName { get; set; }
        public string SessionType { get; set; }
    }
}