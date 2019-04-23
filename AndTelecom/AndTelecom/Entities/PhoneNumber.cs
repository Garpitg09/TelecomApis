using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndTelecom.Entities
{
    public class PhoneNumber
    {
        public string Number { get; set; }
        public PhoneStatus Status { get; set; }
    }
}
