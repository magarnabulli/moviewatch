using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchDb.Entities
{
	public interface IReference
	{
		public int FilmId { get; set; }
		public int GenreId { get; set; }
	}
}
