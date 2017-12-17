using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_self_service_system.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public  CategoryViewModel ()
        {
            Id = 0;
            Name = "";
        }
        public CategoryViewModel(Category c)
        {
            Id = c.Id;
            Name = c.Name;
        }
    }

}