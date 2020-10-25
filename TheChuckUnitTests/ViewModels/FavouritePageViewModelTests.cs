using System;
using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using TheChuck.Services;
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
    }
}
