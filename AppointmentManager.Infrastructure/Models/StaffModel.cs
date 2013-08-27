using AppointmentManager.Core.Interfaces;

namespace AppointmentManager.Infrastructure.Models
{
    public class StaffModel : IStaff
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Bio { get; set; }
        public bool IsMale { get; set; }
    }
}