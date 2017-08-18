using Cinema_Entity_1._0.Commands;
using Cinema_Entity_1._0.Model;
using CinemaDataBaseLibrary.Engine;
using CinemaDataBaseLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cinema_Entity_1._0.View;
using System.Windows;

namespace Cinema_Entity_1._0.ViewModel
{
    class SettingsViewModel : ViewModelBase
    {

        DbEngine DB;

        ObservableCollection<Film> _films;
        public ObservableCollection<Film> Films
        {
            get { return _films; }
            set
            {
                _films = value;
                Notify();
            }
        }
        Film _selectedFilm;
        public Film SelectedFilm
        {
            get { return _selectedFilm; }
            set {
                _selectedFilm = value;
                Notify();
                UpdateSession();
            }
        }

        private void UpdateSession()
        {
            Sessions = DB.GetSessions(SelectedFilm);
        }

        ObservableCollection<Session> _session;
        public ObservableCollection<Session> Sessions
        {
            get { return _session; }
            set
            {
                _session = value;
                Notify();
            }
        }
        Session _selectedSession;
        public Session SelectedSession
        {
            get { return _selectedSession; }
            set { _selectedSession = value; Notify(); }
        }

        ObservableCollection<Genre> _genre;
        public ObservableCollection<Genre> Genre
        {
            get { return _genre; }
            set
            {
                _genre = value;
                Notify();
            }
        }
        Genre selectedGenre;
        public Genre SelectedGenre
        {
            get { return selectedGenre; }
            set { selectedGenre = value; Notify(); }
        }

        ObservableCollection<Director> _director;
        public ObservableCollection<Director> Director
        {
            get { return _director; }
            set
            {
                _director = value;
                Notify();
            }
        }
        Director _selectedDirector;
        public Director SelectedDirector
        {
            get { return _selectedDirector; }
            set { _selectedDirector = value; Notify(); }
        }

        ObservableCollection<CinemaRoom> _rooms;
        public ObservableCollection<CinemaRoom> Rooms
        {
            get { return _rooms; }
            set
            {
                _rooms = value;
                Notify();
            }
        }
        CinemaRoom _selectedRoom;
        public CinemaRoom SelectedRoom
        {
            get { return _selectedRoom; }
            set { _selectedRoom = value; Notify(); }
        }


        public SettingsViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            DB = Transfer.Instance.db;
            DB.LoadData();
            Films = DB.GetFilms();
            if (Films[0] != null) SelectedFilm = Films[0];
            Genre = DB.Data.Genres.Local;
            SelectedGenre = Genre[0];
            Director = DB.Data.Directors.Local;
            SelectedDirector = Director[0];
            Sessions = DB.GetSessions(SelectedFilm);
            Rooms = DB.GetRooms();
        }

        RelayCommand _addFilm;
        public ICommand AddFilm
        {
            get
            {
                if (_addFilm == null)
                    _addFilm = new RelayCommand(addFilmAsync);
                return _addFilm;
            }
        }

        RelayCommand _delFilm;
        public ICommand DelFilm
        {
            get
            {
                if (_delFilm == null)
                    _delFilm = new RelayCommand(delFilm);
                return _delFilm;
            }
        }

        RelayCommand _addSession;
        public ICommand AddSession
        {
            get
            {
                if (_addSession == null)
                    _addSession = new RelayCommand(addSession);
                return _addSession;
            }
        }

        RelayCommand _addRoom;
        public ICommand AddRoom
        {
            get
            {
                if (_addRoom == null)
                    _addRoom = new RelayCommand(addRoom);
                return _addRoom;
            }
        }

        private void addRoom(object obj)
        {
            Transfer.Instance.TransRoom = new CinemaRoom();
            AddEditRoomWindow arw = new AddEditRoomWindow();
            if(arw.ShowDialog() == true)
            {

            }
        }

        private void addSession(object obj)
        {
            Transfer.Instance.TransSession = new Session();
            AddEditSessionWindow asw = new AddEditSessionWindow();
            asw.ShowDialog();
            if(asw.DialogResult == true)
            {
                Session t = Transfer.Instance.TransSession;
                t.SessionFilm = SelectedFilm;
                
                DB.AddSession(t);
                DB.Update();
                UpdateSession();
            }
        }

        private async void delFilm(object obj)
        {
            DB.DelFilm(SelectedFilm);
            await DB.Update();
        }

        RelayCommand _editFilm;
        public ICommand EditFilm
        {
            get
            {
                if (_editFilm == null)
                    _editFilm = new RelayCommand(editFilmAsync);
                return _editFilm;
            }
        }

        private async void editFilmAsync(object obj)
        {
            Transfer.Instance.TransFilms = SelectedFilm;
            AddEditFilmWindow afw = new AddEditFilmWindow();
            afw.ShowDialog();
            if (afw.DialogResult == true)
            {
                MessageBox.Show("Film saved");
                await DB.Update();
                Films = DB.GetFilms();
            }
        }

        private async void addFilmAsync(object obj)
        {
            Transfer.Instance.TransFilms = new Film() { FilmName = "new film" };
            AddEditFilmWindow aefw = new AddEditFilmWindow();
            aefw.ShowDialog();
            if (aefw.DialogResult == true)
            {
                DB.AddFilm(Transfer.Instance.TransFilms);
                await DB.Update();
            }
            //MessageBox.Show(Transfer.Instance.TransFilms.FilmName + Transfer.Instance.TransFilms.Rating.ToString());

        }

        RelayCommand _addGenre;
        public ICommand AddGenre
        {
            get
            {
                if (_addGenre == null)
                    _addGenre = new RelayCommand(addGenre);
                return _addGenre;
            }
        }

        private void addGenre(object obj)
        {
            
            DB.AddGenre(obj.ToString());

        }

        RelayCommand _delGenre;
        public ICommand DelGenre
        {
            get
            {
                if (_delGenre == null)
                    _delGenre = new RelayCommand(x => DB.DelGenre((x as Genre)));
                return _delGenre;
            }
        }

        RelayCommand _addDirector;
        public ICommand AddDirector
        {
            get
            {
                if (_addDirector == null)
                    _addDirector = new RelayCommand(x => DB.AddDirector(x as string));
                return _addDirector;
            }
        }

        RelayCommand _delDirector;
        public ICommand DelDirector
        {
            get
            {
                if (_delDirector == null)
                    _delDirector = new RelayCommand(delDirector);
                return _delDirector;
            }
        }

        private void delDirector(object obj)
        {

            DB.DelDirector((obj as Director));

        }
    }
}
