using System;
using Microsoft.AspNetCore.Mvc;
using AndTelecom.Repository;

/*This is a sample API required by a telecom provider. */
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
        public IActionResult GetPhoneNumbers()
        {
            try
            {
                var phoneNumbers = _phoneRepository.GetAllPhoneNumbers();
                return Ok(phoneNumbers);
            }
            catch (Exception e)
            {
                return Forbid("Sorry, we are not able to retrieve phone numbers");
            }
        }

        //endpoint to fetch the phone numbers against one customer id.
        [HttpGet("{id}")]
        public IActionResult GetPhoneNumbersById(int id)
        {
            try
            {
                var phoneNumbers = _phoneRepository.GetPhoneNumbersById(id);
                if(phoneNumbers.Count == 0)
                    return BadRequest("Sorry, we can not find the customer in our system");
                return Ok(phoneNumbers);
            }
            catch (Exception)
            {
                return Forbid("Sorry, we are not able to retrieve phone numbers for the customer");
            }
        }

        //endpoint to activate the provided phone number, if it is in the system. id used here is the phone number.
        [HttpPut("{id}")]
        public IActionResult ActivatePhoneNumber(string id)
        {
            try
            {
                if (id.Length != 10)
                    return BadRequest("Provided phone number is not correct");

                if (_phoneRepository.ActivatePhoneNumber(id))
                    return Ok("Activation successful");
                else
                    return BadRequest("Sorry, provided phone number not found in the system");
            }
            catch (Exception e)
            {
                return Forbid("Sorry, we are unable to activate your mobile number now. Please try later");
            }
        }
    }
}
