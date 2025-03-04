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
        public override Dictionary<string, string> attributeTypes { get; set; }

        public int? id { get; set; }
        public int employee_id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string picture { get; set; }
        public string target { get; set; }
        public string date_posted { get; set; }

        public NewsMessage()
        {
            this.attributes = new string[] {"id", "employee_id", "title", "content", "picture", "target", "date_posted" };
            this.attributeTypes = new Dictionary<string, string>() {
                {"id", "int"},
                {"employee_id", "int"},
                {"title", "string"},
                {"content", "string"},
                {"picture", "string"},
                {"target", "string"},
                {"date_posted", "string"}
                };
            this.id = -1;
            this.employee_id = -1;
            this.tableName = "news";
            this.title = "No title";
            this.content = "No content";
            this.picture = "No picture";
            this.target = "No target";
            this.date_posted = "DateTime.Now";
        }

        public NewsMessage(int posterId, string title, string content, string picture, string target) 
        { 
            this.attributes = new string[] {"id", "employee_id", "title", "content", "picture", "target", "date_posted"};
            this.attributeTypes = new Dictionary<string, string>() {
                {"id", "int"},
                {"employee_id", "int"},
                {"title", "string"},
                {"content", "string"},
                {"picture", "string"},
                {"target", "string"},
                {"date_posted", "string"}
                };
            this.tableName = "news";
            this.title = title;
            this.content = content;
            this.picture = picture;
            this.target = target;
        }

        public NewsMessage(int id, int posterId, string title, string content, string picture, string target)
        {
            this.attributes = new string[] { "id", "employee_id", "title", "content", "picture", "target", "date_posted" };
            this.attributeTypes = new Dictionary<string, string>() {
                {"id", "int"},
                {"employee_id", "int"},
                {"title", "string"},
                {"content", "string"},
                {"picture", "string"},
                {"target", "string"},
                {"date_posted", "string"}
                };
            this.tableName = "news";
            this.id = id;
            this.title = title;
            this.content = content;
            this.picture = picture;
            this.target = target;
        }
    }
}

// TODO: Implement datetime