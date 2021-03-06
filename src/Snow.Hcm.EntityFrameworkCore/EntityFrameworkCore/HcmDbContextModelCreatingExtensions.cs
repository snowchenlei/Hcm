﻿using Microsoft.EntityFrameworkCore;
using Snow.Hcm.EmployeeManagement.ContractAnnexes;
using Snow.Hcm.EmployeeManagement.Contracts;
using Snow.Hcm.EmployeeManagement.EducationExperiences;
using Snow.Hcm.EmployeeManagement.EmergencyContacts;
using Snow.Hcm.EmployeeManagement.Employees;
using Snow.Hcm.EmployeeManagement.Salaries;
using Snow.Hcm.EmployeeManagement.WorkExperiences;
using Snow.Hcm.MediaDescriptors;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Snow.Hcm.EntityFrameworkCore
{
    public static class HcmDbContextModelCreatingExtensions
    {
        public static void ConfigureHcm(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<MediaDescriptor>(b =>
            {
                b.ToTable(HcmConsts.DbTablePrefix + nameof(MediaDescriptor), HcmConsts.DbSchema);

                b.ConfigureByConvention();

                b.Property(x => x.EntityType).IsRequired().HasMaxLength(MediaDescriptorConsts.MaxEntityTypeLength);
                b.Property(x => x.Name).IsRequired().HasMaxLength(MediaDescriptorConsts.MaxNameLength);
                b.Property(x => x.MimeType).IsRequired().HasMaxLength(MediaDescriptorConsts.MaxMimeTypeLength);
                b.Property(x => x.Size).HasMaxLength(MediaDescriptorConsts.MaxSizeLength);
                
                b.ConfigureFullAuditedAggregateRoot();
            });

            #region EmployeeManagement

            builder.Entity<Employee>(b =>
            {
                b.ToTable(HcmConsts.DbTablePrefix + nameof(Employee), HcmConsts.DbSchema);
                b.Property(e => e.Name).HasMaxLength(EmployeeConsts.MaxNameLength);
                b.Property(e => e.EmployeeNumber).HasMaxLength(EmployeeConsts.MaxEmployeeNumberLength);
                b.Property(e => e.PhoneNumber).HasMaxLength(EmployeeConsts.MaxPhoneNumberLength);
                b.Property(e => e.IdCardNumber).HasMaxLength(EmployeeConsts.MaxIdCardNumberLength);
                b.Property(e => e.Address).HasMaxLength(EmployeeConsts.MaxAddressLength);
                b.Property(e => e.BankCardNumber).HasMaxLength(EmployeeConsts.MaxBankCardNumberLength);
                b.Property(e => e.BankOfDeposit).HasMaxLength(EmployeeConsts.MaxBankOfDepositLength);
                b.ConfigureFullAudited();
            });

            builder.Entity<EmergencyContact>(b =>
            {
                b.ToTable(HcmConsts.DbTablePrefix + nameof(EmergencyContact), HcmConsts.DbSchema);
                b.Property(e => e.Name).HasMaxLength(EmergencyContactConsts.MaxNameLength);
                b.Property(e => e.PhoneNumber).HasMaxLength(EmergencyContactConsts.MaxPhoneNumberLength);
                b.Property(e => e.Relation).HasMaxLength(EmergencyContactConsts.MaxRelationLength);
                b.ConfigureCreationTime();
            });

            builder.Entity<WorkExperience>(b =>
            {
                b.ToTable(HcmConsts.DbTablePrefix + nameof(WorkExperience), HcmConsts.DbSchema);
                b.Property(e => e.CompanyName).HasMaxLength(WorkExperienceConsts.MaxCompanyNameLength);
                b.Property(e => e.Post).HasMaxLength(WorkExperienceConsts.MaxPostLength);
                b.Property(e => e.Description).HasMaxLength(WorkExperienceConsts.MaxDescriptionLength);
                b.ConfigureCreationTime();
            });

            builder.Entity<EducationExperience>(b =>
            {
                b.ToTable(HcmConsts.DbTablePrefix + nameof(EducationExperience), HcmConsts.DbSchema);
                b.Property(e => e.SchoolName).HasMaxLength(EducationExperienceConsts.MaxSchoolNameLength);
                b.Property(e => e.Specialty).HasMaxLength(EducationExperienceConsts.MaxSpecialtyLength);
                b.Property(e => e.Description).HasMaxLength(EducationExperienceConsts.MaxDescriptionLength);
                b.ConfigureCreationTime();
            });

            builder.Entity<Contract>(b =>
            {
                b.ToTable(HcmConsts.DbTablePrefix + nameof(Contract), HcmConsts.DbSchema);
                b.Property(e => e.Name).HasMaxLength(ContractConsts.MaxNameLength);
                b.Property(e => e.ContractNumber).HasMaxLength(ContractConsts.MaxContractNumberLength);
            });
            builder.Entity<ContractAnnex>(b =>
            {
                b.ToTable(HcmConsts.DbTablePrefix + nameof(ContractAnnex), HcmConsts.DbSchema);
            });

            builder.Entity<Salary>(b =>
            {
                b.ToTable(HcmConsts.DbTablePrefix + nameof(Salary), HcmConsts.DbSchema);
            });

            #endregion
        }
    }
}