using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HCA.DbModels
{
    public partial class HCAContext : DbContext
    {
        public HCAContext()
        {
        }

        public HCAContext(DbContextOptions<HCAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Designation> Designations { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleMenuAuth> RoleMenuAuths { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserMenuAuth> UserMenuAuths { get; set; } = null!;
        public virtual DbSet<UserRoleAuth> UserRoleAuths { get; set; } = null!;
        public virtual DbSet<VuMenuDetail> VuMenuDetails { get; set; } = null!;
        public virtual DbSet<VuRoleBaseDetail> VuRoleBaseDetails { get; set; } = null!;
        public virtual DbSet<VuUserDetail> VuUserDetails { get; set; } = null!;
        public virtual DbSet<VuUserMenuDetail> VuUserMenuDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:hca_Connection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasKey(e => e.ApplicationSk)
                    .HasName("PK_application");

                entity.ToTable("applications");

                entity.Property(e => e.ApplicationSk).HasColumnName("application_sk");

                entity.Property(e => e.ApplicationDesc)
                    .IsUnicode(false)
                    .HasColumnName("application_desc");

                entity.Property(e => e.ApplicationLogo).HasColumnName("application_logo");

                entity.Property(e => e.ApplicationName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("application_name");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentSk);

                entity.ToTable("departments");

                entity.Property(e => e.DepartmentSk).HasColumnName("department_sk");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.DepartmentDesc).HasColumnName("department_desc");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(250)
                    .HasColumnName("department_name");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.HasKey(e => e.DesignationSk);

                entity.ToTable("designations");

                entity.Property(e => e.DesignationSk).HasColumnName("designation_sk");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.DesignationDesc).HasColumnName("designation_desc");

                entity.Property(e => e.DesignationName)
                    .HasMaxLength(250)
                    .HasColumnName("designation_name");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocationSk);

                entity.ToTable("locations");

                entity.Property(e => e.LocationSk).HasColumnName("location_sk");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LocationDesc).HasColumnName("location_desc");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(250)
                    .HasColumnName("location_name");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.MenuSk);

                entity.ToTable("menus");

                entity.Property(e => e.MenuSk).HasColumnName("menu_sk");

                entity.Property(e => e.ApplicationSk).HasColumnName("application_sk");

                entity.Property(e => e.ChildSeq)
                    .HasColumnName("child_seq")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MenuIcon)
                    .HasMaxLength(80)
                    .HasColumnName("menu_icon");

                entity.Property(e => e.MenuTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("menu_title");

                entity.Property(e => e.MenuUrl)
                    .HasMaxLength(250)
                    .HasColumnName("menu_url");

                entity.Property(e => e.ParentSeq)
                    .HasColumnName("parent_seq")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ParentSk).HasColumnName("parent_sk");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleSk);

                entity.ToTable("roles");

                entity.Property(e => e.RoleSk).HasColumnName("role_sk");

                entity.Property(e => e.ApplicationSk).HasColumnName("application_sk");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReportingTo).HasColumnName("reporting_to");

                entity.Property(e => e.RoleDesc)
                    .HasMaxLength(250)
                    .HasColumnName("role_desc");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<RoleMenuAuth>(entity =>
            {
                entity.HasKey(e => e.RoleMenuSk);

                entity.ToTable("role_menu_auth");

                entity.Property(e => e.RoleMenuSk).HasColumnName("role_menu_sk");

                entity.Property(e => e.CanCreate)
                    .HasColumnName("can_create")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CanDelete)
                    .HasColumnName("can_delete")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CanEdit)
                    .HasColumnName("can_edit")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CanView)
                    .HasColumnName("can_view")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MenuSk).HasColumnName("menu_sk");

                entity.Property(e => e.RoleSk).HasColumnName("role_sk");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserSk);

                entity.ToTable("users");

                entity.Property(e => e.UserSk).HasColumnName("user_sk");

                entity.Property(e => e.ApplicationSk).HasColumnName("application_sk");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.DepartmentSk).HasColumnName("department_sk");

                entity.Property(e => e.DesignationSk).HasColumnName("designation_sk");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LocationSk).HasColumnName("location_sk");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.PasswordExpiry)
                    .HasColumnType("datetime")
                    .HasColumnName("password_expiry")
                    .HasDefaultValueSql("(dateadd(day,(30),getdate()))");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");

                entity.Property(e => e.UserFullName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("user_full_name");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .HasColumnName("user_name");
            });

            modelBuilder.Entity<UserMenuAuth>(entity =>
            {
                entity.HasKey(e => e.UserMenuSk);

                entity.ToTable("user_menu_auth");

                entity.Property(e => e.UserMenuSk).HasColumnName("user_menu_sk");

                entity.Property(e => e.CanCreate)
                    .HasColumnName("can_create")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CanDelete)
                    .HasColumnName("can_delete")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CanEdit)
                    .HasColumnName("can_edit")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CanView)
                    .HasColumnName("can_view")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MenuSk).HasColumnName("menu_sk");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");

                entity.Property(e => e.UserSk).HasColumnName("user_sk");
            });

            modelBuilder.Entity<UserRoleAuth>(entity =>
            {
                entity.HasKey(e => e.UserRoleSk);

                entity.ToTable("user_role_auth");

                entity.Property(e => e.UserRoleSk).HasColumnName("user_role_sk");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RoleSk).HasColumnName("role_sk");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");

                entity.Property(e => e.UserSk).HasColumnName("user_sk");
            });

            modelBuilder.Entity<VuMenuDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vu_menu_details");

                entity.Property(e => e.CanCreate).HasColumnName("can_create");

                entity.Property(e => e.CanDelete).HasColumnName("can_delete");

                entity.Property(e => e.CanEdit).HasColumnName("can_edit");

                entity.Property(e => e.CanView).HasColumnName("can_view");

                entity.Property(e => e.ChildSeq).HasColumnName("child_seq");

                entity.Property(e => e.MenuIcon)
                    .HasMaxLength(80)
                    .HasColumnName("menu_icon");

                entity.Property(e => e.MenuSk).HasColumnName("menu_sk");

                entity.Property(e => e.MenuTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("menu_title");

                entity.Property(e => e.MenuUrl)
                    .HasMaxLength(250)
                    .HasColumnName("menu_url");

                entity.Property(e => e.ParentSeq).HasColumnName("parent_seq");

                entity.Property(e => e.ParentSk).HasColumnName("parent_sk");

                entity.Property(e => e.UserSk).HasColumnName("user_sk");
            });

            modelBuilder.Entity<VuRoleBaseDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vu_role_base_details");

                entity.Property(e => e.CanCreate).HasColumnName("can_create");

                entity.Property(e => e.CanDelete).HasColumnName("can_delete");

                entity.Property(e => e.CanEdit).HasColumnName("can_edit");

                entity.Property(e => e.CanView).HasColumnName("can_view");

                entity.Property(e => e.ChildSeq).HasColumnName("child_seq");

                entity.Property(e => e.MenuIcon)
                    .HasMaxLength(80)
                    .HasColumnName("menu_icon");

                entity.Property(e => e.MenuSk).HasColumnName("menu_sk");

                entity.Property(e => e.MenuTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("menu_title");

                entity.Property(e => e.MenuUrl)
                    .HasMaxLength(250)
                    .HasColumnName("menu_url");

                entity.Property(e => e.ParentSeq).HasColumnName("parent_seq");

                entity.Property(e => e.ParentSk).HasColumnName("parent_sk");

                entity.Property(e => e.UserSk).HasColumnName("user_sk");
            });

            modelBuilder.Entity<VuUserDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vu_user_details");

                entity.Property(e => e.ApplicationDesc)
                    .IsUnicode(false)
                    .HasColumnName("application_desc");

                entity.Property(e => e.ApplicationName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("application_name");

                entity.Property(e => e.ApplicationSk).HasColumnName("application_sk");

                entity.Property(e => e.DepartmentDesc).HasColumnName("department_desc");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(250)
                    .HasColumnName("department_name");

                entity.Property(e => e.DepartmentSk).HasColumnName("department_sk");

                entity.Property(e => e.DesignationDesc).HasColumnName("designation_desc");

                entity.Property(e => e.DesignationName)
                    .HasMaxLength(250)
                    .HasColumnName("designation_name");

                entity.Property(e => e.DesignationSk).HasColumnName("designation_sk");

                entity.Property(e => e.LocationDesc).HasColumnName("location_desc");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(250)
                    .HasColumnName("location_name");

                entity.Property(e => e.LocationSk).HasColumnName("location_sk");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.PasswordExpiry)
                    .HasColumnType("datetime")
                    .HasColumnName("password_expiry");

                entity.Property(e => e.UserFullName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("user_full_name");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserSk).HasColumnName("user_sk");
            });

            modelBuilder.Entity<VuUserMenuDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vu_user_menu_details");

                entity.Property(e => e.CanCreate).HasColumnName("can_create");

                entity.Property(e => e.CanDelete).HasColumnName("can_delete");

                entity.Property(e => e.CanEdit).HasColumnName("can_edit");

                entity.Property(e => e.CanView).HasColumnName("can_view");

                entity.Property(e => e.ChildSeq).HasColumnName("child_seq");

                entity.Property(e => e.MenuIcon)
                    .HasMaxLength(80)
                    .HasColumnName("menu_icon");

                entity.Property(e => e.MenuSk).HasColumnName("menu_sk");

                entity.Property(e => e.MenuTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("menu_title");

                entity.Property(e => e.MenuUrl)
                    .HasMaxLength(250)
                    .HasColumnName("menu_url");

                entity.Property(e => e.ParentSeq).HasColumnName("parent_seq");

                entity.Property(e => e.ParentSk).HasColumnName("parent_sk");

                entity.Property(e => e.UserSk).HasColumnName("user_sk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
