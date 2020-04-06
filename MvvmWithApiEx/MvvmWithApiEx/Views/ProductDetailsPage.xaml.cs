using MvvmWithApiEx.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmWithApiEx.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmWithApiEx.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsPage : ContentPage
    {
        public ProductDetailsPage()
        {
            InitializeComponent();

            BindingContext = new ProductDetailsPageViewModel();
        }
    }
}