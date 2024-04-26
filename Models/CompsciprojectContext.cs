﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SoundScape.Models;

public partial class CompsciprojectContext : DbContext
{
    public CompsciprojectContext()
    {
    }

    public CompsciprojectContext(DbContextOptions<CompsciprojectContext> options)
        : base(options)
    {
    }

    /*
    This line declares a DbSet for the Album entity. A DbSet represents a collection of all entities in the database
    of a given type (Album in this case), and it's the primary way you query and save instances of your entities.
    */
    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<PlaylistSong> PlaylistSongs { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:compscifinalproject.database.windows.net,1433;Database=compsciproject;User ID=Guestacc1;Password=exbKD9oQ;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("guest");

        modelBuilder.Entity<Album>(entity =>
        {
            entity.ToTable("Album", "dbo");

            entity.Property(e => e.AlbumId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("AlbumID");
            entity.Property(e => e.Albumname).IsUnicode(false);
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.ToTable("Playlists", "dbo");

            entity.HasIndex(e => e.PlaylistId, "PlaylistID").IsUnique();

            entity.Property(e => e.PlaylistId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("PlaylistID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.PlaylistName).IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.Playlists)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("Username");
        });

        modelBuilder.Entity<PlaylistSong>(entity =>
        {
            entity.HasKey(e => e.PlaylistSongId).HasName("PK_NewTable");

            entity.ToTable("PlaylistSongs", "dbo");

            entity.Property(e => e.PlaylistSongId)
                .ValueGeneratedNever()
                .HasColumnName("PlaylistSongID");
            entity.Property(e => e.PlaylistId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("PlaylistID");
            entity.Property(e => e.TrackId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("TrackID");

            entity.HasOne(d => d.Playlist).WithMany(p => p.PlaylistSongs)
                .HasForeignKey(d => d.PlaylistId)
                .HasConstraintName("PlaylistID");

            entity.HasOne(d => d.Track).WithMany(p => p.PlaylistSongs)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("TrackID");
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.TrackId).HasName("PK_Songdetails");

            entity.ToTable("Songs", "dbo");

            entity.Property(e => e.TrackId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("TrackID");
            entity.Property(e => e.AlbumId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("AlbumID");
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sample)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrackName)
                .IsUnicode(false)
                .HasColumnName("track_name");

            entity.HasOne(d => d.Album).WithMany(p => p.Songs)
                .HasForeignKey(d => d.AlbumId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("AlbumID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("Users", "dbo");

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
