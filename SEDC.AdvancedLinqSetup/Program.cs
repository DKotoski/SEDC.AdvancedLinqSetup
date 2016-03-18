using Newtonsoft.Json;
using SEDC.AdvancedLinqSetup.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SEDC.AdvancedLinqSetup
{


    class Program
    {
        static void Main()
        {
            InitData();

            Console.ReadLine();
            var x = DataContext.Users;
            Console.ReadLine();
        }

        //Initializes full data model
        public static void InitData()
        {
            Console.WriteLine("Downloading page...");


            var users = DownloadPageAsync<List<User>>("http://jsonplaceholder.typicode.com/users").Result;

            var posts = DownloadPageAsync<List<Post>>("http://jsonplaceholder.typicode.com/posts").Result;

            var comments = DownloadPageAsync<List<Comment>>("http://jsonplaceholder.typicode.com/comments").Result;

            var albums = DownloadPageAsync<List<Album>>("http://jsonplaceholder.typicode.com/albums").Result;

            var photos = DownloadPageAsync<List<Photo>>("http://jsonplaceholder.typicode.com/photos").Result;

            var todos = DownloadPageAsync<List<Todo>>("http://jsonplaceholder.typicode.com/todos").Result;

            foreach (var comment in comments)
            {
                posts.Where(x => x.id == comment.postId).ToList().ForEach(x => x.comments.Add(comment));
            }

            foreach (var post in posts)
            {
                users.Where(x => x.id == post.userId).ToList().ForEach(x => x.posts.Add(post));
            }

            foreach (var photo in photos)
            {
                albums.Where(x => x.id == photo.albumId).ToList().ForEach(x => x.photos.Add(photo));
            }

            foreach (var album in albums)
            {
                users.Where(x => x.id == album.userId).ToList().ForEach(x => x.albums.Add(album));
            }

            foreach (var todo in todos)
            {
                users.Where(x => x.id == todo.userId).ToList().ForEach(x => x.todos.Add(todo));
            }

            DataContext.Users = users;
            DataContext.Albums = albums;
            DataContext.Comments = comments;
            DataContext.Photos = photos;
            DataContext.Posts = posts;
            DataContext.Todos = todos;

            Console.WriteLine("Downloading Complete");
        }

        //Downloads data from internet
        static async Task<T> DownloadPageAsync<T>(string url) where T : new()
        {
            // ... Target page.
            string page = url;

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                // ... Display the result.
                if (result != null)
                {
                    Console.WriteLine("Finished Downloading " + typeof(T));
                    return JsonConvert.DeserializeObject<T>(result);

                }
            }
            return new T();
        }

    }
}
