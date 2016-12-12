﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace vika3
{
    public class GreetingPage : ContentPage
    {
        private Button _searchButton = new Button()
        {
            Text = "Get movies",
            BorderColor = Color.Teal,
            HorizontalOptions = LayoutOptions.Fill
        };

        private Label _movieResult = new Label()
        {
            Text = string.Empty
        };

        private Label _greeting = new Label()
        {
            HorizontalOptions = LayoutOptions.Start,
            HorizontalTextAlignment = TextAlignment.Center,
            Text = "Enter a word in a movie",
            FontSize = 30
        };

        private Entry _movieSearchEntry = new Entry
        {
            HorizontalOptions = LayoutOptions.Fill,
            Placeholder = "Movie word"
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

        private void DisplayMovie(object sender, EventArgs e)
        {
            _movieResult.Text = _movieSearchEntry.Text;
            _movieSearchEntry.Text = string.Empty;
        }
    }
}