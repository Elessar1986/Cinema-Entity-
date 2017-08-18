using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDataBaseLibrary.Model
{
    [Table("Tickets")]
    public class Ticket : BaseModel
    {
        public int TicketId { set; get; }

        public int Row { get; set; }
        public int PlaceNum { get; set; }
        
        public virtual Film FilmId { set; get; }
        public virtual CinemaRoom CinemaRoomId { set; get; }
        public virtual Session SesionId { get; set; }

        


    }
}
