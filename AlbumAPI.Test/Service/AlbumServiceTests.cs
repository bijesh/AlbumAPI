using AlbumAPI.Contract;
using AlbumAPI.Interface;
using AlbumAPI.Service;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AlbumAPI.Test.Service
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class AlbumServiceTests
    {
        private AlbumService _albumService;
        private Mock<IWebApiClient> _webApiClientMock;
        private Mock<IConfiguration> _configurationMock;
        private Mock<IConfigurationSection> _configurationSectionMock;

        [SetUp]
        public void Setup()
        {
            _webApiClientMock = new Mock<IWebApiClient>();
            _webApiClientMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(GetResponse());
            _configurationMock = new Mock<IConfiguration>();
            _configurationSectionMock = new Mock<IConfigurationSection>();
            _configurationSectionMock.SetupGet(m => m[It.Is<string>(s => s == "http")]).Returns("http://test/");
            _configurationMock.Setup(a => a.GetSection("AlbumApi")).Returns(_configurationSectionMock.Object);
            _albumService = new AlbumService(_webApiClientMock.Object, _configurationMock.Object);
        }

        [Test]
        public async Task GetAlbum_Returns_Album_List()
        {

            //Act
            var albums = await _albumService.GetAlbums();

            //Assert
            Assert.IsInstanceOf<IEnumerable<Album>>(albums);
        }

        [Test]
        public async Task GetAlbums_Returns_Expected_Album_List()
        {
            // Arrange
            var expectedAlbums = GetAlbum();

            //Act
            var albums = await _albumService.GetAlbums();

            //Assert
            albums.Should().BeEquivalentTo(expectedAlbums);
        }

        [Test]
        public async Task GetAlbum_Calls_GetSection_Method()
        {
            // Act
            await _albumService.GetAlbums();

            // Assert
            _configurationMock.Verify(x => x.GetSection(It.IsAny<string>()), Times.Once);
        }

        private HttpResponseMessage GetResponse()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"[{""userId"": 1,""id"": 1,""title"": ""quidem molestiae enim""},]", Encoding.UTF8, "application/json")
            };
        }

        private List<Album> GetAlbum()
        {
            return new List<Album>()
            {
                new Album
                {
                    id = 1,
                    userId = 1,
                    title = "quidem molestiae enim"
                }
            };
        }

    }
}
