using System;
using System.Threading.Tasks;
using Cinemas.BLL.Contracts;
using Cinemas.BLL.Implementation;
using Cinemas.DataAccess.Contracts;
using Cinemas.Domain;
using Cinemas.Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Cinemas.BLL.Tests
{
    public class ScreeningUpdateServiceTests
    {
        [Test]
        public async Task UpdateAsync_DepartmentValidationSucceed_CreatesScreening()
        {
            // Arrange
            var screening = new ScreeningUpdateModel();
            var expected = new Screening();
            
            var cinemaGetService = new Mock<ICinemaGetService>();
            cinemaGetService.Setup(x => x.ValidateAsync(screening));

            var movieGetService = new Mock<IMovieGetService>();
            movieGetService.Setup(x => x.ValidateAsync(screening));

            var screeningDataAccess = new Mock<IScreeningDataAccess>();
            screeningDataAccess.Setup(x => x.UpdateAsync(screening)).ReturnsAsync(expected);
            
            var screeningGetService = new ScreeningUpdateService(screeningDataAccess.Object, cinemaGetService.Object, movieGetService.Object);
            
            // Act
            var result = await screeningGetService.UpdateAsync(screening);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task UpdateAsync_CinemaValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var screening = new ScreeningUpdateModel();
            var expected = fixture.Create<string>();
            
            var cinemaGetService = new Mock<ICinemaGetService>();
            cinemaGetService
                .Setup(x => x.ValidateAsync(screening))
                .Throws(new InvalidOperationException(expected));

            var movieGetService = new Mock<IMovieGetService>();
            movieGetService.Setup(x => x.ValidateAsync(screening)).Throws(new InvalidOperationException(expected));

            
            var screeningDataAccess = new Mock<IScreeningDataAccess>();

            var screeningGetService = new ScreeningUpdateService(screeningDataAccess.Object, cinemaGetService.Object, movieGetService.Object);
            
            // Act
            var action = new Func<Task>(() => screeningGetService.UpdateAsync(screening));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            screeningDataAccess.Verify(x => x.UpdateAsync(screening), Times.Never);
        }
    }
}