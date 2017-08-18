using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CinemaDataBaseLibrary;
using CinemaDataBaseLibrary.Model;
using CinemaDataBaseLibrary;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RoomEditor
{
    class ViewModel : INotifyPropertyChanged
    {
        Grid el;
        public Grid EL
        {
            get
            {
                return el;
            }
            set
            {
                el = value;
                OnPropChange();
            }
        }

        RoomMap room;
        public RoomMap Room
        {
            get
            {
                if (room == null)
                    room = new RoomMap();
                return room;
            }
            set
            {
                room = value;
                OnPropChange();
            }
        }

        RelayCommand place;
        public ICommand Place
        {
            get
            {
                if (place == null)
                    place = new RelayCommand(x =>
                    {
                        //Button b = x as Button;
                        PL(x);
                    });
                return place;
            }
        }

        private void PL(object o)
        {
            Button b = o as Button;
            int r = Grid.GetRow(b);
            int c = Grid.GetColumn(b);
            if (Room.Places[r][c] == 1)
            {
                Room.Places[r][c] = 0;
                b.Background = Brushes.Gray;
            }
            else
            {
                Room.Places[r][c] = 1;
                b.Background = Brushes.Orange;
            }
        }

        RelayCommand save_file;
        public ICommand Save_File
        {
            get
            {
                if (save_file == null)
                    save_file = new RelayCommand(SF);
                return save_file;
            }
        }

        private void SF(object o)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "XML File|*.xml"
            };
            if (sfd.ShowDialog() == true)
                Serializer.SerializeAll(Room, sfd.FileName);
        }

        RelayCommand do_grid;
        public ICommand Do_Grid
        {
            get
            {
                if (do_grid == null)
                    do_grid = new RelayCommand(DG);
                return do_grid;
            }
        }

        private void DG(object o)
        {
            EL = new Grid();
            for (int i = 0; i < Room.Rows; i++)
            {
                var rd = new RowDefinition();
                EL.RowDefinitions.Add(rd);
            }
            for (int i = 0; i < Room.Columns; i++)
            {
                var cd = new ColumnDefinition();
                EL.ColumnDefinitions.Add(cd);
            }
            for (int i = 0; i < Room.Rows; i++)
            {
                for (int j = 0; j < Room.Columns; j++)
                {
                    Button b = new Button()
                    {
                        Name = "button_" + i.ToString() + "_" + j.ToString(),
                        Background = Brushes.Orange,
                        Margin = new Thickness(2),
                        Content = $"{(j + 1).ToString()}"

                    };
                    b.Command = Place;
                    b.CommandParameter = b;
                    Grid.SetRow(b, i);
                    Grid.SetColumn(b, j);
                    EL.Children.Add(b);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropChange( [CallerMemberName]string name = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
