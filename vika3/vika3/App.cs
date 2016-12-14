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
        public App()
        {
            MovieDbFactory.RegisterSettings(new ApiConnectionClass());
            // The root page of your application
			var content = new GreetingPage(new Movies());
            var greetingNavigationPage = new NavigationPage(content);
            greetingNavigationPage.Title = "Movie Search";
            

            var topRated = new MovieListPage();
            var topRatedNavigationPage = new NavigationPage(topRated);
            topRatedNavigationPage.Title = "Top rated";

            var popularMovies = new PopularMoviesPage();
            var popularMoviesNavigationPage = new NavigationPage(popularMovies);
            popularMoviesNavigationPage.Title = "Popular";

            var tabbedPage = new TabbedPage();
            tabbedPage.Children.Add(greetingNavigationPage);
            tabbedPage.Children.Add(topRatedNavigationPage);
            tabbedPage.Children.Add(popularMoviesNavigationPage);


            tabbedPage.CurrentPageChanged += async (sender, e) =>
            {
                if (tabbedPage.CurrentPage == topRatedNavigationPage)
                {
                    await topRated.TopRatedMovies();
                }
                else if (tabbedPage.CurrentPage == popularMoviesNavigationPage)
                {
                    await popularMovies.PopularMovies();
                }
            };

            MainPage = tabbedPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
