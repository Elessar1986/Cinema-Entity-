using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace CinemaDataBaseLibrary.Model
{
    [Table("Directors")]
    public class Director : BaseModel
    {
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }

        
        public Director() { }

        public Director(int directorId, string directorName)
        {
            DirectorId = directorId;
            DirectorName = directorName;
        }

        public override string ToString()
        {
            return DirectorName;
        }
    }
}
