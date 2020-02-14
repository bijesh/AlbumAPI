using AlbumAPI.Contract;
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
    public class PhotoViewModelBuilderTest
    {

        private PhotoViewModelBuilder photoViewModelBuilder;

        [SetUp]
        public void SetUp()
        {
            photoViewModelBuilder = new PhotoViewModelBuilder();
        }

        [Test]
        public void Build_Returns_Expected_PhotoViewModel_Result()
        {
            // Arrange
            var expectedResult = GetPhotoViewModel();

            // Act
            var actualResult = photoViewModelBuilder.Build(GetPhoto());

            // Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Build_Returns_InstanceOf_PhotoViewModel()
        {

            // Act
            var actualResult = photoViewModelBuilder.Build(GetPhoto());

            // Assert
            Assert.IsInstanceOf<PhotoViewModel>(actualResult);
        }

        private Photo GetPhoto()
        {
            return new Photo
            {
                id = 1,
                albumId = 1,
                title = "quidem molestiae enim",
                url = "https://via.placeholder.com/600/92c952",
                thumbnailUrl = "https://via.placeholder.com/600/92c952"
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
    }
}
