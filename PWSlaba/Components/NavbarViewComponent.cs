using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Collections;
using System.Collections.Generic;

namespace PWSlaba.Components
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly IEnumerable<string> _menuElements;
        public NavbarViewComponent() => _menuElements = new List<string>() { "Home", "AboutUs", "FeedBack", "UploadFiles" };
        public IViewComponentResult Invoke()
        {
            return View(_menuElements);
        }
    }
}