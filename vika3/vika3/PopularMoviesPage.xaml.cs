using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.MovieApi;
using Xamarin.Forms;

namespace vika3
{
    public partial class PopularMoviesPage : ContentPage
    {
        private Movies _popularMovies;
        public PopularMoviesPage()
        {
            _popularMovies = new Movies();
            InitializeComponent();
            flowlistview.FlowItemTapped += (sender, e) =>
            {
                Listview_OnItemSelected(sender,e);
            };
            flowlistview.IsPullToRefreshEnabled = true;
        }

        public async Task PopularMovies()
        {
            //populate list
            _popularMovies.AllMovies.Clear();
            Spinner.IsRunning = true;
            Spinner.IsVisible = true;

            var movieApi = MovieDbFactory.Create<DM.MovieApi.MovieDb.Movies.IApiMovieRequest>().Value;
            DM.MovieApi.ApiResponse.ApiSearchResponse<DM.MovieApi.MovieDb.Movies.MovieInfo> response = await movieApi.GetPopularAsync();

            if (response != null)
            {
                foreach (var i in response.Results)
                {
                    var resp = await movieApi.GetCreditsAsync(i.Id);
                    var response2 = await movieApi.FindByIdAsync(i.Id);
                    var tmpmovie = new Movie();

                    _popularMovies.AddMovie(i, resp, response2, tmpmovie);
                }
            }

            BindingContext = _popularMovies;

            Spinner.IsRunning = false;
            Spinner.IsVisible = false;
            //Render list as movieListPage
        }

        private void Listview_OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }
            this.Navigation.PushAsync(new DetailsPage() { BindingContext = e.Item });
            ((ListView)sender).SelectedItem = null;
        }
    }
}
