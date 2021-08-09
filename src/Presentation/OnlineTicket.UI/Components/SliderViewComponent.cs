using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineTicket.UI.Components
{
    public class SliderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<string> sliderImages = new List<string>()
            {
                "1.jpg",
                "2.jpg",
                "3.jpg"
            }.Select(x => Path.Combine("/images", "sliders", x)).ToList();

            return View(sliderImages);
        }
    }
}