﻿using System;
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
		private Movies _movies;

		private Button _searchButton = new Button()
		{
			Text = "Get movies",
			BackgroundColor = Color.White,
			TextColor = Color.Gray,
            HorizontalOptions = LayoutOptions.Fill
        };

        private Label _movieResult = new Label()
        {
            HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			Text = string.Empty,
			TextColor = Color.Red,
        };

		private Label _please = new Label()
		{
			HorizontalOptions = LayoutOptions.Center,
			HorizontalTextAlignment = TextAlignment.Center,
			TextColor = Color.White,
			Text = "Please",
			FontSize = 60,
			FontAttributes = FontAttributes.Bold
		};

        private Label _greeting = new Label()
        {
			HorizontalOptions = LayoutOptions.Center,
            HorizontalTextAlignment = TextAlignment.Center,
			TextColor = Color.White,
            Text = "enter a word in a movie",
            FontSize = 20
        };

		private Entry _movieSearchEntry = new Entry
		{
			HorizontalOptions = LayoutOptions.Fill,
			Placeholder = "Movie word",
        };

		private ActivityIndicator _progressBar = new ActivityIndicator
		{
			Color = Color.White,
			IsRunning = false,
			Margin = 20
		};

		public GreetingPage(Movies movies)
		{
		    //Icon = "Search";
			_movies = movies;

            BackgroundColor = Color.Teal;
            Title = "Movie Search";
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
								_please,    
								_greeting,
                                _movieSearchEntry
                            }
                        },
                        _searchButton,
						_movieResult,
						_progressBar
                }   
            };

			_searchButton.Clicked += DisplayMovie;
			_movieSearchEntry.Completed += DisplayMovie;
        }

		private async void DisplayMovie(object sender, EventArgs e)
        {
			_progressBar.IsRunning = true;
			_searchButton.IsEnabled = false;
			_movieResult.Text = string.Empty;

			_movies.AllMovies.Clear();

            var movieApi = MovieDbFactory.Create<DM.MovieApi.MovieDb.Movies.IApiMovieRequest>().Value;
			DM.MovieApi.ApiResponse.ApiSearchResponse<DM.MovieApi.MovieDb.Movies.MovieInfo> response = await movieApi.SearchByTitleAsync(_movieSearchEntry.Text);

            if (response != null)
			{
				foreach (var i in response.Results)
				{

					var resp = await movieApi.GetCreditsAsync(i.Id);
					var response2 = await movieApi.FindByIdAsync(i.Id);
					var tmpmovie = new Movie();

					_movies.AddMovie(i, resp, response2, tmpmovie);
				}
			}

			if (this._movies.AllMovies.Count == 0)
			{
				_movieResult.Text = "No results for given word";
			}
			else
			{
				await this.Navigation.PushAsync(new MovieListPage() { BindingContext = this._movies });
			}

			_progressBar.IsRunning = false;
			_searchButton.IsEnabled = true;
			_movieSearchEntry.Text = "";
        }
    }
}
