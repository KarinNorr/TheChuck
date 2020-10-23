using System;
using TheChuck.Mocks;
using TheChuck.ViewModels;
using Xunit;
using Nito.AsyncEx;
using FluentAssertions;


namespace TheChuckUnitTests.ViewModels
{
    public class MainPageViewModelTests
    {
        [Fact()]
        public void GoToCategory_Should_Call_NavigationService_One()
        {
            //Arrange
            var sut = sutFactory();

            //Act
            AsyncContext.Run(() =>
            {
                sut.GoToCategoryCommand.Execute(null);
            });

            //Assert
            Assert.Equal(1, (sut.navigationService as NavigationServiceMock).GoToCategoryPageCall);

        }

        [Fact()]
        public void GoToSearch_Should_Call_NavigationService_One()
        {
            //Arrange
            var sut = sutFactory();

            //Act
            AsyncContext.Run(() =>
            {
                sut.GoToSearchPageCommand.Execute(null);
            });

            //Assert
            Assert.Equal(1, (sut.navigationService as NavigationServiceMock).GoToSearchPageCall);

        }


        [Fact()]
        public async void LoadCategorys_Should_Fetch_List_With_Categorys_From_Api()
        {
            //Arrange
            var sut = sutFactory();

            //Act
            await sut.LoadCategories();

            //Assert
            sut.Categories.Should().Contain("HomeParty", "Animals", "Food", "Activitys");
        }


        private MainPageViewModel sutFactory()
        {
            var sut = new MainPageViewModel();
            sut.apiService = new ApiServiceMock();
            sut.navigationService = new NavigationServiceMock();

            return sut;
        }
    }
}
