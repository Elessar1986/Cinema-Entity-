using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaDataBaseLibrary.Model
{
    [Serializable]
    public class CinemaRoom : BaseModel
    {
        
        public int CinemaRoomId { set; get; }
        public string RoomName { set; get; }
        public int NumOfPlaces { set; get; }
        public int NumOfBusyPlaces { set; get; }
        public string RoomXMLmap { set; get; }
        [NotMapped]
        public RoomMap RoomMap { get; set; }

        public CinemaRoom() { }

        public override string ToString()
        {
            return $"{CinemaRoomId}  {RoomName}  {NumOfPlaces}  {NumOfBusyPlaces}";
        }

        public static RoomMap GetRoomMap(string filename)
        {
            RoomMap room = Serializer.DeserializeAll<RoomMap>(filename);
            return room;
        }
    }

    
}
