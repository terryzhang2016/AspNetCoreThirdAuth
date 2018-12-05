using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BotDetect.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebAppThirdAuth.Models;
using WebAppThirdAuth.Options;

namespace WebAppThirdAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyOptions _options;
        public HomeController(IOptionsMonitor<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";
            var user = User;
            return View();
        }

        [HttpGet]
        public IActionResult Captcha()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha", "Incorrect!")]
        public IActionResult Captcha(ExampleModel model)
        {
            MvcCaptcha.ResetCaptcha("ExampleCaptcha");
            return View(model);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            ViewData["Option1"] = _options.Option1;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
