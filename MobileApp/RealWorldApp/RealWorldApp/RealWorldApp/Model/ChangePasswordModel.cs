using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldApp.Model
{
    public class ChangePasswordModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
