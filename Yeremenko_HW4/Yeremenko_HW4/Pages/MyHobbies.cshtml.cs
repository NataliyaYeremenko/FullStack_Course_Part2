using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yeremenko_HW4.Models;

namespace Yeremenko_HW4.Pages
{
    public class MyHobbiesModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public List<Hobby> hobbiesList = new List<Hobby>
            {
                new Hobby { Id = 1, Name = "Reading books", Description = "Why you should try reading books: reading helps to stimulate your mind and divert your focus from issues and problems that are responsible for your stress. A Book has the power to take you to other realms and fill your mind with positivity.", Image = "images//Book.jpg" },
                new Hobby { Id = 2, Name = "Painting by numbers", Description = "Why you should try painting by numbers: it helps develop intellectual skills and promotes concentration. It also helps to develop creativity and a sense of orderliness. Paint by Numbers is undeniably an ideal way to learn painting.", Image = "images/Painting.jpg" },
                new Hobby { Id = 3, Name = "Cross stitch", Description = "Why you should try cross stitch: it is a relatively simple craft that can be enjoyed by people of all ages and skill levels.", Image = "images/CrossStich.jpg" }
            };
    }
}
