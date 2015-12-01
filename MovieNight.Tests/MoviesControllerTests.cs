using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieNight.Domain.Interfaces;
using MovieNight.WebAPI.Controllers;
using System.Web.Http;
using MongoDB.Driver;
using MovieNight.Domain.Entities;
using MovieNight.Domain.Enums;

namespace MovieNight.Tests
{
    [TestClass]
    public class MoviesControllerTests
    {
        public readonly List<Movie> Movies = new List<Movie>
        {
            new Movie {
                Title = "Test Movie 1",
                Year = 2015,
                ReleaseDate = DateTime.Now,
                Rating = "R",
                Length = 120,
                Genres = new List<Genre>()
                    {
                        new Genre()
                        {
                            Category = GenreCategory.Action
                        },
                        new Genre()
                        {
                            Category = GenreCategory.Adventure
                        }
                    },
                CastMembers = new List<CastMember>(),
                Writers = new List<Writer>(),
                Directors = new List<Director>()
            },
            new Movie {
                Title = "Test Movie 2",
                Year = 2014,
                ReleaseDate = DateTime.Now,
                Rating = "PG",
                Length = 90,
                Genres = new List<Genre>()
                    {
                        new Genre()
                        {
                            Category = GenreCategory.SciFi
                        },
                        new Genre()
                        {
                            Category = GenreCategory.Suspense
                        }
                    },
                CastMembers = new List<CastMember>(),
                Writers = new List<Writer>(),
                Directors = new List<Director>()
            },
        };
            
        [TestMethod]
        public async Task GetMovies_Should_Call_FindAllMovies()
        {
            // Arrange
            var mockRepository = new Mock<IMoviesRepository>();
            mockRepository.Setup(x => x.FindAllMovies()).ReturnsAsync(new List<Movie>());

            var controller = new MoviesController(mockRepository.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            await controller.GetMovies();

            // Assert
            mockRepository.Verify(x => x.FindAllMovies());
        }

        [TestMethod]
        public async Task GetMovies_Should_Return_200_Status()
        {
            // Arrange
            var mockRepository = new Mock<IMoviesRepository>();
            mockRepository.Setup(x => x.FindAllMovies())
                .ReturnsAsync(Movies);

            var controller = new MoviesController(mockRepository.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var results = await controller.GetMovies();

            // Assert
            Assert.AreEqual(results.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task GetMovies_Should_Return_404_Status()
        {
            // Arrange
            var mockRepository = new Mock<IMoviesRepository>();
            mockRepository.Setup(x => x.FindAllMovies())
                .Returns(Task.FromResult(new List<Movie>()));

            var controller = new MoviesController(mockRepository.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var results = await controller.GetMovies();

            // Assert
            Assert.AreEqual(results.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        [ExpectedException(typeof(MongoException))]
        public async Task GetMovies_Should_Return_500_Status_MongoException()
        {
            // Arrange
            var mockRepository = new Mock<IMoviesRepository>();
            mockRepository.Setup(x => x.FindAllMovies())
                .Throws(new MongoException("error"));

            var controller = new MoviesController(mockRepository.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var results = await controller.GetMovies();

            // Assert
            Assert.AreEqual(results.StatusCode, HttpStatusCode.InternalServerError);
        }

        [TestMethod]
        [ExpectedException(typeof(TimeoutException))]
        public async Task GetMovies_Should_Return_500_Status_TimeoutException()
        {
            // Arrange
            var mockRepository = new Mock<IMoviesRepository>();
            mockRepository.Setup(x => x.FindAllMovies())
                .Throws(new TimeoutException());

            var controller = new MoviesController(mockRepository.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var results = await controller.GetMovies();

            // Assert
            Assert.AreEqual(results.StatusCode, HttpStatusCode.InternalServerError);
        }
    }
}
