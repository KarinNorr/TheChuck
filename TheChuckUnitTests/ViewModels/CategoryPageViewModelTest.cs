using System;
using FluentAssertions;
using Nito.AsyncEx;
using TheChuck;
using FakeItEasy;
using TheChuck.Mocks;
using TheChuck.Services;
using TheChuck.ViewModels;
using Xunit;
using System.Threading.Tasks;

namespace TheChuckUnitTests.ViewModels
{
    public class CategoryPageViewModelTest 
    {

        [Fact()]
        public async Task SaveAsFavourite_Call_To_Database_Should_Not_Return_Null_Async()
        {
            //Arrange
            var favourite = A.Fake<Favourite>();
            var sut = A.Fake<IDataBaseService>();


            //Act
            var result = await sut.SaveFavouriteAsync(favourite);

            //Assert
            result.Should().NotBe(null);
            //result.Should().BeOfType<Task<int>>("because task...", typeof(int));
            //vad tetsar jag här?
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
