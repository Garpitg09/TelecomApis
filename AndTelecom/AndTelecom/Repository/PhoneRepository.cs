using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndTelecom.Repository
{
    public class PhoneRepository : IPhoneRepository
    {
        public bool? ActivatePhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllPhoneNumbers()
        {
            throw new NotImplementedException();
        }

        public List<string> GetPhoneNumbersById(string customerId)
        {
            throw new NotImplementedException();
        }
    }
}
