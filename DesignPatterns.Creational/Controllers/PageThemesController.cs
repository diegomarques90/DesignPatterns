using DesignPatterns.Core.BridgePatternExample;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    [ApiController]
    [Route("api/pageThemes")]
    public class PageThemesController : Controller
    {
        [HttpGet("get-pagesDarkTheme")]
        public IActionResult GetPagesDarkTheme()
        {
            var pagesList = new List<string>();
            var darkTheme = new DarkTheme();

            var about = new About(darkTheme);
            var careers = new Careers(darkTheme);

            pagesList.Add(about.GetContent());
            pagesList.Add(careers.GetContent());

            return Ok(pagesList);
        }

        [HttpGet("get-pagesLightTheme")]
        public IActionResult GetPagesLightTheme()
        {
            var pagesList = new List<string>();
            var lightTheme = new LightTheme();

            var about = new About(lightTheme);
            var careers = new Careers(lightTheme);

            pagesList.Add(about.GetContent());
            pagesList.Add(careers.GetContent());

            return Ok(pagesList);
        }
    }
}
