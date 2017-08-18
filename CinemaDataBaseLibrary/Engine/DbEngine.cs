using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDataBaseLibrary.Model;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace CinemaDataBaseLibrary.Engine
{
    public class DbEngine
    {

        public delegate void ExeptionMessage(string message);
        public event ExeptionMessage myExeption;

        public delegate void WriteMessage(string message);
        public event WriteMessage ShowMessage;

        private MyDataContext data;
        public MyDataContext Data {
            get { return data; }
            set { data = value; }
        }

        public DbEngine()
        {
            Data = new MyDataContext();
            //System.Windows.Forms.MessageBox.Show("Connection set!");
        }

        //public void TestCon()
        //{
        //    if (ShowMessage != null) ShowMessage("Start DbEngine");
        //    try
        //    {
        //        //data = new MyDataContext();
        //        var e = (from g in data.Genres
        //                 select g).ToList();
        //        if (ShowMessage != null) ShowMessage(e.Count.ToString());
        //    }
        //    catch (Exception e)
        //    {
        //        if (myExeption != null)
        //            myExeption("ERROR:" + e.Message);
        //    }
        //}



        public ObservableCollection<Genre> GetGenres()
        {         
            return Data.Genres.Local;
        }



        public void LoadData()
        {
            Data.Films.Load();
            Data.Genres.Load();
            Data.Directors.Load();
            Data.Rooms.Load();
            Data.Places.Load();
            Data.Sessions.Load();
            Data.Tickets.Load();
            Data.Users.Load();

        }

        public ObservableCollection<Session> GetSessions(Film film)
        {
            var res = from s in Data.Sessions
                      where s.SessionFilm.FilmId == film.FilmId
                      select s;
            return new ObservableCollection<Session>(res.ToList());
        }

        public async Task Update()
        {
            await Data.SaveChangesAsync();
        }

        public void AddRoom(CinemaRoom room)
        {
            try
            {
                data.Rooms.Add(room);
                data.SaveChanges();
                if (ShowMessage != null) ShowMessage("Room added sucesful!");
            }
            catch (Exception e)
            {
                if (myExeption != null)
                    myExeption("ERROR:" + e.Message);
            }
        }

        public void AddFilm(Film film)
        {
            try
            {
                data.Films.Add(film);
                data.SaveChanges();
                if (ShowMessage != null) ShowMessage("Film added sucesful!");
            }
            catch (Exception e)
            {
                if (myExeption != null)
                    myExeption("ERROR:" + e.Message);
            }
        }

        public void DelFilm(Film film)
        {
            try
            {
                data.Films.Remove(film);
                data.SaveChanges();
                if (ShowMessage != null) ShowMessage("Film deleted sucesful!");
            }
            catch (Exception e)
            {
                if (myExeption != null)
                    myExeption("ERROR:" + e.Message);
            }
        }

        public void AddSession(Session session)
        {
            try
            {
                data.Sessions.Add(session);
                data.SaveChanges();
                if (ShowMessage != null) ShowMessage("Session added sucesful!");
            }
            catch (Exception e)
            {
                if (myExeption != null)
                    myExeption("ERROR:" + e.Message);
            }
        }

        public ObservableCollection<CinemaRoom> GetRooms()
        {
            return Data.Rooms.Local;
        }

        public void AddGenre(string genre)
        {
            try
            {
                data.Genres.Add(new Genre() { GenreName = genre });
                data.SaveChanges();
                if (ShowMessage != null) ShowMessage("Genre added sucesful!");
            }
            catch (Exception e)
            {
                if (myExeption != null)
                    myExeption("ERROR:" + e.Message);
            }
        }

        public void AddDirector(string director)
        {
            try
            {
                data.Directors.Add(new Director() { DirectorName = director });
                data.SaveChanges();
                if (ShowMessage != null) ShowMessage("Director added sucesful!");
            }
            catch (Exception e)
            {
                if (myExeption != null)
                    myExeption("ERROR:" + e.Message);
            }
        }

        public void DelGenre(Genre g)
        {
            try
            {
                data.Genres.Remove(g);
                data.SaveChanges();
                if (ShowMessage != null) ShowMessage("Genre deleted sucesful!");
            }
            catch (Exception e)
            {
                if (myExeption != null)
                    myExeption("ERROR:" + e.Message);
            }
        }

        public ObservableCollection<Film> GetFilms()
        {
            return Data.Films.Local;
        }

        public void DelDirector(Director d)
        {
            try
            {
                data.Directors.Remove(d);
                data.SaveChanges();
                if (ShowMessage != null) ShowMessage("Director deleted sucesful!");
            }
            catch (Exception e)
            {
                if (myExeption != null)
                    myExeption("ERROR:" + e.Message);
            }
        }


    }
}
