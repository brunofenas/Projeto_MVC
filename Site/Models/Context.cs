using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class Context : DbContext
    {
        public Context()
   : base(@"Data Source=localhost;Initial Catalog=fatec;User Id=fatec; Password=fatec;Integrated Security=True")
        {
            // Find out the connection string being used

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<Context>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Cadastro> Cadastros { get; set; }
    }
}