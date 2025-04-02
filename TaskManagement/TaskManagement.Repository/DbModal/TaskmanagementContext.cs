using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Repository.DbModal;

public partial class TaskmanagementContext : DbContext
{
    public TaskmanagementContext()
    {
    }

    public TaskmanagementContext(DbContextOptions<TaskmanagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TaskManagement> TaskManagements { get; set; }

    public virtual DbSet<Taskstatus> Taskstatuses { get; set; }

    public virtual DbSet<UserAuthontication> UserAuthontications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Taskmanagement;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__263E2DD3123CDFDA");

            entity.ToTable("Employee", tb => tb.HasTrigger("tr_UserAuthontication"));

            entity.Property(e => e.EmpId).HasColumnName("Emp_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmpName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Emp_name");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.RolesNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Roles)
                .HasConstraintName("FK__Employee__Roles__3B75D760");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC0793E2FBD5");

            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Role_name");
        });

        modelBuilder.Entity<TaskManagement>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__TaskMana__0492148DB02954C3");

            entity.ToTable("TaskManagement");

            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.AssignedBy).HasColumnName("assigned_by");
            entity.Property(e => e.AssignedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("assigned_time");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.TaskDetails).HasColumnName("task_details");
            entity.Property(e => e.TaskFor).HasColumnName("task_for");
            entity.Property(e => e.TaskName)
                .HasMaxLength(250)
                .HasColumnName("task_name");
            entity.Property(e => e.TaskStatus).HasColumnName("task_status");

            entity.HasOne(d => d.AssignedByNavigation).WithMany(p => p.TaskManagementAssignedByNavigations)
                .HasForeignKey(d => d.AssignedBy)
                .HasConstraintName("FK__TaskManag__assig__47DBAE45");

            entity.HasOne(d => d.TaskForNavigation).WithMany(p => p.TaskManagementTaskForNavigations)
                .HasForeignKey(d => d.TaskFor)
                .HasConstraintName("FK__TaskManag__task___46E78A0C");

            entity.HasOne(d => d.TaskStatusNavigation).WithMany(p => p.TaskManagements)
                .HasForeignKey(d => d.TaskStatus)
                .HasConstraintName("FK__TaskManag__task___45F365D3");
        });

        modelBuilder.Entity<Taskstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Taskstat__3213E83F091B5AE0");

            entity.ToTable("Taskstatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Status_name");
        });

        modelBuilder.Entity<UserAuthontication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserAuth__3213E83FC52D41D9");

            entity.ToTable("UserAuthontication");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Token).HasColumnName("token");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.User).WithMany(p => p.UserAuthontications)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK__UserAutho__useri__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
