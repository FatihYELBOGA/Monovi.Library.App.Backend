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
                .OnDelete(DeleteBehavior.Cascade);

            // user-book comments relationships
            modelBuilder.Entity<BookComments>()
                .HasOne(bc => bc.User)
                .WithMany(u => u.BookComments)
                .HasForeignKey(bc => bc.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<BookComments>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookComments)
                .HasForeignKey(bc => bc.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // user-book favorites relationships
            modelBuilder.Entity<FavoriteBooks>()
                .HasOne(fb => fb.User)
                .WithMany(u => u.FavoriteBooks)
                .HasForeignKey(fb => fb.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<FavoriteBooks>()
                .HasOne(fb => fb.Book)
                .WithMany(b => b.FavoriteBooks)
                .HasForeignKey(fb => fb.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // user-book ratings relationships
            modelBuilder.Entity<BookRatings>()
                .HasOne(br => br.User)
                .WithMany(b => b.BookRatings)
                .HasForeignKey(br => br.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<BookRatings>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookRatings)
                .HasForeignKey(br => br.BookId).
                OnDelete(DeleteBehavior.ClientSetNull);

            // user-user friends relationships
            modelBuilder.Entity<UserFriends>()
               .HasKey(uf => new { uf.FriendOneId, uf.FriendTwoId });

            modelBuilder.Entity<UserFriends>()
                .HasOne(uf => uf.FriendOne)
                .WithMany(u => u.UserFriendsOne)
                .HasForeignKey(uf => uf.FriendOneId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<UserFriends>()
                .HasOne(uf => uf.FriendTwo)
                .WithMany(u => u.UserFriendsTwo)
                .HasForeignKey(uf => uf.FriendTwoId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // user-user-book sharings relationships
            modelBuilder.Entity<SharingBooks>()
                .HasOne(sb => sb.SenderUser)
                .WithMany(u => u.SenderBooks)
                .HasForeignKey(sb => sb.SenderUserId).
                OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<SharingBooks>()
                .HasOne(sb => sb.ReceiverUser)
                .WithMany(u => u.ReceiverBooks)
                .HasForeignKey(sb => sb.ReceiverUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<SharingBooks>()
                .HasOne(sb => sb.Book)
                .WithMany(u => u.SharingBooks)
                .HasForeignKey(sb => sb.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // book-writer relationship
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Writer)
                .WithMany(w => w.Books)
                .HasForeignKey(b => b.WriterId)
                .OnDelete(DeleteBehavior.Cascade);

            // user-book-file relationships
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profil)
                .WithOne(f => f.User)
                .HasForeignKey<User>(u => u.ProfilId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Photo)
                .WithOne(f => f.Book)
                .HasForeignKey<Book>(b => b.PhotoId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Content)
                .WithOne(f => f.BookContent)
                .HasForeignKey<Book>(b => b.ContentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // user - token relationship
            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithOne(u => u.RefreshToken)
                .HasForeignKey<RefreshToken>(rt => rt.UserId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);
        }

        public static void Seed(Database database)
        {

            if (database.Database.GetPendingMigrations().Count() == 0)
            {
                if (database.Users.Count() == 0) 
                {
                    database.Users.AddRange(users);
                    database.Writers.AddRange(writers);
                    database.Books.AddRange(books);
                    database.BookComments.AddRange(bookComments);
                    database.BookRatings.AddRange(bookRatings);
                    database.FavoriteBooks.AddRange(favoriteBooks);
                    database.SharingBooks.AddRange(sharingBooks);
                    database.UserFriends.AddRange(userFriends);
                    database.SaveChanges();
                }
            }
        }

        private static User[] users =
        {
            new User()
            {
                Email = "fatihyelboga@gmail.com",
                Password = "fatih123",
                Role = Enumerations.Role.USER,
                FirstName = "Fatih",
                LastName = "YELBOĞA",
                BornDate = new DateTime(2001, 01, 12),
                Gender = Enumerations.Gender.MALE,
                About = "He is professional football player."
            },
            new User()
            {
                Email = "berkaybayrak@gmail.com",
                Password = "berkay123",
                Role = Enumerations.Role.USER,
                FirstName = "Berkay",
                LastName = "YAPRAK",
                BornDate = new DateTime(2000, 06, 18),
                Gender = Enumerations.Gender.MALE,
                About = "He is pornstar."
            }
        };

        private static Writer[] writers =
        {
            new Writer()
            {
                FirstName = "Osman",
                LastName = "ALTUNAY",
                Gender = Enumerations.Gender.FEMALE,
                Nationality = Enumerations.Nationality.ENGLAND,
                Biography = "Hi guys, l am Osman ALTUNAY."
            },
            new Writer()
            {
                FirstName = "Enes",
                LastName = "DEMİREL",
                Gender = Enumerations.Gender.MALE,
                Nationality = Enumerations.Nationality.TURKEY,
                Biography = "Merhaba guys, ben Enes DEMİREL."
            }
        };

        private static Book[] books =
        {
            new Book()
            {
                User = users[0],
                Writer = writers[1],
                BookType = Enumerations.BookType.ESSAY,
                Name = "Machine Learning with Python",
                Description = "If you want to learn machine learning with python, you can read this tutorials.",
                PageNumber = 512,
                Language = Enumerations.Language.ENGLISH
            },
            new Book()
            {
                User = users[1],
                Writer = writers[0],
                BookType = Enumerations.BookType.NOVEL,
                Name = "Dede Korkut Hikayeleri",
                Description = "Dede Korkut Kitabı, Oğuz Türklerinin bilinen en eski epik destansı hikâyeleridir.",
                PageNumber = 1024,
                Language = Enumerations.Language.TURKISH
            }
        };

        private static BookComments[] bookComments =
        {
            new BookComments()
            {
                User = users[0],
                Book = books[1],
                Comment = "Güzel bir hikayeydi!",
                CommentDate = new DateTime(2023, 09, 7, 10, 00, 00)
            },
            new BookComments()
            {
                User = users[1],
                Book = books[0],
                Comment = "Güzel bir tutorial!",
                CommentDate = new DateTime(2023, 08, 5, 20, 00, 00)
            }
        };

        private static BookRatings[] bookRatings =
        {
            new BookRatings()
            {
                User = users[0],
                Book = books[1],
                Point = 8
            },
            new BookRatings()
            {
                User = users[1],
                Book = books[0],
                Point = 6
            }
        };

        private static FavoriteBooks[] favoriteBooks =
        {
            new FavoriteBooks()
            {
                User = users[0],
                Book = books[1]
            },
            new FavoriteBooks()
            {
                User = users[1],
                Book = books[0]
            }
        };

        private static SharingBooks[] sharingBooks =
        {
            new SharingBooks()
            {
                SenderUser = users[0],
                ReceiverUser = users[1],
                Book = books[0]
            },
            new SharingBooks()
            {
                SenderUser = users[1],
                ReceiverUser = users[0],
                Book = books[1]
            }
        };

        private static UserFriends[] userFriends =
        {
            new UserFriends()
            {
                FriendOne = users[0],
                FriendTwo = users[0],
                RequestStatus = Enumerations.RequestStatus.APPROVED
            }
        };

    }

}