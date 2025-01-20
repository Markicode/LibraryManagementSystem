using LibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class NewsMessage : Model
    {
        public override string[] attributes { get; set; }
        public override string tableName { get; set; }

        public int? id { get; set; }
        public int posterId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string picture { get; set; }
        public string target { get; set; }

        public NewsMessage(int posterId, string title, string content, string picture, string target) 
        { 
            this.attributes = new string[] {"id", "title", "content", "picture", "target"};
            this.tableName = "news";
            this.title = title;
            this.content = content;
            this.picture = picture;
            this.target = target;
        }

        public NewsMessage(int id, int posterId, string title, string content, string picture, string target)
        {
            this.attributes = new string[] { "id", "title", "content", "picture", "target" };
            this.tableName = "news";
            this.id = id;
            this.title = title;
            this.content = content;
            this.picture = picture;
            this.target = target;
        }
    }
}
