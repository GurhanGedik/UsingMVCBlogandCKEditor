﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLoginPageAndCKEditor.Models.Entities
{
    public class ApplicationUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }  
    }
}