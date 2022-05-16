using Microsoft.EntityFrameworkCore;
using Sozluk.Api.Domain.Models;
using System.Reflection;

namespace Sozluk.Infrastructure.Persistence.Context
{
    public class SozlukContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";

        public SozlukContext()
        {
        }

        public SozlukContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryVote> EntryVotes { get; set; }
        public DbSet<EntryFavorite> EntryFavorites { get; set; }

        public DbSet<EntryComment> EntryComments { get; set; }
        public DbSet<EntryCommentVote> EntryCommentVotes { get; set; }
        public DbSet<EntryCommentFavorite> EntryCommentFavorites { get; set; }
        public DbSet<EmailConfirmation> EmailConfirmations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //For Design Time Operations! For Example Migrations.
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = "Data Source=127.0.0.1; Initial Catalog=sozlukdb; Persist Security Info=True; User ID=sa; Password=1Secure*Password1";
                optionsBuilder.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {
            var addedEntities = ChangeTracker.Entries()
                .Where(i => i.State == EntityState.Added)
                .Select(i => (BaseEntity)i.Entity);

            PrepareAddedEntites(addedEntities);
        }

        private void PrepareAddedEntites(IEnumerable<BaseEntity> entites)
        {
            foreach (var entity in entites)
            {
                if(entity.CreateDate ==DateTime.MinValue)
                    entity.CreateDate = DateTime.Now;
            }
        }
    }
}
