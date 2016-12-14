using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.MovieApi;
using Xamarin.Forms;

namespace vika3
{
    public partial class TopRatedPage
    {
        private Movies _TopRatedMovies;
        public TopRatedPage()
        {
            _TopRatedMovies = new Movies();
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Spinner.IsRunning = true;
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


           this.Spinner.IsRunning = false;
        }

        private void Listview_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            this.Navigation.PushAsync(new DetailsPage() { BindingContext = e.SelectedItem });
            ((ListView)sender).SelectedItem = null;
        }
    }
}
