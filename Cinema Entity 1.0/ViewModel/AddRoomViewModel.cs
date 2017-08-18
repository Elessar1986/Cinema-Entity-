using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDataBaseLibrary.Engine;
using Cinema_Entity_1._0.Commands;
using System.Windows.Input;
using System.Windows;
using CinemaDataBaseLibrary.Model;
using Cinema_Entity_1._0.Model;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace Cinema_Entity_1._0.ViewModel
{
    class AddRoomViewModel : ViewModelBase
    {
        public CinemaRoom AddedRoom { get; set; }

        DbEngine DB;

        ObservableCollection<Genre> _g;
        public ObservableCollection<Genre> G
        {
            get { return _g; }
            set
            {
                _g = value;
                Notify();
            }
        }
        Genre selectedGenre;
        public Genre SelectedGenre
        {
            get { return selectedGenre; }
            set { selectedGenre = value; Notify(); }
        }

        public AddRoomViewModel()
        {
            AddedRoom = Transfer.Instance.TransRoom;
            DB = Transfer.Instance.db;
            DB.LoadData();
            G = DB.Data.Genres.Local;
        }

        RelayCommand _ok;
        public ICommand OK
        {
            get
            {
                if (_ok == null)
                    _ok = new RelayCommand(ok);
                return _ok;
            }
        }

        private void ok(object obj)
        {
            Transfer.Instance.mainView.R.Add(AddedRoom);
            (obj as Window).DialogResult = true;
        }

        RelayCommand _exit;
        public ICommand MyExit
        {
            get
            {
                if (_exit == null)
                    _exit = new RelayCommand(x => (x as Window).Close());
                return _exit;
            }
        }

        RelayCommand _delGenre;
        public ICommand DelGenre
        {
            get
            {
                if (_delGenre == null)
                    _delGenre = new RelayCommand(delGenre);
                return _delGenre;
            }
        }

        private void delGenre(object obj)
        {
            //MessageBox.Show(obj.ToString());
            DB.DelGenre((obj as Genre));

        }
    }
}
