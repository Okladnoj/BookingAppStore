using System.Data.Entity;

namespace BookingAppStore.Models
{
    public class BookContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
 }