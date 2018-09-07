using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApiZoom.JWT.Zoom;
using TestApiZoom.Models;

namespace TestApiZoom.Controllers
{
    public class MeetingController : Controller
    {
        // GET: Reuniao
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string topic)
        {
            ZoomAPI zoom = new ZoomAPI();
            Meeting meeting = zoom.CreateMeeting(topic);

            return View("Index", meeting);
           

        }

    }
}