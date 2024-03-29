﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0310.Models;

public partial class Mission08Context : DbContext
{
    public Mission08Context()
    {
    }

    public Mission08Context(DbContextOptions<Mission08Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ToDoItem> ToDoItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Mission08.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.HasIndex(e => e.CategoryID, "IX_Category_CategoryID").IsUnique();

            entity.Property(e => e.CategoryID).HasColumnName("CategoryID");
        });

        modelBuilder.Entity<Category>().HasData(

            new Category { CategoryID = 1, CategoryName = "Home" },
            new Category { CategoryID = 2, CategoryName = "School" },
            new Category { CategoryID = 3, CategoryName = "Work" },
            new Category { CategoryID = 4, CategoryName = "Church" }
            );


        modelBuilder.Entity<ToDoItem>(entity =>
        {
            entity.ToTable("ToDoItem");

            entity.HasIndex(e => e.TaskId, "IX_Task_TaskID").IsUnique();

            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.CategoryID).HasColumnName("CategoryID");

            entity.HasOne(d => d.Category).WithMany().HasForeignKey(d => d.CategoryID);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
