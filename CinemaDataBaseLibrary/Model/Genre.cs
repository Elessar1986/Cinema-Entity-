using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDataBaseLibrary.Model
{
    [Table("Genres")]
    public class Genre : BaseModel
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public Genre() { }

        public Genre(int genreId, string genreName)
        {
            GenreId = genreId;
            GenreName = genreName;
        }
        public override string ToString()
        {
            return GenreName;
        }
    }
}
