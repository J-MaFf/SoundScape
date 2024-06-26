﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace COMPSCI366.Models;

public partial class CompsciprojectContext : DbContext
{
    public CompsciprojectContext()
    {
    }

    public CompsciprojectContext(DbContextOptions<CompsciprojectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<PlaylistSong> PlaylistSongs { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=tcp:compscifinalproject.database.windows.net,1433;Database=compsciproject;User ID=Guestacc1;Password=exbKD9oQ;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("guest");

        // ALBUM
        modelBuilder.Entity<Album>(entity =>
        {
            entity.ToTable("Album", "dbo");

            entity.HasIndex(e => e.AlbumId, "AlbumID").IsUnique();

            entity.Property(e => e.AlbumId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("AlbumID");
            entity.Property(e => e.Name).IsUnicode(false);

            entity.Property(e => e.Totalsongs)
                .IsUnicode(false)
                .HasColumnName("Totalsongs")
                .IsRequired();


            entity.Property(e => e.Duration).IsUnicode(false)
                .HasColumnName("Duration")
                .IsUnicode(false);
        });

        // PLAYLIST
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
        // PLAYLIST SONG
        modelBuilder.Entity<PlaylistSong>(entity =>
        {
            entity.HasKey(e => e.PlaylistSongId);

            entity.ToTable("PlaylistSongs", "dbo");

            entity.HasIndex(e => e.PlaylistSongId, "PlaylistSongID").IsUnique();

            entity.Property(e => e.PlaylistSongId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PlaylistSongID");
            entity.Property(e => e.PlaylistId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("PlaylistID");
            entity.Property(e => e.TrackId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("TrackID");
            entity.Property<int?>(e => e.Order) // int? might throw errors
                .IsUnicode(false)
                .HasColumnName("Order");

            entity.HasOne(d => d.Playlist).WithMany(p => p.PlaylistSongs)
                .HasForeignKey(d => d.PlaylistId)
                .HasConstraintName("PlaylistID");
        });
        // SONG
        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.TrackId);

            entity.ToTable("Songs", "dbo");

            entity.HasIndex(e => e.TrackId, "TrackID").IsUnique();

            entity.Property(e => e.TrackId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("TrackID");
            entity.Property(e => e.AlbumId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("AlbumID");

            entity.Property(e => e.Albumname).IsUnicode(false);
            entity.Property(e => e.Artists).IsUnicode(false);
            entity.Property(e => e.Genre).IsUnicode(false);
            entity.Property(e => e.Trackname).IsUnicode(false);

            entity.Property<double?>(e => e.Danceability)
                .HasColumnName("Danceability")
                .IsUnicode(false);

            entity.Property<bool?>(e => e.Profanity)
                .HasColumnName("Profanity")
                .IsUnicode(false);

            entity.Property<int?>(e => e.Duration)
                .HasColumnName("Duration")
                .IsUnicode(false);

            entity.HasOne(d => d.Album).WithMany(p => p.Songs)
                .HasForeignKey(d => d.AlbumId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("AlbumID");
        });

        // USER
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("Users", "dbo");

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);

            entity.Property(e => e.MinutesListened).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
