using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentManager.Core.Interfaces;
using AppointmentManager.Infrastructure.AppointmentServiceReference;
using AppointmentManager.Infrastructure.Models;

namespace AppointmentManager.Infrastructure.Services
{
    public class AppointmentService : IAppointmentService
    {
        public List<IAppointment> GetAppointments(long staffId, DateTime appointmentDate)
        {
            var request = new GetStaffAppointmentsRequest
                    {
                        // Set Source Credentials
                        SourceCredentials = new SourceCredentials
                            {
                                SourceName = "apidevhomework",
                                Password = "apidevhomework1234!",
                                SiteIDs = new ArrayOfInt {-31100}
                            },
                        // Set Staff Credentials
                        StaffCredentials = new StaffCredentials
                            {
                                Username = @"Owner",
                                Password = @"apidemo1234",
                                SiteIDs = new ArrayOfInt { -31100 }
                            },
                        // Inquire about this. Instructions say to use staff credentials in the format below, which doesn't yeild any results.
                        // Using the owner creds with the StaffIds array does get the results that we are looking for. Bug in API Or User Error?
                        // Note to Self: Change first parameter back to IStaff instead of long when this is working as instructions state
                        //StaffCredentials = new StaffCredentials
                        //    {
                        //        Username = string.Format("{0}.{1}", staff.FirstName, staff.LastName),
                        //        Password = string.Format("{0}{1}{2}", staff.FirstName[0], staff.LastName[0], staff.Id),
                        //        SiteIDs = new ArrayOfInt {-31100}
                        //    }
                        StaffIDs = new ArrayOfLong { staffId },

                        StartDate = appointmentDate,
                        EndDate =  appointmentDate
                    };

                var proxy = new AppointmentServiceSoapClient();
                GetStaffAppointmentsResult response = proxy.GetStaffAppointments(request);

                return response.Appointments.Select(appointment => new AppointmentModel
                    {
                        Id = appointment.ID,
                        AppointmentDate = appointment.StartDateTime,
                        StartTime = appointment.StartDateTime,
                        EndTime = appointment.EndDateTime,
                        ClientName = string.Format("{0} {1}", appointment.Client.FirstName, appointment.Client.LastName),
                        SessionType = appointment.SessionType.Name
                    }).Cast<IAppointment>().ToList();
            
        }
    }
}