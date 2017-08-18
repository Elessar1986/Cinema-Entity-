using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDataBaseLibrary.Model
{
    [Serializable]
    public class Place : BaseModel
    {
        public int PlaceId { get; set; }
        public int Row { get; set; }
        public int PlaceNum { get; set; }
       

        public override string ToString()
        {
            return $"Ряд: {Row} Место: {PlaceNum}";
        }
    }
}
