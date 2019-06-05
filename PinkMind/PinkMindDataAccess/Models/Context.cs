using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinkMindDataAccess.Models
{
    class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<IssueType> IssueTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=OS-20160215ADTW\SQLEXPRESS01;Database=PinkMind;Trusted_Connection=True;");
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Issue>(entity =>
        //    {
        //        entity.Property(e => e.Url).IsRequired();
        //    });

        //    modelBuilder.Entity<Post>(entity =>
        //    {
        //        entity.HasOne(d => d.Blog)
        //            .WithMany(p => p.Post)
        //            .HasForeignKey(d => d.BlogId);
        //    });
        //}

    }
}
