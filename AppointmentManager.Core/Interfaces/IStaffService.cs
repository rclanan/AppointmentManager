using System.Collections.Generic;

namespace AppointmentManager.Core.Interfaces
{
    public interface IStaffService
    {
        List<IStaff> GetStaffMembers();
    }
}