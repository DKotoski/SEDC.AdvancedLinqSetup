using Newtonsoft.Json;
using SEDC.AdvancedLinqSetup.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.AdvancedLinqSetup
{


    class Program
    {
        static void Main()
        {
            Utils.InitData();

                var userComments = DataContext.Users.Join(
                DataContext.Posts, 
                x => x.id, 
                y => y.userId, 
                (x,y)=>new
                {
                    UserId = x.id,
                    Name = x.name,
                    PostID = y.id
                }).Join(
                DataContext.Comments,
                x => x.PostID,
                y => y.postId,
                (x, y) => new
                {
                    Name = x.Name,
                    Comment = y.body
                }).ToList();

            userComments.ForEach(x => Console.WriteLine(x));
            Console.ReadLine();            
        }    
        

    }
}
