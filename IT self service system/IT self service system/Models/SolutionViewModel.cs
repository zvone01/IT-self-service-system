using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_self_service_system.Models
{
    public class SolutionViewModel
    {
        
        public Category category { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int reputation { get; set; }
        public int Id { get; set; }
        public uint counter { get; set; }
        public string ContactInfo { get; set; }

        public SolutionViewModel(Solution s)
        {
            Id = s.Id; 
            category = s.Category;
            title = s.Title;
            description = s.Description;
            reputation = s.Reputation;
            ContactInfo = s.ContactInfo;
        }
    }

    public class CreateSolutionViewModel
    {
        public int Id { get; set; }
        public List<Category> categoryList { get; set; }
        public int selectedCategory { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int reputation { get; set; }
        public string ContactInfo { get; set; }


        public CreateSolutionViewModel()
        {
            categoryList = new List<Category>();
        }
        public CreateSolutionViewModel(Solution s)
        {
            Id = s.Id;
            selectedCategory = s.CategoryId;
            title = s.Title;
            description = s.Description;
            reputation = s.Reputation;
            ContactInfo = s.ContactInfo;
        }
    }
    
    public class SolutionListViewModel
    {
        public List<SolutionViewModel> listSolution { get; set; }

        public SolutionListViewModel()
        {
            listSolution = new List<SolutionViewModel>();
        }

       public SolutionListViewModel(List<Solution> list)
        {
            foreach(var item in list)
            {
                listSolution.Add(new SolutionViewModel(item));
            }
        }

        public void AddSolutionsToList(List<Solution> list)
        {
            foreach (var item in list)
            {
                var s = listSolution.FirstOrDefault(x => x.Id == item.Id);
                if (s == null)
                    listSolution.Add(new SolutionViewModel(item));
                else
                s.counter++;
            }
        }
    }

    public class SetMarkData
    {
        public int SolutionID { get; set; }
        public bool Mark { get; set; }
    }
}