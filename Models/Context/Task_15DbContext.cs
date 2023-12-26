using Microsoft.EntityFrameworkCore;
using Task_15.Models.Customers;
using Task_15.Models.Entities;

namespace Task_15.Models.Context
{
    public class Task_15DbContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<Recent>? Recents { get; set; }
        public DbSet<About>? Abouts { get; set; }
        public DbSet<AboutHeader>? AboutHeaders { get; set; }
        public DbSet<Pricing>? Pricing { get; set; }    
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<ContactHeader>? ContactHeader { get; set; } 
        public DbSet <ContactInfo>? ContactsInfo { get; set; }
        public Task_15DbContext(DbContextOptions options) : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
         

            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified=>data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
