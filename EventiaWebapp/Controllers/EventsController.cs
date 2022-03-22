using System.Reflection.Metadata.Ecma335;
using EventiaWebapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult JoinEvent(Event evnt, Attendee attendee)//Behöver nog inte attendee
        {
            return View("JoinEvent");
        }
        public IActionResult ConfirmEvent(int id)
        {
            return View("ConfirmEvent", id);
        }
    }
}