using System;
using System.Threading.Tasks;
using AutoFixture;
using Cinemas.BLL.Implementation;
using Cinemas.DataAccess.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Cinemas.BLL.Tests
{
    public class ScreeningGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_ScreeningExists_DoesNothing()
        {
            // Arrange
            var screeningContainer = new Mock<IScreeningContainer>();

            var screening = new Screening();
            var screeningDataAccess = new Mock<IScreeningDataAccess>();
            screeningDataAccess.Setup(x => x.GetByAsync(screeningContainer.Object)).ReturnsAsync(screening);

            var screeningGetService = new ScreeningGetService(screeningDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => screeningGetService.ValidateAsync(screeningContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_ScreeningNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var screeningContainer = new Mock<IScreeningContainer>();
            screeningContainer.Setup(x => x.ScreeningId).Returns(id);

            var screening = new Screening();
            var screeningDataAccess = new Mock<IScreeningDataAccess>();
            screeningDataAccess.Setup(x => x.GetByAsync(screeningContainer.Object)).ReturnsAsync((Screening)null);

            var screeningGetService = new ScreeningGetService(screeningDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => screeningGetService.ValidateAsync(screeningContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Screening not found by id {id}");
        }
    }
}