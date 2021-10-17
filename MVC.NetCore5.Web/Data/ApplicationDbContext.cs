using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using MVC.NetCore5.Web.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC.NetCore5.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) :
            base(options)
        {
        }

        public DbSet<Category> Category { get; set; }

        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Book>(book =>
                {
                    book.HasKey(b => b.Id);
                    book.Property(b => b.Name).IsRequired();
                    book.Property(b => b.ISBN).IsRequired();

                    // A book belongs to a category which can contain many books.
                    book.HasOne(b => b.Category).WithMany(c => c.Books);
                });

            modelBuilder
                .Entity<Category>(category =>
                {
                    category.HasKey(c => c.Id);
                    category.Property(c => c.Name).IsRequired();
                    category.Property(c => c.DisplayOrder).IsRequired();

                    // A category has many books which have one category.
                    category.HasMany(c => c.Books).WithOne(b => b.Category);
                });
        }
    }
}
