using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Commands
{
    class DataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Command blueCommand;
        Command redCommand;
        Command greenCommand;
        Command yellowCommand;
        string selectedColor="Black";
        public DataSource()
        {
            blueCommand = new DelegateCommand(() => SelectedColor = "Blue", () => SelectedColor != "Blue");
            redCommand = new DelegateCommand(() => SelectedColor = "Red", () => SelectedColor != "Red");
            greenCommand = new DelegateCommand(() => SelectedColor = "Green", () => SelectedColor != "Green");
            yellowCommand = new DelegateCommand(() => SelectedColor = "Yellow", () => SelectedColor != "Yellow");
            PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals(nameof(SelectedColor)))
                {
                    blueCommand.RiseCanExecuteChange();
                    redCommand.RiseCanExecuteChange();
                    greenCommand.RiseCanExecuteChange();
                    yellowCommand.RiseCanExecuteChange();
                }
            };
        }
        public ICommand BlueCommand => blueCommand;
        public ICommand RedCommand => redCommand;
        public ICommand GreenCommand => greenCommand;
        public ICommand YellowCommand => yellowCommand;

        public string SelectedColor { get => selectedColor;
            set
            {
                if (!selectedColor.Equals(value))
                {
                    selectedColor = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedColor)));
                }
            }
        
        }
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
