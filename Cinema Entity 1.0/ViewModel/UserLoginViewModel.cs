using Cinema_Entity_1._0.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Cinema_Entity_1._0.Model;

namespace Cinema_Entity_1._0.ViewModel
{
    class UserLoginViewModel : ViewModelBase
    {
        const string pas = "nimana";

        ObservableCollection<string> type;
        public ObservableCollection<string> Type
        {
            get { return type; }
            set
            {
                type = value;
                Notify();
            }
        }

        string selectedType;
        public string SelectedType
        {
            get { return selectedType; }
            set
            {
                selectedType = value;
                Notify();
            }
        }

        string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                Notify();
            }
        }

        private ObservableCollection<string> GetTypes()
        {
            var t = new ObservableCollection<string>();
            t.Add("пользователь");
            t.Add("администратор");
            return t;
        }


        public UserLoginViewModel()
        {
            Type = GetTypes();
            SelectedType = Type[0];
        }

        RelayCommand _enter;
        public ICommand Enter
        {
            get
            {
                if (_enter == null)
                    _enter = new RelayCommand(enter);
                return _enter;
            }
        }

        private void enter(object obj)
        {
            if(SelectedType == "администратор")
            {
                if (pas == Password)
                {
                    Transfer.Instance.AdmPas = true;
                    (obj as Window).Close();
                }
                else
                {
                    MessageBox.Show("Не правильно введен пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
                }

            }
            else
            {
                (obj as Window).Close();
            }

        }
    }
}
