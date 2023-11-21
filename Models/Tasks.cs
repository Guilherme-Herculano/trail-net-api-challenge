using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrailNetApiChallenge.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public EnumStatusTasks Status { get; set; }
    }
}