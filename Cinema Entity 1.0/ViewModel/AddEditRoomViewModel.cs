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
    class AddEditRoomViewModel : ViewModelBase
    {
        CinemaRoom room;
        public CinemaRoom Room
        {
            get { return room; }
            set { room = value;
                Notify();
            }
        }

        public AddEditRoomViewModel()
        {
            Room = Transfer.Instance.TransRoom;
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
