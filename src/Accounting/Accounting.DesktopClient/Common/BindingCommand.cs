namespace Accounting.DesktopClient.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    internal class BindingCommand : ICommand
    {
        private readonly Action<object> action;

        public BindingCommand(Action<object> action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => this.action(parameter);
    }
}
