using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sem26
{
	[Table("anime")]
	class Anime
	{
		[Key]
		[Column("anime_id")]
		public long AnimeId { get; set; }

		public string Name { get; set; }

		public string Genre { get; set; }

		public string Type { get; set; }
		[Column("episodes")]
		public string EpisodesString
		{
			get { return Episodes.ToString(); }
			set
			{
				if (int.TryParse(value, out int episodes))
				{
					Episodes = episodes;
				}
				else { Episodes = -1; }

			}
		}

		public double Rating { get; set; }

		public long Members { get; set; }

		[NotMapped]
		public int Episodes { get; set; }

		public override string ToString()
		{
			return Name;

		}
	}

	[Table("rating")]
	class Rating
	{
		[Key]
		[Column("user_id", Order = 2)]
		public long UserId { get; set; }
		[Key]
		[Column("anime_id", Order = 1)]
		public long AnimeId { get; set; }
		[Column("rating")]
		public long UserRating { get; set; }

		public override string ToString()
		{
			return $"{UserId} {AnimeId} {UserRating}";
		}
	}

	class AnimeRatingContext : System.Data.Entity.DbContext
	{
		const string connectingString = "Server=tcp:seminar-sharp.database.windows.net,1433;Initial Catalog=C-Sharp-Test;Persist Security Info=False;User ID=seminarist;Password=Qwerty000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

		public AnimeRatingContext() : base(connectingString) { }

		public DbSet<Anime> Anime { get; set; }
		public DbSet<Rating> Rating { get; set; }

	}
	class Program
	{
		static void Main(string[] args)
		{
			using (var context = new AnimeRatingContext())
			{
				var entityLongAnime = from anime in context.Anime
									  where anime.EpisodesString.Length > 2
									  select anime;

				Console.WriteLine(entityLongAnime);
				var objLongAnime = (entityLongAnime).ToList().Where(anime => anime.Episodes>100);

				Console.WriteLine(objLongAnime);

				foreach (var anime in objLongAnime)
				{
				//	Console.WriteLine(anime);
				}

				var userAnime = from rating in context.Rating
								where rating.UserId == 17
								where rating.UserRating > 8
								join anime in context.Anime on rating.AnimeId equals anime.AnimeId
								select new { rating.UserId, anime.Name, Raiting = rating.UserRating};

				foreach (var a in userAnime)
				{
		//			Console.WriteLine(a);
				}


				// user id = 54
				// user rating > 9
				// Sort by User rating then by Rating
				// Top 3 


				var newSort = from rating in context.Rating
								where rating.UserId == 17
								where rating.UserRating > 9
								join anime in context.Anime on rating.AnimeId equals anime.AnimeId
							orderby rating.UserRating descending, anime.Rating descending
							  select new { rating.UserId, anime.Name, Raiting = rating.UserRating, AvgRating = anime.Rating };

				var newSortList = (newSort).ToList().Distinct().Take(5);

				foreach (var a in newSortList)
				{
					Console.WriteLine(a);
				}
			}
		}
	}
}
