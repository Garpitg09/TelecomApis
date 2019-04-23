using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AndTelecom.Repository;

namespace AndTelecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumbersController: ControllerBase
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneNumbersController(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        //default endpoint to fetch all the phone numbers in the database
        [HttpGet]
        public IList<string> GetPhoneNumbers()
        {
            return null;
        }

        //endpoint to fetch the phone numbers against one customer id.
        [HttpGet("{id}")]
        public IList<string> GetPhoneNumbersById()
        {
            return null;
        }

        //endpoint to activate the provided phone number, if it is in the system
        [HttpPut("{phoneNumber}")]
        public bool? ActivatePhoneNumber()
        {
            return null;
        }
    }
}
