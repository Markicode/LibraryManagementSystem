using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Book : Item
    {
        public override string tableName
        { get; set; }

        public override string[] attributes
        { get; set; }

        public override Dictionary<string, string> attributeTypes { get; set; }

        public string isbn { get; set; }
        public string title { get; set; }
        public int author {  get; set; }
        public int genre { get; set; }

        public Book()
        {

        }

        public Book(string isbn, string title, int author, int genre) 
        {
            this.tableName = "book";
            this.attributes = new string[] { "isbn", "title", "author", "genre" };
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.genre = genre;
        }
    }
}
