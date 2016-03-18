using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.AdvancedLinqSetup.Domain
{
    public static class DataContext
    {
        public static List<User> Users;
        public static List<Post> Posts;
        public static List<Comment> Comments;
        public static List<Album> Albums;
        public static List<Photo> Photos;
        public static List<Todo> Todos;

        static DataContext()
        {
            Users = new List<User>();
            Posts = new List<Post>();
            Comments = new List<Comment>();
            Albums = new List<Album>();
            Photos = new List<Photo>();
            Todos = new List<Todo>();
        }
    }
}
