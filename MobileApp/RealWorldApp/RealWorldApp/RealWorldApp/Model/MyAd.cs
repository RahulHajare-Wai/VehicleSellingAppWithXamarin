using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldApp.Model
{
    public class MyAd
    {
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string model { get; set; }
        public string location { get; set; }
        public string company { get; set; }
        public DateTime datePosted { get; set; }
        public bool isFeatured { get; set; }
        public object imageUrl { get; set; }
        public string isFeaturedAd => isFeatured ? "Featured" : "Free";
        public string AdPostedDate => datePosted.ToString("y");
        public string FullImageUrl => $"http://cvehiclesapp.azurewebsites.net/{imageUrl}";
    }
}
