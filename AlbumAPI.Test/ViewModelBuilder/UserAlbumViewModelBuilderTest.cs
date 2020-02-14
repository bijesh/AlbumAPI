using AlbumAPI.ViewModel;
using AlbumAPI.ViewModelBuilder;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AlbumAPI.Test.ViewModelBuilder
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class UserAlbumViewModelBuilderTest
    {
        private UserAlbumViewModelBuilder userAlbumViewModelBuilder;

        [SetUp]
        public void SetUp()
        {
            userAlbumViewModelBuilder = new UserAlbumViewModelBuilder();
        }

        [Test]
        public void Build_Returns_Expected_UserAlbumViewModel_Result()
        {
            // Arrange
            var userId = 1;
            var expectedResult = GetUserAlbumViewModel();

            // Act
            var actualResult = userAlbumViewModelBuilder.Build(userId, GetAlbumViewModel());

            // Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Build_Returns_InstanceOf_PhotoViewModel()
        {
            // Arrange
            var userId =1;

            // Act
            var actualResult = userAlbumViewModelBuilder.Build(userId, GetAlbumViewModel());

            // Assert
            Assert.IsInstanceOf<UserAlbumViewModel>(actualResult);
        }

        private IEnumerable<AlbumViewModel> GetAlbumViewModel()
        {
            return new List<AlbumViewModel>
            {
                new AlbumViewModel
                {
                    id = 1,
                    title = "quidem molestiae enim",
                    Photos = GetPhotoViewModels()
                }
            };
        }
        private PhotoViewModel GetPhotoViewModel()
        {

            return new PhotoViewModel()
            {
                id = 1,
                title = "quidem molestiae enim",
                thumbnailUrl = "https://via.placeholder.com/600/92c952",
                url = "https://via.placeholder.com/600/92c952"
            };
        }

        private IEnumerable<PhotoViewModel> GetPhotoViewModels()
        {
            return new List<PhotoViewModel>()
            {
                new PhotoViewModel()
                {
                    id = 1,
                    title = "quidem molestiae enim",
                    thumbnailUrl = "https://via.placeholder.com/600/92c952",
                    url = "https://via.placeholder.com/600/92c952"
                }
            };
        }
        private UserAlbumViewModel GetUserAlbumViewModel()
        {
            return new UserAlbumViewModel
            {
                userId=1,
                Albums= GetAlbumViewModel()

            };

        }

    }
}
