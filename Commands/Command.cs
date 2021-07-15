using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Commands
{
    abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        
        public virtual void OnCanExecuteChanged(EventArgs e)
        {
            CanExecuteChanged?.Invoke(this, e);
        }

        public void RiseCanExecuteChange()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }
        public virtual bool CanExecute()
        {

            return true;
        }

        bool ICommand.CanExecute(object parameter)
        {

            return CanExecute();
        }
        public abstract void Execute();
        void ICommand.Execute(object parameter)
        {
            Execute();
        }
    }


    class DelegateCommand : Command
    {
        static Func<bool> defaultCanExecuteMethod = () => true;
        Func<bool> canExecuteMethod;

        Action executeMethod;
        public DelegateCommand(Action executeMethod) : this(executeMethod,defaultCanExecuteMethod)
        {

        }
        public DelegateCommand(Action executeMethod,Func<bool> canExecuteMethod) 
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }
        public override void Execute()
        {
            executeMethod();
        }
        public override bool CanExecute()
        {
            return canExecuteMethod();
        }
    }
}
