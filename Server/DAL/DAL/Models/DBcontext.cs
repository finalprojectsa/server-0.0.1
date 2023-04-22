using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class DBcontext : DbContext
    {
        public DBcontext()
        {
        }

        public DBcontext(DbContextOptions<DBcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Invites> Invites { get; set; }
        public virtual DbSet<OccasionType> OccasionType { get; set; }
        public virtual DbSet<Occasions> Occasions { get; set; }
        public virtual DbSet<People> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server= (LocalDB)\\MSSQLLocalDB;Database= C:\\Users\\אבוביץ\\Desktop\\פרויקט גמר\\DB\\Occasion.mdf;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invites>(entity =>
            {
                entity.HasKey(e => e.InviteeCode)
                    .HasName("PK__Invites__E42A2E970148F790");

                entity.Property(e => e.InviteeCode).HasColumnName("inviteeCode");

                entity.Property(e => e.Answerd).HasColumnName("answerd");

                entity.Property(e => e.OccasionCode).HasColumnName("occasionCode");

                entity.Property(e => e.PersonCode).HasColumnName("personCode");

                entity.Property(e => e.Portions).HasColumnName("portions");

                entity.Property(e => e.ReminderDay)
                    .HasColumnName("reminderDay")
                    .HasColumnType("datetime");

                entity.Property(e => e.TryCount).HasColumnName("tryCount");

                entity.HasOne(d => d.OccasionCodeNavigation)
                    .WithMany(p => p.Invites)
                    .HasForeignKey(d => d.OccasionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invites_ToTable");
            });

            modelBuilder.Entity<OccasionType>(entity =>
            {
                entity.HasKey(e => e.OccasionTypeCode)
                    .HasName("PK__Occasion__18C0A06652C9745A");

                entity.Property(e => e.OccasionTypeCode).HasColumnName("occasionTypeCode");

                entity.Property(e => e.OccasionTypename)
                    .IsRequired()
                    .HasColumnName("occasionTypename")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Occasions>(entity =>
            {
                entity.HasKey(e => e.OccasionCode)
                    .HasName("PK__Occasion__7189C71437DC6137");

                entity.Property(e => e.OccasionCode).HasColumnName("occasionCode");

                entity.Property(e => e.FirstMessage)
                    .HasColumnName("firstMessage")
                    .HasColumnType("datetime");

                entity.Property(e => e.InviterCode).HasColumnName("inviterCode");

                entity.Property(e => e.OccasionDate)
                    .HasColumnName("occasionDate")
                    .HasColumnType("date");

                entity.Property(e => e.OccasionTypeCode).HasColumnName("occasionTypeCode");

                entity.Property(e => e.Range).HasColumnName("range");

                entity.Property(e => e.RecordFile)
                    .IsRequired()
                    .HasColumnName("recordFile")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Repetition).HasColumnName("repetition");

                entity.HasOne(d => d.OccasionTypeCodeNavigation)
                    .WithMany(p => p.Occasions)
                    .HasForeignKey(d => d.OccasionTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Occasions_ToTable");
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.HasKey(e => e.PersonCode)
                    .HasName("PK__People__DBE53335C4606744");

                entity.Property(e => e.PersonCode).HasColumnName("personCode");

                entity.Property(e => e.Cellephone)
                    .HasColumnName("cellephone")
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.DavenPlace)
                    .HasColumnName("davenPlace")
                    .HasMaxLength(50);

                entity.Property(e => e.EducationPlace)
                    .HasColumnName("educationPlace")
                    .HasMaxLength(50);

                entity.Property(e => e.FatherCode)
                    .HasColumnName("fatherCode")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FatherInLawCode)
                    .HasColumnName("fatherInLawCode")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(50);

                entity.Property(e => e.Suffix)
                    .HasColumnName("suffix")
                    .HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.HasOne(d => d.FatherCodeNavigation)
                    .WithMany(p => p.InverseFatherCodeNavigation)
                    .HasForeignKey(d => d.FatherCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_People_ToTable");

                entity.HasOne(d => d.FatherInLawCodeNavigation)
                    .WithMany(p => p.InverseFatherInLawCodeNavigation)
                    .HasForeignKey(d => d.FatherInLawCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_People_ToTable_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
