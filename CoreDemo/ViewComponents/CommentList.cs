using System.Collections.Generic;
using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    Id = 1,
                    Username = "Bünyamin"
                },
                new UserComment
                {
                    Id = 2,
                    Username = "Mehmet"
                },
                new UserComment
                {
                    Id = 3,
                    Username = "Derya"
                },
            };
            return View(commentValues);
        }
    }
}
