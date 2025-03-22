using System.ComponentModel.DataAnnotations;
using TCFiapProducerCreateContact.Application.Inputs;

namespace TCFiapProducerCreateContact.Tests.UnitTests.Inputs
{
    [TestFixture]
    public class CreateContactInputModelTests
    {
        private IList<ValidationResult> ValidateModel(CreateContactInputModel model)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, new ValidationContext(model), results, true);
            return results;
        }

        [TestCase("Ramon", "Dino", "ramon.dino@hotmail.com", 11, 12345678, 0, "",
            TestName = "Validate_CreateContactInputModel_WithValidInput_ShouldBeValid")]
        [TestCase("J", "Dino", "ramon.dino@hotmail.com", 11, 12345678, 1, "Nome inválido",
            TestName = "Validate_CreateContactInputModel_WithInvalidFirstName_ShouldReturnError")]
        [TestCase("Ramon", "D", "ramon.dino@hotmail.com", 11, 12345678, 1, "Sobrenome inválido",
            TestName = "Validate_CreateContactInputModel_WithInvalidLastName_ShouldReturnError")]
        [TestCase("Ramon", "Dino", "notanemail", 11, 12345678, 1, "email",
            TestName = "Validate_CreateContactInputModel_WithInvalidEmail_ShouldReturnError")]
        [TestCase("Ramon", "Dino", "ramon.dino@hotmail.com", 10, 12345678, 1, "DDD inválido",
            TestName = "Validate_CreateContactInputModel_WithInvalidDDD_ShouldReturnError")]
        [TestCase("Ramon", "Dino", "ramon.dino@hotmail.com", 11, 1234567, 1, "telefone",
            TestName = "Validate_CreateContactInputModel_WithInvalidPhone_ShouldReturnError")]
        public void Validate_CreateContactInputModel_TestCases(string firstName, string lastName, string email,
            int ddd, int phone, int expectedErrorCount, string expectedErrorSubstring)
        {
            // Arrange
            var model = new CreateContactInputModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                DDD = ddd,
                Phone = phone
            };

            // Act
            var results = ValidateModel(model);

            // Assert
            if (expectedErrorCount > 0)
                Assert.IsTrue(results.Any(r => r.ErrorMessage.Contains(expectedErrorSubstring)));

            Assert.AreEqual(expectedErrorCount, results.Count);
        }
    }
}
