using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class Book : Item
    {
        override protected string[] attributes {  get; set; }

        public Book() 
        { 
            attributes = new string[1];
        }
    }
}
