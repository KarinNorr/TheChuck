using System;
using FakeItEasy;
using FluentAssertions;
using Nito.AsyncEx;
using TheChuck.Mocks;
using TheChuck.Services;
using TheChuck.ViewModels;
using Xunit;

namespace TheChuckUnitTests.ViewModels
{
    public class SearchPageViewModelTests
    {

        [Fact()]
        public async void SearchForJokes_Should_Make_Call_To_ApiService()
        {
            //Arrange 
            var apiService = A.Fake<IApiService>();
            var search = "TestString";

            //Act
            await apiService.GetJokesFromSearchQuery(search);


            //Assert 
            A.CallTo(() => apiService.GetJokesFromSearchQuery(search)).MustHaveHappened();
        }

        [Fact()]
        public async void SearchForJokes_Should_Return_DTOResultFromQuery()
        {
            //Arrange
            var apiService = A.Fake<IApiService>();
            var testDTO = A.Fake<DTOResultFromQuery>();
            var search = "TestString";


            //Act
            var result = await apiService.GetJokesFromSearchQuery(search);

            //Assert 
            result.Should().BeEquivalentTo(testDTO);

        }



        [Fact()]
        public void GoToFavouritePage_Should_Call_NavigationService_One()
        {
            //Arrange
            var sut = sutFactory();

            //Act
            AsyncContext.Run(() =>
            {
                sut.GetFavouritesCommand.Execute(null);
            });

            //Assert
            Assert.Equal(1, (sut.navigationService as NavigationServiceMock).GotToFavouritesPageCall);

        }

        [Fact()]
        public async void Save_Favourite_Should_Call_DataBaseService_Method_SaveFavouriteAsync()
        {
            //Arrange
            var databaseService = A.Fake<IDataBaseService>();
            var favourite = A.Fake<Favourite>();


            //Act
            await databaseService.SaveFavouriteAsync(favourite);

            //Assert
            A.CallTo(() => databaseService.SaveFavouriteAsync(favourite)).MustHaveHappened();
        }

        private SearchPageViewModel sutFactory()
        {
            var sut = new SearchPageViewModel();
            sut.apiService = new ApiServiceMock();
            sut.navigationService = new NavigationServiceMock();

            return sut;
        }
    }
}
