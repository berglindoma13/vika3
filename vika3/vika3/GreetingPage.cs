using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using DM.MovieApi;
using Xamarin.Forms;

namespace vika3
{
    public class GreetingPage : ContentPage
    {
		private Button _searchButton = new Button()
		{
			Text = "Get movies",
			BackgroundColor = Color.Gray,
			TextColor = Color.White,
            HorizontalOptions = LayoutOptions.Fill
        };

        private Label _movieResult = new Label()
        {
            Text = string.Empty,
			TextColor = Color.White,
        };

        private Label _greeting = new Label()
        {
            HorizontalOptions = LayoutOptions.Start,
            HorizontalTextAlignment = TextAlignment.Center,
			TextColor = Color.White,
            Text = "Enter a word in a movie",
            FontSize = 30
        };

		private Entry _movieSearchEntry = new Entry
		{
			HorizontalOptions = LayoutOptions.Fill,
			Placeholder = "Movie word",
			Keyboard = Keyboard.Default
        };

        public GreetingPage()
        {
            BackgroundColor = Color.Teal;
            Title = "Welcome to Movie Search";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Start,
                Spacing = 10,
                Margin = 30,
                Children =
                {
                        new StackLayout()
                        {
                            Children =
                            {
                                _greeting,
                                _movieSearchEntry
                            }
                        },
                        _searchButton,
                        _movieResult
                }   
            };

            _searchButton.Clicked += DisplayMovie;
            _movieSearchEntry.Completed += DisplayMovie;
        }

        private async void DisplayMovie(object sender, EventArgs e)
        {
            var movieApi = MovieDbFactory.Create<DM.MovieApi.MovieDb.Movies.IApiMovieRequest>().Value;
            DM.MovieApi.ApiResponse.ApiSearchResponse<DM.MovieApi.MovieDb.Movies.MovieInfo> response = await movieApi.SearchByTitleAsync(_movieSearchEntry.Text);

            _movieResult.Text = response.Results[0].Title;
            _movieSearchEntry.Text = string.Empty;
        }
    }
}
