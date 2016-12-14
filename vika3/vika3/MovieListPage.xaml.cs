using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace vika3
{
	public partial class MovieListPage : ContentPage
	{
		public MovieListPage()
		{
			InitializeComponent();
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
	}
}
