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
            greetingNavigationPage.Title = "Movies";

            var topRated = new TopRatedPage();
            var topRatedNavigationPage = new NavigationPage(topRated);
            topRatedNavigationPage.Title = "Top rated Movies";

            var tabbedPage = new TabbedPage();
            tabbedPage.Children.Add(greetingNavigationPage);
            tabbedPage.Children.Add(topRatedNavigationPage);

            

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
