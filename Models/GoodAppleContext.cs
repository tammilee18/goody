using System;
using Microsoft.EntityFrameworkCore;

namespace GoodAppleProj.Models {
    public class GoodAppleContext : DbContext {
        public GoodAppleContext(DbContextOptions options): base(options) {}
        public DbSet<User> users {get;set;}
        public DbSet<Teacher> teachers {get;set;}
        public DbSet<Connection> connections {get;set;}
        public DbSet<Project> projects {get;set;}
        public DbSet<Donation> donations {get;set;}
        public DbSet<Comment> comments {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<User>()
            .HasOne(u => u.IsTeacher)
            .WithOne(t => t.User)
            .HasForeignKey<Teacher>(t => t.UserId);

            modelBuilder.Entity<Connection>()
            .HasKey(c => new {c.UserId, c.FriendId});

            modelBuilder.Entity<Connection>()
            .HasOne(c => c.Friend)
            .WithMany(f => f.Connections)
            .HasForeignKey(c => c.FriendId);

            modelBuilder.Entity<Connection>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}