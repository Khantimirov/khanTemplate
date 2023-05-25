using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_4335.Class
{
    public class ApplicationContext : DbContext
    {
        public DbSet<SkiService> SkiServices { get; set; }

        public ApplicationContext() : base("SkiRentPoint") { }
    }
}