using DatingAppModelToDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingAppModelToDatabase.Data
{
    public class DatingAppContext : DbContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserBio> UserBio { get; set; }

        public DatingAppContext(DbContextOptions<DatingAppContext> options)
        
            : base(options) 
        { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=DatingApp;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().HasIndex(u => u.LoginName).IsUnique();
            modelBuilder.Entity<City>().HasIndex(u => u.CityName).IsUnique();

            modelBuilder.Entity<Likes>()
              .HasKey(l => l.LikesID);

            modelBuilder.Entity<Likes>()
                .HasOne(l => l.Liker)
                .WithMany(u => u.LikedUsers)
                .HasForeignKey(l => l.LikerID)
                .OnDelete(DeleteBehavior.Restrict); // Set the appropriate delete behavior

            modelBuilder.Entity<Likes>()
                .HasOne(l => l.Likee)
                .WithMany(u => u.LikedByUsers)
                .HasForeignKey(l => l.LikeeID)
                .OnDelete(DeleteBehavior.Restrict); // Set the appropriate delete behavior

            // Additional configurations for UserProfile entity if needed
            modelBuilder.Entity<User>()
                .HasMany(u => u.LikedUsers)
                .WithOne(l => l.Liker)
                .HasForeignKey(l => l.LikerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.LikedByUsers)
                .WithOne(l => l.Likee)
                .HasForeignKey(l => l.LikeeID)
                .OnDelete(DeleteBehavior.Restrict);


            // Message entity configuration:
            // Configure the many-to-many relationship between UserProfile and Like
            modelBuilder.Entity<Message>()
                .HasKey(l => l.MessageID);

            modelBuilder.Entity<Message>()
                .HasOne(l => l.Sender)
                .WithMany(u => u.MsgReciever)
                .HasForeignKey(l => l.SenderID)
                .OnDelete(DeleteBehavior.Restrict); // Set the appropriate delete behavior

            modelBuilder.Entity<Message>()
                .HasOne(l => l.Reciever)
                .WithMany(u => u.MsgSender)
                .HasForeignKey(l => l.RecieverID)
                .OnDelete(DeleteBehavior.Restrict); // Set the appropriate delete behavior

            // Additional configurations for UserProfile entity if needed
            modelBuilder.Entity<User>()
                .HasMany(u => u.MsgReciever)
                .WithOne(l => l.Sender)
                .HasForeignKey(l => l.SenderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.MsgSender)
                .WithOne(l => l.Reciever)
                .HasForeignKey(l => l.RecieverID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
