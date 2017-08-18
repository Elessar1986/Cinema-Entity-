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
    class AddEditSessionViewModel : ViewModelBase
    {
        Session _selectedSession;
        public Session SelectedSession
        {
            get { return _selectedSession; }
            set { _selectedSession = value; Notify(); }
        }

        public AddEditSessionViewModel()
        {
            SelectedSession = Transfer.Instance.TransSession;
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

        private void save(object obj)
        {
            (obj as Window).DialogResult = true;
        }
    }
}
