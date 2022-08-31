using Microsoft.AspNetCore.Mvc;
using Bsef19a041_Project.Models;
using Bsef19a041_Project.Models.Repositories;

namespace Bsef19a041_Project.ViewComponents


{
    public class menuCardViewComponent : ViewComponent
    {
        ContentRepository contentRepo=new ContentRepository();
        public IViewComponentResult Invoke()
        {
            List<Content> contents = new List<Content>();
            contents=contentRepo.GetContent();
            return View(contents);
        }
    }
}
