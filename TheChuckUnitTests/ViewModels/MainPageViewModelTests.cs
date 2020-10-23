using System;
using TheChuck.ViewModels;
using Xunit;

namespace TheChuckUnitTests.ViewModels
{
    public class MainPageViewModelTests
    {
        [Fact()]
        public void GoToCategory_Should_Call_NavigationService_One()
        {

        }
        [Fact()]
        public void Load_Should_Fetch_List_With_Categorys_From_Api()
        {

        }





        private MainPageViewModel sutFactory()
        {
            var sut = new MainPageViewModel();
            sut.apiService = new

            return sut;


        }
    }

}
