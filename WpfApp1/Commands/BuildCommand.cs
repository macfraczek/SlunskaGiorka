namespace WpfApp1.Commands
{
    using System;
    using System.Windows.Input;

    class BuildCommand : ICommand
    {
        Action _execute;
        public BuildCommand(Action execMeth)
        {
            _execute = execMeth;
        }



        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute();
        }


    }
}
