using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban_Dotnet_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanban_Dotnet_Backend.Data;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("KanbanDatabase"));
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<ProjectTask> ProjectTasks { get; set; }
    public DbSet<Subtask> Subtasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the relationships between entities
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Categories)
            .WithOne(c => c.Project)
            .HasForeignKey(c => c.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Cards)
            .WithOne(card => card.Category)
            .HasForeignKey(card => card.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Card>()
            .HasMany(card => card.ProjectTasks)
            .WithOne(pt => pt.Card)
            .HasForeignKey(pt => pt.CardId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProjectTask>()
            .HasMany(pt => pt.Subtasks)
            .WithOne(st => st.ProjectTask)
            .HasForeignKey(st => st.ProjectTaskId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}