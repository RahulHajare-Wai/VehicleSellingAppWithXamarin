﻿using RealWorldApp.Services;
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
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            var userName = EntName.Text;
            var response=await ApiService.RegisterUser(userName, EntEmail.Text, EntPassword.Text);
            if (response)
            {
                  await DisplayAlert($"Hii {userName} !", "Registration Successfull", "Ok");
                  await Navigation.PushModalAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert($"Oops {userName} !", "Something Went wrong", "Cancel");
            }
        }

        
    }
}