using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogezy_App.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tags { get; set; }

        public virtual UserApp UserApp { get; set; }
        public string UserAppId { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }

        public string Description { get; set; }
        public string Detail { get; set; }
        public string PhotoPath { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime EditDate { get; set; }
        public int ViewCount { get; set; }
    }
}
