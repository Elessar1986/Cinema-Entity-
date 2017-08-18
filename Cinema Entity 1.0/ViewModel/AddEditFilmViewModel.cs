using Cinema_Entity_1._0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDataBaseLibrary.Model;
using Cinema_Entity_1._0.Commands;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using CinemaDataBaseLibrary.Engine;
using System.Data.Entity;
using Microsoft.Win32;

namespace Cinema_Entity_1._0.ViewModel
{
    class AddEditFilmViewModel : ViewModelBase
    {
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

        Film _selectedFilm;
        public Film SelectedFilm
        {
            get { return _selectedFilm; }
            set { _selectedFilm = value; Notify(); }
        }

        DbEngine DB;

        public AddEditFilmViewModel()
        {
            SelectedFilm = Transfer.Instance.TransFilms;
            LoadData();
        }

        private void LoadData()
        {
            DB = Transfer.Instance.db;
            DB.Data.Films.Load();
            Genre = DB.Data.Genres.Local;
            SelectedGenre = SelectedFilm.GenreId;
            DB.Data.Directors.Load();
            Director = DB.Data.Directors.Local;
            SelectedDirector = SelectedFilm.DirectorId;
        }

        RelayCommand _save;
        public ICommand Save
        {
            get
            {
                if (_save == null)
                    _save = new RelayCommand(save);
                return _save;
            }
        }

        RelayCommand _openFile;
        public ICommand OpenFile
        {
            get
            {
                if (_openFile == null)
                    _openFile = new RelayCommand(openFile);
                return _openFile;
            }
        }

        private void openFile(object obj)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"
            };
            if(ofd.ShowDialog() == true)
            {
                
                SelectedFilm.FilmPhotoFileName = ofd.FileName;
                SelectedFilm = SelectedFilm; }
        }

        private void save(object obj)
        {
            SelectedFilm.GenreId = SelectedGenre;
            SelectedFilm.DirectorId = SelectedDirector;
            (obj as Window).DialogResult = true;
        }
    }
}
