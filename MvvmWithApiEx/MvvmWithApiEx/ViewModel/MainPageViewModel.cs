using MvvmWithApiEx.Model;
using MvvmWithApiEx.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmWithApiEx.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            getEmployeesList();

            _LoginOperation = new Command(navigateNextPage);
        }


        private Employee _SelectEmployee;
        public Employee SelectEmployee
        {
            set
            {
                _SelectEmployee = value;

                Application.Current.MainPage.Navigation.PushAsync(new ProductDetailsPage());

                MessagingCenter.Send(this, "EmployeeItem", _SelectEmployee);

                MessagingCenter.Send(this, "UserName", "visa");


            }
            get
            {
                return _SelectEmployee;
            }
        }


        private string _userName;
        public string userName
        {
            set
            {
                _userName = value;
            }
            get
            {
                return _userName;
            }
        }

        private string _Password;
        public string Password
        {
            set
            {
                _Password = value;
            }
            get
            {
                return _Password;
            }
        }

        private void navigateNextPage()
        {
            
            if (_userName != null && _userName.Length > 0 && _Password != null && _Password.Length > 0)
            {
                Application.Current.MainPage.Navigation.PushAsync(new ProductDetailsPage());
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("LoginValidation", "Please enter all required fileds", "Ok");
            }
        }


        private ICommand _LoginOperation;
        public ICommand LoginOperation
        {
            set
            {
                _LoginOperation = value;
            }
            get
            {
                return _LoginOperation;
            }
        }

        private List<Employee> _EmployeesList;
        public List<Employee> EmployeesList
        {
            set
            {
                _EmployeesList = value;
            }
            get
            {
                return _EmployeesList;
            }
        }

        private async void getEmployeesList()
        {
            HttpClient objHttpClient = new HttpClient();
            var empList = await objHttpClient.GetStringAsync("http://dummy.restapiexample.com/api/v1/employees");
            var EmployeesList = JsonConvert.DeserializeObject<List<Employee>>(empList.ToString());
            _EmployeesList = EmployeesList;

           raisePropertyChanged("EmployeesList");

        }

    }
}