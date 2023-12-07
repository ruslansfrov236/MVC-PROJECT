using Microsoft.EntityFrameworkCore;
using Task_15.Models.Entities;

namespace Task_15.Models.Context
{
    public class Task_15DbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Recent> Recents { get; set; }
        public DbSet<About> Abours { get; set; }
        public DbSet<AboutHeader> AboutHeaders { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet <ContactInfo> ContactsInfo { get; set; }
        public Task_15DbContext(DbContextOptions options) : base(options)
        {
        }


    }
}
