using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface IParkModelDAL
    {
        IList<ParkModel> GetParkModels();


        ParkModel GetParkModel(string code);
    }
}
