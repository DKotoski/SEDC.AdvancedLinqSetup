using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.AdvancedLinqSetup.Domain
{
    public class Post
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public List<Comment> comments { get; set; }

        public Post()
        {
            comments = new List<Comment>();
        }
    }
}
