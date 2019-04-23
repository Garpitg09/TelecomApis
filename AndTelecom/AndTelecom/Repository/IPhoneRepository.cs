using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndTelecom.Repository
{
    public interface IPhoneRepository
    {
        List<string> GetAllPhoneNumbers();
        List<string> GetPhoneNumbersById(string customerId);
        bool? ActivatePhoneNumber(string phoneNumber);
    }
}
