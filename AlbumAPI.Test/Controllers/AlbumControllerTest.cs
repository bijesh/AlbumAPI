using AlbumAPI.Controllers;
using AlbumAPI.Interface;
using AlbumAPI.ViewModel;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace AlbumAPI.Test.Controllers
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class AlbumControllerTest
    {
        private AlbumController _albumController;
        private Mock<ISearchService> _searchService;

        [SetUp]
        public void Setup()
        {
            _searchService = new Mock<ISearchService>();
            _searchService.Setup(x => x.GetUserAlbums(It.IsAny<int>())).ReturnsAsync(GetUserAlbumViewModel);
            _albumController = new AlbumController(_searchService.Object);
        }

        [Test]
        public async Task Get_Returns_Instance_Of_UserAlbumViewModel()
        {
            // Arrange 
            int userId = 1;

            //Act

            var result = await _albumController.Get(userId);

            // Assert
            Assert.IsInstanceOf<UserAlbumViewModel>(result);
        }

        [Test]
        public async Task Get_Returns_Expected_UserAlbumViewModel_Object()
        {
            // Arrange 
            int userId = 1;
            var expectedUserAlbumViewModel = GetUserAlbumViewModel();

            //Act

            var result = await _albumController.Get(userId);

            // Assert
            result.Should().BeEquivalentTo(expectedUserAlbumViewModel);
        }

        [Test]
        public async Task Verify_Get_Method_Calling_GetUserAlbums_Method()
        {
            // Arrange 
            int userId = 1;

            //Act
            var result = await _albumController.Get(userId);

            // Assert
            _searchService.Verify(x => x.GetUserAlbums(It.IsAny<int>()), Times.Once);
        }

        private UserAlbumViewModel GetUserAlbumViewModel()
        {
            return new UserAlbumViewModel
            {
                userId = 1,
                Albums = new List<AlbumViewModel>
                {
                    new AlbumViewModel
                    {
                        id=1,
                        title="sample album",
                        Photos= new List<PhotoViewModel>
                        {
                            new PhotoViewModel
                            {
                                id=1,
                                title="first photo",
                                thumbnailUrl="https://via.placeholder.com/600/92c952",
                                url="https://via.placeholder.com/600/92c952"
                            }
                        }
                    }
                }
            };
        }
    }
}
