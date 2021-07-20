using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Data.Models;

namespace WebApi.Data
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // For seeding data
        }

        public static void Configure(this ModelBuilder modelBuilder)
        {
            var question = modelBuilder.Entity<Question>();
            question.HasKey(e => e.Id);
            question.Property(e => e.Title).IsRequired();
            question.HasMany(e => e.Choices).WithOne();
            question.Property(e => e.CreatedDateTime).HasColumnType("Date");
            question.Property(e => e.UpdatedDateTime).HasColumnType("Date");

            var choice = modelBuilder.Entity<Choice>();
            choice.HasKey(e => e.Id);
            choice.Property(e => e.Title).IsRequired();
            choice.Property(e => e.CreatedDateTime).HasColumnType("Date");
            choice.Property(e => e.UpdatedDateTime).HasColumnType("Date");

            var answer = modelBuilder.Entity<Answer>();
            answer.HasKey(e => e.Id);
            answer.HasOne(e => e.Participant).WithMany(e => e.Answers);
            answer.Property(e => e.CreatedDateTime).HasColumnType("Date");
            answer.Property(e => e.UpdatedDateTime).HasColumnType("Date");

            var participant = modelBuilder.Entity<Participant>();
            participant.HasKey(e => e.Id);
            participant.HasOne(e => e.LastQuestion);
            participant.Property(e => e.CreatedDateTime).HasColumnType("Date");
            participant.Property(e => e.UpdatedDateTime).HasColumnType("Date");
        }
    }
}