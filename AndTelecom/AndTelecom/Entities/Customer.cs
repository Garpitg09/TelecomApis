﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndTelecom.Entities
{
    public class Customer
    {
        public int id { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
    }
}
