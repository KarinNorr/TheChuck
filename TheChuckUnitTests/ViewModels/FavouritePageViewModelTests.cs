using System;
using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using Nito.AsyncEx;
using TheChuck.Mocks;
using TheChuck.Services;
using TheChuck.ViewModels;
using Xunit;

namespace TheChuckUnitTests.ViewModels
{
    public class FavouritePageViewModelTests
    {
        [Fact()]
        public async void LoadFavouritesCommand_Should_Return_List_With_Favourites()
        {
            //Arrange
            var databaseService = A.Fake<IDataBaseService>();
            var testList = A.Fake<List<Favourite>>();

            //Act
            var result = await databaseService.GetFavouritesAsync();

            //Assert
            result.Should().BeEquivalentTo(testList);
        }

        [Fact()]
        public void UpdateFavouritesCommand_Should_Use_ListWith_Favourites()
        {
            //Arrange
            var sut = sutFactory();
            var litsToTestWith = A.Fake<List<Favourite>>();


            //Act
            AsyncContext.Run(() =>
            {
                sut.UpdateFavouritesCommand.Execute(null);
            });

            //Assert
            A.CallTo(() => sut.UpdateFavouritesCommand.Execute(null)).Should().BeEquivalentTo(litsToTestWith);
        }

        private FavouritePageViewModel sutFactory()
        {
            var sut = new FavouritePageViewModel();
            sut.apiService = new ApiServiceMock();
            sut.navigationService = new NavigationServiceMock();

            return sut;
        }
    }
}
