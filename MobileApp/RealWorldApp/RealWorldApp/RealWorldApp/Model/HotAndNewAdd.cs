using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldApp.Model
{
    public class HotAndNewAdd
    {
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string model { get; set; }
        public string company { get; set; }
        public bool isFeatured { get; set; }
        public string imageUrl { get; set; }
        public string FullImageUrl => $"http://cvehiclesapp.azurewebsites.net/{imageUrl}";
    }
}
