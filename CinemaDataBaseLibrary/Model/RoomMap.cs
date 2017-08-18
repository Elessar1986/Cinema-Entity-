using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDataBaseLibrary.Model
{
    [Serializable]
    public class RoomMap
    {
        //public int RoomId { get; set; }
        int rows;
        public int Rows
        {
            get { return rows; }
            set
            {
                rows = value;
                ChangeSize();
            }
        }
        int columns;
        public int Columns
        {
            get { return columns; }
            set
            {
                columns = value;
                ChangeSize();
            }
        }

        public int[][] Places { get; set; }

        public RoomMap()
        {
            Rows = 10;
            Columns = 10;

            ChangeSize();
        }

        public void ChangeSize()
        {
            Places = new int[Rows][];
            for (int i = 0; i < Rows; i++)
            {
                Places[i] = new int[Columns];
                for (int j = 0; j < Columns; j++)
                {
                    Places[i][j] = 1;
                }
            }
        }
    }
}
