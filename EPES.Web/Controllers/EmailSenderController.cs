using Microsoft.AspNetCore.Mvc;

namespace EPES.Web.Controllers
{
    public class EmailSenderController : Controller
    {
        public ActionResult SendEmail()
        {
            return View();
        }
    }

}
