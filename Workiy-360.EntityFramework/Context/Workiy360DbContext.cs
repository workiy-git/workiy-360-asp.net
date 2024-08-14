using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Workiy_360.EntityFramework;

namespace Workiy_360.EntityFramework.Context
{
    public partial class Workiy360DbContext : DbContext
    {
        public Workiy360DbContext()
        {
        }

        public Workiy360DbContext(DbContextOptions<Workiy360DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactType> ContactTypes { get; set; } = null!;
      
        public virtual DbSet<EmployeeAddressDetail> EmployeeAddressDetails { get; set; } = null!;
      
        public virtual DbSet<EmployeeContactDetail> EmployeeContactDetails { get; set; } = null!;
        public virtual DbSet<EmployeeEducationalDetail> EmployeeEducationalDetails { get; set; } = null!;
        public virtual DbSet<EmployeeExperienceDetail> EmployeeExperienceDetails { get; set; } = null!;
      
        public virtual DbSet<EmployeeInformation> EmployeeInformations { get; set; } = null!;
      
        public virtual DbSet<EmployeeNationalityDocument> EmployeeNationalityDocuments { get; set; } = null!;
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=workiy360;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<ContactType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PRIMARY");

                entity.ToTable("contact_type");

                entity.Property(e => e.TypeId).HasColumnName("TYPE_ID");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(255)
                    .HasColumnName("TYPE_NAME");
            });

 

            modelBuilder.Entity<EmployeeAddressDetail>(entity =>
            {
                entity.HasKey(e => e.AddressPkId)
                    .HasName("PRIMARY");

                entity.ToTable("employee_address_details");

                entity.HasIndex(e => e.ContactFkId, "CONTACT_FK_ID");

                entity.HasIndex(e => e.FkId, "FK_ID");

                entity.Property(e => e.AddressPkId).HasColumnName("ADDRESS_PK_ID");

                entity.Property(e => e.Address1)
                    .HasMaxLength(255)
                    .HasColumnName("ADDRESS_1");

                entity.Property(e => e.Address2)
                    .HasMaxLength(255)
                    .HasColumnName("ADDRESS_2");

                entity.Property(e => e.AddressType)
                    .HasMaxLength(255)
                    .HasColumnName("ADDRESS_TYPE");

                entity.Property(e => e.Area)
                    .HasMaxLength(255)
                    .HasColumnName("AREA");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("CITY");

                entity.Property(e => e.ContactFkId).HasColumnName("CONTACT_FK_ID");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.FkId).HasColumnName("FK_ID");

                entity.Property(e => e.Pincode).HasColumnName("PINCODE");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .HasColumnName("STATE");

                entity.HasOne(d => d.ContactFk)
                    .WithMany(p => p.EmployeeAddressDetails)
                    .HasForeignKey(d => d.ContactFkId)
                    .HasConstraintName("employee_address_details_ibfk_1");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.EmployeeAddressDetails)
                    .HasForeignKey(d => d.FkId)
                    .HasConstraintName("employee_address_details_ibfk_2");
            });

           

            modelBuilder.Entity<EmployeeContactDetail>(entity =>
            {
                entity.HasKey(e => e.ContactPkId)
                    .HasName("PRIMARY");

                entity.ToTable("employee_contact_details");

                entity.HasIndex(e => e.FkId, "FK_ID");

                entity.HasIndex(e => e.TypeId, "TYPE_ID");

                entity.Property(e => e.ContactPkId).HasColumnName("CONTACT_PK_ID");

                entity.Property(e => e.ConNum)
                    .HasMaxLength(15)
                    .HasColumnName("CON_NUM");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.EmergencyConName)
                    .HasMaxLength(255)
                    .HasColumnName("EMERGENCY_CON_NAME");

                entity.Property(e => e.FkId).HasColumnName("FK_ID");

                entity.Property(e => e.Relation)
                    .HasMaxLength(255)
                    .HasColumnName("RELATION");

                entity.Property(e => e.StatusInd).HasColumnName("STATUS_IND");

                entity.Property(e => e.TypeId).HasColumnName("TYPE_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_DATE");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.EmployeeContactDetails)
                    .HasForeignKey(d => d.FkId)
                    .HasConstraintName("employee_contact_details_ibfk_1");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.EmployeeContactDetails)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("employee_contact_details_ibfk_2");
            });

            modelBuilder.Entity<EmployeeEducationalDetail>(entity =>
            {
                entity.HasKey(e => e.EducationalPkId)
                    .HasName("PRIMARY");

                entity.ToTable("employee_educational_details");

                entity.HasIndex(e => e.FkId, "FK_ID");

                entity.Property(e => e.EducationalPkId).HasColumnName("EDUCATIONAL_PK_ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.Degree)
                    .HasMaxLength(255)
                    .HasColumnName("DEGREE");

                entity.Property(e => e.FkId).HasColumnName("FK_ID");

                entity.Property(e => e.Institute)
                    .HasMaxLength(255)
                    .HasColumnName("INSTITUTE");

                entity.Property(e => e.Major)
                    .HasMaxLength(255)
                    .HasColumnName("MAJOR");

                entity.Property(e => e.NameOfTheDegree)
                    .HasMaxLength(255)
                    .HasColumnName("NAME_OF_THE_DEGREE");

                entity.Property(e => e.StatusInd).HasColumnName("STATUS_IND");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.YearOfCompletion).HasColumnName("YEAR_OF_COMPLETION");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.EmployeeEducationalDetails)
                    .HasForeignKey(d => d.FkId)
                    .HasConstraintName("employee_educational_details_ibfk_1");
            });

            modelBuilder.Entity<EmployeeExperienceDetail>(entity =>
            {
                entity.HasKey(e => e.ExpId)
                    .HasName("PRIMARY");

                entity.ToTable("employee_experience_details");

                entity.HasIndex(e => e.FkId, "FK_ID");

                entity.Property(e => e.ExpId).HasColumnName("EXP_ID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.Designation)
                    .HasMaxLength(255)
                    .HasColumnName("DESIGNATION");

                entity.Property(e => e.Duration)
                    .HasMaxLength(255)
                    .HasColumnName("DURATION");

                entity.Property(e => e.EndDate).HasColumnName("END_DATE");

                entity.Property(e => e.FkId).HasColumnName("FK_ID");

                entity.Property(e => e.KeyRole)
                    .HasMaxLength(255)
                    .HasColumnName("KEY_ROLE");

                entity.Property(e => e.OtherInfo)
                    .HasColumnType("text")
                    .HasColumnName("OTHER_INFO");

                entity.Property(e => e.StartDate).HasColumnName("START_DATE");

                entity.Property(e => e.StatusInd).HasColumnName("STATUS_IND");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_DATE");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.EmployeeExperienceDetails)
                    .HasForeignKey(d => d.FkId)
                    .HasConstraintName("employee_experience_details_ibfk_1");
            });

            

            modelBuilder.Entity<EmployeeInformation>(entity =>
            {
                entity.HasKey(e => e.PkEmployeeId)
                    .HasName("PRIMARY");

                entity.ToTable("employee_information");

                entity.Property(e => e.PkEmployeeId).HasColumnName("PK_EMPLOYEE_ID");

                entity.Property(e => e.Age).HasColumnName("AGE");

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(10)
                    .HasColumnName("BLOOD_GROUP");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.DateOfBirth).HasColumnName("DATE_OF_BIRTH");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(255)
                    .HasColumnName("FATHER_NAME");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("GENDER");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(255)
                    .HasColumnName("MARITAL_STATUS");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(15)
                    .HasColumnName("MOBILE_NO");

                entity.Property(e => e.PersonalMail)
                    .HasMaxLength(255)
                    .HasColumnName("PERSONAL_MAIL");

                entity.Property(e => e.Prefix)
                    .HasMaxLength(255)
                    .HasColumnName("PREFIX");

                entity.Property(e => e.StatusInd).HasColumnName("STATUS_IND");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_DATE");
            });

           

            modelBuilder.Entity<EmployeeNationalityDocument>(entity =>
            {
                entity.HasKey(e => e.NatPkId)
                    .HasName("PRIMARY");

                entity.ToTable("employee_nationality_document");

                entity.HasIndex(e => e.FkId, "FK_ID");

                entity.Property(e => e.NatPkId).HasColumnName("NAT_PK_ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.FkId).HasColumnName("FK_ID");

                entity.Property(e => e.NationalityGpLink)
                    .HasColumnType("text")
                    .HasColumnName("NATIONALITY_GP_LINK");

                entity.Property(e => e.NationalityGpName)
                    .HasColumnType("text")
                    .HasColumnName("NATIONALITY_GP_NAME");

                entity.Property(e => e.NationalityGpNumber)
                    .HasColumnType("text")
                    .HasColumnName("NATIONALITY_GP_NUMBER");

                entity.Property(e => e.StatusInd).HasColumnName("STATUS_IND");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_DATE");

                entity.HasOne(d => d.Fk)
                    .WithMany(p => p.EmployeeNationalityDocuments)
                    .HasForeignKey(d => d.FkId)
                    .HasConstraintName("employee_nationality_document_ibfk_1");
            });

           

          
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
