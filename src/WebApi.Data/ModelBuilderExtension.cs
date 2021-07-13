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

            var choice = modelBuilder.Entity<Choice>();
            choice.HasKey(e => e.Id);
            choice.Property(e => e.Title).IsRequired();
            choice.Property(e => e.CreatedDateTime).HasColumnType("Date");

            var answer = modelBuilder.Entity<Answer>();
            answer.HasKey(e => e.Id);
            answer.Property(e => e.CreatedDateTime).HasColumnType("Date");
        }
    }
}