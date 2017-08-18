using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RoomEditor
{
    class RelayCommand : ICommand
    {
        readonly Action<object> _ex;
        readonly Predicate<object> _canEx;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public RelayCommand(Action<object> e, Predicate<object> ce = null)
        {
            _ex = e;
            _canEx = ce;
        }

        public bool CanExecute(object parameter)
        {
            return _canEx == null ? true : _canEx(parameter);
        }

        public void Execute(object parameter)
        {
            _ex(parameter);
        }
    }
}
