using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestApiZoom.JWT;
using TestApiZoom.JWT.Zoom;
using TestApiZoom.Models;

namespace TestApiZoom.Controllers
{
    public class HomeController : Controller
    {

       
        public ActionResult Index()
        {
            
            ZoomAPI zoom = new ZoomAPI();
            var meetings = zoom.ListMeetings();
            return View(meetings);
        }

        //[HttpPost]
        //public ActionResult CriarReuniao(string topico)
        //{
        //    ZoomAPI zoom = new ZoomAPI();
        //    Meeting reuniao = zoom.CriarReuniao(topico);

        //    return View("Index",reuniao);

        //}

    }
}