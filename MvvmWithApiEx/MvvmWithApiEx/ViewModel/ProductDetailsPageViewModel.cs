using MvvmWithApiEx.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MvvmWithApiEx.ViewModel
{
    public class ProductDetailsPageViewModel : BaseViewModel
    {
        public ProductDetailsPageViewModel()
        {

 

            MessagingCenter.Subscribe<MainPageViewModel, Employee>(this, "EmployeeItem", (sender, arg) =>
            {

                _EmpName = arg.employee_name;
                _EmpSalary = arg.employee_salary;
                _EmpAge = arg.employee_age; 

                raisePropertyChanged("EmpName");
                raisePropertyChanged("EmpSalary");
                raisePropertyChanged("EmpAge");
            });

            MessagingCenter.Subscribe<MainPageViewModel, string>(this, "UserName", (sender, arg) =>
              {
                  _PageTitle = arg.ToString();
                  raisePropertyChanged("PageTitle");

              });

        }


        private string _PageTitle;
        public string PageTitle
        {
            set
            {
                _PageTitle = value;
            }
            get
            {
                return _PageTitle;
            }
        }


        private string _EmpName;
        public string EmpName
        {
            set
            {
                _EmpName = value;
            }
            get
            {
                return _EmpName;
            }
        }

        private string _EmpSalary;
        public string EmpSalary
        {
            set
            {
                _EmpSalary = value;
            }
            get
            {
                return _EmpSalary;
            }
        }

        private string _EmpAge;
        public string EmpAge
        {
            set
            {
                _EmpAge = value;
            }
            get
            {
                return _EmpAge;
            }
        }
    }
}
