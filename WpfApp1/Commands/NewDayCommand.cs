

namespace WpfApp1.Commands
{
    using System;
    using System.Windows.Input;

    class NewDayCommand : ICommand
    {
        Action _execute;

        public event EventHandler CanExecuteChanged;

        public NewDayCommand(Action execMeth)
        {
            _execute = execMeth;
        }
        

        public void Execute(object parametr)
        {
            if (_execute != null)
                _execute();
        }
        public bool CanExecute(object parametr)
        {
            return true;
        }
    }
}
