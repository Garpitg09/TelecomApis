using Moq;
using NUnit.Framework;
using AndTelecom.Controllers;
using AndTelecom.Repository;
using System.Collections.Generic;

namespace AndTelecom.Tests
{
    // NUnit test case for code coverage of PhoneNumbersController. Added different test cases to cater for different business scenarios.
    [TestFixture]
    public class PhoneNumbersControllerTests
    {
        private Mock<IPhoneRepository> _phoneRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _phoneRepositoryMock = new Mock<IPhoneRepository>();
        }

        // when GetPhoneNumbers return a successful response
        [Test]
        public void get_all_phonenumbers_success()
        {
            _phoneRepositoryMock.Setup(x => x.GetAllPhoneNumbers()).Returns(new List<string>() { "9875433121" });

            var phoneNumbersController = new PhoneNumbersController(_phoneRepositoryMock.Object);
            var result = phoneNumbersController.GetPhoneNumbers();
            Assert.IsNotEmpty(result);
        }

        // when system fails to return any data maybe due to Internal server error or any other possible issue. Assumption is that the repository layer will throw an exception, which can be used to inform the customer
        [Test]
        public void get_all_phonenumbers_failure()
        {
            _phoneRepositoryMock.Setup(x => x.GetAllPhoneNumbers()).Throws(new System.Exception());

            var phoneNumbersController = new PhoneNumbersController(_phoneRepositoryMock.Object);

            var ex = Assert.Throws<System.Exception>(() => phoneNumbersController.GetPhoneNumbers());
            Assert.IsTrue(ex.Message.Contains("Not able to retrieve phone numbers"));
        }

       // when GetPhoneNumbersById returns a successful response
        [Test]
        public void get_phonenumbers_byid_success()
        {
            _phoneRepositoryMock.Setup(x => x.GetPhoneNumbersById(It.IsAny<string>())).Returns(new List<string>() { "9875433121", "9761876232" });

            var phoneNumbersController = new PhoneNumbersController(_phoneRepositoryMock.Object);
            var result = phoneNumbersController.GetPhoneNumbersById();
            Assert.IsNotEmpty(result);
        }

        // when GetPhoneNumbersById fails due to invalid customer Id. Assumption is repository layer will send an empty response indicating that no data is present for requested customer id
        [Test]
        public void get_phonenumbers_byid_invalid_customerid_failure()
        {
            _phoneRepositoryMock.Setup(x => x.GetPhoneNumbersById(It.IsAny<string>())).Returns(new List<string>());

            var phoneNumbersController = new PhoneNumbersController(_phoneRepositoryMock.Object);
            var result = phoneNumbersController.GetPhoneNumbersById();
            Assert.IsEmpty(result);
        }

        // when system fails to return any data maybe due to Internal server error or any other possible issue. Assumption is that the repository layer will throw an exception, which can be used to inform the customer
        [Test]
        public void get_phonenumbers_byid_failure()
        {
            _phoneRepositoryMock.Setup(x => x.GetPhoneNumbersById(It.IsAny<string>())).Throws(new System.Exception());

            var phoneNumbersController = new PhoneNumbersController(_phoneRepositoryMock.Object);

            var ex = Assert.Throws<System.Exception>(() => phoneNumbersController.GetPhoneNumbersById());
            Assert.IsTrue(ex.Message.Contains("Not able to retrieve phone numbers for the customer"));
        }

        // when activate phone number is successful
        [Test]
        public void activate_phonenumbers_success()
        {
            _phoneRepositoryMock.Setup(x => x.ActivatePhoneNumber(It.IsAny<string>())).Returns(true);

            var phoneNumbersController = new PhoneNumbersController(_phoneRepositoryMock.Object);
            var result = phoneNumbersController.ActivatePhoneNumber();
            Assert.IsTrue(result);
        }

        // when activate phone number is not successful
        [Test]
        public void activate_phonenumbers_failure()
        {
            _phoneRepositoryMock.Setup(x => x.ActivatePhoneNumber(It.IsAny<string>())).Returns(false);

            var phoneNumbersController = new PhoneNumbersController(_phoneRepositoryMock.Object);
            var result = phoneNumbersController.ActivatePhoneNumber();
            Assert.IsFalse(result);
        }
    }
}
