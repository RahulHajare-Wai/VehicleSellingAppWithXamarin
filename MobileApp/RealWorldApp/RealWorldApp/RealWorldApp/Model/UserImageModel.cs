using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldApp.Model
{
    public class UserImageModel
    {
        public string imageUrl { get; set; }
        public string FullImagePath => $"http://cvehiclesapp.azurewebsites.net/{imageUrl}";
    }
}
