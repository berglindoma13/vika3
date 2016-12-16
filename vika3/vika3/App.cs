using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DM.MovieApi;
using Xamarin.Forms;

namespace vika3
{
    public class App : Application
    {
        private MovieListPage topRated;
        private PopularMoviesPage popularMovies;
        public App()
        {
            MovieDbFactory.RegisterSettings(new ApiConnectionClass());
            // The root page of your application
			var content = new GreetingPage(new Movies());
            var greetingNavigationPage = new NavigationPage(content);
            greetingNavigationPage.Title = "Movie Search";
            greetingNavigationPage.Icon = "searchicon";
            

            topRated = new MovieListPage();
            var topRatedNavigationPage = new NavigationPage(topRated);
            topRatedNavigationPage.Title = "Top rated";
            topRatedNavigationPage.Icon = "toprated";

            popularMovies = new PopularMoviesPage();
            var popularMoviesNavigationPage = new NavigationPage(popularMovies);
            popularMoviesNavigationPage.Title = "Popular";
            popularMoviesNavigationPage.Icon = "popular";
            


            var tabbedPage = new TabbedPage();
            tabbedPage.Children.Add(greetingNavigationPage);
            tabbedPage.Children.Add(topRatedNavigationPage);
            tabbedPage.Children.Add(popularMoviesNavigationPage);


            /*tabbedPage.CurrentPageChanged += async (sender, e) =>
            {
				tabbedPage.IsEnabled = false;
                if (tabbedPage.CurrentPage == topRatedNavigationPage)
                {
                    await topRated.TopRatedMovies();
                }
                else if (tabbedPage.CurrentPage == popularMoviesNavigationPage)
                {
                    await popularMovies.PopularMovies();
                }
				tabbedPage.IsEnabled = true;
            };*/

            MainPage = tabbedPage;
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            await popularMovies.PopularMovies();
            await topRated.TopRatedMovies();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
