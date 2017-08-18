using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDataBaseLibrary.Model;
using Cinema_Entity_1._0.ViewModel;
using CinemaDataBaseLibrary.Engine;

namespace Cinema_Entity_1._0.Model
{
    class Transfer
    {
        private static volatile Transfer instance;
        private static object syncRoot = new Object();
        

        private Transfer() { }

        public MainWindowViewModel mainView { get; set; }
        public CinemaRoom TransRoom { get; set; } 
        public Film TransFilms { get; set; }
        public Genre TransGenres { get; set; }
        public Director TransDirectors { get; set; }
        public Ticket TransTickets { get; set; }
        public Session TransSession { get; set; }
        public DbEngine db { get; set; }

        public bool AdmPas { get; set; }

        public static Transfer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Transfer();
                    }
                }
                return instance;
            }
        }
    }
}
