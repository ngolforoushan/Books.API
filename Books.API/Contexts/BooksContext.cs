﻿using Books.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Books.API.Contexts
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Navid",
                    LastName = "Golforoushan"
                },
                new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Nima",
                    LastName = "Golforoushan"
                },
                new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Ali",
                    LastName = "Jason"
                },
                new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = "James",
                    LastName = "Elroy"
                }, new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Douglas",
                    LastName = "Adams"
                },
                new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Stephan",
                    LastName = "Fry"
                },
                new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = "George",
                    LastName = "RR Martin"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
