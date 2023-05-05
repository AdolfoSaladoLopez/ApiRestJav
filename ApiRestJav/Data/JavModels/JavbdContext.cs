using System;
using System.Collections.Generic;
using ApiRestJav;
using Microsoft.EntityFrameworkCore;

namespace ApiRestJav.Data.JavModels;

public partial class JavbdContext : DbContext
{
    public JavbdContext()
    {
    }

    public JavbdContext(DbContextOptions<JavbdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Weapon> Weapons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.ToTable("Answer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer1)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("answer");
            entity.Property(e => e.Correct).HasColumnName("correct");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.QuestionId).HasColumnName("questionId");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Answer_Question");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.ToTable("Character");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Level).HasColumnName("level");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.ToTable("Lesson");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Completed).HasColumnName("completed");
            entity.Property(e => e.FirstDescription)
                .HasMaxLength(1000)
                .IsFixedLength()
                .HasColumnName("firstDescription");
            entity.Property(e => e.FirstImage).HasColumnName("firstImage");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.SecondDescription)
                .HasMaxLength(1000)
                .IsFixedLength()
                .HasColumnName("secondDescription");
            entity.Property(e => e.SecondImage).HasColumnName("secondImage");
            entity.Property(e => e.ThirdDescription)
                .HasMaxLength(1000)
                .IsFixedLength()
                .HasColumnName("thirdDescription");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lesson_User");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.ToTable("Question");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.LessonId).HasColumnName("lessonId");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Question1)
                .HasMaxLength(300)
                .IsFixedLength()
                .HasColumnName("question");

            entity.HasOne(d => d.Lesson).WithMany(p => p.Questions)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Question_Lesson");
        });

        modelBuilder.Entity<Weapon>(entity =>
        {
            entity.ToTable("Weapon");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("description");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.LessonId).HasColumnName("lessonId");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Lesson).WithMany(p => p.Weapons)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Weapon_Lesson");

            entity.HasOne(d => d.User).WithMany(p => p.Weapons)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Weapon_User1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
