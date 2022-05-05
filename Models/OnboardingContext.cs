using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Employee_Onboarding.Models
{
    public partial class OnboardingContext : DbContext
    {
        public OnboardingContext()
        {
        }

        public OnboardingContext(DbContextOptions<OnboardingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Educationinfo> Educationinfos { get; set; }
        public virtual DbSet<Personalinfo> Personalinfos { get; set; }
        public virtual DbSet<Professionalinfo> Professionalinfos { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Userlogin> Userlogins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Onboarding;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Educationinfo>(entity =>
            {
                entity.HasKey(e => e.Educationid)
                    .HasName("PK__Educatio__4BBF3C2D6EB08DA0");

                entity.ToTable("Educationinfo");

                entity.Property(e => e.Degree)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DegreeCollegeName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Degree_College_Name");

                entity.Property(e => e.DegreePassingYear).HasColumnName("Degree_Passing_Year");

                entity.Property(e => e.DegreePercentage).HasColumnName("Degree_percentage");

                entity.Property(e => e.HighestQualificaion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Highest_Qualificaion");

                entity.Property(e => e.HscCollegeName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("HSC_College_Name");

                entity.Property(e => e.HscPassingYear).HasColumnName("HSC_Passing_Year");

                entity.Property(e => e.HscPercentage).HasColumnName("HSC_percentage");

                entity.Property(e => e.SscPassingYear).HasColumnName("SSC_Passing_Year");

                entity.Property(e => e.SscPercentage).HasColumnName("SSC_percentage");

                entity.Property(e => e.SscSchoolName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SSC_School_Name");

                entity.Property(e => e.University)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Educationinfos)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Education__Emplo__5165187F");
            });

            modelBuilder.Entity<Personalinfo>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__Personal__7AD04F11A2EFA5F1");

                entity.ToTable("Personalinfo");

                entity.Property(e => e.Adharcardfilepath)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Degreefilepath)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Emailid)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Hscfilepath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("HSCfilepath");

                entity.Property(e => e.LocalityAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Locality_Address");

                entity.Property(e => e.Passportfilepath)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Resumefilepath)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Signaturefilepath)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Sscfilepath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SSCfilepath");

                entity.Property(e => e.StateN)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("State_N");
            });

            modelBuilder.Entity<Professionalinfo>(entity =>
            {
                entity.HasKey(e => e.Professionalid)
                    .HasName("PK__Professi__B243EB90244AF71F");

                entity.ToTable("Professionalinfo");

                entity.Property(e => e.Company)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Experties)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FieldOfExperience)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Field_of_Experience");

                entity.Property(e => e.WorkExperience)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Professionalinfos)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__Emplo__5441852A");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("emailId");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("userPassword");
            });

            modelBuilder.Entity<Userlogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("userlogin");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("emailId");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("userPassword");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
