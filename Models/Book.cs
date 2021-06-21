using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string image;

        public Book()
        {
        }

        public Book(int id, string title, string author, string image)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.image = image;
        }

        [Required(ErrorMessage = "Khong bo trong tieu de!")]
        [StringLength(250,ErrorMessage = "Tieu de khong vuot qua 250 ky tu!")]
        [Display(Name = "Tieu de")]


        public int Id { get { return id; } set => id = value; }
        public string Title { get { return title; } set => title = value; }
        public string Author { get { return author; } set => author = value; }
        public string Image { get { return image; } set => image = value; }


    }
}