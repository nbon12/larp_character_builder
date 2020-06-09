using Microsoft.AspNetCore.Mvc;

namespace LarpCharacterBuilder3
{
    public class CharacterController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}