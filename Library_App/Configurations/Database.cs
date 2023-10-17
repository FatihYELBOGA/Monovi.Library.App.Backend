using Library_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_App.Configurations
{
    public class Database : DbContext
    {
        public Database(DbContextOptions options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Models.File> Files { get; set; }
        public DbSet<BookComments> BookComments { get; set; }
        public DbSet<BookRatings> BookRatings { get; set; }
        public DbSet<UserFriends> UserFriends { get; set; }
        public DbSet<SharingBooks> SharingBooks { get; set; }
        public DbSet<FavoriteBooks> FavoriteBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // user-book relationship
            modelBuilder.Entity<Book>()
                .HasOne(b => b.User)
                .WithMany(u => u.Books)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // user-book comments relationships
            modelBuilder.Entity<BookComments>()
                .HasOne(bc => bc.User)
                .WithMany(u => u.BookComments)
                .HasForeignKey(bc => bc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BookComments>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookComments)
                .HasForeignKey(bc => bc.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            // user-book favorites relationships
            modelBuilder.Entity<FavoriteBooks>()
                .HasOne(fb => fb.User)
                .WithMany(u => u.FavoriteBooks)
                .HasForeignKey(fb => fb.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FavoriteBooks>()
                .HasOne(fb => fb.Book)
                .WithMany(b => b.FavoriteBooks)
                .HasForeignKey(fb => fb.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            // user-book ratings relationships
            modelBuilder.Entity<BookRatings>()
                .HasOne(br => br.User)
                .WithMany(b => b.BookRatings)
                .HasForeignKey(br => br.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BookRatings>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookRatings)
                .HasForeignKey(br => br.BookId).
                OnDelete(DeleteBehavior.NoAction);

            // user-user friends relationships
            modelBuilder.Entity<UserFriends>()
                .HasOne(uf => uf.FriendOne)
                .WithMany(u => u.UserFriendsOne)
                .HasForeignKey(uf => uf.FriendOneId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserFriends>()
                .HasOne(uf => uf.FriendTwo)
                .WithMany(u => u.UserFriendsTwo)
                .HasForeignKey(uf => uf.FriendTwoId)
                .OnDelete(DeleteBehavior.NoAction);

            // user-user-book sharings relationships
            modelBuilder.Entity<SharingBooks>()
                .HasOne(sb => sb.SenderUser)
                .WithMany(u => u.SenderBooks)
                .HasForeignKey(sb => sb.SenderUserId).
                OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SharingBooks>()
                .HasOne(sb => sb.ReceiverUser)
                .WithMany(u => u.ReceiverBooks)
                .HasForeignKey(sb => sb.ReceiverUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SharingBooks>()
                .HasOne(sb => sb.Book)
                .WithMany(u => u.SharingBooks)
                .HasForeignKey(sb => sb.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            // book-writer relationship
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Writer)
                .WithMany(w => w.Books)
                .HasForeignKey(b => b.WriterId)
                .OnDelete(DeleteBehavior.NoAction);

            // user-writer-book relationships
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profil)
                .WithOne(f => f.User)
                .HasForeignKey<User>(u => u.ProfilId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Writer>()
                .HasOne(w => w.Profil)
                .WithOne(f => f.Writer)
                .HasForeignKey<Writer>(w => w.ProfilId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Photo)
                .WithOne(f => f.Book)
                .HasForeignKey<Book>(b => b.PhotoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Content)
                .WithOne(f => f.BookContent)
                .HasForeignKey<Book>(b => b.ContentId)
                .OnDelete(DeleteBehavior.NoAction);

            // user - token relationship
            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithOne(u => u.RefreshToken)
                .HasForeignKey<RefreshToken>(rt => rt.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public static void Seed(Database database)
        {

            if (database.Database.GetPendingMigrations().Count() == 0)
            {
                if (database.Users.Count() == 0) 
                {

                }
            }

        }

    }

}