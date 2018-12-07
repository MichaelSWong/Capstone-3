using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;


//this one is just going to show the park index
namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
     
        [HttpGet]
        public ActionResult Index()
        {
            ParkModelDAL dal = new ParkModelDAL();
            return View(dal.GetParkModels());
        }

        public IActionResult Detail(string code)
        {
            ParkModelDAL dal = new ParkModelDAL();
            ParkModel park = dal.GetParkModel(code);

            return View(park);
        }

        public ActionResult WeatherDetailView(string code)
        {
            WeatherDetailDAL dal = new WeatherDetailDAL();
      
            IList<WeatherModel> results = dal.GetWeather(code);
            string tempUnit = HttpContext.Session.GetString(isCelcius_Session_ID);
            foreach (WeatherModel weatherly in results)
            {


                if (tempUnit == null)
                {
                    tempUnit = "false";


                    weatherly.isCelsius = false;


                }
                else
                {

                    weatherly.isCelsius = Convert.ToBoolean(tempUnit);


                    
                }
                WeatherModel.ChangeTemp(weatherly);
            }
            return View(results);

        }
        [HttpGet]
        public IActionResult Favorites()
        {
            SurveyDAL dal = new SurveyDAL();
            return View(dal.SurveyList());
        }

   

        [HttpGet]
        public IActionResult NewSurvey()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewSurvey(SurveyModel model)
        {
            SurveyDAL myDal = new SurveyDAL();
            myDal.SaveSurvey(model);

            return RedirectToAction("favorites");
        }
        private List<SelectListItem> parkselect = new List<SelectListItem>()
        {
            new SelectListItem(){Text="Glacier National Park"},
            new SelectListItem() {Text ="Grand National Park"},
            new SelectListItem() {Text ="Grand Teton National Park"},
            new SelectListItem() {Text ="Mount Ranier National Park"},
            new SelectListItem() {Text ="Great Smoky Mountain National Park"},
            new SelectListItem() {Text ="Everglades National Park"},
            new SelectListItem() {Text ="Yellowstone National Park" },
            new SelectListItem() {Text ="Yosemite National Park"},
            new SelectListItem() {Text ="Cuyahoga Valley National Park" },
            new SelectListItem() {Text ="Rocky Mountain National Park"}
        };

        private List<SelectListItem> states = new List<SelectListItem>()
        {
            new SelectListItem() {Text ="Alabama" },
            new SelectListItem() {Text ="Alaska"},
            new SelectListItem() {Text ="Arizona"},
            new SelectListItem() {Text ="Arkansas"},
            new SelectListItem() {Text ="California"},
            new SelectListItem() {Text ="Colorado" },
            new SelectListItem() {Text ="Connecticut"},
            new SelectListItem() {Text ="Delaware"},
            new SelectListItem() {Text ="District Of Columbia"},
            new SelectListItem() {Text ="Florida" },
            new SelectListItem() {Text ="Georgia"},
            new SelectListItem() {Text ="Hawaii"},
            new SelectListItem() {Text ="Idaho"},
            new SelectListItem() {Text ="Illinois"},
            new SelectListItem() {Text ="Indiana"},
            new SelectListItem() {Text ="Iowa"},
            new SelectListItem() {Text ="Kansas"},
            new SelectListItem() {Text ="Kentucky"},
            new SelectListItem() {Text ="Louisiana"},
            new SelectListItem() {Text ="Maine"},
            new SelectListItem() {Text ="Maryland"},
            new SelectListItem() {Text ="Massachusetts" },
            new SelectListItem() {Text ="Michigan"},
            new SelectListItem() {Text ="Minnesota"},
            new SelectListItem() {Text ="Mississippi"},
            new SelectListItem() {Text ="Missouri"},
            new SelectListItem() {Text ="Montana"},
            new SelectListItem() {Text ="Nebraska"},
            new SelectListItem() {Text ="Nevada"},
            new SelectListItem() {Text ="New Hampshire"},
            new SelectListItem() {Text ="New Jersey" },
            new SelectListItem() {Text ="New Mexico"},
            new SelectListItem() {Text ="New York"},
            new SelectListItem() {Text ="North Carolina"},
            new SelectListItem() {Text ="North Dakota"},
            new SelectListItem() {Text ="Ohio" },
            new SelectListItem() {Text ="Oklahoma"},
            new SelectListItem() {Text ="Oregon"},
            new SelectListItem() {Text ="Pennsylvania"},
            new SelectListItem() {Text ="Rhode Island"},
            new SelectListItem() {Text ="South Carolina"},
            new SelectListItem() {Text ="South Dakota"},
            new SelectListItem() {Text ="Tennessee"},
            new SelectListItem() {Text ="Texas"},
            new SelectListItem() {Text ="Utah"},
            new SelectListItem() {Text ="Vermont" },
            new SelectListItem() {Text ="Virginia" },
            new SelectListItem() {Text ="Washington"},
            new SelectListItem() {Text ="West Virginia" },
            new SelectListItem() {Text ="Wisconsin"},
            new SelectListItem() {Text ="Wyoming" }
        };

        private List<SelectListItem> active = new List<SelectListItem>()
        {
            new SelectListItem(){Text="extremely active"},
            new SelectListItem() {Text ="active"},
            new SelectListItem() {Text ="sedentary"},
            new SelectListItem() {Text ="inactive"}
        };

        private string isCelcius_Session_ID = "weatherTempController";




        public IActionResult ChangeTemp(WeatherModel weatherly)
        {

            string tempUnit = weatherly.isCelsius.ToString();
          
            HttpContext.Session.SetString(isCelcius_Session_ID,tempUnit);

            return RedirectToAction("WeatherDetailView", new { code = weatherly.ParkCode});
        }
        




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
