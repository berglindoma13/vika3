using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using DM.MovieApi;
using Xamarin.Forms;

namespace vika3
{
    
    public class TopRated : ContentPage
    {
        private Movies _TopRatedMovies;
        private ActivityIndicator _progressBar = new ActivityIndicator
        {
            Color = Color.White,
            IsRunning = false
        };

        public async void TopRatedMovies()
        {
            _progressBar.IsRunning = true;
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


            _progressBar.IsRunning = false;
            //Render list as movieListPage
            this.Navigation.PushAsync(new MovieListPage() { BindingContext = this._TopRatedMovies });
        }
       
    }
}
