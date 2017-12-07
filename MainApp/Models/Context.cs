using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Models
{

    public class Context: DbContext
    {
        public Context(): base("mydbconnection") //"mydbconnection"
        {

        }

        /*   static Context()
        {
            Database.SetInitializer<Context>(new ContextInitializer());
        } */  
        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Year> Years { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Picture> Pictures { get; set; }

      /*    protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            // modelBuilder.Configurations.Add(new UserAttachmentConfiguration());
            modelBuilder.Entity<Category>().HasKey(t => t.Id);
            modelBuilder.Entity<Category>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            base.OnModelCreating(modelBuilder);
             
             //disable autoincrement
        }*/

       /*  class UserAttachmentConfiguration : EntityTypeConfiguration<Category>
        {
            public UserAttachmentConfiguration()
                : base()
            {
                HasKey(p => p.Id);
                Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
                ToTable("Categories");

            }
        }*/ 
    }
}
