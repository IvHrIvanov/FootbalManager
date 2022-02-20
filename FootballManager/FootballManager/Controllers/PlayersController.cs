using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.ViewModels;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;
        public PlayersController(Request request
            )
            : base(request)
        {
        }
        [Authorize]
        public Response Add()
        {
            return View(new { IsAuthenticated = true });
        }
        [HttpPost]
        [Authorize]
        public Response Add(AddPlayerViewModel model)
        {
            var (created,error) = playerService.Add(model);
            if (!created)
            {
                return View(new {ErrorMessage = error},"/Error");
            }
            return Redirect("/");
        }
        [Authorize]
       public Response Collection()
        {
            return View(new { IsAuthenticated = true });
        }
        [Authorize]
        public Response All()
        {
            return View(new { IsAuthenticated = true });

        }
    }
}
