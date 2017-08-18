using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;

namespace CinemaDataBaseLibrary.Model
{
    [Table("Films")]
    public class Film : BaseModel
    {
        [NotMapped]
        int filmId;
        [NotMapped]
        string filmName;
        [NotMapped]
        int filmYear;
        [NotMapped]
        float rating;
        [NotMapped]
        string description;
        [NotMapped]
        string filmPhotoFileName;
        [NotMapped]
        byte[] filmPhotoData;
        [NotMapped]
        Director directorId;
        [NotMapped]
        Genre genreId;

        public int FilmId { set { filmId = value; Notify(); } get { return filmId; } }
        public string FilmName { set; get; }
        public int FilmYear { set; get; }
        public float Rating { set; get; }
        public string Description { set; get; }
        public string FilmPhotoFileName { get; set; }
        public byte[] FilmPhotoData { set; get; }
        public virtual Director DirectorId { set; get; }
        public virtual Genre GenreId { set; get; }

        public void AddPhotos(string fileName)
        {
            FilmPhotoFileName = Path.GetFileName(fileName);
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                FilmPhotoData = new byte[fs.Length];
                fs.Read(FilmPhotoData, 0, FilmPhotoData.Length);
            }
        }
    }
}
