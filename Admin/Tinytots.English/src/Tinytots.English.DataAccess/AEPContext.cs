using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace Tinytots.English.DataAccess
{
    public partial class AEPContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=.;Database=AEP;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accent>(entity =>
            {
                entity.Property(e => e.American)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.British)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.Image).WithMany(p => p.Accent).HasForeignKey(d => d.ImageId);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(300);
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<LessonPageMapping>(entity =>
            {
                entity.HasOne(d => d.Lesson).WithMany(p => p.LessonPageMapping).HasForeignKey(d => d.LessonId);

                entity.HasOne(d => d.Page).WithMany(p => p.LessonPageMapping).HasForeignKey(d => d.PageId);
            });

            modelBuilder.Entity<ProseActivity>(entity =>
            {
                entity.Property(e => e.Answer).HasMaxLength(300);

                entity.Property(e => e.Datetime).HasColumnType("datetime");

                entity.Property(e => e.Identity).HasMaxLength(200);

                entity.Property(e => e.Question).HasMaxLength(300);

                entity.HasOne(d => d.Accent).WithMany(p => p.ProseActivity).HasForeignKey(d => d.AccentId);
            });

            modelBuilder.Entity<Vocabulary>(entity =>
            {
                entity.Property(e => e.Synonym)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Image).WithMany(p => p.Vocabulary).HasForeignKey(d => d.ImageId);
            });
        }

        public virtual DbSet<Accent> Accent { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<LessonPageMapping> LessonPageMapping { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<ProseActivity> ProseActivity { get; set; }
        public virtual DbSet<Vocabulary> Vocabulary { get; set; }
    }
}