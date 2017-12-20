using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_self_service_system.Models
{
    public class FormViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        //   public ApplicationUser User { get; set; }
        public string UserName { get; set; }

        public int SolutionId { get; set; }
        //   public Solution Solution { get; set; }
        
        public FormStatus Status { get; set; }

        public FormViewModel()
        {
       //     User = null;// new ApplicationUser();
         //   Solution = null;// new Solution();
        }

        public FormViewModel(Form data)
        {
            Id = data.id;
            Title = data.Title;
            Text = data.Text;
            Comment = data.Comment;
            UserId = data.UserId;
            UserName = data.User.UserName;
            Status = data.Status;
            SolutionId = data.SolutionId;
            
          //  Solution = data.Solution;
        }

        public Form GetDbForm()
        {
            Form ret = new Form();

            ret.Title = Title;
            ret.Text = Text;
            ret.Comment = Comment;
            ret.UserId = UserId;
       //     ret.User = User;
            Status = Status;
            ret.SolutionId = SolutionId;
        //    ret.Solution = Solution;

            return ret;
        }
    }

    public class FormEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public short StatusID { get; set; }
        public List<FormStatus> StatusList { get; set; }

        public FormEditViewModel()
        {
            StatusList = new List<FormStatus>();
        }


        public FormEditViewModel(Form data)
        {
            Id = data.id;
            Title = data.Title;
            Text = data.Text;
            Comment = data.Comment;
            UserName = data.User.UserName;
            StatusID = data.Status.Id;
            StatusList = new List<FormStatus>();
            //  Solution = data.Solution;
        }
    }

}