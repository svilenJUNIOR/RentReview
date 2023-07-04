using Microsoft.AspNetCore.Mvc;

namespace RentReview.Controllers
{
    public class PropertyController : Controller
    {
        public IActionResult All()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
