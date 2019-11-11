using System;
using System.Data.Entity;

namespace BookingAppStore.Models
{
    public class BookDbInitializer : DropCreateDatabaseIfModelChanges<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Price = 220 });
            db.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Price = 180 });
            db.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Price = 150 });

            db.People.Add(new Person { Name = "Nik Keyn", Address = "г. Харьков, ул. Малышева 23", DateBorn = new DateTime(1988, 06, 24) });
            db.People.Add(new Person { Name = "Alan Dely", Address = "г. Харьков, ул. Гагарина 15", DateBorn = new DateTime(1963, 08, 15) });

            db.Purchases.Add(new Purchase { Person = "Nik", BookId = 3, Address = "г. Харьков, ул. Малышева 23", PurchaseId = 12121212, Date = DateTime.Now });
            db.Purchases.Add(new Purchase { Person = "Nik", BookId = 1, Address = "г. Харьков, ул. Малышева 23", PurchaseId = 12121212, Date = DateTime.Now });


            base.Seed(db);
        }
    }
}