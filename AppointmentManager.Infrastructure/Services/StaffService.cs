using System.Collections.Generic;
using System.Linq;
using AppointmentManager.Core.Interfaces;
using AppointmentManager.Infrastructure.Models;
using AppointmentManager.Infrastructure.StaffServiceReference;

namespace AppointmentManager.Infrastructure.Services
{
    public class StaffService : IStaffService
    {
        public List<IStaff> GetStaffMembers()
        {
            var request = new GetStaffRequest
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
                            SiteIDs = new ArrayOfInt {-31100}
                        },
                    // Set Filters
                    Filters = new[]
                        {
                            StaffFilter.StaffViewable,
                            StaffFilter.AppointmentInstructor
                        }
                };

            var proxy = new StaffServiceSoapClient();
            GetStaffResult response = proxy.GetStaff(request);

            return response.StaffMembers.Select(member => new StaffModel
                {
                    Id = member.ID,
                    Address = member.Address,
                    Bio = member.Bio,
                    City = member.City,
                    Country = member.Country,
                    FirstName = member.FirstName,
                    HomePhone = member.HomePhone,
                    IsMale = member.isMale,
                    LastName = member.LastName,
                    MobilePhone = member.MobilePhone,
                    Name = member.Name,
                    State = member.State,
                    PostalCode = member.PostalCode,
                }).Cast<IStaff>().ToList();
        }
    }
}