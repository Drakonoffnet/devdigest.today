using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace WebSite.Controllers
{
    public class ContentController : Controller
    {
        private readonly FacebookCrosspostManager _facebookCrosspostCrosspostManager;
        private readonly TelegramCrosspostManager _telegramCrosspostCrosspostManager;

        public ContentController(
            IMemoryCache cache, 
            FacebookCrosspostManager facebookCrosspostCrosspostManager, 
            TelegramCrosspostManager telegramCrosspostCrosspostManager)
        {
            _facebookCrosspostCrosspostManager = facebookCrosspostCrosspostManager;
            _telegramCrosspostCrosspostManager = telegramCrosspostCrosspostManager;
        }

        [Route("content/partners")]
        public async Task<IActionResult> Partners()
        {
            ViewData["Title"] = Core.Pages.Partners;

            return View("~/Views/Content/Partners.cshtml");
        }

        [Route("content/about")]
        public async Task<IActionResult> About()
        {
            ViewData["Title"] = Core.Pages.AboutUs;

            return View("~/Views/Content/About.cshtml");
        }

        [Route("content/developex-tech-club")]
        public async Task<IActionResult> DevelopexTechClub()
        {
            ViewData["Title"] = Core.Pages.DevelopexTechClub;

            return View("~/Views/Content/DevelopexTechClub.cshtml");
        }

        [Route("search")]
        public async Task<IActionResult> Search()
        {
            ViewData["Title"] = Core.Pages.Search;

            return View("~/Views/Content/Search.cshtml");
        }

        [Route("content/privacy")]
        public async Task<IActionResult> Privacy()
        {
            return View("~/Views/Content/Privacy.cshtml");
        }
        
        [Route("content/how-to-post-vacancy")]
        public async Task<IActionResult> HowToPostVacancy()
        {
            return View("~/Views/Content/HowToPostVacancy.cshtml");
        }
        
        [Route("content/microsoft-tech-summit-warsaw")]
        public async Task<IActionResult> MicrosoftTechSummitWarsaw()
        {
            ViewData["Title"] = Core.Pages.MicrosoftTechSummitWarsaw;
            
            return View("~/Views/Content/MicrosoftTechSummitWarsaw.cshtml");
        }
        
        [Route("content/cloud-developers-days")]
        public async Task<IActionResult> CloudDevelopersDaysPoland()
        {
            ViewData["Title"] = Core.Pages.CloudDevelopersDays;
            
            return View("~/Views/Content/CloudDevelopersDaysPoland.cshtml");
        } 
        
        [Route("content/build-2018")]
        public async Task<IActionResult> Build2018()
        {
            ViewData["Title"] = Core.Pages.Build2018;
            
            return View("~/Views/Content/Build2018.cshtml");
        }


        [Route("content/telegram")]
        public async Task<IActionResult> Telegram()
        {
            ViewData["Title"] = Core.Pages.Telegram;

            var channels = _telegramCrosspostCrosspostManager
                .GetTelegramChannels()
                .Select(o => new Core.ViewModels.TelegramViewModel(o.Name)
                {
                    Title = o.Title,
                    Description = o.Description,                    
                    Logo = o.Logo
                }).ToList();


            return View("~/Views/Content/Telegram.cshtml", channels);
        }


        [Route("partners")]
        public async Task<IActionResult> PartnersRedirect() => RedirectPermanent("content/partners");

        [Route("about")]
        public async Task<IActionResult> AboutRedirect() => RedirectPermanent("content/about");

    }
}