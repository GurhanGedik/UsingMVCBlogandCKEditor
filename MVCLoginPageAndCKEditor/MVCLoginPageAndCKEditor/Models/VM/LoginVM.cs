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
            EmailAddress(ErrorMessage = "E-posta Formatinda giris yapiniz."),
            Required(ErrorMessage = "E-posta Giriniz."),
            DisplayName("E-posta")
        ]
        public string Email { get; set; }
        [
            Required(ErrorMessage = "Parola Giriniz."),
            DisplayName("Parola")
        ]
        public string Password { get; set; }
        [
            DisplayName("Beni hatırla")
        ]
        public bool IsPersistant { get; set; }
    }
}