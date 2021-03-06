using ImageToArray;
using Plugin.Media;
using Plugin.Media.Abstractions;
using RealWorldApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealWorldApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAccountPage : ContentPage
    {
        private MediaFile file;
        public MyAccountPage()
        {
            InitializeComponent();
        }

        private void TapUploadImage_Tapped(object sender, EventArgs e)
        {
            PicImageFromGallery();
        }

        private async void PicImageFromGallery()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Oops..!", ":( Your Device does not support this feature.", "OK");
                return;
            }

             file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            ImgProfile.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                AddImageToServer();
                return stream;
            });
        }

        private async void AddImageToServer()
        {
            var imageArray=FromFile.ToArray(file.GetStream());
            file.Dispose();
            var res=await ApiService.EditUserProfile(imageArray);
            if (res) return;
            await DisplayAlert("Ooops","Something went wrong \n please upload image again", "Ok");
        }

        private void TapChangePassword_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePasswordPage());
        }

        private void TapChangePhone_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePhonePage());
        }

        private void TapLogout_Tapped(object sender, EventArgs e)
        {
            Preferences.Set("accessToken", String.Empty);
            Preferences.Set("tokenExpirationTime", 0);
            Application.Current.MainPage = new NavigationPage(new SignupPage());
        }

        //everytime you come into an account page this method will be invoked
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var profileImage = await ApiService.GetUserProfileImage();
            if (string.IsNullOrEmpty(profileImage.imageUrl))
            {
                ImgProfile.Source = "userPlaceholder.png";
            }
            else
            {
                ImgProfile.Source = profileImage.FullImagePath;
            }
        }
    }
}