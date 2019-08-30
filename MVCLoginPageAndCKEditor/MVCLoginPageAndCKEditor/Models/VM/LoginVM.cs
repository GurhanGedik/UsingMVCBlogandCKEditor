using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCLoginPageAndCKEditor.Models.VM
{
    public class LoginVM
    {
        [
            EmailAddress(ErrorMessage = "Login in the e-mail form."),
            Required(ErrorMessage = "Please enter your e-mail."),
            DisplayName("E-mail")
        ]
        public string Email { get; set; }
        [
            Required(ErrorMessage = "Enter Password."),
            DisplayName("Password")
        ]
        public string Password { get; set; }
        [
            DisplayName("Remember me")
        ]
        public bool IsPersistant { get; set; }
    }
}