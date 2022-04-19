using Microsoft.EntityFrameworkCore;
using PostsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsMicroservice
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Post { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=db;userid=mydbuser;pwd=mydbpd;port=3306;database=mydbname");
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().ToTable("Post");
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
