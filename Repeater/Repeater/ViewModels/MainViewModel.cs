using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Repeater.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<string> _employees;
        private List<string> _students;

        public List<string> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        public List<string> Students
        {
            get => _students;
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectStudentCommand => new Command(student =>
        {

        });
        
        public MainViewModel()
        {
            Employees = new List<string>
            {
                "Adam", "Hassen", "Gabriel", "Joseph", "Marie"
            };

            Students = new List<string>
            {
                "Omar", "Seif", "Mahdi", "Safa", "Kamel"
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
