using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MODEL;

namespace EFCORE.Infrastructure.Configs
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(s => s.Name)
             .IsRequired()
             .HasMaxLength(50);

            builder.Property(s => s.Age)
           .IsRequired(true);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(e => e.Evaluations)
     .WithOne(s => s.Student)
     .HasForeignKey(s => s.StudentId)
     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
