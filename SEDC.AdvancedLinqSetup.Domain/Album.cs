using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.AdvancedLinqSetup.Domain
{
    public class Album
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public List<Photo> photos { get; set; }

        public Album()
        {
            photos = new List<Photo>();
        }
    }
}
