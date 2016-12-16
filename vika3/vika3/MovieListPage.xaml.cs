using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DM.MovieApi;
using Xamarin.Forms;

namespace vika3
{
	public partial class MovieListPage : ContentPage
	{
	    private Movies _TopRatedMovies;
		public MovieListPage()
		{
            _TopRatedMovies = new Movies();
			InitializeComponent();
 
		    listview.IsPullToRefreshEnabled = true;
		}

		private void Listview_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return;
			}
            this.Navigation.PushAsync(new DetailsPage() { BindingContext = e.SelectedItem });
		    ((ListView) sender).SelectedItem = null;
		}

        public async Task TopRatedMovies()
        {
            Spinner.IsRunning = true;
            Spinner.IsVisible = true;
            //populate list
            _TopRatedMovies.AllMovies.Clear();

            var movieApi = MovieDbFactory.Create<DM.MovieApi.MovieDb.Movies.IApiMovieRequest>().Value;
            DM.MovieApi.ApiResponse.ApiSearchResponse<DM.MovieApi.MovieDb.Movies.MovieInfo> response = await movieApi.GetTopRatedAsync();

            if (response != null)
            {
                foreach (var i in response.Results)
                {
                    var resp = await movieApi.GetCreditsAsync(i.Id);
                    var response2 = await movieApi.FindByIdAsync(i.Id);
                    var tmpmovie = new Movie();

                    _TopRatedMovies.AddMovie(i, resp, response2, tmpmovie);
                }
            }

            BindingContext = _TopRatedMovies;

            Spinner.IsRunning = false;
            Spinner.IsVisible = false;
            //Render list as movieListPage
        }

    }
}
