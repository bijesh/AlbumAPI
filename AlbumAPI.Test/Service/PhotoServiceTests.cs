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
    public class PhotoServiceTests
    {
        private PhotoService _photoService;
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
            _configurationMock.Setup(a => a.GetSection("PhotoApi")).Returns(_configurationSectionMock.Object);
            _photoService = new PhotoService(_webApiClientMock.Object, _configurationMock.Object);
        }


        [Test]
        public async Task GetPhoto_Returns_Photo_List()
        {
            //Act
            var photos = await _photoService.GetPhotos();

            //Assert
            Assert.IsInstanceOf<IEnumerable<Photo>>(photos);
        }

        [Test]
        public async Task GetPhoto_Returns_Expected_Photo_List()
        {
            // Arrange
            var expectedPhotos = GetPhoto();

            //Act
            var photos = await _photoService.GetPhotos();

            //Assert
            photos.Should().BeEquivalentTo(expectedPhotos);
        }

        [Test]
        public async Task GetPhoto_Calls_GetSection_Method()
        {
            // Act
            await _photoService.GetPhotos();

            // Assert
            _configurationMock.Verify(x => x.GetSection(It.IsAny<string>()), Times.Once);
        }

        private HttpResponseMessage GetResponse()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"[{""albumId"": 1,""id"": 1,""title"": ""quidem molestiae enim"", ""url"":""https://via.placeholder.com/600/92c952"",""thumbnailUrl"": ""https://via.placeholder.com/150/92c952""},]", Encoding.UTF8, "application/json")
            };
        }

        private List<Photo> GetPhoto()
        {
            return new List<Photo>
            {
                new Photo
                {
                    id = 1,
                    albumId = 1,
                    title = "quidem molestiae enim",
                    url = "https://via.placeholder.com/600/92c952",
                    thumbnailUrl = "https://via.placeholder.com/150/92c952"
                }
            };
            
        }

    }
}
