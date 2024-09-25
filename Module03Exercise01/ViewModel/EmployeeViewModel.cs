using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module03Exercise01.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;


namespace Module03Exercise01.ViewModel
{
    internal class EmployeeViewModel : INotifyPropertyChanged
    {
        private Employee _employee;
        private string _fullName; //variable for data conversion


        public EmployeeViewModel()
        {
            //Initialize a sample student model. Coordination with Model
            _employee = new Employee { FirstName = "Shen", LastName = "Quanrui", Position = "Manager", Department = "IT", IsActive = true };

            //UI Thread Management
            LoadEmployeeManagerCommand = new Command(async () => await LoadEmployeeDataAsync());

            //Collectiions
            Employees = new ObservableCollection<Employee>
            {
                new Employee {FirstName="Hao", LastName="Zhang", Position="Accountant", Department ="Finance", IsActive=true},
                new Employee {FirstName="Hanbin", LastName="Sung", Position="Coordinator", Department ="HR", IsActive=true},
                new Employee {FirstName="Yujin", LastName="Han", Position="Full Stack Developer", Department ="IT", IsActive=false},
                new Employee {FirstName="Gyuvin", LastName="Kim", Position="SEO Specialist", Department ="Marketing", IsActive=true},
                new Employee {FirstName="Gunwook", LastName="Park", Position="Back-End Developer", Department ="IT", IsActive=false},
                new Employee {FirstName="Matthew", LastName="Seok", Position="Marketing Analyst", Department ="Marketing", IsActive=true},
            };
        }

        //Setting collections in public
        public ObservableCollection<Employee> Employees { get; set; }

        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;

                    OnPropertyChanged(nameof(FullName));

                }
            }
        }

        //UI Thread Management
        public ICommand LoadEmployeeManagerCommand { get; }

        //Two-way Data Biding and Data conversion
        private async Task LoadEmployeeDataAsync()
        {
            await Task.Delay(1000); // I/O operation
            FullName = $"{_employee.FirstName} {_employee.LastName} {_employee.Position}" + $" in " + $"{_employee.Department}" + $" Department"; // Data Conversion

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
