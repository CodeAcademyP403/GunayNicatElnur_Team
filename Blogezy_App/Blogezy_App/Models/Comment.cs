using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogezy_App.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public UserApp UserApp { get; set; }
        public string UserAppId { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime EditDate { get; set; }
    }
}
