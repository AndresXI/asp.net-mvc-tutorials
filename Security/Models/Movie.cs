using System.ComponentModel.DataAnnotations;

namespace IdentityFrameworkProject.Models
{
	public class Movie
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Genre { get; set; }
		public bool HasWatched { get; set; }
		public int WatchedNo { get; set; }
	}
}
