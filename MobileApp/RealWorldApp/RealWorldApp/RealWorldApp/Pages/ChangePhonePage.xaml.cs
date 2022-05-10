using RealWorldApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealWorldApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePhonePage : ContentPage
    {
        public ChangePhonePage()
        {
            InitializeComponent();
        }

        private async void BtnAddPhone_Clicked(object sender, EventArgs e)
        {
           var res=await ApiService.EditPhoneNumber(EntPhone.Text);
            if (!res)
            {
                await DisplayAlert("Oops..!", "Something went wrong", "Ok");
            }
            else
            {
                await DisplayAlert("Success..!", "Phone number added successfully.", "Ok");
                await Navigation.PopAsync();
            }
        }
    }
}