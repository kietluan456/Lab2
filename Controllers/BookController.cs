using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class BookController : Controller
    {
        private int id;

        // GET: Book
        public String Hello(string uni)
        {
            return "Hi Thay" + uni;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("Book1");
            books.Add("Book2");
            books.Add("Book3");
            books.Add("Book4");
            ViewBag.BOOKS = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Xu Xu dung khoc", "Hoi Nha Sach", "/Content/Images/b1c.jpg"));
            books.Add(new Book(2, "Nha gia kim", "Paulo Coelho", "/Content/Images/b2c.jpg" ));
            books.Add(new Book(3, "Muon nhanh thi phai tu tu", "KB", "/Content/Images/b3c.jpg"));
            books.Add(new Book(4, "Neu nhu yeu", "Tran Tra My", "/Content/Images/b4c.jpg"));
            return View(books);
        }

           
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Xu Xu dung khoc", "Hoi Nha Sach", "/Content/Images/b1c.jpg"));
            books.Add(new Book(2, "Nha gia kim", "Paulo Coelho", "/Content/Images/b2c.jpg"));
            books.Add(new Book(3, "Muon nhanh thi phai tu tu", "KB", "/Content/Images/b3c.jpg"));
            books.Add(new Book(4, "Neu nhu yeu", "Tran Tra My", "/Content/Images/b4c.jpg"));

            Book book = new Book();
            foreach(Book a in books)
            {
                if (a.Id == id)
                {
                    book = a;

                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);                       
        }
        //===================================================================================

        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Title, string Author, string Image)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Xu Xu dung khoc", "Hoi Nha Sach", "/Content/Images/b1c.jpg"));
            books.Add(new Book(2, "Nha gia kim", "Paulo Coelho", "/Content/Images/b2c.jpg"));
            books.Add(new Book(3, "Muon nhanh thi phai tu tu", "KB", "/Content/Images/b3c.jpg"));
            books.Add(new Book(4, "Neu nhu yeu", "Tran Tra My", "/Content/Images/b4c.jpg"));

            //Book book = new Book();
            if (id == null)
            {
                return HttpNotFound();
            }

            foreach (Book a in books)
            {
                if (a.Id == id)
                {
                    a.Title = Title;
                    a.Author = Author;
                    a.Image = Image;
                    break;
                }
            }

            return View("ListBookModel", books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        //=================================================================================

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]

        public ActionResult Contact([Bind(Include = "Id, Title, Author, Image")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Xu Xu dung khoc", "Hoi Nha Sach", "/Content/Images/b1c.jpg"));
            books.Add(new Book(2, "Nha gia kim", "Paulo Coelho", "/Content/Images/b2c.jpg"));
            books.Add(new Book(3, "Muon nhanh thi phai tu tu", "KB", "/Content/Images/b3c.jpg"));
            books.Add(new Book(4, "Neu nhu yeu", "Tran Tra My", "/Content/Images/b4c.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }

            }
            catch (/*RetryLimitExceededException*/Exception)
            {
                ModelState.AddModelError("", "Error");
            }
            return View("ListBookModel", books);
        }

    }
}

    