using AlbumAPI.Contract;
using AlbumAPI.Interface;
using AlbumAPI.ViewModel;
using AlbumAPI.ViewModelBuilder;
using FluentAssertions;
using Moq;
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
    public class AlbumViewModelBuilderTests
    {
        private AlbumViewModelBuilder albumViewModelBuilder;
        private Mock<IPhotoViewModelBuilder> photoViewModelBuilderMock;

        [SetUp]
        public void SetUp()
        {
            photoViewModelBuilderMock = new Mock<IPhotoViewModelBuilder>();
            photoViewModelBuilderMock.Setup(x => x.Build(It.IsAny<Photo>())).Returns(GetPhotoViewModel());
            albumViewModelBuilder = new AlbumViewModelBuilder(photoViewModelBuilderMock.Object);
        }

        [Test]
        public void Build_Returns_Expected_AlbumViewModel_Result()
        {
            // Arrange
            var expectedResult = GetAlbumViewModel();

            // Act
            var actualResult = albumViewModelBuilder.Build(GetAlbum(),GetPhotos());

            // Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Build_Returns_InstanceOf_AlbumViewModel()
        {

            // Act
            var actualResult = albumViewModelBuilder.Build(GetAlbum(), GetPhotos());

            // Assert
            Assert.IsInstanceOf<AlbumViewModel>(actualResult);
        }

        private Album GetAlbum()
        {
            return new Album
            {
                id = 1,
                userId = 1,
                title = "quidem molestiae enim"
            };

        }
        private List<Photo> GetPhotos()
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
        private AlbumViewModel GetAlbumViewModel()
        {
            return new AlbumViewModel
            {
                id=1,
                title= "quidem molestiae enim",
                Photos = GetPhotoViewModels()
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
