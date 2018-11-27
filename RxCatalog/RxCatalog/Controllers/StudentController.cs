using Microsoft.AspNetCore.Mvc;

namespace RxCatalog.Controllers
{
    public class StudentController : Controller
    {
        // GET
        public string Index()
        {
            return "This is the student controller";
        }
    }
}