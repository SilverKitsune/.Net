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
    public class CinemaGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_CinemaExists_DoesNothing()
        {
            // Arrange
            var cinemaContainer = new Mock<ICinemaContainer>();

            var cinema = new Cinema();
            var cinemaDataAccess = new Mock<ICinemaDataAccess>();
            cinemaDataAccess.Setup(x => x.GetByAsync(cinemaContainer.Object)).ReturnsAsync(cinema);

            var cinemaGetService = new CinemaGetService(cinemaDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => cinemaGetService.ValidateAsync(cinemaContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_CinemaNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var cinemaContainer = new Mock<ICinemaContainer>();
            cinemaContainer.Setup(x => x.CinemaId).Returns(id);

            var cinema = new Cinema();
            var cinemaDataAccess = new Mock<ICinemaDataAccess>();
            cinemaDataAccess.Setup(x => x.GetByAsync(cinemaContainer.Object)).ReturnsAsync((Cinema)null);

            var cinemaGetService = new CinemaGetService(cinemaDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => cinemaGetService.ValidateAsync(cinemaContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Cinema not found by id {id}");
        }
    }
}