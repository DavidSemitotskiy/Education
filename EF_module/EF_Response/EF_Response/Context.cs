using EF_Response.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Response
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CommentForActor> CommentsForActors { get; set;}

        public DbSet<CommentForMovie> CommentsForMovie { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MovieResponse;Trusted_Connection=True;");
        }
    }
}
