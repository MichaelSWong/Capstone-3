using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Models
{
  
    public class SurveyModel
    {
        public int surveyId { get; set; }

        public string parkCode { get; set; }

        public string emailAddress { get; set; }

        public string state { get; set; }

        public string activityLevel { get; set; }
        //join for this
        public string ParkName { get; set; }


        public static List<SelectListItem> ParkSelect = new List<SelectListItem>()
        {
            new SelectListItem() {Text ="Glacier National Park", Value = "GNP" },
            new SelectListItem() {Text ="Grand  Canyon National Park", Value = "GCNP" },
            new SelectListItem() {Text ="Grand Teton National Park", Value = "GTNP"},
            new SelectListItem() {Text ="Mount Ranier National Park", Value = "MRNP" },
            new SelectListItem() {Text ="Great Smoky Mountain National Park",Value =  "GSMNP"},
            new SelectListItem() {Text ="Everglades National Park", Value = "ENP" },
            new SelectListItem() {Text ="Yellowstone National Park", Value = "YNP" },
            new SelectListItem() {Text ="Yosemite National Park",Value =  "YNP2"},
            new SelectListItem() {Text ="Cuyahoga Valley National Park", Value = "CVNP" },
            new SelectListItem() {Text ="Rocky Mountain National Park", Value = "RMNP" }
        };

        public static List<SelectListItem> States = new List<SelectListItem>()
        {
            new SelectListItem() {Text ="Alabama", Value = "Alabama" },
            new SelectListItem() {Text ="Alaska", Value = "Alaska" },
            new SelectListItem() {Text ="Arizona", Value = "Arizona"},
            new SelectListItem() {Text ="Arkansas", Value = "Arkansas" },
            new SelectListItem() {Text ="California",Value =  "California"},
            new SelectListItem() {Text ="Colorado", Value = "Colorado" },
            new SelectListItem() {Text ="Connecticut", Value = "Connecticut" },
            new SelectListItem() {Text ="Delaware",Value =  "Delaware"},
            new SelectListItem() {Text ="District Of Columbia", Value = "District Of Columbia" },
            new SelectListItem() {Text ="Florida", Value = "Florida" },
            new SelectListItem() {Text ="Georgia", Value = "Georgia" },
            new SelectListItem() {Text ="Hawaii", Value = "Hawaii" },
            new SelectListItem() {Text ="Idaho", Value = "Idaho"},
            new SelectListItem() {Text ="Illinois", Value = "Illinois" },
            new SelectListItem() {Text ="Indiana",Value =  "Indiana"},
            new SelectListItem() {Text ="Iowa", Value = "Iowa" },
            new SelectListItem() {Text ="Kansas", Value = "Kansas" },
            new SelectListItem() {Text ="Kentucky",Value =  "Kentucky"},
            new SelectListItem() {Text ="Louisiana", Value = "Louisiana" },
            new SelectListItem() {Text ="Maine", Value = "Maine" },
            new SelectListItem() {Text ="Maryland", Value = "Maryland" },
            new SelectListItem() {Text ="Massachusetts", Value = "Massachusetts" },
            new SelectListItem() {Text ="Michigan", Value = "Michigan"},
            new SelectListItem() {Text ="Minnesota", Value = "Minnesota" },
            new SelectListItem() {Text ="Mississippi",Value =  "Mississippi"},
            new SelectListItem() {Text ="Missouri", Value = "Missouri" },
            new SelectListItem() {Text ="Montana", Value = "Montana" },
            new SelectListItem() {Text ="Nebraska",Value =  "Nebraska"},
            new SelectListItem() {Text ="Nevada", Value = "Nevada" },
            new SelectListItem() {Text ="New Hampshire", Value = "New Hampshire" },
            new SelectListItem() {Text ="New Jersey", Value = "New Jersey" },
            new SelectListItem() {Text ="New Mexico", Value = "New Mexico" },
            new SelectListItem() {Text ="New York", Value = "New York"},
            new SelectListItem() {Text ="North Carolina", Value = "North Carolina" },
            new SelectListItem() {Text ="North Dakota",Value =  "North Dakota"},
            new SelectListItem() {Text ="Ohio", Value = "Ohio" },
            new SelectListItem() {Text ="Oklahoma", Value = "Oklahoma" },
            new SelectListItem() {Text ="Oregon",Value =  "Oregon"},
            new SelectListItem() {Text ="Pennsylvania", Value = "Pennsylvania" },
            new SelectListItem() {Text ="Rhode Island", Value = "Rhode Island" },
            new SelectListItem() {Text ="South Carolina", Value = "South Carolina" },
            new SelectListItem() {Text ="South Dakota", Value = "South Dakota" },
            new SelectListItem() {Text ="Tennessee", Value = "Tennessee"},
            new SelectListItem() {Text ="Texas", Value = "Texas" },
            new SelectListItem() {Text ="Utah",Value =  "Utah"},
            new SelectListItem() {Text ="Vermont", Value = "Vermont" },
            new SelectListItem() {Text ="Virginia", Value = "Virginia" },
            new SelectListItem() {Text ="Washington",Value =  "Washington"},
            new SelectListItem() {Text ="West Virginia", Value = "West Virginia" },
            new SelectListItem() {Text ="Wisconsin", Value = "Wisconsin" },
            new SelectListItem() {Text ="Wyoming", Value = "Wyoming" }
        };

        public static List<SelectListItem> StatesAbb = new List<SelectListItem>()
        {
            new SelectListItem() {Text ="AL", Value = "AL" },
            new SelectListItem() {Text ="AK", Value = "AK" },
            new SelectListItem() {Text ="AZ", Value = "AZ"},
            new SelectListItem() {Text ="AR", Value = "AR" },
            new SelectListItem() {Text ="CA",Value =  "CA"},
            new SelectListItem() {Text ="CO", Value = "CO" },
            new SelectListItem() {Text ="CT", Value = "CT" },
            new SelectListItem() {Text ="DE",Value =  "DE"},
            new SelectListItem() {Text ="DC", Value = "DC" },
            new SelectListItem() {Text ="FL", Value = "FL" },
            new SelectListItem() {Text ="GA", Value = "GA" },
            new SelectListItem() {Text ="HI", Value = "HI" },
            new SelectListItem() {Text ="ID", Value = "ID"},
            new SelectListItem() {Text ="IL", Value = "IL" },
            new SelectListItem() {Text ="IN",Value =  "IN"},
            new SelectListItem() {Text ="IA", Value = "IA" },
            new SelectListItem() {Text ="KS", Value = "KS" },
            new SelectListItem() {Text ="KY",Value =  "KY"},
            new SelectListItem() {Text ="LA", Value = "LA" },
            new SelectListItem() {Text ="ME", Value = "ME" },
            new SelectListItem() {Text ="MD", Value = "MD" },
            new SelectListItem() {Text ="MA", Value = "MA" },
            new SelectListItem() {Text ="MI", Value = "MI"},
            new SelectListItem() {Text ="MN", Value = "MN" },
            new SelectListItem() {Text ="MS",Value =  "MS"},
            new SelectListItem() {Text ="MO", Value = "MO" },
            new SelectListItem() {Text ="MT", Value = "MT" },
            new SelectListItem() {Text ="NE",Value =  "NE"},
            new SelectListItem() {Text ="NV", Value = "NV" },
            new SelectListItem() {Text ="NH", Value = "NH" },
            new SelectListItem() {Text ="NJ", Value = "NJ" },
            new SelectListItem() {Text ="NM", Value = "NM" },
            new SelectListItem() {Text ="NY", Value = "NY"},
            new SelectListItem() {Text ="NC", Value = "NC" },
            new SelectListItem() {Text ="ND",Value =  "ND"},
            new SelectListItem() {Text ="OH", Value = "OH" },
            new SelectListItem() {Text ="OK", Value = "OK" },
            new SelectListItem() {Text ="OR",Value =  "OR"},
            new SelectListItem() {Text ="PA", Value = "PA" },
            new SelectListItem() {Text ="RI", Value = "RI" },
            new SelectListItem() {Text ="SC", Value = "SC" },
            new SelectListItem() {Text ="SD", Value = "SD" },
            new SelectListItem() {Text ="TN", Value = "TN"},
            new SelectListItem() {Text ="TX", Value = "TX" },
            new SelectListItem() {Text ="UT",Value =  "UT"},
            new SelectListItem() {Text ="VT", Value = "VT" },
            new SelectListItem() {Text ="VA", Value = "VA" },
            new SelectListItem() {Text ="WA",Value =  "WA"},
            new SelectListItem() {Text ="WV", Value = "WV" },
            new SelectListItem() {Text ="WI", Value = "WI" },
            new SelectListItem() {Text ="WY", Value = "WY" }
        };

        public static List<SelectListItem> Active = new List<SelectListItem>()
        {
            new SelectListItem() {Text ="extremely active", Value = "extremely active" },
            new SelectListItem() {Text ="active", Value = "active" },
            new SelectListItem() {Text ="sedentary", Value = "sedentary"},
            new SelectListItem() {Text ="inactive", Value = "inactive" }
        };
            

    }

   
}
