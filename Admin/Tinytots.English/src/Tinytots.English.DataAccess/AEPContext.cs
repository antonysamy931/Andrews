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
                entity.Property(e => e.American).Required();

                entity.Property(e => e.British).Required();

                entity.Reference(d => d.Image).InverseCollection(p => p.Accent).ForeignKey(d => d.ImageId);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Content).Required();
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.Name).Required();
            });

            modelBuilder.Entity<LessonPageMapping>(entity =>
            {
                entity.Reference(d => d.Lesson).InverseCollection(p => p.LessonPageMapping).ForeignKey(d => d.LessonId);

                entity.Reference(d => d.Page).InverseCollection(p => p.LessonPageMapping).ForeignKey(d => d.PageId);
            });

            modelBuilder.Entity<ProseActivity>(entity =>
            {
                entity.Reference(d => d.Accent).InverseCollection(p => p.ProseActivity).ForeignKey(d => d.AccentId);
            });

            modelBuilder.Entity<Vocabulary>(entity =>
            {
                entity.Property(e => e.Synonym).Required();

                entity.Property(e => e.Word).Required();

                entity.Reference(d => d.Image).InverseCollection(p => p.Vocabulary).ForeignKey(d => d.ImageId);
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