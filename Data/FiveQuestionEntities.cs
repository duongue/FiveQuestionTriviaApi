using Data.Configuration;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class FiveQuestionEntities : DbContext
    {
        public FiveQuestionEntities() : base()
        {
        }

        public FiveQuestionEntities(DbContextOptions<FiveQuestionEntities> options) : base(options)
        { }

        public DbSet<Domain.Category> Categories { get; set; }
        public DbSet<Domain.Level> Levels { get; set; }
        public DbSet<Domain.Question> Questions { get; set; }
        public DbSet<Domain.Encouragement> Encouragements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new CategoryConfiguration());
            modelBuilder.AddConfiguration(new LevelConfiguration());
            modelBuilder.AddConfiguration(new QuestionConfiguration());
            modelBuilder.AddConfiguration(new EncouragementConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
