namespace AppointmentManager.Core.Interfaces
{
    public interface IStaff
    {
        long? Id { get; set; }
        string Name { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MobilePhone { get; set; }
        string HomePhone { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Country { get; set; }
        string PostalCode { get; set; }
        string Bio { get; set; }
        bool IsMale { get; set; }
    }
}