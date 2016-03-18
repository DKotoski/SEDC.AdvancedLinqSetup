using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.AdvancedLinqSetup.Domain
{



    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
        public List<Post> posts { get; set; }
        public List<Album> albums { get; set; }
        public List<Todo> todos { get; set; }

        public User()
        {
            posts = new List<Post>();
            albums = new List<Album>();
            todos = new List<Todo>();
        }
    }
}
