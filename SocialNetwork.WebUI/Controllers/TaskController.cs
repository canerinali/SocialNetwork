using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.Abstract;
using SocialNetwork.WebUI.EntityHelper;
using System.Linq;

namespace SocialNetwork.WebUI.Controllers
{
    public class TaskController : Controller
    {
        IPostService _postService;
        IBaseHelper _baseHelper;

        public TaskController(IPostService postService, IBaseHelper baseHelper)
        {
            _postService = postService;
            _baseHelper = baseHelper;
        }
        public IActionResult Index()
        {
            var postJs = _postService.GetAll().Select(x=> x.CalendarJs).ToList();
            return View(postJs);
        }
    }
}
