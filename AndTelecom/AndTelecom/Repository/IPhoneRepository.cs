﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndTelecom.Repository
{
    public interface IPhoneRepository
    {
        List<string> GetAllPhoneNumbers();
        List<string> GetPhoneNumbersById(int customerId);
        bool ActivatePhoneNumber(string phoneNumber);
    }
}
