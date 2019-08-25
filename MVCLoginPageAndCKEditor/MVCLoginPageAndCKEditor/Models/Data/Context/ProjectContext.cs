using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCLoginPageAndCKEditor.Models.Entities;

namespace MVCLoginPageAndCKEditor.Models.Data.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=.\\SQLEXPRESS;Database=MyBlogDB;Integrated Security = True;";
        }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<Blogs> Blog { get; set; }
    }
}