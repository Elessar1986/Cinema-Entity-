using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaDataBaseLibrary.Model
{
    public class Session : BaseModel
    {
        public int SessionId { get; set; }
        public DateTime SessionTime { get; set; }
        public virtual Film SessionFilm { get; set; }
        public virtual CinemaRoom SessionRoom { get; set; }
        public virtual ICollection<Place> BusyPlaces { get; set; }


    }
}
