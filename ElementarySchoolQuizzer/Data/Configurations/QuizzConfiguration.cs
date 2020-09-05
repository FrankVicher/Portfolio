using ElementarySchoolQuizzer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElementarySchoolQuizzer.Data.Configurations
{
    public class QuizzConfiguration : IEntityTypeConfiguration<Quizz>
    {
        public void Configure(EntityTypeBuilder<Quizz> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Created)
                .IsRequired();
            builder.Property(p => p.End)
                .IsRequired();
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.IsActive)
                .IsRequired();
            builder.Property(p => p.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(p => p.Owner)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(p => p.Published)
                .IsRequired();
            builder.Property(p => p.Start)
                .IsRequired();
            builder.Property(p => p.Updated)
                .IsRequired();

        }
    }
}
