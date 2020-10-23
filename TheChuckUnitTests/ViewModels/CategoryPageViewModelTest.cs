using System;
using FluentAssertions;
using Nito.AsyncEx;
using TheChuck;
using TheChuck.Mocks;
using TheChuck.ViewModels;
using Xunit;

namespace TheChuckUnitTests.ViewModels
{
    public class CategoryPageViewModelTest
    {

        [Fact()]
        public void SaveAsFavourite_()
        {
            //Arrange
            var sut = App.Database;

            //Act
            sut.SaveFavouriteAsync(null);

            //Assert

        }



        [Fact()]
        public async void LoadRandomFromCategory_Should_Fetch_Random_From_Api()
        {
            //Arrange
            var sut = sutFactory();

            //Act
            await sut.LoadRandomFromCategory(null);

            //Assert
            sut.Joke.Should().ContainEquivalentOf("Idag är en tråkig dag!");
        }



        private CategoryPageViewModel sutFactory()
        {
            var sut = new CategoryPageViewModel(null);
            sut.apiService = new ApiServiceMock();
            sut.navigationService = new NavigationServiceMock();
            
            return sut;
        }
    }
}
