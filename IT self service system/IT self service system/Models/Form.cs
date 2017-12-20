using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_self_service_system.Models
{
    public class Form
    {

        public int id { get; set; }
        public string  Title { get; set; }
        public string Text { get; set; }
        public string  Comment { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int SolutionId { get; set; }
        public Solution Solution { get; set; }

        public short StatusId { get; set; }
        public FormStatus Status { get; set; }

    }
}