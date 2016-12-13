using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vika3
{
	using Xamarin.Forms;
	public class Movie
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int Year { get; set; }
		public string ImageName { get; set; }
		public string Actors { get; set; }
		public int Runtime { get; set; }
		public string Genre { get; set; }
		public string Review { get; set; }

		public string TitleYear => Title + " (" + Year + ")";

		public override string ToString()
		{
			return Title + " (" + Year + ")";
		}

	}
}
