using System.ComponentModel.DataAnnotations;
using TCFiapProducerCreateContact.Application.Inputs;

namespace TCFiapProducerCreateContact.Tests.UnitTests.Inputs
{
    [TestFixture]
    public class UpdateContactInputModelTests
    {
        private IList<ValidationResult> ValidateModel(UpdateContactInputModel model)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, new ValidationContext(model), results, true);
            return results;
        }

        [TestCase("Ramon", "Dino", "ramon.dino@hotmail.com", 11, 12345678, 0, "",
            TestName = "Validate_UpdateContactInputModel_WithValidInput_ShouldBeValid")]
        [TestCase("J", "Dino", "ramon.dino@hotmail.com", 11, 12345678, 1, "Nome inválido",
            TestName = "Validate_UpdateContactInputModel_WithInvalidFirstName_ShouldReturnError")]
        [TestCase("Ramon", "D", "ramon.dino@hotmail.com", 11, 12345678, 1, "Sobrenome inválido",
            TestName = "Validate_UpdateContactInputModel_WithInvalidLastName_ShouldReturnError")]
        [TestCase("Ramon", "Dino", "notanemail", 11, 12345678, 1, "email",
            TestName = "Validate_UpdateContactInputModel_WithInvalidEmail_ShouldReturnError")]
        [TestCase("Ramon", "Dino", "ramon.dino@hotmail.com", 10, 12345678, 1, "DDD inválido",
            TestName = "Validate_UpdateContactInputModel_WithInvalidDDD_ShouldReturnError")]
        [TestCase("Ramon", "Dino", "ramon.dino@hotmail.com", 11, 1234567, 1, "telefone",
            TestName = "Validate_UpdateContactInputModel_WithInvalidPhone_ShouldReturnError")]
        public void Validate_UpdateContactInputModel_TestCases(string firstName, string lastName, string email,
            int ddd, int phone, int expectedErrorCount, string expectedErrorSubstring)
        {
            // Arrange
            var model = new UpdateContactInputModel
            {
                Id = Guid.NewGuid(),
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
