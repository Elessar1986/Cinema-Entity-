using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CinemaDataBaseLibrary.Engine;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Cinema_Entity_1._0.Commands;
using System.Windows.Input;
using CinemaDataBaseLibrary.Model;
using System.Collections.ObjectModel;
using Cinema_Entity_1._0.View;
using Cinema_Entity_1._0.Model;
using System.Data.Entity;
using MahApps.Metro.Controls.Dialogs;


namespace Cinema_Entity_1._0.ViewModel
{
    class MainWindowViewModel : ViewModelBase //INotifyPropertyChanged
    {
        public bool Admin { get; set; }

        private IDialogCoordinator dialogCoordinator;

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

        ObservableCollection<CinemaRoom> _r;
        public ObservableCollection<CinemaRoom> R
        {
            get { return _r; }
            set
            {
                _r = value;
                Notify();
            }
        }

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
                //MessageBox.Show(_selectedFilm.FilmName);
                Notify();
            }
        }

        DbEngine db;
        public DbEngine DB
        {
            get {
                return db; }
            set
            {
                db = value;
                Notify();
            }
        }


        public MainWindowViewModel(IDialogCoordinator instance)
        {
            Admin = false;
            Transfer.Instance.mainView = this;
            DB = new DbEngine();
            DB.myExeption += DB_myExeption;
            DB.ShowMessage += DB_ShowMessage;
            DB.Data.Films.Load();
            Films = DB.Data.Films.Local;
            UserLogin ul = new UserLogin();
            ul.ShowDialog();
            Admin = Transfer.Instance.AdmPas;
            dialogCoordinator = instance;
        }

        RelayCommand _makeOrder;
        public ICommand MakeOrder
        {
            get
            {
                if (_makeOrder == null)
                    _makeOrder = new RelayCommand(makeOrderAsync);
                return _makeOrder;
            }
        }

        private async void makeOrderAsync(object obj)
        {
            if(obj != null)
            await dialogCoordinator.ShowMessageAsync(this,"Header", (obj as Film).FilmName, MessageDialogStyle.Affirmative);
            //MessageBox.Show((obj as Film).FilmName);
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
            //MessageBox.Show(obj.ToString());
            DB.AddGenre(obj.ToString());

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

        RelayCommand _settings;
        public ICommand Settings
        {
            get
            {
                if (_settings == null)
                    _settings = new RelayCommand(settings);
                return _settings;
            }
        }

        private void settings(object obj)
        {
            
            Transfer.Instance.db = DB;
            SettingsWindow arw = new SettingsWindow();
            if(arw.ShowDialog() == true)
            {
                
                //MessageBox.Show("Ok");
            }
            else
            {
                //MessageBox.Show("CANCEL");
            }
            
        }



        private void DB_ShowMessage(string message)
        {
            MessageBox.Show( message, "MESSAGE", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DB_myExeption(string message)
        {
            MessageBox.Show( message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        

    }
}
