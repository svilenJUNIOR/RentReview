using FakeItEasy;
using FluentAssertions;
using RentReview.Repository.Contracts;
using RentReview.Services;
using RentReview.Services.Property;
using System.ComponentModel.DataAnnotations;

namespace RentReview.Test
{
    public class PropertyServiceTests
    {
        private readonly IValidator validator;
        private readonly IRepository repository;
        private readonly IBindService bindService;
        private readonly PropertyService propertyService;

        public PropertyServiceTests()
        {
            validator = A.Fake<IValidator>();
            repository = A.Fake<IRepository>();
            propertyService = new PropertyService(repository, validator, bindService);
        }

        [Fact]
        public async Task AddAsync_ShouldThrowException_WhenValidationFails()
        {
            // Arrange
            var data = new AddNewPropertyDataModel { City = "city", Country = "country" };
            var userId = "user123";
            var errors = new List<string> { "Error1", "Error2" };

            A.CallTo(() => _validator.ValidateProperty(data, true)).Returns(errors);

            // Act
            Func<Task> act = async () => await _propertyService.AddAsync(data, userId, true);

            // Assert
            await act.Should().ThrowAsync<ValidationException>().WithMessage("Validation errors occurred.");
        }
    }
}