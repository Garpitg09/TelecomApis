using System;
using System.Collections.Generic;
using AndTelecom.Entities;

namespace AndTelecom.Repository
{
    public class PhoneRepository : IPhoneRepository
    {
        //creating mock data here signifying imaginary database of five customers.
        private readonly List<Customer> customerData = new List<Customer>() {
            new Customer{ id = 1, PhoneNumbers = new List<PhoneNumber>{ new PhoneNumber { Number="9876123456", Status=PhoneStatus.Activated} } },
            new Customer{ id = 2, PhoneNumbers = new List<PhoneNumber>{ new PhoneNumber { Number="9812376612", Status=PhoneStatus.NotActivated} } },
            new Customer{ id = 3, PhoneNumbers = new List<PhoneNumber>{ new PhoneNumber { Number="9861537291", Status=PhoneStatus.DeActivated}, new PhoneNumber { Number = "9876123452", Status = PhoneStatus.Activated } } },
            new Customer{ id = 4, PhoneNumbers = new List<PhoneNumber>{ new PhoneNumber { Number="9816171912", Status=PhoneStatus.Activated} } },
            new Customer{ id = 5, PhoneNumbers = new List<PhoneNumber>{ new PhoneNumber { Number="9812361737", Status=PhoneStatus.NotActivated}, new PhoneNumber { Number = "9861235421", Status = PhoneStatus.DeActivated } } }
                                                                            };
        
        /*If the requested mobile number matches with any number in database, returning true assuming the activation in successful
        To keep the solution clean and simpler, ignoring that there can be many scenarios impacting return value depending upon the current status of the phone number*/
        public bool ActivatePhoneNumber(string phoneNumber)
        {
            foreach (var customer in customerData) {
                foreach (var phone in customer.PhoneNumbers) {
                    if (phoneNumber == phone.Number)
                        return true;
                }
            }
            return false;
        }

        /*Reading every mobile number in the database and returning them in a list*/
        public List<string> GetAllPhoneNumbers()
        {
            var phoneNumbers = new List<string>();
            foreach (var customer in customerData)
            {
                foreach (var phone in customer.PhoneNumbers)
                {
                    phoneNumbers.Add(phone.Number);
                }
            }
            return phoneNumbers;
        }

        /* Reading all the mobile numbers for a specific customer. In case of empty return list. assumption is there is no data against the customer id */
        public List<string> GetPhoneNumbersById(int customerId)
        {
            var phoneNumbers = new List<string>();
            foreach (var customer in customerData)
            {
                if (customer.id == customerId) {
                    foreach (var phone in customer.PhoneNumbers) {
                        phoneNumbers.Add(phone.Number);
                    }
                }
            }
            return phoneNumbers;
        }
    }
}
