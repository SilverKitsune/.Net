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
    public class MovieGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_MovieExists_DoesNothing()
        {
            // Arrange
            var departmentContainer = new Mock<IMovieContainer>();

            var movie = new Movie();
            var movieDataAccess = new Mock<IMovieDataAccess>();
            movieDataAccess.Setup(x => x.GetByAsync(departmentContainer.Object)).ReturnsAsync(movie);

            var movieGetService = new MovieGetService(movieDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => movieGetService.ValidateAsync(departmentContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_MovieNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var movieContainer = new Mock<IMovieContainer>();
            movieContainer.Setup(x => x.MovieId).Returns(id);

            var movie = new Movie();
            var movieDataAccess = new Mock<IMovieDataAccess>();
            movieDataAccess.Setup(x => x.GetByAsync(movieContainer.Object)).ReturnsAsync((Movie)null);

            var movieGetService = new MovieGetService(movieDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => movieGetService.ValidateAsync(movieContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Movie not found by id {id}");
        }
    }
}