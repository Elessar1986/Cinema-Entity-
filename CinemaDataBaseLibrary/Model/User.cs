using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDataBaseLibrary.Model
{
    public class User : BaseModel
    {
        public int UserId { set; get; }
        public string UserName { set; get; }
        public string UserEmail { set; get; }
        public virtual ICollection<Ticket> UsersTicket { get; set; }
    }
}
