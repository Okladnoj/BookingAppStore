using BookingAppStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookingAppStore.Controllers
{
    public class HomeController : Controller

    {
        BookContext db = new BookContext();
        public async Task<ActionResult> StorApp()

        {//синглтон депенденси инжекшн, IоС - контейнер, юнит оф ворк.
            IEnumerable<Book> books = await db.Books.ToListAsync();
            ViewBag.Books = books;
            return View(books);

        }

        public async Task<ActionResult> PayStor()
        {
            IEnumerable<Purchase> purchases = await db.Purchases.ToListAsync();
            ViewBag.Books = purchases;
            return View(purchases);
        }

        public async Task<ActionResult> PersonList()
        {
            IEnumerable<Person> people = await db.People.ToListAsync();
            ViewBag.People = people;
            return View(people);
        }

        [HttpGet]
        public async Task<ActionResult> Buy(int id)
        {

            ViewBag.BookId = id;
            ViewBag.Name = db.Books.Find(id).Name;
            ViewBag.Author = db.Books.Find(id).Author;
            IEnumerable<Person> people = await db.People.ToListAsync();
            ViewBag.People = people;
            return View(people);
        }
        //[HttpGet]
        [HttpPost]
        public /*string*/ async Task<ActionResult> Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            ViewBag.BookId = purchase.BookId;
            ViewBag.Name = db.Books.Find(purchase.BookId).Name;
            ViewBag.Author = db.Books.Find(purchase.BookId).Author;

            purchase.Address = db.People.FirstOrDefault(x => x.Name.Contains(purchase.Person))?.Address;
            IEnumerable<Person> people = await db.People.ToListAsync();
            ViewBag.People = people;

            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            //db.Entry(purchase).State = EntityState.Modified;
            db.SaveChanges();

            //return "Спасибо," + purchase.Person + ", за покупку!";
            return View(people);
        }

        [HttpGet]
        public async Task<ActionResult> AddPerson()
        {
            IEnumerable<Person> people = await db.People.ToListAsync();
            ViewBag.People = people;
            return View(people);
        }

        [HttpPost]
        public /*string*/ async Task<ActionResult> AddPerson(Person purchase)
        {
            IEnumerable<Person> people = await db.People.ToListAsync();
            ViewBag.People = people;
            db.People.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> AddBook()
        {
            IEnumerable<Person> people = await db.People.ToListAsync();
            return View();
        }

        [HttpPost]
        public /*string*/ async Task<ActionResult> AddBook(Book purchase)
        {
            IEnumerable<Person> people = await db.People.ToListAsync();
            db.Books.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            new BookContext().Dispose();
            base.Dispose(disposing);
        }
    }
}