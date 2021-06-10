using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BookLibrary.DAL.Entities
{
    public partial class BibliotecaContext : DbContext
    {
        public BibliotecaContext()
        {
        }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-204PAOD\\SS2019DEV;Database=Biblioteca;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Author)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("Loan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.RentDate).HasColumnType("date");

                entity.Property(e => e.ReturnDate)
                    .HasColumnType("date")
                    .HasComputedColumnSql("(dateadd(day,(14),[RentDate]))", false);

                entity.Property(e => e.SubscriberId).HasColumnName("SubscriberID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentBook_BookID");

                entity.HasOne(d => d.Subscriber)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.SubscriberId)
                    .HasConstraintName("FK_Loan_SubscriberID");
            });

            modelBuilder.Entity<Subscriber>((System.Action<Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Subscriber>>)(entity =>
            {
                entity.ToTable("Subscriber");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany((System.Linq.Expressions.Expression<System.Func<City, System.Collections.Generic.IEnumerable<Subscriber>>>)(p => (System.Collections.Generic.IEnumerable<Subscriber>)p.Subscribers))
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Subscriber_CityID");

                entity.HasOne(d => d.Country)
                    .WithMany((System.Linq.Expressions.Expression<System.Func<Country, System.Collections.Generic.IEnumerable<Subscriber>>>)(p => (System.Collections.Generic.IEnumerable<Subscriber>)p.Subscribers))
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Subscriber_CountryID");
            }));

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
