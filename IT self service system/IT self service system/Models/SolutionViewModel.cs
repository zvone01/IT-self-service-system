using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_self_service_system.Models
{
    public class SolutionViewModel
    {
    }

    public class CreateSolutionViewModel
    {
        public List<Category> categoryList { get; set; }
        public int selectedCategory { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class SolutionListViewModel
    {
        public List<Solution> listSolution { get; set; }
    }
}